using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using AStarFolder;
using Geometry.Shapes;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Geometry;
using GoBot.Ponderations;
using GoBot.Strategies;
using GoBot.Movements;
using GoBot.Beacons;
using GoBot.Communications;
using GoBot.GameElements;
using GoBot.Devices;
using GoBot.Threading;
using GoBot.GameBoard;
using System.Diagnostics;

namespace GoBot
{
    public class Plateau
    {
        private static Obstacles _obstacles;

        public static int RayonAdversaireInitial { get; set; }
        public static int RayonAdversaire { get; set; }

        public static Beacon Balise { get; set; }

        public static Strategy Strategy { get; set; }
        public static Poids PoidActions { get; set; }

        //public static List<IShape> ObstaclesPlateau { get; set; }
        //public static List<IShape> ObstaclesBalise { get; set; }

        private static Polygon _bounds;

        public static IEnumerable<IShape> ObstaclesCouleur
        {
            get
            {
                return _obstacles.FromColor;
            }
        }

        private static bool _colorFreezed = false;

        internal static void FreezeColor()
        {
            _colorFreezed = true;
        }

        public static AllGameElements Elements { get; protected set; }
        public static List<IShape> Detections { get; set; }

        private static Color notreCouleur = CouleurDroiteViolet;
        public static Color NotreCouleur
        {
            get { return notreCouleur; }
            set
            {
                if (!_colorFreezed)
                {
                    if (notreCouleur != value)
                    {
                        notreCouleur = value;
                        if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
                            AllDevices.RecGoBot.SetLedColor(Color.Yellow);
                        else
                            AllDevices.RecGoBot.SetLedColor(Color.DarkViolet);

                        NotreCouleurChange?.Invoke(null, null);
                        if(_obstacles != null)
                            Robots.GrosRobot.MajGraphFranchissable(_obstacles.FromAllExceptBoard);
                    }
                }
            }
        }
        public static event EventHandler NotreCouleurChange;

        public static bool ReflecteursNosRobots { get; set; }

        private static int score;
        public static int Score
        {
            get { return score; }
            set { score = value; ScoreChange?.Invoke(score); }
        }

        public delegate void ScoreChangeDelegate(int score);
        public static event ScoreChangeDelegate ScoreChange;

        public static Color CouleurGaucheJaune { get { return Color.FromArgb(254, 194, 16); } }
        public static Color CouleurDroiteViolet { get { return Color.FromArgb(137, 58, 144); } }

        /// <summary>
        /// Largeur de la table (mm)
        /// </summary>
        public static int Largeur { get { return 3000; } }

        /// <summary>
        /// Hauteur de la table (mm)
        /// </summary>
        public static int Hauteur { get { return 2000; } }

        /// <summary>
        /// Largeur de la bordure de la table (mm)
        /// </summary>
        public static int BorderWidth { get { return 22; } }

        /// <summary>
        /// Liste complète des obstacles fixes et temporaires
        /// </summary>
        public static IEnumerable<IShape> ListeObstacles
        {
            get
            {
                return _obstacles.FromAll.ToList(); // Pour concretiser la liste
            }
        }

        public static IEnumerable<IShape> ObstaclesOpponents
        {
            get
            {
                return _obstacles.FromDetection.ToList();
            }
        }

        public static bool IsInside(RealPoint p, int securityDistance = 0)
        {
            bool inside = _bounds.Contains(p);
            if (inside && securityDistance > 0)
                inside = !_bounds.Sides.Exists(o => o.Distance(p) < securityDistance);

            return inside;
        }

        public static void StartMatch()
        {
            timerZoneDepart = ThreadManager.CreateThread(link =>
            {
                if (qqunZoneDepart)
                    cptZoneDepart++;
                else
                {
                    cptZoneDepart = 0;
                    reduireAdvInZoneDepart = false;
                }

                qqunZoneDepart = false;

                if (cptZoneDepart >= 5)
                    reduireAdvInZoneDepart = true;

            });
            timerZoneDepart.StartInfiniteLoop(1000);
        }

        public Plateau()
        {
            if (!Execution.DesignMode)
            {
                Elements = new GameElements.AllGameElements();
                RayonAdversaireInitial = 200;
                RayonAdversaire = RayonAdversaireInitial;

                ReflecteursNosRobots = true;

                _obstacles = new Obstacles(Elements);
                CreerSommets(50);

                //Balise.PositionEnnemisActualisee += Balise_PositionEnnemisActualisee;

                Strategy = new StrategyMatch();
                Robots.GrosRobot.MajGraphFranchissable(_obstacles.FromAllExceptBoard);

                List<RealPoint> bounds = new List<RealPoint>();
                bounds.Add(new RealPoint(0, 0));
                bounds.Add(new RealPoint(3000, 0));
                bounds.Add(new RealPoint(3000, 2000));

                bounds.Add(new RealPoint(2550, 2000));
                bounds.Add(new RealPoint(2550, 1600));

                bounds.Add(new RealPoint(1500 + 20, 1600));
                bounds.Add(new RealPoint(1500 + 20, 1375));
                bounds.Add(new RealPoint(1500 - 20, 1375));
                bounds.Add(new RealPoint(1500 - 20, 1600));

                bounds.Add(new RealPoint(450, 1600));
                bounds.Add(new RealPoint(450, 2000));

                bounds.Add(new RealPoint(0, 2000));
                _bounds = new Polygon(bounds);

                StartDetection();
            }
        }

        public static void StartDetection()
        {
            ThreadManager.CreateThread(link =>
            {
                while (AllDevices.HokuyoAvoid == null) ;
                    AllDevices.HokuyoAvoid.StartLoopMeasure();
                    AllDevices.HokuyoAvoid.NewMeasure += HokuyoAvoid_NewMeasure;
            }).StartThread();
        }



        private static int cptZoneDepart = 0;
        private static bool qqunZoneDepart = false;
        private static ThreadLink timerZoneDepart;
        private static bool reduireAdvInZoneDepart = false;

        public static void SetOpponents(List<RealPoint> positions)
        {
            if (_obstacles != null)
            {

                // Positions ennemies signalées par la balise

                Stopwatch sw = Stopwatch.StartNew();

                int vitesseMax = Config.CurrentConfig.ConfigRapide.LineSpeed;
                
                // Truc dégueu pour ne pas détecter notre robot secondaire qui est dans la zone de départ au début du match
                positions = positions.Where(o => !NotreZoneDepart().Contains(o)).ToList();
                
                if (Plateau.Strategy == null)
                {
                    // TODOEACHYEAR Tester ICI ce qu'il y a à tester en fonction de la position de l'ennemi AVANT de lancer le match
                }
                else
                {
                    // TODOEACHYEAR Tester ICI ce qu'il y a à tester en fonction de la position de l'ennemi PENDANT le match

                    Elements.SetOpponents(positions);

                    if (Robots.GrosRobot.VitesseAdaptableEnnemi && positions.Count > 0)
                    {
                        double minOpponentDist = positions.Min(p => p.Distance(Robots.GrosRobot.Position.Coordinates));
                        Robots.GrosRobot.SpeedConfig.LineSpeed = SpeedWithOpponent(minOpponentDist, Config.CurrentConfig.ConfigRapide.LineSpeed);
                    }
                }
                
                _obstacles.SetDetections(positions.Select(p =>
                {
                    if (_obstacles.FromColor.ElementAt(0).Contains(p))
                    {
                        qqunZoneDepart = true;
                        if (reduireAdvInZoneDepart)
                            return new Circle(p, RayonAdversaire / 3);
                        else
                            return new Circle(p, RayonAdversaire);
                    }

                    else if (_obstacles.BalanceYellow.Contains(p) && notreCouleur == CouleurDroiteViolet)
                        return new Circle(p, RayonAdversaire / 3);
                    else if (_obstacles.BalanceViolet.Contains(p) && notreCouleur == CouleurGaucheJaune)
                        return new Circle(p, RayonAdversaire / 3);
                    else
                        return new Circle(p, RayonAdversaire);

                }).ToList());

                //_obstacles.SetDetections(positions.Select(p => new Circle(p, RayonAdversaire)).ToList());

                AllDevices.RecGoBot.ChangeLed(LedID.DebugB3);
                Robots.GrosRobot.MajGraphFranchissable(_obstacles.FromAllExceptBoard);
                Robots.GrosRobot.ObstacleTest(_obstacles.FromDetection);
            }
        }

        public static IShape NotreZoneDepart()
        {
            if (Plateau.NotreCouleur == Plateau.CouleurDroiteViolet)
                return new PolygonRectangle(new RealPoint(2550, 300), 400, 900);
            else
                return new PolygonRectangle(new RealPoint(0, 300), 400, 900);
        }

        public static void Init()
        {
            Balise = new Beacon();

            AllDevices.RecGoBot.SetLed(LedID.DebugB3, AllDevices.HokuyoAvoid == null ? RecGoBot.LedStatus.Rouge : RecGoBot.LedStatus.Vert);
        }

        static long cptLIDAR = 0;

        private static void HokuyoAvoid_NewMeasure(List<RealPoint> measure)
        {
            cptLIDAR++;

            if (cptLIDAR % 4 == 0) // TODO2020 : Diminution de l'échantilonnage à l'arrache
            {
                List<RealPoint> pts = measure.Where(o => IsInside(o, 100)).ToList();
                pts = pts.Where(o => o.Distance(Robots.GrosRobot.Position.Coordinates) > 300).ToList();

                List<List<RealPoint>> groups = pts.GroupByDistance(50, 20);

                List<RealPoint> obstacles = new List<RealPoint>();

                foreach (List<RealPoint> group in groups)
                {
                    RealPoint center = group.GetBarycenter();
                    if (!obstacles.Exists(o => o.Distance(center) < 150))
                        obstacles.Add(center);
                }

                Stopwatch sw = Stopwatch.StartNew();
                if (obstacles.Count > 0) SetOpponents(obstacles);
                Debug.Print(sw.ElapsedMilliseconds + " ms");
            }
        }

        /// <summary>
        /// Crée le graph du pathfinding.
        /// </summary>
        /// <param name="resolution">Distance (mm) entre chaque noeud du graph en X et Y</param>
        /// <param name="distanceLiaison">Distance (mm) jusqu'à laquelle les noeuds sont reliés par un arc. Par défaut on crée un graph minimal (liaison aux 8 points alentours : N/S/E/O/NE/NO/SE/SO)</param>
        private void CreerSommets(int resolution, double distanceLiaison = -1)
        {
            if (distanceLiaison == -1)
                distanceLiaison = Math.Sqrt((resolution * resolution) * 2) * 1.05; //+5% pour prendre large

            Robots.GrosRobot.Graph = new Graph(resolution, distanceLiaison);

            // Création des noeuds
            for (int x = resolution / 2; x < Largeur; x += resolution)
                for (int y = resolution / 2; y < Hauteur; y += resolution)
                    Robots.GrosRobot.Graph.AddNode(new Node(x, y), _obstacles.FromBoard, Robots.GrosRobot.Rayon, true);
        }

        public static void SetDetections(IEnumerable<IShape> detections)
        {
            _obstacles?.SetDetections(detections);
        }

        static double lastFactor = 1;

        private static int SpeedWithOpponent(double opponentDist, int maxSpeed)
        {
            double minPower = 0.20;
            double minDist = 250;
            double maxPowerDist = 600;
            double factor;

            if (opponentDist < minDist)
                factor = minPower;
            else
            {
                factor = Math.Min((Math.Pow(opponentDist - minDist, 2) / Math.Pow((maxPowerDist - minDist), 2)) * (1 - minPower) + minPower, 1);
                if (factor < 0.6)
                    factor = 0.6;
                else
                    factor = 1;
            }

            return (int)(factor * maxSpeed);
        }

        /// <summary>
        /// Teste si on point est contenu dans la table
        /// </summary>
        /// <param name="croisement">Point à tester</param>
        /// <returns></returns>
        public static bool Contient(RealPoint point)
        {
            return new PolygonRectangle(new RealPoint(0, 0), Hauteur, Largeur).Contains(point);
        }
    }
}
