using Geometry;
using Geometry.Shapes;
using GoBot.Devices;
using GoBot.GameElements;
using GoBot.Strategies;
using GoBot.Movements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using GoBot.Threading;
using GoBot.BoardContext;

namespace GoBot.IHM
{

    public partial class PageTable : UserControl
    {
        private static ThreadLink _linkDisplay;

        public static GameBoard Plateau { get; set; }

        public PageTable()
        {
            InitializeComponent();
            Plateau = new GameBoard();
            GameBoard.ScoreChange += new GameBoard.ScoreChangeDelegate(Plateau_ScoreChange);
            GameBoard.MyColorChange += GameBoard_MyColorChange;
            Dessinateur.TableDessinee += Dessinateur_TableDessinee;

            btnColorLeft.BackColor = GameBoard.ColorLeftBlue;
            btnColorRight.BackColor = GameBoard.ColorRightYellow;

            checkedListBox.SetItemChecked(0, true);
            checkedListBox.SetItemChecked(1, true);

            toolTip.SetToolTip(btnTeleportRPFace, "Téléportation de face");
            toolTip.SetToolTip(btnTeleportRPCentre, "Téléportation de centre");
            toolTip.SetToolTip(btnPathRPFace, "Path finding de face");
            toolTip.SetToolTip(btnPathRPCentre, "Path finding du centre");
        }

        private void GameBoard_MyColorChange(object sender, EventArgs e)
        {
            picColor.BackColor = GameBoard.MyColor;
        }

        void Dessinateur_TableDessinee(Image img)
        {
            this.InvokeAuto(() => pictureBoxTable.Image = img);
        }

        void Plateau_ScoreChange(int score)
        {
            this.InvokeAuto(() => lblScore.Text = score.ToString());
        }

        void DisplayInfos()
        {
            this.InvokeAuto(() =>
            { 
                lblPosGrosX.Text = Robots.GrosRobot.Position.Coordinates.X.ToString("0.00");
                lblPosGrosY.Text = Robots.GrosRobot.Position.Coordinates.Y.ToString("0.00");
                lblPosGrosTeta.Text = Robots.GrosRobot.Position.Angle.ToString();
            });

            if (GameBoard.Strategy != null)
            {
                TimeSpan tempsRestant = GameBoard.Strategy.TimeBeforeEnd;
                if (tempsRestant.TotalMilliseconds <= 0)
                    tempsRestant = new TimeSpan(0);

                Color couleur;
                if (tempsRestant.TotalSeconds > GameBoard.Strategy.MatchDuration.TotalSeconds / 2)
                    couleur = Color.FromArgb((int)((GameBoard.Strategy.MatchDuration.TotalSeconds - tempsRestant.TotalSeconds) * (150.0 / (GameBoard.Strategy.MatchDuration.TotalSeconds / 2.0))), 150, 0);
                else
                    couleur = Color.FromArgb(150, 150 - (int)((GameBoard.Strategy.MatchDuration.TotalSeconds / 2.0 - tempsRestant.TotalSeconds) * (150.0 / (GameBoard.Strategy.MatchDuration.TotalSeconds / 2.0))), 0);

                this.InvokeAuto(() =>
                {
                    lblSecondes.Text = (int)tempsRestant.TotalSeconds + "";
                    lblMilli.Text = tempsRestant.Milliseconds + "";

                    lblSecondes.ForeColor = couleur;
                    lblMilli.ForeColor = couleur;
                });
            }
        }

        private void btnAffichage_Click(object sender, EventArgs e)
        {
            if (btnAffichage.Text == "Lancer l'affichage")
            {
                _linkDisplay = ThreadManager.CreateThread(link => DisplayInfos());
                _linkDisplay.Name = "Affichage des données";
                _linkDisplay.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, 100));

                Dessinateur.Start();

                btnAffichage.Text = "Stopper l'affichage";
                btnAffichage.Image = GoBot.Properties.Resources.Pause16;
            }
            else
            {
                _linkDisplay?.Cancel();
                _linkDisplay?.WaitEnd();
                _linkDisplay = null;

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
                    GameBoard.SetOpponents(positions);
                    //SuiviBalise.MajPositions(positions, Plateau.Enchainement == null || Plateau.Enchainement.DebutMatch == null);
                }
            }
            else
            {
                RealPoint posOnTable = Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
                lblX.Text = posOnTable.X.ToString("0");
                lblY.Text = posOnTable.Y.ToString("0");

                bool hoverElement = false;
                
                foreach (GameElement element in GameBoard.Elements)
                {
                    if (posOnTable.Distance(element.Position) < element.HoverRadius)
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
            if (!move.Execute())
            {
#if DEBUG
                MessageBox.Show("Echec");
#endif
            }
            move = null;
        }

        Movement move;

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Todo
            
            GameBoard.Score = 0;
        }

        private void CheckElementClick()
        {
            foreach (GameElement element in GameBoard.Elements)
                if (element.IsHover)
                    ThreadManager.CreateThread(link =>
                    {
                        link.Name = "Action " + element.ToString();
                        element.ClickAction();
                    }).StartThread();
        }
        
        //MouseEventArgs ev;

        private void btnGo_Click(object sender, EventArgs e)
        {
            GameBoard.Strategy = new StrategyMatch();
            GameBoard.Strategy.ExecuteMatch();
        }

        private void PanelTable_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                btnAffichage_Click(null, null);
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
        
        List<RealPoint> trajectoirePolaire;
        List<RealPoint> pointsPolaires;

        private void pictureBoxTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (pSelected != -1)
                pSelected = -1;

            if (Dessinateur.modeCourant == Dessinateur.MouseMode.PositionCentre || Dessinateur.modeCourant == Dessinateur.MouseMode.TeleportCentre)
            {
                Direction traj = Maths.GetDirection(Dessinateur.positionDepart, Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));

                positionArrivee = new Position(new AnglePosition(-traj.angle), Dessinateur.positionDepart);

                if (Dessinateur.modeCourant == Dessinateur.MouseMode.PositionCentre)
                    ThreadManager.CreateThread(link => ThreadTrajectory(link)).StartThread();
                else
                    Robots.GrosRobot.ReglerOffsetAsserv(positionArrivee);

                Dessinateur.modeCourant = Dessinateur.MouseMode.None;
            }
            else if (Dessinateur.modeCourant == Dessinateur.MouseMode.PositionFace || Dessinateur.modeCourant == Dessinateur.MouseMode.TeleportFace)
            {
                Point positionFin = pictureBoxTable.PointToClient(MousePosition);

                Direction traj = Maths.GetDirection(Dessinateur.positionDepart, Dessinateur.Scale.ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));

                Point pointOrigine = Dessinateur.positionDepart;
                Position departRecule = new Position(new AnglePosition(-traj.angle), pointOrigine);
                departRecule.Move(-Robots.GrosRobot.Longueur / 2);
                departRecule = new Position(new AnglePosition(-traj.angle), new RealPoint(departRecule.Coordinates.X, departRecule.Coordinates.Y));
                positionArrivee = departRecule;

                if (Dessinateur.modeCourant == Dessinateur.MouseMode.PositionFace)
                    ThreadManager.CreateThread(link => ThreadTrajectory(link)).StartThread();
                else
                    Robots.GrosRobot.ReglerOffsetAsserv(positionArrivee);

                Dessinateur.modeCourant = Dessinateur.MouseMode.None;
            }

            Dessinateur.MouseClicked = false;
        }

        private void btnAleatoire_Click(object sender, EventArgs e)
        {
            GameBoard.Strategy = new StrategyRandomMoves();
            GameBoard.Strategy.ExecuteMatch();
        }
        Position positionArrivee;

        private void ThreadTrajectory(ThreadLink link)
        {
            link.RegisterName();

            this.InvokeAuto(() => btnPathRPCentre.Enabled = false);

            Robots.GrosRobot.GotoXYTeta(new Position(positionArrivee.Angle.InDegrees, positionArrivee.Coordinates));

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
            if (ligne == "Calcul path finding")
                Config.CurrentConfig.AfficheDetailTraj = e.NewValue == CheckState.Checked ? 30 : 0;
            if (ligne == "Historique trajectoire")
                Dessinateur.AfficheHistoriqueCoordonnees = e.NewValue == CheckState.Checked;
        }

        private void btnZoneDepart_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(link => GoToDepart(link)).StartThread();
        }

        public void GoToDepart(ThreadLink link)
        {
            link.RegisterName();
            Robots.GrosRobot.GotoXYTeta(Recalibration.StartPosition);
        }

        private void btnStratNul_Click(object sender, EventArgs e)
        {
            GameBoard.Strategy = new StrategyEmpty();
            GameBoard.Strategy.ExecuteMatch();
        }

        private void btnStratTest_Click(object sender, EventArgs e)
        {
            GameBoard.Strategy = new StrategyRoundTrip();
            GameBoard.Strategy.ExecuteMatch();
        }

        private void btnTestAsser_Click(object sender, EventArgs e)
        {
            ThreadLink th = ThreadManager.CreateThread(link => TestAsser(link));
            th.StartThread();
        }

        private void TestAsser(ThreadLink link)
        {
            link.RegisterName();

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

            Robots.GrosRobot.GotoXYTeta(Recalibration.StartPosition);

            Robots.GrosRobot.Reculer(300);
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

        bool moveMouse = false;
        private void pictureBoxTable_Click(object sender, EventArgs e)
        {
            if (boxSourisObstacle.Checked)
                boxSourisObstacle.Checked = false;
            else if (!moveMouse && Dessinateur.modeCourant == Dessinateur.MouseMode.TrajectoirePolaire)
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

        private void ThreadMouvement(Object o)
        {
            Movement m = (Movement)o;
            m.Execute();
        }

        private void ThreadEnchainement(Object o)
        {
            Strategy m = (Strategy)o;
            GameBoard.Strategy = m;
            GameBoard.Strategy.ExecuteMatch();
        }

        private void btnTestScore_Click(object sender, EventArgs e)
        {
            GameBoard.Score++;
        }

        private void btnRestartRecal_Click(object sender, EventArgs e)
        {
            if(GameBoard.ColorLeftBlue == GameBoard.MyColor)
            {
                Robots.GrosRobot.GotoXYTeta(new Position(90, new RealPoint(300, 300)));
                Recalibration.Calibration();
            }
            else
            {
                Robots.GrosRobot.GotoXYTeta(new Position(90, new RealPoint(3000-300, 300)));
                Recalibration.Calibration();
            }
        }

        private void btnColorLeft_Click(object sender, EventArgs e)
        {
            GameBoard.MyColor = GameBoard.ColorLeftBlue;
        }

        private void btnColorRight_Click(object sender, EventArgs e)
        {
            GameBoard.MyColor = GameBoard.ColorRightYellow;
        }

        private void btnCalib_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(link => Recalibration.Calibration()).StartThread();
        }
    }
}
