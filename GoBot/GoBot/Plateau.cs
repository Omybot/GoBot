using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using AStarFolder;
using GoBot.Geometry.Shapes;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using GoBot.Geometry;
using GoBot.Ponderations;
using GoBot.Enchainements;
using GoBot.Mouvements;
using GoBot.Balises;
using GoBot.Communications;
using GoBot.ElementsJeu;
using GoBot.Devices;

namespace GoBot
{
    public class Plateau
    {
        public static int RayonAdversaireInitial { get; set; }
        public static int RayonAdversaire { get; set; }

        public static Balise Balise { get; set; }

        public static Enchainement Enchainement { get; set; }
        public static Poids PoidActions { get; set; }

        public static List<IShape> ObstaclesPlateau { get; set; }
        public static List<IShape> ObstaclesBalise { get; set; }

        public static RealPoint PositionCibleRobot { get; set; }

        public static GameElements Elements { get; protected set; }
        
        private static Color notreCouleur;
        public static Color NotreCouleur
        {
            get { return notreCouleur; }
            set 
            {
                if (notreCouleur != value)
                {
                    notreCouleur = value;
                    if(Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                        Devices.Devices.RecGoBot.SetLedColor(Color.Blue);
                    else
                        Devices.Devices.RecGoBot.SetLedColor(Color.Yellow);
                    
                    NotreCouleurChange?.Invoke(null, null);
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

        public static Color CouleurGaucheVert { get { return Color.FromArgb(96, 153, 58); } }
        public static Color CouleurDroiteOrange { get { return Color.FromArgb(219, 114, 52); } }

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
        public static List<IShape> ListeObstacles
        {
            get
            {
                List<IShape> toutObstacles = new List<IShape>();
                toutObstacles.AddRange(ObstaclesPlateau);
                toutObstacles.AddRange(ObstaclesBalise);
                return toutObstacles;
            }
        }

        public Plateau()
        {
            if (!Execution.DesignMode)
            {
                Elements = new GameElements();
                RayonAdversaireInitial = 200;
                RayonAdversaire = RayonAdversaireInitial;

                ReflecteursNosRobots = true;

                ObstaclesBalise = new List<IShape>();

                ChargerObstacles();
                CreerSommets(100);
                SauverGraph();

                Balise.PositionEnnemisActualisee += Balise_PositionEnnemisActualisee;
                
                SemaphoreCollisions = new Semaphore(0, int.MaxValue);
                thCollisions = new Thread(ThreadTestCollisions);
                thCollisions.Start();
            }
        }

        void Balise_PositionEnnemisActualisee(List<RealPoint> positions)
        {
            // Positions ennemies signalées par la balise

            lock (ObstaclesBalise)
            {
                ObstaclesBalise.Clear();

                int vitesseMax = Config.CurrentConfig.ConfigRapide.LineSpeed;

                for (int i = 0; i < positions.Count; i++)
                {
                    RealPoint coordonnees = new RealPoint(positions[i].X, positions[i].Y);
                    AjouterObstacle(new Circle(coordonnees, RayonAdversaire));

                    if (Plateau.Enchainement == null)
                    {
                        // Tester ici ce qu'il y a à tester en fonction de la position de l'ennemi AVANT de lancer le match
                    }
                    else
                    {
                        // Tester ici ce qu'il y a à tester en fonction de la position de l'ennemi PENDANT le match

                        if (Robots.GrosRobot.VitesseAdaptableEnnemi)
                        {
                            double distanceAdv = Robots.GrosRobot.Position.Coordinates.Distance(coordonnees);
                            if (distanceAdv < 1500)
                            {
                                vitesseMax = (int)(Math.Min(vitesseMax, (distanceAdv - 300) / 1000.0 * Config.CurrentConfig.ConfigRapide.LineSpeed));
                            }
                        }
                    }
                }
            }

            Robots.GrosRobot.MajGraphFranchissable();

            SemaphoreCollisions.Release();
        }

        public static void Init()
        {
            Balise = new Balise();

            PositionCibleRobot = Robots.GrosRobot.Position.Coordinates;
        }

        private Semaphore SemaphoreCollisions { get; set; }
        private void ThreadTestCollisions()
        {
            while (!Execution.Shutdown)
            {
                // Le timeout sur le Thread permet de vérifier chaque seconde si on est en train d'éteindre l'application pour couper le Thread.
                while (!SemaphoreCollisions.WaitOne(1000) && !Execution.Shutdown) ;
                Robots.GrosRobot.ObstacleTest();
            }
        }

        Thread thCollisions;
        public void ObstacleTest(int x, int y)
        {
            // Obstacle de simulation
            ObstaclesBalise.Clear();
            RealPoint coordonnees = new RealPoint(x, y);

            Console.Write(" Ajout obstacle");
            AjouterObstacle(new Circle(coordonnees, 200));

            if (Plateau.Enchainement == null)
            {
                // Tester ici ce qu'il y a à tester en fonction de la position de l'ennemi AVANT de lancer le match
            }
            else
            {
                // Tester ici ce qu'il y a à tester en fonction de la position de l'ennemi PENDANT le match
            }

            SemaphoreCollisions.Release();
        }

        /// <summary>
        /// Vide les obstacles temporaires et rend tout le graph parcourable
        /// </summary>
        public static void ViderObstacles()
        {
            foreach (Robot robot in new List<Robot> { Robots.GrosRobot })
            {
                for (int i = 0; i < robot.Graph.Arcs.Count; i++)
                    ((Arc)robot.Graph.Arcs[i]).Passable = true;
                for (int i = 0; i < robot.Graph.Nodes.Count; i++)
                    ((Node)robot.Graph.Nodes[i]).Passable = true;
            }
        }

        /// <summary>
        /// Ajoute un obstacle et teste les endroits du graph qui ne sont plus franchissables
        /// </summary>
        /// <param name="obstacle">Forme de l'obstacle</param>
        /// <param name="fixe">Si l'obstacle est fixe, on supprime complètement les noeuds et arcs non franchissables. Sinon on les rends non franchissables temporairement.</param>
        public static void AjouterObstacle(IShape obstacle, bool fixe = false, bool majGraph = false)
        {
            if (majGraph)
                ObstaclesBalise.Clear();

            if (fixe)
                ObstaclesPlateau.Add(obstacle);
            else
                ObstaclesBalise.Add(obstacle);
        }

        /// <summary>
        /// Sauve le graph pour une utilisation ultérieure
        /// </summary>
        public void SauverGraph()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Config.PathData + "/graphGros.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                formatter.Serialize(stream, Robots.GrosRobot.Graph);
        }

        /// <summary>
        /// Charge le dernier graph sauvegardé. Permet de gagner du temps par rapport à une génération du graph à chaque execution.
        /// </summary>
        public static void ChargerGraphGros()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(Config.PathData + "/graphGros.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
                    Robots.GrosRobot.Graph = (Graph)formatter.Deserialize(stream);
            }
            catch (Exception e)
            {
                MessageBox.Show("Impossible de charger le graph." + Environment.NewLine + e.Message);
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
                distanceLiaison = Math.Sqrt((resolution * resolution) * 2) + 1;

            Robots.GrosRobot.Graph = new Graph();

            // Création des noeuds
            for (int x = resolution / 2; x < Largeur; x += resolution)
                for (int y = resolution / 2; y < Hauteur; y += resolution)
                    Robots.GrosRobot.Graph.AddNode(new Node(x, y, 0), Plateau.ObstaclesPlateau, Robots.GrosRobot.Rayon, Math.Sqrt(resolution * resolution * 2) + 1, true);
        }

        public void ChargerObstacles()
        {
            ObstaclesPlateau = new List<IShape>();
            List<RealPoint> points = new List<RealPoint>();

            // Contours du plateau
            AjouterObstacle(new Segment(new RealPoint(0, 0), new RealPoint(Largeur - 4, 0)), true);
            AjouterObstacle(new Segment(new RealPoint(Largeur - 4, 0), new RealPoint(Largeur - 4, Hauteur - 4)), true);
            AjouterObstacle(new Segment(new RealPoint(Largeur - 4, Hauteur - 4), new RealPoint(0, Hauteur - 4)), true);
            AjouterObstacle(new Segment(new RealPoint(0, Hauteur - 4), new RealPoint(0, 0)), true);

            // Distributeurs
            AjouterObstacle(new Circle(new RealPoint(0, 840), 110), true);
            AjouterObstacle(new Circle(new RealPoint(610, 2000), 110), true);
            AjouterObstacle(new Circle(new RealPoint(2390, 2000), 110), true);
            AjouterObstacle(new Circle(new RealPoint(3000, 840), 110), true);

            // Stations dépuration
            AjouterObstacle(new PolygonRectangle(new RealPoint(894, 1750), 1200, 250), true);
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
