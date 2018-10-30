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

        private static Color notreCouleur;
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
                            Devices.Devices.RecGoBot.SetLedColor(Color.Green);
                        else
                            Devices.Devices.RecGoBot.SetLedColor(Color.Orange);

                        NotreCouleurChange?.Invoke(null, null);
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
            set { score = value; ScoreChange?.Invoke(null, null); }
        }
        public static event EventHandler ScoreChange;

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

        public Plateau()
        {
            if (!Execution.DesignMode)
            {
                Elements = new GameElements.AllGameElements();
                RayonAdversaireInitial = 200;
                RayonAdversaire = RayonAdversaireInitial;

                ReflecteursNosRobots = true;

                _obstacles = new Obstacles(Elements);
                CreerSommets(25);

                Balise.PositionEnnemisActualisee += Balise_PositionEnnemisActualisee;

                Strategy = new StrategyMinimumScore();
                Robots.GrosRobot.MajGraphFranchissable(_obstacles.FromAllExceptBoard);
            }
        }

        void Balise_PositionEnnemisActualisee(List<RealPoint> positions)
        {
            // Positions ennemies signalées par la balise

            Stopwatch sw = Stopwatch.StartNew();

            int vitesseMax = Config.CurrentConfig.ConfigRapide.LineSpeed;

            if (Plateau.Strategy == null)
            {
                // TODOEACHYEAR Tester ICI ce qu'il y a à tester en fonction de la position de l'ennemi AVANT de lancer le match
            }
            else
            {
                // TODOEACHYEAR Tester ICI ce qu'il y a à tester en fonction de la position de l'ennemi PENDANT le match

                Elements.SetOpponents(positions);

                if (Robots.GrosRobot.VitesseAdaptableEnnemi)
                {
                    double minOpponentDist = positions.Min(p => p.Distance(Robots.GrosRobot.Position.Coordinates));
                    Robots.GrosRobot.SpeedConfig.LineSpeed = SpeedWithOpponent(minOpponentDist, Config.CurrentConfig.ConfigRapide.LineSpeed);
                }
            }

            _obstacles.SetDetections(positions.Select(p => new Circle(p, RayonAdversaire)).ToList());

            Robots.GrosRobot.MajGraphFranchissable(_obstacles.FromAllExceptBoard);
            Robots.GrosRobot.ObstacleTest(_obstacles.FromDetection);
        }

        public static void Init()
        {
            Balise = new Beacon();
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
            _obstacles.SetDetections(detections);
        }

        private static int SpeedWithOpponent(double opponentDist, int maxSpeed)
        {
            double minPower = 0.20;
            double minDist = 250;
            double maxPowerDist = 600;
            double factor;

            if (opponentDist < minDist)
                factor = minPower;
            else
                factor = Math.Min((Math.Pow(opponentDist - minDist, 2) / Math.Pow((maxPowerDist - minDist), 2)) * (1 - minPower) + minPower, 1);

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
