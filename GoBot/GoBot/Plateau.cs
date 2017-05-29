using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using AStarFolder;
using GoBot.Calculs.Formes;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using GoBot.Calculs;
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

        public static List<IForme> ObstaclesPlateau { get; set; }
        public static List<IForme> ObstaclesBalise { get; set; }

        public static PointReel PositionCibleGros { get; set; }
        public static PointReel PositionCiblePetit { get; set; }

        public static Elements Elements { get; protected set; }

        public static List<ElementJeu> ElementsJeu { get; private set; }

        private static Color notreCouleur;
        public static Color NotreCouleur
        {
            get { return notreCouleur; }
            set 
            {
                if (notreCouleur != value)
                {
                    notreCouleur = value;
                    if(Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                        Devices.Devices.RecGoBot.SetLedColor(Color.Blue);
                    else
                        Devices.Devices.RecGoBot.SetLedColor(Color.Yellow);

                    //Robots.GrosRobot.Init();
                    //Robots.PetitRobot.Init();
                    NotreCouleurChange?.Invoke(null, null);
                }
            }
        }
        public static event EventHandler NotreCouleurChange;

        public static bool ReflecteursNosRobots { get; set; }

        public static IForme[] ObstaclesPieds { get; set; }

        private static int score;
        public static int Score
        {
            get { return score; }
            set { score = value; ScoreChange?.Invoke(null, null); }
        }
        public static event EventHandler ScoreChange;

        /// <summary>
        /// Graph des noeuds et arcs pour le pathfinding
        /// </summary>
        //public static Graph GraphGros { get; private set; }
        //public static Graph GraphPetit { get; private set; }

        public static Color CouleurGaucheBleu { get { return Color.FromArgb(40, 81, 174);} }
        public static Color CouleurDroiteJaune { get { return Color.FromArgb(238, 198, 27); } }

        /// <summary>
        /// Longueur de la table (mm)
        /// </summary>
        public static int LongueurPlateau { get { return 3000; } }

        /// <summary>
        /// Largeur de la table (mm)
        /// </summary>
        public static int LargeurPlateau { get { return 2000; } }

        /// <summary>
        /// Liste complète des obstacles fixes et temporaires
        /// </summary>
        public static List<IForme> ListeObstacles
        {
            get
            {
                List<IForme> toutObstacles = new List<IForme>();
                toutObstacles.AddRange(ObstaclesPlateau);
                toutObstacles.AddRange(ObstaclesBalise);
                return toutObstacles;
            }
        }

        public Plateau()
        {
            if (!Config.DesignMode)
            {
                Elements = new Elements();
                ObstaclesPieds = new IForme[0];
                RayonAdversaireInitial = 200;
                RayonAdversaire = RayonAdversaireInitial;

                ReflecteursNosRobots = true;

                ObstaclesBalise = new List<IForme>();

                ChargerObstacles();
                CreerSommets(110);
                SauverGraph();

                Balise.PositionEnnemisActualisee += Balise_PositionEnnemisActualisee;
                InitElementsJeu();
                
                SemaphoreCollisions = new Semaphore(0, int.MaxValue);
                thCollisions = new Thread(ThreadTestCollisions);
                thCollisions.Start();
            }
        }

        void Balise_PositionEnnemisActualisee(List<PointReel> positions)
        {
            // Positions ennemies signalées par la balise

            Synchronizer.Lock(ObstaclesBalise);
            ObstaclesBalise.Clear();

            int vitesseMax = Config.CurrentConfig.GRVitesseLigneRapide;

            for (int i = 0; i < positions.Count; i++)
            {
                PointReel coordonnees = new PointReel(positions[i].X, positions[i].Y);
                AjouterObstacle(new Cercle(coordonnees, RayonAdversaire));

                if (Plateau.Enchainement == null)
                {
                    // Tester ici ce qu'il y a à tester en fonction de la position de l'ennemi AVANT de lancer le match
                }
                else
                {
                    // Tester ici ce qu'il y a à tester en fonction de la position de l'ennemi PENDANT le match

                    if (Robots.GrosRobot.VitesseAdaptableEnnemi)
                    {
                        double distanceAdv = Robots.GrosRobot.Position.Coordonnees.Distance(coordonnees);
                        if (distanceAdv < 1500)
                        {
                            vitesseMax = (int)(Math.Min(vitesseMax, (distanceAdv - 300) / 1000.0 * Config.CurrentConfig.GRVitesseLigneRapide));
                        }
                    }
                }
            }
            Synchronizer.Unlock(ObstaclesBalise);

            Robots.GrosRobot.MajGraphFranchissable();

            SemaphoreCollisions.Release();
        }

        public static void InitElementsJeu()
        {
            // Initialiser les elements de jeu ici


            ElementsJeu = new List<ElementJeu>();

            // Les ajouters à ElementsJeu

            ElementsJeu.AddRange(Elements.Fusees);
            ElementsJeu.AddRange(Elements.Modules);
            ElementsJeu.AddRange(Elements.ZonesDepose);
        }

        public static void Init()
        {
            Balise = new Balise();

            PositionCibleGros = Robots.GrosRobot.Position.Coordonnees;
        }

        private Semaphore SemaphoreCollisions { get; set; }
        private void ThreadTestCollisions()
        {
            while (!Config.Shutdown)
            {
                // Le timeout sur le Thread permet de vérifier chaque seconde si on est en train d'éteindre l'application pour couper le Thread.
                while (!SemaphoreCollisions.WaitOne(1000) && !Config.Shutdown) ;
                Robots.GrosRobot.ObstacleTest();
            }
        }

        Thread thCollisions;
        public void ObstacleTest(int x, int y)
        {
            // Obstacle de simulation
            ObstaclesBalise.Clear();
            PointReel coordonnees = new PointReel(x, y);

            Console.Write(" Ajout obstacle");
            AjouterObstacle(new Cercle(coordonnees, 200));

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
        public static void AjouterObstacle(IForme obstacle, bool fixe = false, bool majGraph = false)
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
            for (int x = resolution / 2; x < LongueurPlateau; x += resolution)
                for (int y = resolution / 2; y < LargeurPlateau; y += resolution)
                    Robots.GrosRobot.Graph.AddNode(new Node(x, y, 0), Plateau.ObstaclesPlateau, Robots.GrosRobot.Rayon, Math.Sqrt(resolution * resolution * 2) + 1, true);
        }

        public void ChargerObstacles()
        {
            ObstaclesPlateau = new List<IForme>();
            List<PointReel> points = new List<PointReel>();

            // Contours du plateau
            AjouterObstacle(new Segment(new PointReel(0, 0), new PointReel(LongueurPlateau - 4, 0)), true);
            AjouterObstacle(new Segment(new PointReel(LongueurPlateau - 4, 0), new PointReel(LongueurPlateau - 4, LargeurPlateau - 4)), true);
            AjouterObstacle(new Segment(new PointReel(LongueurPlateau - 4, LargeurPlateau - 4), new PointReel(0, LargeurPlateau - 4)), true);
            AjouterObstacle(new Segment(new PointReel(0, LargeurPlateau - 4), new PointReel(0, 0)), true);

            // Zones de départ
            AjouterObstacle(new RectanglePolygone(new PointReel(0, 0), 710, 360 + 22), true);
            AjouterObstacle(new RectanglePolygone(new PointReel(3000 - 710, 0), 710, 360 + 22), true);

            // Zones de départ
            AjouterObstacle(new RectanglePolygone(new PointReel(0, 0), 710, 360 + 22), true);
            AjouterObstacle(new RectanglePolygone(new PointReel(3000 - 710, 0), 710, 360 + 22), true);

            // Zones latérales
            AjouterObstacle(new RectanglePolygone(new PointReel(0, 700 - 22), 80 + 22, 1150 - 700 + 22 + 22), true);
            AjouterObstacle(new RectanglePolygone(new PointReel(3000 - 80 - 22, 700 - 22), 80 + 22, 1150 - 700 + 22 + 22), true);
            
            // Petits cratères
            AjouterObstacle(new Cercle(new PointReel(650, 540), 126), true);
            AjouterObstacle(new Cercle(new PointReel(3000 - 650, 540), 126), true);

            AjouterObstacle(new Cercle(new PointReel(1070, 1870), 126), true);
            AjouterObstacle(new Cercle(new PointReel(3000 - 1070, 1870), 126), true);

            // Grands cratères
            AjouterObstacle(new Cercle(new PointReel(0, 2000), 510 + 30), true);
            AjouterObstacle(new Cercle(new PointReel(3000, 2000), 510 + 30), true);

            // Base de lancement
            AjouterObstacle(new Cercle(new PointReel(1500, 2000), 200), true);
            AjouterObstacle(new RectanglePolygone(new PointReel(1500 - 40 - 28, 2000 - 200 - 600), 28 * 2 + 80, 600), true);

            double cos45 = Math.Cos(45.0 / 180 * Math.PI);
            points.Clear();
            points.Add(new PointReel(1500 + cos45 * 800 - cos45 * 68, 2000 - cos45 * 800 - cos45 * 68));
            points.Add(new PointReel(1500 + cos45 * 200 - cos45 * 68, 2000 - cos45 * 200 - cos45 * 68));
            points.Add(new PointReel(1500 + cos45 * 200 + cos45 * 68, 2000 - cos45 * 200 + cos45 * 68));
            points.Add(new PointReel(1500 + cos45 * 800 + cos45 * 68, 2000 - cos45 * 800 + cos45 * 68));
            AjouterObstacle(new Polygone(points), true);

            points.Clear();
            points.Add(new PointReel(1500 - cos45 * 800 + cos45 * 68, 2000 - cos45 * 800 - cos45 * 68));
            points.Add(new PointReel(1500 - cos45 * 200 + cos45 * 68, 2000 - cos45 * 200 - cos45 * 68));
            points.Add(new PointReel(1500 - cos45 * 200 - cos45 * 68, 2000 - cos45 * 200 + cos45 * 68));
            points.Add(new PointReel(1500 - cos45 * 800 - cos45 * 68, 2000 - cos45 * 800 + cos45 * 68));
            AjouterObstacle(new Polygone(points), true);

            // Fusées
            AjouterObstacle(new Cercle(new PointReel(1150, 40), 40), true);
            AjouterObstacle(new Cercle(new PointReel(3000 - 1150, 40), 40), true);

            AjouterObstacle(new Cercle(new PointReel(40, 1350), 40), true);
            AjouterObstacle(new Cercle(new PointReel(3000 - 40, 1350), 40), true);

        }

        /// <summary>
        /// Teste si on point est contenu dans la table
        /// </summary>
        /// <param name="croisement">Point à tester</param>
        /// <returns></returns>
        public static bool Contient(PointReel point)
        {
            if (point.X < 0 || point.Y < 0 || point.X > LongueurPlateau || point.Y > LargeurPlateau)
                return false;

            return true;
        }
    }
}
