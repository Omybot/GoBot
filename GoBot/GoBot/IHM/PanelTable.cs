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

            toolTip.SetToolTip(btnTeleportRSFace, "Téléportation de face");
            toolTip.SetToolTip(btnTeleportRSCentre, "Téléportation du centre");
            toolTip.SetToolTip(btnTeleportRPFace, "Téléportation de face");
            toolTip.SetToolTip(btnTeleportRPCentre, "Téléportation de centre");
            toolTip.SetToolTip(btnPathRSFace, "Path finding de face");
            toolTip.SetToolTip(btnPathRSCentre, "Path finding du centre");
            toolTip.SetToolTip(btnPathRPFace, "Path finding de face");
            toolTip.SetToolTip(btnPathRPCentre, "Path finding du centre");
        }

        void Dessinateur_TableDessinee(Image img)
        {
            pictureBoxTable.Image = img;
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

                    lblPosPetitX.Text = Math.Round(Robots.PetitRobot.Position.Coordonnees.X, 2).ToString();
                    lblPosPetitY.Text = Math.Round(Robots.PetitRobot.Position.Coordonnees.Y, 2).ToString();
                    lblPosPetitTeta.Text = Robots.PetitRobot.Position.Angle.ToString();
                }));


                for (int i = 0; i < SuiviBalise.PositionsEnnemies.Count; i++)
                {
                    PointReel p = SuiviBalise.PositionsEnnemies[i];

                    if (p == null)
                        continue;

                    double vitesse = Math.Round(Math.Sqrt(p.X * p.X + p.Y * p.Y));

                    if (i == 0)
                    {
                        lblXEnnemi1.Text = Math.Round(p.X).ToString();
                        lblYEnnemi1.Text = Math.Round(p.Y).ToString();
                        lblVitesseEnnemi1.Text = vitesse + " mm/s";
                    }
                }

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

            if (boxSourisObstacle.Checked)
            {
                if ((DateTime.Now - dateCapture).TotalMilliseconds > 50)
                {
                    dateCapture = DateTime.Now;

                    Point p = Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
                    List<PointReel> positions = new List<PointReel>();

                    positions.Add(Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));
                    Plateau.InterpreteurBalise.Actualisation(false, Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));
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
                
                System.Threading.Tasks.Task.Factory.StartNew(() => ChercheTraj(new Position(Robots.GrosRobot.Position)));
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
                if (ev.Button == System.Windows.Forms.MouseButtons.Left)
                    Robots.GrosRobot.PathFinding(positionReelle.X, positionReelle.Y);
                else
                    Robots.PetitRobot.PathFinding(positionReelle.X, positionReelle.Y);

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

                if (move != null)
                {
                    thAction = new Thread(ThreadAction);
                    thAction.Start();
                }
            }
        }
        Thread thAction;

        Thread thPath;
        MouseEventArgs ev;
        private void pictureBoxTable_MouseClick(object sender, MouseEventArgs e)
        {
            ev = e;
            thPath = new Thread(PathFindingClick);
            thPath.Start();
        }

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

        private void pictureBoxTable_MouseDown(object sender, MouseEventArgs e)
        {
            Dessinateur.positionDepart = Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
            Dessinateur.sourisClic = true;
        }

        Thread thGoToRP;
        Thread thGoToRS;
        private void pictureBoxTable_MouseUp(object sender, MouseEventArgs e)
        {
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
            else if (Dessinateur.modeCourant == Dessinateur.Mode.PositionRSCentre || Dessinateur.modeCourant == Dessinateur.Mode.TeleportRSCentre)
            {
                Direction traj = Maths.GetDirection(Dessinateur.positionDepart, Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));

                positionArrivee = new Position(traj.angle, Dessinateur.positionDepart);

                if (Dessinateur.modeCourant == Dessinateur.Mode.PositionRSCentre)
                {
                    thGoToRS = new Thread(ThreadTrajectoirePetit);
                    thGoToRS.Start();
                }
                else
                    Robots.PetitRobot.ReglerOffsetAsserv((int)positionArrivee.Coordonnees.X, (int)positionArrivee.Coordonnees.Y, positionArrivee.Angle.AngleDegresPositif);

                Dessinateur.modeCourant = Dessinateur.Mode.Visualisation;
            }
            else if (Dessinateur.modeCourant == Dessinateur.Mode.PositionRSFace || Dessinateur.modeCourant == Dessinateur.Mode.TeleportRSFace)
            {
                Point positionFin = pictureBoxTable.PointToClient(MousePosition);

                Direction traj = Maths.GetDirection(Dessinateur.positionDepart, Dessinateur.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));

                Point pointOrigine = Dessinateur.positionDepart;
                Position departRecule = new Position(360 - traj.angle, pointOrigine);
                departRecule.Avancer(-Robots.PetitRobot.Longueur / 2);
                departRecule = new Position(traj.angle, new PointReel(departRecule.Coordonnees.X, departRecule.Coordonnees.Y));
                positionArrivee = departRecule;

                if (Dessinateur.modeCourant == Dessinateur.Mode.PositionRSFace)
                {
                    thGoToRS = new Thread(ThreadTrajectoirePetit);
                    thGoToRS.Start();
                }
                else
                    Robots.PetitRobot.ReglerOffsetAsserv((int)positionArrivee.Coordonnees.X, (int)positionArrivee.Coordonnees.Y, positionArrivee.Angle.AngleDegresPositif);

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

        private void ThreadTrajectoirePetit()
        {
            this.Invoke(new EventHandler(delegate
            {
                btnPathRPCentre.Enabled = false;
            }));

            Robots.PetitRobot.GotoXYTeta(positionArrivee.Coordonnees.X, positionArrivee.Coordonnees.Y, 360 - positionArrivee.Angle.AngleDegres);

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
            if (Plateau.NotreCouleur == Plateau.CouleurDroiteVert)
                Robots.GrosRobot.GotoXYTeta(3000 - 555, 1000, 180);
            else
                Robots.GrosRobot.GotoXYTeta(555, 1000, 0);

            Robots.GrosRobot.Reculer(300);

        }

        private void btnStratNul_Click(object sender, EventArgs e)
        {
            Plateau.Enchainement = new EnchainementMatchFixe();
            Plateau.Enchainement.Executer();
        }

        private void btnStratTest_Click(object sender, EventArgs e)
        {
            Plateau.Enchainement = new EnchainementTest();
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


            if (Plateau.NotreCouleur == Plateau.CouleurDroiteVert)
                Robots.GrosRobot.GotoXYTeta(3000 - 555, 1000, 180);
            else
                Robots.GrosRobot.GotoXYTeta(555, 1000, 0);

            Robots.GrosRobot.Reculer(300);

        }
    }
}
