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

        private static Color notreCouleur;
        public static Color NotreCouleur
        {
            get { return notreCouleur; }
            set { notreCouleur = value; if (NotreCouleurChange != null) NotreCouleurChange(null, null); }
        }
        public static event EventHandler NotreCouleurChange;

        public static bool Simulation { get; set; }

        public static bool FresquesCollees { get; set; }
        public static bool LancesCollees { get; set; }
        public static bool FiletLance { get; set; }

        public static Feu[] Feux { get; set; }
        public static Fruimouth[] Fruimouths { get; set; }
        
        public static bool ReflecteursNosRobots { get; set; }

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

        public static Color CouleurJ1Rouge { get { return Color.FromArgb(189, 1, 2); } }
        public static Color CouleurJ2Jaune { get { return Color.FromArgb(202, 201, 0); } }

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
                ReflecteursNosRobots = true;
                FresquesCollees = false;
                LancesCollees = false;
                FiletLance = false;

                ObstaclesTemporaires = new List<IForme>();

                ChargerObstacles();
                CreerSommets(150);
                SauverGraph();
                //ChargerGraph();

                InterpreteurBalise = new InterpreteurBalise();
                //InterpreteurBalise.PositionEnnemisActualisee += new InterpreteurBalise.PositionEnnemisDelegate(interpreteBalise_PositionEnnemisActualisee);
                SuiviBalise.PositionEnnemisActualisee += new Balises.SuiviBalise.PositionEnnemisDelegate(interpreteBalise_PositionEnnemisActualisee);

                if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
                    Simulation = false;
                else
                    Simulation = true;

                NotreCouleur = Color.Red;

                Feux = new Feu[16];

                Feux[0] = new Feu(new PointReel(15, 800), Color.Black, true, 0);
                Feux[1] = new Feu(new PointReel(400, 1100), Color.Black, true, 90);
                Feux[2] = new Feu(new PointReel(900, 600), Color.Black, true, 0);
                Feux[3] = new Feu(new PointReel(900, 1100), Plateau.CouleurJ1Rouge, false, 0);
                Feux[4] = new Feu(new PointReel(900, 1100), Plateau.CouleurJ2Jaune, false, 0);
                Feux[5] = new Feu(new PointReel(900, 1100), Plateau.CouleurJ1Rouge, false, 0);
                Feux[6] = new Feu(new PointReel(900, 1600), Color.Black, true, 180);
                Feux[7] = new Feu(new PointReel(1300, 1985), Color.Black, true, 90);
                Feux[8] = new Feu(new PointReel(1700, 1985), Color.Black, true, 270);
                Feux[9] = new Feu(new PointReel(2100, 600), Color.Black, true, 0);
                Feux[10] = new Feu(new PointReel(2100, 1100), Plateau.CouleurJ2Jaune, false, 0);
                Feux[11] = new Feu(new PointReel(2100, 1100), Plateau.CouleurJ1Rouge, false, 0);
                Feux[12] = new Feu(new PointReel(2100, 1100), Plateau.CouleurJ2Jaune, false, 0);
                Feux[13] = new Feu(new PointReel(2100, 1600), Color.Black, true, 180);
                Feux[14] = new Feu(new PointReel(2600, 1100), Color.Black, true, 270);
                Feux[15] = new Feu(new PointReel(2985, 800), Color.Black, true, 0);

                Random random = new Random();
                Fruimouths = new Fruimouth[24];
                // Arbre 1
                int rand = random.Next(6);
                Fruimouths[0] = new Fruimouth(new PointReel(0, 1180), rand < 1);
                Fruimouths[1] = new Fruimouth(new PointReel(103.92, 1240), rand >= 1 && rand < 2);
                Fruimouths[2] = new Fruimouth(new PointReel(103.92, 1360), rand >= 2 && rand < 3);
                Fruimouths[3] = new Fruimouth(new PointReel(0, 1420), rand >= 3 && rand < 4);
                Fruimouths[4] = new Fruimouth(new PointReel(-103.92, 1360), rand >= 4 && rand < 5);
                Fruimouths[5] = new Fruimouth(new PointReel(-103.92, 1240), rand >= 5 && rand < 6);
                // Arbre 2
                rand = random.Next(6);
                Fruimouths[6] = new Fruimouth(new PointReel(640, 1896.08), rand < 1);
                Fruimouths[7] = new Fruimouth(new PointReel(760, 1896.08), rand >= 1 && rand < 2);
                Fruimouths[8] = new Fruimouth(new PointReel(820, 2000), rand >= 2 && rand < 3);
                Fruimouths[9] = new Fruimouth(new PointReel(760, 2103.92), rand >= 3 && rand < 4);
                Fruimouths[10] = new Fruimouth(new PointReel(640, 2103.92), rand >= 4 && rand < 5);
                Fruimouths[11] = new Fruimouth(new PointReel(580, 2000), rand >= 5 && rand < 6);
                // Arbre 3
                rand = random.Next(6);
                Fruimouths[12] = new Fruimouth(new PointReel(2240, 1896.08), rand < 1);
                Fruimouths[13] = new Fruimouth(new PointReel(2360, 1896.08), rand >= 1 && rand < 2);
                Fruimouths[14] = new Fruimouth(new PointReel(2420, 2000), rand >= 2 && rand < 3);
                Fruimouths[15] = new Fruimouth(new PointReel(2360, 2103.92), rand >= 3 && rand < 4);
                Fruimouths[16] = new Fruimouth(new PointReel(2240, 2103.92), rand >= 4 && rand < 5);
                Fruimouths[17] = new Fruimouth(new PointReel(2180, 2000), rand >= 5 && rand < 6);
                // Arbre 4
                rand = random.Next(6);
                Fruimouths[18] = new Fruimouth(new PointReel(3000, 1180), rand < 1);
                Fruimouths[19] = new Fruimouth(new PointReel(3103.92, 1240), rand >= 1 && rand < 2);
                Fruimouths[20] = new Fruimouth(new PointReel(3103.92, 1360), rand >= 2 && rand < 3);
                Fruimouths[21] = new Fruimouth(new PointReel(3000, 1420), rand >= 3 && rand < 4);
                Fruimouths[22] = new Fruimouth(new PointReel(2896.08, 1360), rand >= 4 && rand < 5);
                Fruimouths[23] = new Fruimouth(new PointReel(2896.08, 1240), rand >= 5 && rand < 6);

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
            while (true)
            {
                SemaphoreCollisions.WaitOne();
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

            for (int i = 0; i < SuiviBalise.PositionsEnnemies.Count; i++)
            {
                PointReel coordonnees = new PointReel(SuiviBalise.PositionsEnnemies[i].X, SuiviBalise.PositionsEnnemies[i].Y);
                AjouterObstacle(new Cercle(coordonnees, 200));

                if (Plateau.Enchainement == null)
                {
                    // Tester ici ce qu'il y a à tester en fonction de la position de l'ennemi AVANT de lancer le match
                }
                else
                {
                    // Tester ici ce qu'il y a à tester en fonction de la position de l'ennemi PENDANT le match
                }
            }

            SemaphoreCollisions.Release();
        }

        /// <summary>
        /// Vide les obstacles temporaires et rend tout le graph parcourable
        /// </summary>
        public static void ViderObstacles()
        {
            foreach(Robot robot in new List<Robot>{Robots.GrosRobot, Robots.PetitRobot})
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
            using (Stream stream = new FileStream("graphGros.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                formatter.Serialize(stream, Robots.GrosRobot.Graph);

            using (Stream stream = new FileStream("graphPetit.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
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
                using (Stream stream = new FileStream("graphGros.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
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
                using (Stream stream = new FileStream("graphPetit.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
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

            // Panier 1
            points.Clear();
            points.Add(new PointReel(400, 0));
            points.Add(new PointReel(1100, 0));
            points.Add(new PointReel(1100, 300));
            points.Add(new PointReel(400, 300));
            AjouterObstacle(new Polygone(points), true);

            // Panier 1
            points.Clear();
            points.Add(new PointReel(1900, 0));
            points.Add(new PointReel(2600, 0));
            points.Add(new PointReel(2600, 300));
            points.Add(new PointReel(1900, 300));
            AjouterObstacle(new Polygone(points), true);

            // Foyer central
            AjouterObstacle(new Cercle(new PointReel(1500, 1050), 150), true);

            // Foyer coin 1
            AjouterObstacle(new Cercle(new PointReel(0, 2000), 250), true);

            // Foyer coin 2
            AjouterObstacle(new Cercle(new PointReel(3000, 2000), 250), true);
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
