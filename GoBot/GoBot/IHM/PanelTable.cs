using GoBot.Geometry;
using GoBot.Actionneurs;
using GoBot.Geometry;
using GoBot.Geometry.Shapes;
using GoBot.Devices;
using GoBot.ElementsJeu;
using GoBot.Strategies;
using GoBot.Mouvements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

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
            this.InvokeAuto(() => pictureBoxTable.Image = img);
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thAffichage != null)
                thAffichage.Abort();
        }

        void Plateau_ScoreChange(object sender, EventArgs e)
        {
            this.InvokeAuto(() => lblScore.Text = Plateau.Score.ToString());
        }

        void MAJAffichage()
        {
            while (!Execution.Shutdown && Thread.CurrentThread.IsAlive)
            {
                this.InvokeAuto(() =>
                { 
                    lblPosGrosX.Text = Math.Round(Robots.GrosRobot.Position.Coordinates.X, 2).ToString();
                    lblPosGrosY.Text = Math.Round(Robots.GrosRobot.Position.Coordinates.Y, 2).ToString();
                    lblPosGrosTeta.Text = Robots.GrosRobot.Position.Angle.ToString();
                });

                if (Plateau.Strategy != null)
                {
                    TimeSpan tempsRestant = Plateau.Strategy.TimeBeforeEnd;
                    if (tempsRestant.TotalMilliseconds <= 0)
                        tempsRestant = new TimeSpan(0);

                    Color couleur;
                    if (tempsRestant.TotalSeconds > Plateau.Strategy.MatchDuration.TotalSeconds / 2)
                        couleur = Color.FromArgb((int)((Plateau.Strategy.MatchDuration.TotalSeconds - tempsRestant.TotalSeconds) * (150.0 / (Plateau.Strategy.MatchDuration.TotalSeconds / 2.0))), 150, 0);
                    else
                        couleur = Color.FromArgb(150, 150 - (int)((Plateau.Strategy.MatchDuration.TotalSeconds / 2.0 - tempsRestant.TotalSeconds) * (150.0 / (Plateau.Strategy.MatchDuration.TotalSeconds / 2.0))), 0);

                    this.InvokeAuto(() =>
                    {
                        lblSecondes.Text = (int)tempsRestant.TotalSeconds + "";
                        lblMilli.Text = tempsRestant.Milliseconds + "";

                        lblSecondes.ForeColor = couleur;
                        lblMilli.ForeColor = couleur;
                    });
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
                btnAffichage.Image = GoBot.Properties.Resources.Pause16;
            }
            else
            {
                thAffichage.Abort();
                Dessinateur.Stop();
                btnAffichage.Text = "Lancer l'affichage";
                btnAffichage.Image = GoBot.Properties.Resources.Play16;
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
                pointsPolaires[pSelected] = Dessinateur.Scale.ScreenToRealPosition(e.Location);

                trajectoirePolaire = BezierCurve.GetPoints(pointsPolaires, (int)(numNbPoints.Value));//((int)pointsPolaires[0].Distance(pointsPolaires[pointsPolaires.Count - 1])) / 50);
                Dessinateur.TrajectoirePolaire = trajectoirePolaire;
                Dessinateur.PointsPolaire = pointsPolaires;
            }

            if (boxSourisObstacle.Checked)
            {
                if ((DateTime.Now - dateCapture).TotalMilliseconds > 50)
                {
                    dateCapture = DateTime.Now;

                    Point p = Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
                    List<RealPoint> positions = new List<RealPoint>();

                    positions.Add(Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));
                    Plateau.Balise.Actualisation(false, Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));
                    //SuiviBalise.MajPositions(positions, Plateau.Enchainement == null || Plateau.Enchainement.DebutMatch == null);
                }
            }
            else
            {
                Point positionSurTable = Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
                lblPos.Text = positionSurTable.X + " : " + positionSurTable.Y;

                bool hoverElement = false;

                RealPoint positionRelle = new RealPoint(positionSurTable.X, positionSurTable.Y);
                
                foreach (GameElement element in Plateau.Elements)
                {
                    if (positionRelle.Distance(element.Position) < element.HoverRadius)
                    {
                        element.IsHover = true;
                        hoverElement = true;
                    }
                    else
                        element.IsHover = false;
                }

                if (hoverElement)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Arrow;

                //System.Threading.Tasks.Task.Factory.StartNew(() => ChercheTraj(new Position(Robots.GrosRobot.Position)));
            }

            semMove.Release();
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
            
            Plateau.Score = 0;
        }

        private void CheckElementClick()
        {
            foreach (GameElement element in Plateau.Elements)
                if (element.IsHover)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(StartElementMouvement), element);
        }

        private void StartElementMouvement(Object element)
        {
            ((GameElement)element).ClickAction();
        }
        
        //MouseEventArgs ev;

        private void btnGo_Click(object sender, EventArgs e)
        {
            Plateau.Strategy = new StrategyMatch();
            Plateau.Strategy.Execute();
        }

        private void PanelTable_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                btnAffichage_Click(null, null);
                ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
            }
        }

        private int pSelected = -1;
        private void pictureBoxTable_MouseDown(object sender, MouseEventArgs e)
        {
            Dessinateur.positionDepart = Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
            Dessinateur.MouseClicked = true;

            if (Dessinateur.modeCourant == Dessinateur.MouseMode.TrajectoirePolaire)
            {
                moveMouse = false;
                Point pClic = e.Location;
                for (int i = 0; i < pointsPolaires.Count; i++)
                {
                    Point pPolaire = Dessinateur.Scale.RealToScreenPosition(pointsPolaires[i]);
                    if (new RealPoint(pClic).Distance(new RealPoint(pPolaire)) <= 3)
                    {
                        moveMouse = true;
                        pSelected = i;
                    }
                }
            }
        }

        Thread thGoToRP;
        List<RealPoint> trajectoirePolaire;
        List<RealPoint> pointsPolaires;

        private void pictureBoxTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (pSelected != -1)
                pSelected = -1;

            if (Dessinateur.modeCourant == Dessinateur.MouseMode.PositionCentre || Dessinateur.modeCourant == Dessinateur.MouseMode.TeleportCentre)
            {
                Direction traj = Maths.GetDirection(Dessinateur.positionDepart, Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));

                positionArrivee = new Position(traj.angle, Dessinateur.positionDepart);

                if (Dessinateur.modeCourant == Dessinateur.MouseMode.PositionCentre)
                {
                    thGoToRP = new Thread(ThreadTrajectoireGros);
                    thGoToRP.Start();
                }
                else
                    Robots.GrosRobot.ReglerOffsetAsserv(positionArrivee);

                Dessinateur.modeCourant = Dessinateur.MouseMode.None;
            }
            else if (Dessinateur.modeCourant == Dessinateur.MouseMode.PositionFace || Dessinateur.modeCourant == Dessinateur.MouseMode.TeleportFace)
            {
                Point positionFin = pictureBoxTable.PointToClient(MousePosition);

                Direction traj = Maths.GetDirection(Dessinateur.positionDepart, Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));

                Point pointOrigine = Dessinateur.positionDepart;
                Position departRecule = new Position(360 - traj.angle, pointOrigine);
                departRecule.Move(-Robots.GrosRobot.Longueur / 2);
                departRecule = new Position(traj.angle, new RealPoint(departRecule.Coordinates.X, departRecule.Coordinates.Y));
                positionArrivee = departRecule;

                if (Dessinateur.modeCourant == Dessinateur.MouseMode.PositionFace)
                {
                    thGoToRP = new Thread(ThreadTrajectoireGros);
                    thGoToRP.Start();
                }
                else
                {
                    Robots.GrosRobot.ReglerOffsetAsserv(positionArrivee);
                }

                Dessinateur.modeCourant = Dessinateur.MouseMode.None;
            }

            Dessinateur.MouseClicked = false;
        }

        private void btnAleatoire_Click(object sender, EventArgs e)
        {
            Plateau.Strategy = new StrategyRandomMoves();
            Plateau.Strategy.Execute();
        }
        Position positionArrivee;

        private void ThreadTrajectoireGros()
        {
            this.InvokeAuto(() => btnPathRPCentre.Enabled = false);

            Robots.GrosRobot.GotoXYTeta(new Position(360 - positionArrivee.Angle.InDegrees, positionArrivee.Coordinates)); // TODO2018 pourquoi on change de repère ?

            this.InvokeAuto(() => btnPathRPCentre.Enabled = true);
        }

        #region GroupBox Déplacements

        private void btnPathRPCentre_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.MouseMode.PositionCentre)
                Dessinateur.modeCourant = Dessinateur.MouseMode.PositionCentre;
            else
                Dessinateur.modeCourant = Dessinateur.MouseMode.None;
        }

        private void btnPathRPFace_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.MouseMode.PositionFace)
                Dessinateur.modeCourant = Dessinateur.MouseMode.PositionFace;
            else
                Dessinateur.modeCourant = Dessinateur.MouseMode.None;
        }

        private void btnTeleportRPCentre_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.MouseMode.TeleportCentre)
                Dessinateur.modeCourant = Dessinateur.MouseMode.TeleportCentre;
            else
                Dessinateur.modeCourant = Dessinateur.MouseMode.None;
        }

        private void btnTeleportRPFace_Click(object sender, EventArgs e)
        {
            Dessinateur.positionDepart = null;
            if (Dessinateur.modeCourant != Dessinateur.MouseMode.TeleportFace)
                Dessinateur.modeCourant = Dessinateur.MouseMode.TeleportFace;
            else
                Dessinateur.modeCourant = Dessinateur.MouseMode.None;
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
            if (ligne == "Graph (noeuds)")
                Dessinateur.AfficheGraph = e.NewValue == CheckState.Checked;
            if (ligne == "Graph (arcs)")
                Dessinateur.AfficheGraphArretes = e.NewValue == CheckState.Checked;
            if (ligne == "Coûts mouvements")
                Dessinateur.AfficheCoutsMouvements = e.NewValue == CheckState.Checked;
            if (ligne == "Détections balises")
                Dessinateur.AfficheLigneDetections = e.NewValue == CheckState.Checked;
            if (ligne == "Calcul path finding")
                Config.CurrentConfig.AfficheDetailTraj = e.NewValue == CheckState.Checked ? 200 : 0;
            if (ligne == "Historique trajectoire")
                Dessinateur.AfficheHistoriqueCoordonnees = e.NewValue == CheckState.Checked;
        }

        private void btnZoneDepart_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(GoToDepart);
            th.Start();
        }

        public void GoToDepart()
        {
            Robots.GrosRobot.GotoXYTeta(Recallages.PositionDepart);
        }

        private void btnStratNul_Click(object sender, EventArgs e)
        {
            Plateau.Strategy = new StrategyRoundTrip();
            Plateau.Strategy.Execute();
        }

        private void btnStratTest_Click(object sender, EventArgs e)
        {
            Plateau.Strategy = new StrategyMinimumScore();
            Plateau.Strategy.Execute();
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

            Robots.GrosRobot.GotoXYTeta(Recallages.PositionDepart);

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
                List<RealPoint> points = Actionneur.Hokuyo.GetMesure();

                if (points.Count > 0)
                {
                    Plateau.ObstaclesPlateau = new List<IShape>();
                    foreach (RealPoint p in points)
                    {
                        Plateau.ObstaclesPlateau.Add(new Circle(p, 4));
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
            Dessinateur.modeCourant = Dessinateur.MouseMode.TrajectoirePolaire;
            pSelected = -1;
            pointsPolaires = new List<RealPoint>();
        }

        private void btnTrajLancer_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TrajectoirePolaire(SensAR.Avant, trajectoirePolaire, false);
        }

        private void pwet_Click(object sender, EventArgs e)
        {
            ////Robots.GrosRobot.ReglerOffsetAsserv(160, 850, 0);
            //Robots.GrosRobot.ReglerOffsetAsserv((int)(Robots.GrosRobot.Longueur / 2), (int)(600 + 5 + Robots.GrosRobot.Largeur / 2), 0);
            ////Robots.GrosRobot.ReglerOffsetAsserv(100, 700, 0);
            //Robots.GrosRobot.VitesseDeplacement = 1500;


            //// Trajectoire de drift
            ////Robots.GrosRobot.AccelerationDebutDeplacement = 4000;
            ////Robots.GrosRobot.AccelerationFinDeplacement = 4000;


            //// Trajectoire normale
            //Robots.GrosRobot.AccelerationDebutDeplacement = 1200;
            //Robots.GrosRobot.AccelerationFinDeplacement = 1700;


            //Robots.GrosRobot.VitessePivot = 1000;
            //Robots.GrosRobot.AccelerationPivot = 1000;

            //Robots.GrosRobot.EnvoyerPIDCap(10000, 0, 300);
            ////Robots.GrosRobot.EnvoyerPIDCap(15000, 0, 100);
            //Robots.GrosRobot.EnvoyerPIDVitesse(20, 0, 200);

            //pointsPolaires = new List<PointReel>();
            ////for (int i = 0; i < 10; i++)
            // //   pointsPolaires.Add(new PointReel(i * 10, 0));

            //// Trajectoire normale de départ
            ////pointsPolaires.Add(new PointReel(Robots.GrosRobot.Position.Coordonnees.X, Robots.GrosRobot.Position.Coordonnees.Y));
            ////pointsPolaires.Add(new PointReel(700, Robots.GrosRobot.Position.Coordonnees.Y + 100));
            ////pointsPolaires.Add(new PointReel(550, 400));
            ////pointsPolaires.Add(new PointReel(1500, 400));

            //pointsPolaires.Add(new PointReel(Robots.GrosRobot.Position.Coordonnees.X, Robots.GrosRobot.Position.Coordonnees.Y));
            //pointsPolaires.Add(new PointReel(700, Robots.GrosRobot.Position.Coordonnees.Y + 80));
            //pointsPolaires.Add(new PointReel(550, 400));
            //pointsPolaires.Add(new PointReel(1300, 500));

            //// Trajectoire de drift
            ////pointsPolaires.Add(new PointReel(Robots.GrosRobot.Position.Coordonnees.X, Robots.GrosRobot.Position.Coordonnees.Y));
            ////pointsPolaires.Add(new PointReel(700, Robots.GrosRobot.Position.Coordonnees.Y + 100));
            ////pointsPolaires.Add(new PointReel(550, 300));
            ////pointsPolaires.Add(new PointReel(1250, 600));

            //trajectoirePolaire = BezierCurve.GetPoints(pointsPolaires, (int)numNbPoints.Value);
            //Dessinateur.modeCourant = Dessinateur.Mode.TrajectoirePolaire; 
            //Dessinateur.TrajectoirePolaire = trajectoirePolaire;
            //Dessinateur.PointsPolaire = pointsPolaires;

            //Stopwatch watch = Stopwatch.StartNew();
            //Robots.GrosRobot.TrajectoirePolaire(SensAR.Avant, trajectoirePolaire, true);

            //ThreadHokuyoRecalViolet();
        }

        bool moveMouse = false;
        private void pictureBoxTable_Click(object sender, EventArgs e)
        {
            if (!moveMouse && Dessinateur.modeCourant == Dessinateur.MouseMode.TrajectoirePolaire)
            {
                RealPoint point = Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
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
                CheckElementClick();
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
            List<RealPoint> pts = lidar.GetMesure();
            Plateau.ObstaclesPlateau = new List<IShape>();
            foreach (RealPoint p in pts)
            {
                Plateau.ObstaclesPlateau.Add(new Circle(p, 4));
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
            Strategy m = (Strategy)o;
            Plateau.Strategy = m;
            Plateau.Strategy.Execute();
        }

        private void ThreadHokuyoRecalViolet()
        {
            Robots.GrosRobot.PositionerAngle(180);

            Angle a = Actionneur.Hokuyo.CalculAngle(new Segment(new RealPoint(0, 50), new RealPoint(0, 900)), 50, 10);
            if (a.InPositiveDegrees > 180)
                Robots.GrosRobot.PivotDroite(a.InPositiveDegrees - 270);
            else
                Robots.GrosRobot.PivotGauche((90 - a.InPositiveDegrees));

            Robots.GrosRobot.ReglerOffsetAsserv(new Position(180, Robots.GrosRobot.Position.Coordinates));

            double distance = Actionneur.Hokuyo.CalculDistanceX(new Segment(new RealPoint(0, 50), new RealPoint(0, 900)), 50, 2);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(180, Robots.GrosRobot.Position.Coordinates.Translation(-distance, 0)));

            distance = Actionneur.Hokuyo.CalculDistanceY(970, 1170, 150, 2);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(180, Robots.GrosRobot.Position.Coordinates.Translation(0, -distance)));
        }

        private void ThreadHokuyoRecalVert()
        {
            Robots.GrosRobot.PositionerAngle(0);

            Angle a = Actionneur.Hokuyo.CalculAngle(new Segment(new RealPoint(3000, 50), new RealPoint(3000, 900)), 50, 10);
            if (a.InPositiveDegrees > 180)
                Robots.GrosRobot.PivotDroite(a.InPositiveDegrees - 270);
            else
                Robots.GrosRobot.PivotGauche((90 - a.InPositiveDegrees));

            Robots.GrosRobot.ReglerOffsetAsserv(new Position(0, Robots.GrosRobot.Position.Coordinates));

            double distance = Actionneur.Hokuyo.CalculDistanceX(new Segment(new RealPoint(3000, 50), new RealPoint(3000, 900)), 50, 10);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(0, Robots.GrosRobot.Position.Coordinates.Translation(-(distance - 3000), 0)));

            Robots.GrosRobot.PositionerAngle(45);

            distance = Actionneur.Hokuyo.CalculDistanceY(3000 - 1170, 3000 - 970, 150, 2);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(0, Robots.GrosRobot.Position.Coordinates.Translation(0, -distance)));
        }
    }
}
