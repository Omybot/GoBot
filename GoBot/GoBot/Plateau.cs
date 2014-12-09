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

namespace GoBot
{
    public class Plateau
    {
        public static int RayonAdversaireInitial { get; set; }
        public static int RayonAdversaire { get; set; }

        public static Balise Balise1 { get; set; }
        public static Balise Balise2 { get; set; }
        public static Balise Balise3 { get; set; }
        public static InterpreteurBalise InterpreteurBalise { get; set; }

        public static Enchainement Enchainement { get; set; }
        public static Poids PoidActions { get; set; }

        public static List<IForme> ObstaclesFixes { get; set; }
        public static List<IForme> ObstaclesTemporaires { get; set; }
        public static PointReel PositionCibleGros { get; set; }
        public static PointReel PositionCiblePetit { get; set; }

        public static List<Clap> Claps { get; private set; }
        public static List<Pied> Pieds { get; private set; }
        public static List<DistributeurPopCorn> DistributeursPopCorn { get; private set; }

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
                    Robots.GrosRobot.Init();
                    Robots.PetitRobot.Init();
                    if (NotreCouleurChange != null)
                        NotreCouleurChange(null, null);
                }
            }
        }
        public static event EventHandler NotreCouleurChange;

        public static bool ReflecteursNosRobots { get; set; }

        public static IForme[] ObstaclesTorches { get; set; }

        private static int score;
        public static int Score
        {
            get { return score; }
            set { score = value; if (ScoreChange != null) ScoreChange(null, null); }
        }
        public static event EventHandler ScoreChange;

        /// <summary>
        /// Graph des noeuds et arcs pour le pathfinding
        /// </summary>
        //public static Graph GraphGros { get; private set; }
        //public static Graph GraphPetit { get; private set; }

        public static Color CouleurGaucheJaune { get { return Color.FromArgb(250, 210, 1); } }
        public static Color CouleurDroiteVert { get { return Color.FromArgb(87, 166, 57); } }

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
                toutObstacles.AddRange(ObstaclesFixes);
                toutObstacles.AddRange(ObstaclesTemporaires);
                return toutObstacles;
            }
        }

        public Plateau()
        {
            if (!Config.DesignMode)
            {
                RayonAdversaireInitial = 200;
                RayonAdversaire = RayonAdversaireInitial;

                ReflecteursNosRobots = true;

                ObstaclesTemporaires = new List<IForme>();

                ChargerObstacles();
                CreerSommets(150);
                SauverGraph();
                
                //ChargerGraph();

                InterpreteurBalise = new InterpreteurBalise();
                //InterpreteurBalise.PositionEnnemisActualisee += new InterpreteurBalise.PositionEnnemisDelegate(interpreteBalise_PositionEnnemisActualisee);
                SuiviBalise.PositionEnnemisActualisee += new Balises.SuiviBalise.PositionEnnemisDelegate(interpreteBalise_PositionEnnemisActualisee);

                // Initialiser les elements de jeu ici

                Claps = new List<Clap>();
                Claps.Add(new Clap(new PointReel(400 - 80, 2000 + 15), CouleurGaucheJaune));
                Claps.Add(new Clap(new PointReel(700 - 80, 2000 + 15), CouleurDroiteVert));
                Claps.Add(new Clap(new PointReel(1000 - 80, 2000 + 15), CouleurGaucheJaune));
                Claps.Add(new Clap(new PointReel(2000 + 80, 2000 + 15), CouleurDroiteVert));
                Claps.Add(new Clap(new PointReel(2300 + 80, 2000 + 15), CouleurGaucheJaune));
                Claps.Add(new Clap(new PointReel(2600 + 80, 2000 + 15), CouleurDroiteVert));

                Pieds = new List<Pied>();
                Pieds.Add(new Pied(new PointReel(90, 200), CouleurGaucheJaune));
                Pieds.Add(new Pied(new PointReel(90, 1750), CouleurGaucheJaune));
                Pieds.Add(new Pied(new PointReel(90, 1850), CouleurGaucheJaune));
                Pieds.Add(new Pied(new PointReel(850, 100), CouleurGaucheJaune));
                Pieds.Add(new Pied(new PointReel(850, 200), CouleurGaucheJaune));
                Pieds.Add(new Pied(new PointReel(870, 1355), CouleurGaucheJaune));
                Pieds.Add(new Pied(new PointReel(1100, 1770), CouleurGaucheJaune));
                Pieds.Add(new Pied(new PointReel(1300, 1400), CouleurGaucheJaune));
                Pieds.Add(new Pied(new PointReel(1700, 1400), CouleurDroiteVert));
                Pieds.Add(new Pied(new PointReel(1900, 1770), CouleurDroiteVert));
                Pieds.Add(new Pied(new PointReel(2130, 1355), CouleurDroiteVert));
                Pieds.Add(new Pied(new PointReel(2150, 200), CouleurDroiteVert));
                Pieds.Add(new Pied(new PointReel(2150, 100), CouleurDroiteVert));
                Pieds.Add(new Pied(new PointReel(2910, 1850), CouleurDroiteVert));
                Pieds.Add(new Pied(new PointReel(2910, 1750), CouleurDroiteVert));
                Pieds.Add(new Pied(new PointReel(2910, 200), CouleurDroiteVert));

                DistributeursPopCorn = new List<DistributeurPopCorn>();
                DistributeursPopCorn.Add(new DistributeurPopCorn(new PointReel(300, 35)));
                DistributeursPopCorn.Add(new DistributeurPopCorn(new PointReel(600, 35)));
                DistributeursPopCorn.Add(new DistributeurPopCorn(new PointReel(2400, 35)));
                DistributeursPopCorn.Add(new DistributeurPopCorn(new PointReel(2700, 35)));

                ElementsJeu = new List<ElementJeu>();

                for (int i = 0; i < Claps.Count; i++)
                    ElementsJeu.Add(Claps[i]);
                for (int i = 0; i < Pieds.Count; i++)
                    ElementsJeu.Add(Pieds[i]);
                for (int i = 0; i < DistributeursPopCorn.Count; i++)
                    ElementsJeu.Add(DistributeursPopCorn[i]);


                Random random = new Random();
                
                SemaphoreCollisions = new Semaphore(0, 999999999);
                thCollisions = new Thread(ThreadTestCollisions);
                thCollisions.Start();
            }
        }

        public static void Init()
        {
            Balise1 = new Balise(Carte.RecBun);
            Balise2 = new Balise(Carte.RecBeu);
            Balise3 = new Balise(Carte.RecBoi);

            PositionCiblePetit = Robots.PetitRobot.Position.Coordonnees;
            PositionCibleGros = Robots.GrosRobot.Position.Coordonnees;
        }

        private Semaphore SemaphoreCollisions { get; set; }
        private void ThreadTestCollisions()
        {
            while (!Config.Shutdown)
            {
                // Le timeout sur le Thread permet de vérifier chaque seconde si on est en train d'éteindre l'application pour couper le Thread.
                while (!SemaphoreCollisions.WaitOne(1000) && !Config.Shutdown) ;
                Robots.PetitRobot.ObstacleTest();
                Robots.GrosRobot.ObstacleTest();
            }
        }

        Thread thCollisions;
        public void ObstacleTest(int x, int y)
        {
            // Obstacle de simulation
            ObstaclesTemporaires.Clear();
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

        void interpreteBalise_PositionEnnemisActualisee()
        {
            // Position ennemie signalée
            ObstaclesTemporaires.Clear();

            int vitesseMax = Config.CurrentConfig.GRVitesseLigneRapide;

            for (int i = 0; i < SuiviBalise.PositionsEnnemies.Count; i++)
            {
                PointReel coordonnees = new PointReel(SuiviBalise.PositionsEnnemies[i].X, SuiviBalise.PositionsEnnemies[i].Y);
                AjouterObstacle(new Cercle(coordonnees, RayonAdversaire));

                if (Plateau.Enchainement == null)
                {
                    // Tester ici ce qu'il y a à tester en fonction de la position de l'ennemi AVANT de lancer le match
                }
                else
                {
                    // Tester ici ce qu'il y a à tester en fonction de la position de l'ennemi PENDANT le match
                    
                    double distanceAdv = Robots.GrosRobot.Position.Coordonnees.Distance(coordonnees);
                    if (distanceAdv < 1500)
                    {
                        vitesseMax = (int)(Math.Min(vitesseMax, (distanceAdv - 500) / 1000.0 * Config.CurrentConfig.GRVitesseLigneRapide));
                    }
                }
            }

            if (Plateau.Enchainement != null && (DateTime.Now - Plateau.Enchainement.DebutMatch).TotalSeconds > 10)
                Robots.GrosRobot.VitesseDeplacement = vitesseMax;

            SemaphoreCollisions.Release();
        }

        /// <summary>
        /// Vide les obstacles temporaires et rend tout le graph parcourable
        /// </summary>
        public static void ViderObstacles()
        {
            foreach (Robot robot in new List<Robot> { Robots.GrosRobot, Robots.PetitRobot })
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
                ObstaclesTemporaires.Clear();

            if (fixe)
                ObstaclesFixes.Add(obstacle);
            else
                ObstaclesTemporaires.Add(obstacle);
        }

        /// <summary>
        /// Sauve le graph pour une utilisation ultérieure
        /// </summary>
        public void SauverGraph()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Config.PathData + "/graphGros.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                formatter.Serialize(stream, Robots.GrosRobot.Graph);

            using (Stream stream = new FileStream(Config.PathData + "/graphPetit.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                formatter.Serialize(stream, Robots.PetitRobot.Graph);
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
        /// Charge le dernier graph sauvegardé. Permet de gagner du temps par rapport à une génération du graph à chaque execution.
        /// </summary>
        public static void ChargerGraphPetit()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(Config.PathData + "/graphPetit.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
                    Robots.PetitRobot.Graph = (Graph)formatter.Deserialize(stream);
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
                    Robots.GrosRobot.AddNode(Robots.GrosRobot.Graph, new Node(x, y, 0), Math.Sqrt(resolution * resolution * 2) + 1);

            Robots.PetitRobot.Graph = new Graph();

            // Création des noeuds
            for (int x = resolution / 2; x < LongueurPlateau; x += resolution)
                for (int y = resolution / 2; y < LargeurPlateau; y += resolution)
                    Robots.PetitRobot.AddNode(Robots.PetitRobot.Graph, new Node(x, y, 0), Math.Sqrt(resolution * resolution * 2) + 1);
        }

        public void ChargerObstacles()
        {
            ObstaclesFixes = new List<IForme>();
            List<PointReel> points = new List<PointReel>();

            // Contours du plateau
            AjouterObstacle(new Segment(new PointReel(0, 0), new PointReel(LongueurPlateau - 4, 0)), true);
            AjouterObstacle(new Segment(new PointReel(LongueurPlateau - 4, 0), new PointReel(LongueurPlateau - 4, LargeurPlateau - 4)), true);
            AjouterObstacle(new Segment(new PointReel(LongueurPlateau - 4, LargeurPlateau - 4), new PointReel(0, LargeurPlateau - 4)), true);
            AjouterObstacle(new Segment(new PointReel(0, LargeurPlateau - 4), new PointReel(0, 0)), true);

            // Escaliers
            AjouterObstacle(new RectanglePolygone(new PointReel(967, 0), 1066, 580), true);

            // Distributeurs
            AjouterObstacle(new RectanglePolygone(new PointReel(300-35, 0), 70, 70), true);
            AjouterObstacle(new RectanglePolygone(new PointReel(600-35, 0), 70, 70), true);
            AjouterObstacle(new RectanglePolygone(new PointReel(3000-300-35, 0), 70, 70), true);
            AjouterObstacle(new RectanglePolygone(new PointReel(3000 - 600 - 35, 0), 70, 70), true);

            // Zone départ jaune
            AjouterObstacle(new Segment(new PointReel(0, 800 - 11), new PointReel(400, 800 - 11)), true);
            AjouterObstacle(new Segment(new PointReel(0, 1211), new PointReel(400, 1211)), true);
            AjouterObstacle(new Segment(new PointReel(70 - 11, 800), new PointReel(70 - 11, 1200)), true);

            // Zone départ verte
            AjouterObstacle(new Segment(new PointReel(3000, 800 - 11), new PointReel(3000-400, 800 - 11)), true);
            AjouterObstacle(new Segment(new PointReel(3000, 1211), new PointReel(3000 - 400, 1211)), true);
            AjouterObstacle(new Segment(new PointReel(3000 - 70 + 11, 800), new PointReel(3000 - 70 + 11, 1200)), true);

            // Dépose centrale
            AjouterObstacle(new RectanglePolygone(new PointReel(1200, 1900), 600, 100), true);
        }

        /// <summary>
        /// Rend traversables tous les noeuds et arcs du graph
        /// </summary>
        internal void SupprimerObstacles()
        {
            foreach (Robot robot in new List<Robot> { Robots.GrosRobot, Robots.PetitRobot })
            {
                for (int i = 0; i < robot.Graph.Nodes.Count; i++)
                    ((Node)(robot.Graph.Nodes[i])).Passable = true;

                for (int i = 0; i < robot.Graph.Arcs.Count; i++)
                    ((Arc)(robot.Graph.Arcs[i])).Passable = true;
            }
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

        /// <summary>
        /// Recalle les balises en angle. Necessite qu'un réflecteur à deux étages soit au milieu de la piste
        /// </summary>
        public static void RecallageBalises()
        {
            Balise1.ReglerOffset(12);
            Balise2.ReglerOffset(12);
            Balise3.ReglerOffset(12);

            while (Balise1.ReglageOffset || Balise2.ReglageOffset || Balise3.ReglageOffset)
                Thread.Sleep(100);
        }
    }
}
