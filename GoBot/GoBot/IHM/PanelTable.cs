using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Calculs.Formes;
using GoBot.Calculs;
using AStarFolder;
using System.Threading;
using GoBot.Mouvements;
using GoBot.Enchainements;
using GoBot.Balises;
using GoBot.ElementsJeu;
using GoBot.Actionneurs;
using GoBot.PathFinding;
using Gobot.Calculs;
using GoBot.Devices;
using System.Diagnostics;
using GoBot.Communications;

namespace GoBot.IHM
{

    public partial class PanelTable : UserControl
    {
        public static Plateau Plateau { get; set; }

        public PanelTable()
        {
            InitializeComponent();
            Plateau = new Plateau();
            Plateau.ScoreChange += new EventHandler(Plateau_ScoreChange);
            Dessinateur.TableDessinee += Dessinateur_TableDessinee;

            checkedListBox.SetItemChecked(0, true);
            checkedListBox.SetItemChecked(1, true);

            toolTip.SetToolTip(btnTeleportRPFace, "Téléportation de face");
            toolTip.SetToolTip(btnTeleportRPCentre, "Téléportation de centre");
            toolTip.SetToolTip(btnPathRPFace, "Path finding de face");
            toolTip.SetToolTip(btnPathRPCentre, "Path finding du centre");
        }

        void Dessinateur_TableDessinee(Image img)
        {
            this.Invoke(new EventHandler(delegate
            {
                pictureBoxTable.Image = img;
            }));
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thAffichage != null)
                thAffichage.Abort();
        }

        void Plateau_ScoreChange(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(delegate
                {
                    lblScore.Text = Plateau.Score + "";
                }));
        }

        void MAJAffichage()
        {
            while (!Config.Shutdown && Thread.CurrentThread.IsAlive)
            {
                this.Invoke(new EventHandler(delegate
                {
                    lblPosGrosX.Text = Math.Round(Robots.GrosRobot.Position.Coordonnees.X, 2).ToString();
                    lblPosGrosY.Text = Math.Round(Robots.GrosRobot.Position.Coordonnees.Y, 2).ToString();
                    lblPosGrosTeta.Text = Robots.GrosRobot.Position.Angle.ToString();
                }));

                if (Plateau.Enchainement != null)
                {
                    TimeSpan tempsRestant = Plateau.Enchainement.TempsRestant;
                    if (tempsRestant.TotalMilliseconds <= 0)
                        tempsRestant = new TimeSpan(0);

                    lblSecondes.Text = (int)tempsRestant.TotalSeconds + "";
                    lblMilli.Text = tempsRestant.Milliseconds + "";

                    Color couleur;
                    if (tempsRestant.TotalSeconds > Enchainement.DureeMatch.TotalSeconds / 2)
                        couleur = Color.FromArgb((int)((Enchainement.DureeMatch.TotalSeconds - tempsRestant.TotalSeconds) * (150.0 / (Enchainement.DureeMatch.TotalSeconds / 2.0))), 150, 0);
                    else
                        couleur = Color.FromArgb(150, 150 - (int)((Enchainement.DureeMatch.TotalSeconds / 2.0 - tempsRestant.TotalSeconds) * (150.0 / (Enchainement.DureeMatch.TotalSeconds / 2.0))), 0);

                    lblSecondes.ForeColor = couleur;
                    lblMilli.ForeColor = couleur;
                }
            }
        }

        Thread thAffichage;
        private void btnAffichage_Click(object sender, EventArgs e)
        {
            if (btnAffichage.Text == "Lancer l'affichage")
            {
                thAffichage = new Thread(MAJAffichage);
                thAffichage.Start();
                Dessinateur.Start();
                btnAffichage.Text = "Stopper l'affichage";
                btnAffichage.Image = GoBot.Properties.Resources.Pause;
            }
            else
            {
                thAffichage.Abort();
                Dessinateur.Stop();
                btnAffichage.Text = "Lancer l'affichage";
                btnAffichage.Image = GoBot.Properties.Resources.Play;
            }
        }

        DateTime dateCapture = DateTime.Now;
        Semaphore semMove = new Semaphore(1, 1);

        Random rand = new Random();
        private void pictureBoxTable_MouseMove(object sender, MouseEventArgs e)
        {
            semMove.WaitOne();
            Dessinateur.PositionCurseur = pictureBoxTable.PointToClient(MousePosition);

            if (pSelected != -1)
            {
                pointsPolaires[pSelected] = Dessinateur.ScreenToRealPosition(e.Location);

                trajectoirePolaire = BezierCurve.GetPoints(pointsPolaires, (int)(numNbPoints.Value));//((int)pointsPolaires[0].Distance(pointsPolaires[pointsPolaires.Count - 1])) / 50);
                Dessinateur.TrajectoirePolaire = trajectoirePolaire;
                Dessinateur.PointsPolaire = pointsPolaires;
            }

            if (boxSourisObstacle.Checked)
            {
                if ((DateTime.Now - dateCapture).TotalMilliseconds > 50)
                {
                    dateCapture = DateTime.Now;

                    Point p = Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
                    List<PointReel> positions = new List<PointReel>();

                    positions.Add(Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));
                    Plateau.Balise.Actualisation(false, Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));
                    //SuiviBalise.MajPositions(positions, Plateau.Enchainement == null || Plateau.Enchainement.DebutMatch == null);
                }
            }
            else
            {
                Point positionSurTable = Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
                lblPos.Text = positionSurTable.X + " : " + positionSurTable.Y;

                bool hoverElement = false;

                PointReel positionRelle = new PointReel(positionSurTable.X, positionSurTable.Y);


                for (int i = 0; i < Plateau.ElementsJeu.Count; i++)
                {
                    if (positionRelle.Distance(Plateau.ElementsJeu[i].Position) < Plateau.ElementsJeu[i].RayonHover)
                    {
                        Plateau.ElementsJeu[i].Hover = true;
                        hoverElement = true;
                    }
                    else
                        Plateau.ElementsJeu[i].Hover = false;
                }

                if (hoverElement)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Arrow;
                
                //System.Threading.Tasks.Task.Factory.StartNew(() => ChercheTraj(new Position(Robots.GrosRobot.Position)));
            }

            semMove.Release();
        }

        bool calculTraj = false;
        public void ChercheTraj(Position depart)
        {
            if (!calculTraj)
            {
                calculTraj = true;

                DateTime debut = DateTime.Now;

                List<Trajectoire> trajs = new List<Trajectoire>();

                /*foreach (Mouvement m in Plateau.Enchainement.ListeMouvementsGros)
                {
                    if (m.PositionProche != null && m.Score > 0)
                    {
                        //foreach (Position pt in m.Positions)
                        {
                            Trajectoire traj = PathFinder.ChercheTrajectoire(Robots.GrosRobot.Graph, Plateau.ListeObstacles, depart, m.PositionProche, Robots.GrosRobot.Rayon, 160);
                            if (traj != null)
                            {
                                trajs.Add(traj);
                                Console.WriteLine(m.ToString() + " -> " + traj.Duree + "ms");
                            }
                        }
                    }
                }
                Dessinateur.Trajectoires = trajs;*/
                calculTraj = false;

                //Console.WriteLine("Temps calcul toutes possibilités : " + (DateTime.Now - debut).TotalMilliseconds + " ms");
            }
        }

        public void ThreadAction()
        {
            if (!move.Executer())
            {
#if DEBUG
                MessageBox.Show("Echec");
#endif
            }
            move = null;
        }

        Mouvement move;

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Todo

            Plateau.InitElementsJeu();

            Plateau.Score = 0;
        }

        private void PathFindingClick()
        {
            PointReel positionReelle = Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
            if (Dessinateur.modeCourant == Dessinateur.Mode.FinTrajectoire)
            {
                Robots.GrosRobot.PathFinding(positionReelle.X, positionReelle.Y);

                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
            }
            else
            {
                PointReel point = new PointReel(positionReelle.X, positionReelle.Y);

                /* Todo Tester ici si le clic a été fait sur un élément de jeu dans le but de lancer un mouvement.
                   Si c'est le cas, lancer un thread pour effectuer le mouvement 

                exemple : 
                if (Plateau.ZoneDepartVert.Hover)
                    move = new MouvementDeposeDepart(Plateau.ZoneDepartVert);*/

                for (int i = 0; i < Plateau.Elements.Fusees.Count; i++)
                    if (Plateau.Elements.Fusees[i].Hover)
                        move = new MouvementFusee(i);
                for (int i = 0; i < Plateau.Elements.Modules.Count; i++)
                    if (Plateau.Elements.Modules[i].Hover)
                        move = new MouvementModuleAvant(i);
                for (int i = 0; i < Plateau.Elements.ZonesDepose.Count; i++)
                    if (Plateau.Elements.ZonesDepose[i].Hover)
                        move = new MouvementDeposeModules(i);

                    if (move != null)
                    {
                        thAction = new Thread(ThreadAction);
                        thAction.Start();
                    }
            }
        }
        Thread thAction;

        Thread thPath;
        //MouseEventArgs ev;

        private void btnGo_Click(object sender, EventArgs e)
        {
            Plateau.Enchainement = new EnchainementMatch();
            Plateau.Enchainement.Executer();
        }

        private void PanelTable_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                btnAffichage_Click(null, null);
                ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
            }
        }

        private int pSelected = -1;
        private void pictureBoxTable_MouseDown(object sender, MouseEventArgs e)
        {
            Dessinateur.positionDepart = Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
            Dessinateur.sourisClic = true;

            if (Dessinateur.modeCourant == Dessinateur.Mode.TrajectoirePolaire)
            {
                moveMouse = false;
                Point pClic = e.Location;
                for(int i = 0; i < pointsPolaires.Count; i++)
                {
                    Point pPolaire = Dessinateur.RealToScreenPosition(pointsPolaires[i]);
                    if (new PointReel(pClic).Distance(new PointReel(pPolaire)) <= 3)
                    {
                        moveMouse = true;
                        pSelected = i;
                    }
                }
            }
        }

        Thread thGoToRP;
        Thread thGoToRS;
        List<PointReel> trajectoirePolaire;
        List<PointReel> pointsPolaires;

        private void pictureBoxTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (pSelected != -1)
                pSelected = -1;

            if (Dessinateur.modeCourant == Dessinateur.Mode.PositionRPCentre || Dessinateur.modeCourant == Dessinateur.Mode.TeleportRPCentre)
            {
                Direction traj = Maths.GetDirection(Dessinateur.positionDepart, Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));

                positionArrivee = new Position(traj.angle, Dessinateur.positionDepart);

                if (Dessinateur.modeCourant == Dessinateur.Mode.PositionRPCentre)
                {
                    thGoToRP = new Thread(ThreadTrajectoireGros);
                    thGoToRP.Start();
                }
                else
                    Robots.GrosRobot.ReglerOffsetAsserv((int)positionArrivee.Coordonnees.X, (int)positionArrivee.Coordonnees.Y, positionArrivee.Angle.AngleDegresPositif);

                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
            }
            else if (Dessinateur.modeCourant == Dessinateur.Mode.PositionRPFace || Dessinateur.modeCourant == Dessinateur.Mode.TeleportRPFace)
            {
                Point positionFin = pictureBoxTable.PointToClient(MousePosition);

                Direction traj = Maths.GetDirection(Dessinateur.positionDepart, Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));

                Point pointOrigine = Dessinateur.positionDepart;
                Position departRecule = new Position(360 - traj.angle, pointOrigine);
                departRecule.Avancer(-Robots.GrosRobot.Longueur / 2);
                departRecule = new Position(traj.angle, new PointReel(departRecule.Coordonnees.X, departRecule.Coordonnees.Y));
                positionArrivee = departRecule;

                if (Dessinateur.modeCourant == Dessinateur.Mode.PositionRPFace)
                {
                    thGoToRP = new Thread(ThreadTrajectoireGros);
                    thGoToRP.Start();
                }
                else
                {
                    Robots.GrosRobot.ReglerOffsetAsserv((int)positionArrivee.Coordonnees.X, (int)positionArrivee.Coordonnees.Y, positionArrivee.Angle.AngleDegresPositif);
                }

                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
            }

            Dessinateur.sourisClic = false;
        }

        private void btnAleatoire_Click(object sender, EventArgs e)
        {
            Plateau.Enchainement = new EnchainementAleatoire();
            Plateau.Enchainement.Executer();
        }
        Position positionArrivee;

        private void ThreadTrajectoireGros()
        {
            this.Invoke(new EventHandler(delegate
            {
                btnPathRPCentre.Enabled = false;
            }));

            Console.WriteLine("Path : " + Thread.CurrentThread.ManagedThreadId);
            Robots.GrosRobot.GotoXYTeta(positionArrivee.Coordonnees.X, positionArrivee.Coordonnees.Y, 360 - positionArrivee.Angle.AngleDegres);

            this.Invoke(new EventHandler(delegate
            {
                btnPathRPCentre.Enabled = true;
            }));
        }

        #region GroupBox Déplacements

        private void btnPathRPCentre_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.Mode.PositionRPCentre)
                Dessinateur.modeCourant = Dessinateur.Mode.PositionRPCentre;
            else
                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
        }

        private void btnPathRPFace_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.Mode.PositionRPFace)
                Dessinateur.modeCourant = Dessinateur.Mode.PositionRPFace;
            else
                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
        }

        private void btnPathRSCentre_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.Mode.PositionRSCentre)
                Dessinateur.modeCourant = Dessinateur.Mode.PositionRSCentre;
            else
                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
        }

        private void btnPathRSFace_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.Mode.PositionRSFace)
                Dessinateur.modeCourant = Dessinateur.Mode.PositionRSFace;
            else
                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
        }

        private void btnTeleportRPCentre_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.Mode.TeleportRPCentre)
                Dessinateur.modeCourant = Dessinateur.Mode.TeleportRPCentre;
            else
                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
        }

        private void btnTeleportRPFace_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.Mode.TeleportRPFace)
                Dessinateur.modeCourant = Dessinateur.Mode.TeleportRPFace;
            else
                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
        }

        private void btnTeleportRSCentre_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.Mode.TeleportRSCentre)
                Dessinateur.modeCourant = Dessinateur.Mode.TeleportRSCentre;
            else
                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
        }

        private void btnTeleportRSFace_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.Mode.TeleportRSFace)
                Dessinateur.modeCourant = Dessinateur.Mode.TeleportRSFace;
            else
                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
        }

        #endregion

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            String ligne = (String)checkedListBox.Items[e.Index];
            if (ligne == "Plateau")
                Dessinateur.AfficheTable = e.NewValue == CheckState.Checked;
            if (ligne == "Plateau perspective")
                Dessinateur.AfficheTableRelief = e.NewValue == CheckState.Checked;
            if (ligne == "Obstacles")
                Dessinateur.AfficheObstacles = e.NewValue == CheckState.Checked;
            if (ligne == "Elements de jeu")
                Dessinateur.AfficheElementsJeu = e.NewValue == CheckState.Checked;
            if (ligne == "Graph gros robots (noeuds)")
                Dessinateur.AfficheGraphGros = e.NewValue == CheckState.Checked;
            if (ligne == "Graph gros robot (arcs)")
                Dessinateur.AfficheGraphArretesGros = e.NewValue == CheckState.Checked;
            if (ligne == "Graph petit robots  (noeuds)")
                Dessinateur.AfficheGraphPetit = e.NewValue == CheckState.Checked;
            if (ligne == "Graph petit robot (arcs)")
                Dessinateur.AfficheGraphArretesPetit = e.NewValue == CheckState.Checked;
            if (ligne == "Coûts gros robot")
                Dessinateur.AfficheCoutsMouvementsGros = e.NewValue == CheckState.Checked;
            if (ligne == "Coûts petit robot")
                Dessinateur.AfficheCoutsMouvementsPetit = e.NewValue == CheckState.Checked;
            if (ligne == "Détections balises")
                Dessinateur.AfficheLigneDetections = e.NewValue == CheckState.Checked;
            if (ligne == "Calcul path finding")
                Config.CurrentConfig.AfficheDetailTraj = e.NewValue == CheckState.Checked ? 200 : 0;
            if (ligne == "Historique trajectoire gros")
                Dessinateur.AfficheHistoriqueCoordonneesGros = e.NewValue == CheckState.Checked;
            if (ligne == "Historique trajectoire petit")
                Dessinateur.AfficheHistoriqueCoordonneesPetit = e.NewValue == CheckState.Checked;
        }

        private void btnZoneDepart_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(GoToDepart);
            th.Start();
        }

        public void GoToDepart()
        {
            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Robots.GrosRobot.GotoXYTeta(3000 - 555, 1000, 180);
            else
                Robots.GrosRobot.GotoXYTeta(555, 1000, 0);

            Robots.GrosRobot.Reculer(300);

        }

        private void btnStratNul_Click(object sender, EventArgs e)
        {
            Plateau.Enchainement = new EnchainementAllerRetour();
            Plateau.Enchainement.Executer();
        }

        private void btnStratTest_Click(object sender, EventArgs e)
        {
            Plateau.Enchainement = new EnchainementHomologation();
            Plateau.Enchainement.Executer();
        }

        private void btnTestAsser_Click(object sender, EventArgs e)
        {
            Thread thTest = new Thread(TestAsser);
            thTest.Start();
        }

        private void TestAsser()
        {

            Robots.GrosRobot.Avancer(2000);
            Robots.GrosRobot.PivotDroite(270);
            Robots.GrosRobot.Avancer(200);
            Robots.GrosRobot.PivotDroite(10);
            Robots.GrosRobot.Avancer(100);
            Robots.GrosRobot.PivotDroite(10);
            Robots.GrosRobot.Avancer(100);
            Robots.GrosRobot.PivotDroite(10);
            Robots.GrosRobot.Avancer(100);
            Robots.GrosRobot.Reculer(1000);
            Robots.GrosRobot.PivotGauche(90);
            Robots.GrosRobot.Reculer(500);
            Robots.GrosRobot.PivotGauche(10);
            Robots.GrosRobot.Avancer(1000);
            Robots.GrosRobot.PivotGauche(10);
            Robots.GrosRobot.Avancer(100);
            Robots.GrosRobot.PivotGauche(10);
            Robots.GrosRobot.Avancer(100);
            Robots.GrosRobot.PivotGauche(10);
            Robots.GrosRobot.Avancer(100);
            Robots.GrosRobot.PivotGauche(10);
            Robots.GrosRobot.Avancer(100);


            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Robots.GrosRobot.GotoXYTeta(3000 - 555, 1000, 180);
            else
                Robots.GrosRobot.GotoXYTeta(555, 1000, 0);

            Robots.GrosRobot.Reculer(300);

        }

        Thread threadHokuyo;

        private void button1_Click(object sender, EventArgs e)
        {
            //String mess = "MS000072500001";


            /*
            String mess = "VV\n00P\n";

            byte[] b = new Byte[mess.Length];

            for (int i = 0; i < mess.Length; i++)
            {
                b[i] = (byte)mess[i];
            }

            Trame trameUart = new Trame(b);
            Trame trameUdp = TrameFactory.EnvoyerUart(Carte.RecIO, trameUart);
            Connexions.ConnexionIO.SendMessage(trameUdp);*/

            threadHokuyo = new Thread(FonctionHokuyo);
            threadHokuyo.Start();

            //PololuMiniUart.setTarget(15, 0);
            //Thread.Sleep(1000);
            //PololuMiniUart.setTarget(15, 500);

            //HokuyoUart lidar = new HokuyoUart(LidarID.LidarSol);
            //List<PointReel> pts = lidar.GetMesure();
            //Plateau.ObstaclesFixes = new List<IForme>();
            //foreach (PointReel p in pts)
            //{
            //    Plateau.ObstaclesFixes.Add(new Cercle(p, 4));
            //}
            //MessageBox.Show(pts.Count + " points");
        }

        private void FonctionHokuyo()
        {
            while (true)
            {
                List<PointReel> points = Actionneur.Hokuyo.GetMesure();

                if (points.Count > 0)
                {
                    Plateau.ObstaclesPlateau = new List<IForme>();
                    foreach (PointReel p in points)
                    {
                        Plateau.ObstaclesPlateau.Add(new Cercle(p, 4));
                    }

                    //Segment seg = new Segment(new PointReel(0, 50), new PointReel(0, 900));
                    //List<PointReel> pointsBordure = points.Where(p => p.Distance(seg) < 30).ToList();

                    //Droite interpol = new Droite(pointsBordure);

                    //Plateau.ObstaclesFixes.Add(interpol);

                    //Console.WriteLine(new Angle(Math.Atan(interpol.A), AnglyeType.Radian).AngleDegresPositif - 270);

                    //Droite interpol = new Droite(points.GetRange((int)(points.Count *0.8), (int)(points.Count * 0.1)+1));
                    //Plateau.ObstaclesFixes.Add(interpol);

                    // Cherche le point à droite du robot qui fait la bordure
                    /*points = points.Where(p => p.X > Robots.GrosRobot.Position.Coordonnees.X).ToList();

                    PointReel pointDroite = points[0];

                    for (int i = 0; i < points.Count; i++)
                    {
                        if (Math.Abs(points[i].Y - Robots.GrosRobot.Position.Coordonnees.Y) < Math.Abs(pointDroite.Y - Robots.GrosRobot.Position.Coordonnees.Y))
                            pointDroite = points[i];
                    }

                    double distanceDroite = pointDroite.X - Actionneur.Hokuyo.Position.Coordonnees.X;
                    distanceDroite -= 76; // Pour avoir la distance par rapport au bord du robot

                    PointReel p0 = new PointReel(Actionneur.Hokuyo.Position.Coordonnees);
                    p0.X += 76;
                    p0.Y += 100;
                    Dessinateur._PointBordRobot = p0;
                    Dessinateur._DistanceBordRobot = distanceDroite;*/
                }
            }
        }

        private void btnTrajCreer_Click(object sender, EventArgs e)
        {
            Dessinateur.modeCourant = Dessinateur.Mode.TrajectoirePolaire;
            pSelected = -1;
            pointsPolaires = new List<PointReel>();
        }

        private void btnTrajLancer_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TrajectoirePolaire(SensAR.Avant, trajectoirePolaire, false);
        }

        private void pwet_Click(object sender, EventArgs e)
        {
            //Robots.GrosRobot.ReglerOffsetAsserv(160, 850, 0);
            Robots.GrosRobot.ReglerOffsetAsserv(Robots.GrosRobot.Longueur / 2, 600 + 5 + Robots.GrosRobot.Largeur / 2, 0);
            //Robots.GrosRobot.ReglerOffsetAsserv(100, 700, 0);
            Robots.GrosRobot.VitesseDeplacement = 1500;


            // Trajectoire de drift
            //Robots.GrosRobot.AccelerationDebutDeplacement = 4000;
            //Robots.GrosRobot.AccelerationFinDeplacement = 4000;


            // Trajectoire normale
            Robots.GrosRobot.AccelerationDebutDeplacement = 1200;
            Robots.GrosRobot.AccelerationFinDeplacement = 1700;


            Robots.GrosRobot.VitessePivot = 1000;
            Robots.GrosRobot.AccelerationPivot = 1000;

            Robots.GrosRobot.EnvoyerPIDCap(10000, 0, 300);
            //Robots.GrosRobot.EnvoyerPIDCap(15000, 0, 100);
            Robots.GrosRobot.EnvoyerPIDVitesse(20, 0, 200);

            pointsPolaires = new List<PointReel>();
            //for (int i = 0; i < 10; i++)
             //   pointsPolaires.Add(new PointReel(i * 10, 0));

            // Trajectoire normale de départ
            //pointsPolaires.Add(new PointReel(Robots.GrosRobot.Position.Coordonnees.X, Robots.GrosRobot.Position.Coordonnees.Y));
            //pointsPolaires.Add(new PointReel(700, Robots.GrosRobot.Position.Coordonnees.Y + 100));
            //pointsPolaires.Add(new PointReel(550, 400));
            //pointsPolaires.Add(new PointReel(1500, 400));

            pointsPolaires.Add(new PointReel(Robots.GrosRobot.Position.Coordonnees.X, Robots.GrosRobot.Position.Coordonnees.Y));
            pointsPolaires.Add(new PointReel(700, Robots.GrosRobot.Position.Coordonnees.Y + 80));
            pointsPolaires.Add(new PointReel(550, 400));
            pointsPolaires.Add(new PointReel(1300, 500));

            // Trajectoire de drift
            //pointsPolaires.Add(new PointReel(Robots.GrosRobot.Position.Coordonnees.X, Robots.GrosRobot.Position.Coordonnees.Y));
            //pointsPolaires.Add(new PointReel(700, Robots.GrosRobot.Position.Coordonnees.Y + 100));
            //pointsPolaires.Add(new PointReel(550, 300));
            //pointsPolaires.Add(new PointReel(1250, 600));

            trajectoirePolaire = BezierCurve.GetPoints(pointsPolaires, (int)numNbPoints.Value);
            Dessinateur.modeCourant = Dessinateur.Mode.TrajectoirePolaire; 
            Dessinateur.TrajectoirePolaire = trajectoirePolaire;
            Dessinateur.PointsPolaire = pointsPolaires;

            Stopwatch watch = Stopwatch.StartNew();
            Robots.GrosRobot.TrajectoirePolaire(SensAR.Avant, trajectoirePolaire, true);

            ThreadHokuyoRecalViolet();
        }

        bool moveMouse = false;
        private void pictureBoxTable_Click(object sender, EventArgs e)
        {
            if (!moveMouse && Dessinateur.modeCourant == Dessinateur.Mode.TrajectoirePolaire)
            {
                PointReel point = Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
                //if (pointsPolaires.Count >= 2 && pointsPolaires.Count < 4)
                //    pointsPolaires.Insert(pointsPolaires.Count - 1, point);
                //else if (pointsPolaires.Count < 4)
                pointsPolaires.Add(point);

                if (pointsPolaires.Count > 1)
                {
                    trajectoirePolaire = BezierCurve.GetPoints(pointsPolaires, (int)(numNbPoints.Value));//((int)pointsPolaires[0].Distance(pointsPolaires[pointsPolaires.Count - 1])) / 50);
                    Dessinateur.TrajectoirePolaire = trajectoirePolaire;
                    Dessinateur.PointsPolaire = pointsPolaires;
                }
            }
            else
            {
                thPath = new Thread(PathFindingClick);
                thPath.Start();
            }
        }

        private void btnHokuyoUart_Click(object sender, EventArgs e)
        {
            ////String mess = "MS000072500001";
                        
            //String mess = "VV\n00P\n";

            //byte[] b = new Byte[mess.Length];

            //for (int i = 0; i < mess.Length; i++)
            //{
            //    b[i] = (byte)mess[i];
            //}

            //Trame trameUart = new Trame(b);
            //Trame trameUdp = TrameFactory.EnvoyerUart(Carte.RecIO, trameUart);
            //Connexions.ConnexionIO.SendMessage(trameUdp);

            HokuyoUart lidar = new HokuyoUart(LidarID.ScanSol);
            List<PointReel> pts = lidar.GetMesure();
            Plateau.ObstaclesPlateau = new List<IForme>();
            foreach (PointReel p in pts)
            {
                Plateau.ObstaclesPlateau.Add(new Cercle(p, 4));
            }
            MessageBox.Show(pts.Count + " points");
        }

        private void ThreadMouvement(Object o)
        {
            Mouvement m = (Mouvement)o;
            m.Executer();
        }

        private void ThreadEnchainement(Object o)
        {
            Enchainement m = (Enchainement)o;
            Plateau.Enchainement = m;
            Plateau.Enchainement.Executer();
        }

        private void ThreadHokuyoRecalViolet()
        {
            Robots.GrosRobot.PositionerAngle(180);

            Angle a = Actionneur.Hokuyo.CalculAngle(new Segment(new PointReel(0, 50), new PointReel(0, 900)), 50, 10);
            if (a.AngleDegresPositif > 180)
                Robots.GrosRobot.PivotDroite(a.AngleDegresPositif - 270);
            else
                Robots.GrosRobot.PivotGauche((90 - a.AngleDegresPositif));

            Robots.GrosRobot.ReglerOffsetAsserv((int)Robots.GrosRobot.Position.Coordonnees.X, (int)Robots.GrosRobot.Position.Coordonnees.Y, 180);

            double distance = Actionneur.Hokuyo.CalculDistanceX(new Segment(new PointReel(0, 50), new PointReel(0, 900)), 50, 2);
            Robots.GrosRobot.ReglerOffsetAsserv((int)(Robots.GrosRobot.Position.Coordonnees.X - distance), (int)Robots.GrosRobot.Position.Coordonnees.Y, 180);

            distance = Actionneur.Hokuyo.CalculDistanceY(970, 1170, 150, 2);
            Robots.GrosRobot.ReglerOffsetAsserv((int)(Robots.GrosRobot.Position.Coordonnees.X), (int)(Robots.GrosRobot.Position.Coordonnees.Y - distance), 180);
        }

        private void ThreadHokuyoRecalVert()
        {
            Robots.GrosRobot.PositionerAngle(0);

            Angle a = Actionneur.Hokuyo.CalculAngle(new Segment(new PointReel(3000, 50), new PointReel(3000, 900)), 50, 10);
            if (a.AngleDegresPositif > 180)
                Robots.GrosRobot.PivotDroite(a.AngleDegresPositif - 270);
            else
                Robots.GrosRobot.PivotGauche((90 - a.AngleDegresPositif));

            Robots.GrosRobot.ReglerOffsetAsserv((int)Robots.GrosRobot.Position.Coordonnees.X, (int)Robots.GrosRobot.Position.Coordonnees.Y, 0);

            double distance = Actionneur.Hokuyo.CalculDistanceX(new Segment(new PointReel(3000, 50), new PointReel(3000, 900)), 50, 10);
            Robots.GrosRobot.ReglerOffsetAsserv((int)(Robots.GrosRobot.Position.Coordonnees.X - (distance - 3000)), (int)Robots.GrosRobot.Position.Coordonnees.Y, 0);

            Robots.GrosRobot.PositionerAngle(45);

            distance = Actionneur.Hokuyo.CalculDistanceY(3000 - 1170, 3000 - 970, 150, 2);
            Robots.GrosRobot.ReglerOffsetAsserv((int)(Robots.GrosRobot.Position.Coordonnees.X), (int)(Robots.GrosRobot.Position.Coordonnees.Y - distance), 0);
        }
    }
}
