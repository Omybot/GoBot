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

namespace GoBot
{
    public class Plateau
    {
        public static Balise Balise1 { get; set; }
        public static Balise Balise2 { get; set; }
        public static Balise Balise3 { get; set; }
        public static InterpreteurBalise InterpreteurBalise { get; set; }
        public static bool Degommage { get; set; }

        public static Enchainement Enchainement { get; set; }
        public static Poids PoidActions { get; set; }

        private static List<IForme> ObstaclesFixes { get; set; }
        public static List<IForme> ObstaclesTemporaires { get; set; }

        public static int DerniereBougieGros { get; set; }

        private static Color notreCouleur;
        public static Color NotreCouleur 
        {
            get { return notreCouleur; }
            set { notreCouleur = value; if(NotreCouleurChange != null) NotreCouleurChange(null, null); }
        }
        public static event EventHandler NotreCouleurChange;

        public static bool Simulation { get; set; }

        public static DateTime DateBalle;
        public static Color CouleurBalleLancee;
        public static int NbBallesMarquees { get; set; }

        public static Color[] CouleursBougies { get; set; }

        public static PointReel[] PositionsBougies { get; set; }
        public static bool[] BougiesEnfoncees { get; set; }
        public static PointReel[] PositionsCadeaux { get; set; }
        public static bool[] CadeauxActives { get; set; }
        public static Position[] PositionsAssiettes { get; set; }
        public static bool[] AssiettesVidees { get; set; }
        public static bool[] AssiettesExiste { get; set; }

        public static int AssietteAttrapee { get; set; }

        public static bool ReflecteursNosRobots { get; set; }

        private static int score;
        public static int Score
        {
            get { return score; }
            set { score = value; if (ScoreChange != null) ScoreChange(null, null); }
        }
        public static event EventHandler ScoreChange;

        /// <summary>
        /// Sémaphore à verrouiller pendant la manipulation du graph du pathfinding pour éviter les modification pendant énumération entre autres
        /// </summary>
        public static Semaphore SemaphoreGraph { get; private set; }

        public static Color CouleurJ1R { get { return Color.FromArgb(165, 32, 25); } }
        public static Color CouleurJ2B { get { return Color.FromArgb(6, 57, 113); } }

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
                NbBallesMarquees = 0;
                Degommage = false;
                ReflecteursNosRobots = true;
                DerniereBougieGros = -1;
                AssietteAttrapee = -1;
                Plateau.SemaphoreGraph = new Semaphore(1, 1);

                //CreerSommets(150);
                ChargerGraph();
                ChargerObstacles();

                ObstaclesTemporaires = new List<IForme>();

                InterpreteurBalise = new InterpreteurBalise();
                InterpreteurBalise.PositionEnnemisActualisee += new GoBot.InterpreteurBalise.PositionEnnemisDelegate(interpreteBalise_PositionEnnemisActualisee);


                if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
                    Simulation = false;
                else
                    Simulation = true;

                CouleursBougies = new Color[20];
                for (int i = 0; i < 20; i++)
                    CouleursBougies[i] = Color.White;

                NotreCouleur = Color.Red;

                PositionsBougies = new PointReel[20];

                PositionsBougies[0] = new PointReel(1845, 68);
                PositionsBougies[1] = new PointReel(1946, 59);
                PositionsBougies[2] = new PointReel(1791, 194);
                PositionsBougies[3] = new PointReel(1916, 172);
                PositionsBougies[4] = new PointReel(1694, 291);
                PositionsBougies[5] = new PointReel(1857, 274);
                PositionsBougies[6] = new PointReel(1774, 357);
                PositionsBougies[7] = new PointReel(1672, 416);
                PositionsBougies[8] = new PointReel(1568, 343);
                PositionsBougies[9] = new PointReel(1559, 446);

                PositionsBougies[10] = new PointReel(1157, 68);
                PositionsBougies[11] = new PointReel(1054, 59);
                PositionsBougies[12] = new PointReel(1209, 194);
                PositionsBougies[13] = new PointReel(1084, 172);
                PositionsBougies[14] = new PointReel(1306, 291);
                PositionsBougies[15] = new PointReel(1143, 274);
                PositionsBougies[16] = new PointReel(1226, 357);
                PositionsBougies[17] = new PointReel(1328, 416);
                PositionsBougies[18] = new PointReel(1432, 343);
                PositionsBougies[19] = new PointReel(1441, 446);

                BougiesEnfoncees = new bool[20];
                for (int i = 0; i < 20; i++)
                    BougiesEnfoncees[i] = false;

                PositionsCadeaux = new PointReel[8];
                PositionsCadeaux[0] = new PointReel(600 - 86, 2000);
                PositionsCadeaux[1] = new PointReel(600 + 86, 2000);
                PositionsCadeaux[2] = new PointReel(1200 - 86, 2000);
                PositionsCadeaux[3] = new PointReel(1200 + 86, 2000);
                PositionsCadeaux[4] = new PointReel(1800 - 86, 2000);
                PositionsCadeaux[5] = new PointReel(1800 + 86, 2000);
                PositionsCadeaux[6] = new PointReel(2400 - 86, 2000);
                PositionsCadeaux[7] = new PointReel(2400 + 86, 2000);

                CadeauxActives = new bool[8];
                for (int i = 0; i < 8; i++)
                    CadeauxActives[i] = false;

                Random r = new Random(DateTime.Now.Millisecond);
                PositionsAssiettes = new Position[10];
                PositionsAssiettes[0] = new Position(new Angle(r.Next(4) * 90), new PointReel(200, 250));
                PositionsAssiettes[1] = new Position(new Angle(r.Next(4) * 90), new PointReel(200, 600));
                PositionsAssiettes[2] = new Position(new Angle(r.Next(4) * 90), new PointReel(200, 1000));
                PositionsAssiettes[3] = new Position(new Angle(r.Next(4) * 90), new PointReel(200, 1400));
                PositionsAssiettes[4] = new Position(new Angle(r.Next(4) * 90), new PointReel(200, 1750));
                PositionsAssiettes[5] = new Position(new Angle(r.Next(4) * 90), new PointReel(2800, 250));
                PositionsAssiettes[6] = new Position(new Angle(r.Next(4) * 90), new PointReel(2800, 600));
                PositionsAssiettes[7] = new Position(new Angle(r.Next(4) * 90), new PointReel(2800, 1000));
                PositionsAssiettes[8] = new Position(new Angle(r.Next(4) * 90), new PointReel(2800, 1400));
                PositionsAssiettes[9] = new Position(new Angle(r.Next(4) * 90), new PointReel(2800, 1750));

                AssiettesExiste = new bool[10];
                for (int i = 0; i < 10; i++)
                    AssiettesExiste[i] = true;

                AssiettesVidees = new bool[10];
                for (int i = 0; i < 10; i++)
                    AssiettesVidees[i] = false;
            }
        }

        public static void Init()
        {
            Balise1 = new Balise(Carte.RecBun);
            Balise2 = new Balise(Carte.RecBeu);
            Balise3 = new Balise(Carte.RecBoi);
        }

        public void ObstacleTest(int x, int y)
        {
            SemaphoreGraph.WaitOne();
            ViderObstacles();
            PointReel coordonnees = new PointReel(x, y);
            AjouterObstacle(new Cercle(coordonnees, 200));
            SemaphoreGraph.Release();

            // Avant de lancer le match
            if(Plateau.Enchainement == null)
            for (int i = 0; i < 10; i++)
            {
                if (PositionsAssiettes[i].Coordonnees.Distance(coordonnees) < 250)
                    AssiettesExiste[i] = false;
            }
            // Une fois le match lancé
            for (int i = 0; i < 10; i++)
            {
                if (PositionsAssiettes[i].Coordonnees.Distance(coordonnees) < 250)
                    AssiettesVidees[i] = true;
            }

            Robots.PetitRobot.ObstacleTest();
            Robots.GrosRobot.ObstacleTest();
        }

        void interpreteBalise_PositionEnnemisActualisee(InterpreteurBalise interprete)
        {
            SemaphoreGraph.WaitOne();
            ViderObstacles();
            for (int i = 0; i < interprete.PositionsEnnemies.Count; i++)
            {
                PointReel coordonnees = new PointReel(interprete.PositionsEnnemies[i].X, interprete.PositionsEnnemies[i].Y);
                AjouterObstacle(new Cercle(coordonnees, 200));

                // Avant de lancer le match
                if (Plateau.Enchainement == null)
                    for (int iAssiette = 0; iAssiette < 10; iAssiette++)
                    {
                        if (PositionsAssiettes[iAssiette].Coordonnees.Distance(coordonnees) < 250)
                            AssiettesExiste[iAssiette] = false;
                    }
                // Une fois le match lancé
                for (int iAssiette = 0; iAssiette < 10; iAssiette++)
                {
                    if (PositionsAssiettes[iAssiette].Coordonnees.Distance(coordonnees) < 250)
                        AssiettesVidees[iAssiette] = true;
                }
            }
            SemaphoreGraph.Release();

            Robots.PetitRobot.ObstacleTest();
            Robots.GrosRobot.ObstacleTest();
        }

        /// <summary>
        /// Vide les obstacles temporaires et rend tout le graph parcourable
        /// </summary>
        public void ViderObstacles()
        {
            ObstaclesTemporaires.Clear();
            for (int i = 0; i < Graph.Arcs.Count; i++)
                ((Arc)Graph.Arcs[i]).Passable = true;
            for (int i = 0; i < Graph.Nodes.Count; i++)
                ((Node)Graph.Nodes[i]).Passable = true;
        }

        /// <summary>
        /// Ajoute un obstacle et teste les endroits du graph qui ne sont plus franchissables
        /// </summary>
        /// <param name="obstacle">Forme de l'obstacle</param>
        /// <param name="fixe">Si l'obstacle est fixe, on supprime complètement les noeuds et arcs non franchissables. Sinon on les rends non franchissables temporairement.</param>
        public static void AjouterObstacle(IForme obstacle, bool fixe = false)
        {
            DateTime debut = DateTime.Now;

            if (fixe)
                ObstaclesFixes.Add(obstacle);
            else
                ObstaclesTemporaires.Add(obstacle);

            // Teste les arcs non franchissables
            for (int i = 0; i < Graph.Arcs.Count; i++)
            {
                Arc arc = (Arc)Graph.Arcs[i];

                if (arc.Passable)
                {
                    Segment segment = new Segment(new PointReel(arc.StartNode.X, arc.StartNode.Y), new PointReel(arc.EndNode.X, arc.EndNode.Y));
                    if (Robots.GrosRobot.TropProche(obstacle, segment))
                    {
                        if (fixe)
                        {
                            Graph.RemoveArc(i);
                            i--;
                        }
                        else
                            arc.Passable = false;
                    }
                }
            }

            // Teste les noeuds non franchissables
            for (int i = 0; i < Graph.Nodes.Count; i++)
            {
                Node n = (Node)Graph.Nodes[i];

                if (n.Passable)
                {
                    PointReel noeud = new PointReel(n.X, n.Y);
                    if (Robots.GrosRobot.TropProche(obstacle, noeud))
                    {
                        if (fixe)
                        {
                            Graph.RemoveNode(i);
                            i--;
                        }
                        else
                            n.Passable = false;

                    }
                }
            }
        }

        /// <summary>
        /// Sauve le graph pour une utilisation ultérieure
        /// </summary>
        public void SauverGraph()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("graph.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Graph);
            stream.Close();
        }

        /// <summary>
        /// Charge le dernier graph sauvegardé. Permet de gagner du temps par rapport à une génération du graph à chaque execution.
        /// </summary>
        public static void ChargerGraph()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("graph.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Graph = (Graph)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Impossible de charger le graph." + Environment.NewLine + e.Message);
            }
        }


        /// <summary>
        /// Graph des noeuds et arcs pour le pathfinding
        /// </summary>
        public static Graph Graph { get; private set; }

        /// <summary>
        /// Crée le graph du pathfinding.
        /// </summary>
        /// <param name="resolution">Distance (mm) entre chaque noeud du graph en X et Y</param>
        /// <param name="distanceLiaison">Distance (mm) jusqu'à laquelle les noeuds sont reliés par un arc. Par défaut on crée un graph minimal (liaison aux 8 points alentours : N/S/E/O/NE/NO/SE/SO)</param>
        private void CreerSommets(int resolution, double distanceLiaison = -1)
        {
            if (distanceLiaison == -1)
                distanceLiaison = Math.Sqrt((resolution * resolution) * 2) + 1;

            Graph = new Graph();

            // Création des noeuds
            for (int x = 0; x < LongueurPlateau; x += resolution)
                for (int y = 0; y < LargeurPlateau; y += resolution)
                    Graph.AddNode(x, y, 0);

            // Création des arcs
            foreach (Node node1 in Graph.Nodes)
                foreach (Node node2 in Graph.Nodes)
                {
                    if (node1 != node2)
                    {
                        double distance = Math.Sqrt((node1.Position.X - node2.Position.X) * (node1.Position.X - node2.Position.X) + (node1.Position.Y - node2.Position.Y) * (node1.Position.Y - node2.Position.Y));
                        if (distance < distanceLiaison)
                        {
                            Arc b = new Arc(node2, node1);
                            b.Weight = Math.Sqrt(distance);
                            Graph.AddArc(b);
                        }
                    }
                }
        }

        public void ChargerObstacles()
        {
            ObstaclesFixes = new List<IForme>();

            // Contours du plateau
            AjouterObstacle(new Calculs.Formes.Segment(new PointReel(0, 0), new PointReel(LongueurPlateau - 4, 0)), true);
            AjouterObstacle(new Calculs.Formes.Segment(new PointReel(LongueurPlateau - 4, 0), new PointReel(LongueurPlateau - 4, LargeurPlateau - 4)), true);
            AjouterObstacle(new Calculs.Formes.Segment(new PointReel(LongueurPlateau - 4, LargeurPlateau - 4), new PointReel(0, LargeurPlateau - 4)), true);
            AjouterObstacle(new Calculs.Formes.Segment(new PointReel(0, LargeurPlateau - 4), new PointReel(0, 0)), true);

            // Gateau
            AjouterObstacle(new Cercle(new PointReel(1500, 0), 500), true);

            // Coins surélevés
            List<PointReel> points = new List<PointReel>();

            points.Add(new PointReel(0, 0.1));
            points.Add(new PointReel(400, 0));
            points.Add(new PointReel(400, 100));
            points.Add(new PointReel(0, 100));
            AjouterObstacle(new Polygone(points), true);

            points.Clear();
            points.Add(new PointReel(0, 1900));
            points.Add(new PointReel(400, 1900));
            points.Add(new PointReel(400, 2000));
            points.Add(new PointReel(0, 2000));
            AjouterObstacle(new Polygone(points), true);

            points.Clear();
            points.Add(new PointReel(2600, 1900));
            points.Add(new PointReel(3000, 1900));
            points.Add(new PointReel(3000, 2000));
            points.Add(new PointReel(2600, 2000));
            AjouterObstacle(new Polygone(points), true);

            points.Clear();
            points.Add(new PointReel(2600, 0));
            points.Add(new PointReel(3000, 0));
            points.Add(new PointReel(3000, 100));
            points.Add(new PointReel(2600, 100));
            AjouterObstacle(new Polygone(points), true);
        }

        /// <summary>
        /// Ajoute un noeud au graph en reliant tous les points à une distance maximale
        /// </summary>
        /// <param name="node">Noeud à ajouter</param>
        /// <param name="distanceMax">Distance (mm) max de liaison avec les autres noeuds</param>
        public static void AddNode(Node node, Robot robot, int distanceMax = 400)
        {
            double distanceNode;

            // Si un noeud est deja présent à cet endroit on ne l'ajoute pas
            Graph.ClosestNode(node.X, node.Y, node.Z, out distanceNode, true);
            if (distanceNode == 0)
                return;

            // Teste si le noeud est franchissable avec la liste des obstacles
            foreach (IForme obstacle in ObstaclesFixes)
            {
                if (obstacle.contient(new PointReel(node.X, node.Y)))
                {
                    node.Passable = false;
                    return;
                }
            }

            Graph.Nodes.Add(node);

            // Liaisons avec les autres noeuds du graph
            foreach (Node no in Graph.Nodes)
            {
                if (node != no)
                {
                    double distance = Math.Sqrt((node.Position.X - no.Position.X) * (node.Position.X - no.Position.X) + (node.Position.Y - no.Position.Y) * (node.Position.Y - no.Position.Y));
                    if (distance < distanceMax)
                    {
                        Arc arc = new Arc(no, node);
                        arc.Weight = Math.Sqrt(distance);
                        Arc arc2 = new Arc(node, no);
                        arc2.Weight = Math.Sqrt(distance);

                        foreach (IForme obstacle in ListeObstacles)
                        {
                            if (obstacle.Distance(new Segment(new PointReel(no.X, no.Y), new PointReel(node.X, node.Y))) < robot.Taille / 2)
                            {
                                arc.Passable = false;
                                arc2.Passable = false;
                                break;
                            }
                        }

                        if (arc.Passable)
                        {
                            Graph.AddArc(arc);
                            Graph.AddArc(arc2);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Rend traversables tous les noeuds et arcs du graph
        /// </summary>
        internal void SupprimerObstacles()
        {
            for (int i = 0; i < Graph.Nodes.Count; i++)
                ((Node)(Graph.Nodes[i])).Passable = true;

            for (int i = 0; i < Graph.Arcs.Count; i++)
                ((Arc)(Graph.Arcs[i])).Passable = true;
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

        public static void BaisserBras()
        {
            if (DerniereBougieGros != -1)
            {
                Robots.GrosRobot.Historique.Log("Fermeture des bras : fin des bougies");
                Robots.GrosRobot.PositionerAngle(new Angle(PositionsMouvements.PositionGrosBougie[DerniereBougieGros].Angle.AngleDegres + 90), 10);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasRange);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasRange);
                DerniereBougieGros = -1;
            }
        }
    }
}
