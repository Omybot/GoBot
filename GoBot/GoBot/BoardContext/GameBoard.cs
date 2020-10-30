using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using AStarFolder;
using Geometry.Shapes;
using GoBot.Strategies;
using GoBot.GameElements;
using GoBot.Devices;
using GoBot.Threading;

namespace GoBot.BoardContext
{
    public class GameBoard
    {
        private static Obstacles _obstacles;
        private static Color _myColor = ColorRightYellow;
        private static int _score;

        private static int _initialOpponentRadius { get; set; }
        private static int _currentOpponentRadius { get; set; }

        private static int _startZoneCounter = 0;
        private static bool _startZonePresence = false;
        private static bool _startZoneSizeReduction = false;
        private static ThreadLink _linkStartZone;

        private static Strategy _currentStrategy;
        private static AllGameElements _elements;
        private static List<IShape> _detections;

        private static Polygon _bounds;

        public GameBoard()
        {
            if (!Execution.DesignMode)
            {
                _elements = new AllGameElements();
                _initialOpponentRadius = 200;
                _currentOpponentRadius = _initialOpponentRadius;

                _obstacles = new Obstacles(Elements);
                CreateGraph(75);

                //Balise.PositionEnnemisActualisee += Balise_PositionEnnemisActualisee;

                Robots.MainRobot.UpdateGraph(_obstacles.FromAllExceptBoard);

                // TODOEACHYEAR Définir ici la zone correspondant au plateau où les detections d'adversaire sont autorisées (enlever les pentes par exemple)
                _bounds = new PolygonRectangle(new RealPoint(0, 0), 3000, 2000);

                StartDetection();

                if (Config.CurrentConfig.IsMiniRobot)
                {
                    _currentStrategy = new StrategyMini();
                }
                else
                {
                    _currentStrategy = new StrategyMatch();
                }
            }
        }

        public static Strategy Strategy
        {
            //TODO2020 gérer un démarrage de stratégie mieux défini (avec une publique ?)
            get { return _currentStrategy; }
            set { _currentStrategy = value; }
        }

        public static void AddObstacle(IShape shape)
        {
            _obstacles.AddObstacle(shape);
        }

        public static AllGameElements Elements
        {
            get { return _elements; }
        }

        public static List<IShape> Detections
        {
            get { return _detections; }
            set { _detections = value; }
        }

        public static Color MyColor
        {
            get { return _myColor; }
            set
            {
                if (_myColor != value)
                {
                    _myColor = value;
                    MyColorChange?.Invoke(null, null);
                    if (_obstacles != null) Robots.MainRobot.UpdateGraph(_obstacles.FromAllExceptBoard);


                    if (Config.CurrentConfig.IsMiniRobot)
                    {
                        _currentStrategy = new StrategyMini();
                    }
                    else
                    {
                        _currentStrategy = new StrategyMatch();
                    }
                }
            }
        }
        public static event EventHandler MyColorChange;

        public static int Score
        {
            get { return _score; }
            set { _score = value; ScoreChange?.Invoke(_score); }
        }

        public delegate void ScoreChangeDelegate(int score);
        public static event ScoreChangeDelegate ScoreChange;

        public static Color ColorLeftBlue { get { return Color.FromArgb(0, 91, 140); } }
        public static Color ColorRightYellow { get { return Color.FromArgb(247, 181, 0); } }
        public static Color ColorNeutral { get { return Color.White; } }

        /// <summary>
        /// Largeur de la table (mm)
        /// </summary>
        public static int Width { get { return 3000; } }

        /// <summary>
        /// Hauteur de la table (mm)
        /// </summary>
        public static int Height { get { return 2000; } }

        /// <summary>
        /// Largeur de la bordure de la table (mm)
        /// </summary>
        public static int BorderSize { get { return 22; } }

        /// <summary>
        /// Diamètre actuellement considéré pour un adversaire
        /// </summary>
        public static int OpponentRadius
        {
            get { return _currentOpponentRadius; }
            set { _currentOpponentRadius = value; } // TODO2020 une publique non ? Reduce...
        }

        /// <summary>
        /// Diamètre initiallement considéré pour un adversaire
        /// </summary>
        public static int OpponentRadiusInitial
        {
            get { return _initialOpponentRadius; }
        }

        /// <summary>
        /// Liste complète des obstacles fixes et temporaires
        /// </summary>
        public static IEnumerable<IShape> ObstaclesAll
        {
            get
            {
                return _obstacles.FromAll.ToList(); // Pour concretiser la liste
            }
        }

        /// <summary>
        /// Liste complète des obstacles fixes et temporaires
        /// </summary>
        public static IEnumerable<IShape> ObstaclesBoardConstruction
        {
            get
            {
                return _obstacles.FromBoardConstruction.ToList(); // Pour concretiser la liste
            }
        }

        /// <summary>
        /// Liste complète des obstacles vus par un lidart au niveau du sol
        /// </summary>
        public static IEnumerable<IShape> ObstaclesLidarGround
        {
            get
            {
                return _obstacles.FromBoard.Concat(Elements.AsVisibleObstacles).ToList(); // Pour concretiser la liste
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
            _linkStartZone = ThreadManager.CreateThread(link => CheckStartZonePresence());
            _linkStartZone.StartInfiniteLoop(1000);
            _linkStartZone.Name = "Check zone départ";
        }

        private static void CheckStartZonePresence()
        {
            if (_startZonePresence)
                _startZoneCounter++;
            else
            {
                _startZoneCounter = 0;
                _startZoneSizeReduction = false;
            }

            _startZonePresence = false;

            if (_startZoneCounter >= 5)
                _startZoneSizeReduction = true;
        }

        public static void StartDetection()
        {
            if (AllDevices.LidarAvoid != null)
            {
                AllDevices.LidarAvoid.StartLoopMeasure();
                AllDevices.LidarAvoid.NewMeasure += LidarAvoid_NewMeasure;
            }
        }

        public static void SetOpponents(List<RealPoint> positions)
        {
            if (_obstacles != null && Strategy != null && Strategy.IsRunning)
            {
                // Positions ennemies signalées par la balise

                // TODO2020 Truc dégueu pour ne pas détecter notre robot secondaire qui est dans la zone de départ au début du match
                positions = positions.Where(o => !NotreZoneDepart().Contains(o)).ToList();

                if (GameBoard.Strategy == null)
                {
                    // TODOEACHYEAR Tester ICI ce qu'il y a à tester en fonction de la position de l'ennemi AVANT de lancer le match
                }
                else
                {
                    // TODOEACHYEAR Tester ICI ce qu'il y a à tester en fonction de la position de l'ennemi PENDANT le match

                    Elements.SetOpponents(positions);

                    if (Robots.MainRobot.IsSpeedAdvAdaptable && positions.Count > 0)
                    {
                        double minOpponentDist = positions.Min(p => p.Distance(Robots.MainRobot.Position.Coordinates));
                        Robots.MainRobot.SpeedConfig.LineSpeed = SpeedWithOpponent(minOpponentDist, Config.CurrentConfig.ConfigRapide.LineSpeed);
                    }
                }

                _obstacles.SetDetections(positions.Select(p =>
                {
                    //TODO 2020 : accès à l'élément 0 c'est faux... il faut tester la zone de départ explicitement
                    if (_obstacles.FromColor.ElementAt(0).Contains(p))
                    {
                        _startZonePresence = true;
                        if (_startZoneSizeReduction)
                            return new Circle(p, _currentOpponentRadius / 3);
                        else
                            return new Circle(p, _currentOpponentRadius);
                    }

                    return new Circle(p, _currentOpponentRadius);

                }).ToList());

                //_obstacles.SetDetections(positions.Select(p => new Circle(p, RayonAdversaire)).ToList());

                // TODO2020 : faudrait pouvoir mettre à jour le graph sans refaire les zones interdites de couleur (sauvegarder un résultat après application de la couleur ?)
                // parce que les carrés c'est beaucoup plus long que les ronds...
                Robots.MainRobot.UpdateGraph(_obstacles.FromAllExceptBoard);
                Robots.MainRobot.OpponentsTrajectoryCollision(_obstacles.FromDetection);
            }
        }

        public static IShape NotreZoneDepart()
        {
            if (GameBoard.MyColor == GameBoard.ColorRightYellow)
                return new PolygonRectangle(new RealPoint(2550, 300), 400, 900);
            else
                return new PolygonRectangle(new RealPoint(0, 300), 400, 900);
        }

        public static void Init()
        {
        }

        private static void LidarAvoid_NewMeasure(List<RealPoint> measure)
        {
            List<RealPoint> pts = measure.Where(o => IsInside(o, 100)).ToList();
            pts = pts.Where(o => o.Distance(Robots.MainRobot.Position.Coordinates) > 300).ToList();

            List<List<RealPoint>> groups = pts.GroupByDistance(50, 20);

            List<RealPoint> obstacles = new List<RealPoint>();

            foreach (List<RealPoint> group in groups)
            {
                if (group.Count > 2)
                {
                    RealPoint center = group.GetBarycenter();
                    if (!obstacles.Exists(o => o.Distance(center) < 150))
                        obstacles.Add(center);
                }
            }

            SetOpponents(obstacles);
        }

        /// <summary>
        /// Teste si on point est contenu dans la table
        /// </summary>
        /// <param name="croisement">Point à tester</param>
        /// <returns></returns>
        public static bool Contains(RealPoint point)
        {
            return new PolygonRectangle(new RealPoint(0, 0), Height, Width).Contains(point);
        }

        /// <summary>
        /// Crée le graph du pathfinding.
        /// </summary>
        /// <param name="resolution">Distance (mm) entre chaque noeud du graph en X et Y</param>
        /// <param name="distanceLiaison">Distance (mm) jusqu'à laquelle les noeuds sont reliés par un arc. Par défaut on crée un graph minimal (liaison aux 8 points alentours : N/S/E/O/NE/NO/SE/SO)</param>
        private void CreateGraph(int resolution, double distanceLiaison = -1)
        {
            if (distanceLiaison == -1)
                distanceLiaison = Math.Sqrt((resolution * resolution) * 2) * 1.05; //+5% pour prendre large

            Robots.MainRobot.Graph = new Graph(resolution, distanceLiaison);

            // Création des noeuds
            for (int x = resolution / 2; x < Width; x += resolution)
                for (int y = resolution / 2; y < Height; y += resolution)
                    Robots.MainRobot.Graph.AddNode(new Node(x, y), _obstacles.FromBoard, Robots.MainRobot.Radius, true);
        }

        /// <summary>
        /// Retourne la vitesse à adopter en fonction de la proximité de l'adversaire
        /// </summary>
        /// <param name="opponentDist">DIstance de l'adveraire</param>
        /// <param name="maxSpeed">Vitesse de pointe maximum</param>
        /// <returns>Vitese maximale prenant en compte la proximité de l'adversaire</returns>
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
    }
}
