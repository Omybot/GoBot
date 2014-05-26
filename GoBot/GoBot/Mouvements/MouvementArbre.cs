using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using System.Threading;
using GoBot.Actionneur;

namespace GoBot.Mouvements
{
    class MouvementArbre : Mouvement
    {
        private int numeroArbre;
        private bool vide = false;

        public MouvementArbre(int i)
        {
            numeroArbre = i;
            Positions.Add(PositionsMouvements.PositionArbres[i]);
            Robot = Robots.GrosRobot;
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début arbre " + numeroArbre);

            Position position = PositionProche;

            if (Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRCanonPuissance, true);
                DateTime debut = DateTime.Now;

                if (numeroArbre == 1)
                {
                    Servomoteur servoEpaule = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFruitsEpaule, 0);
                    Servomoteur servoCoude = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFruitsCoude, 0);

                    servoCoude.VitesseMax = 200;
                    servoEpaule.VitesseMax = 200;

                    CanonFruits.Baisser();

                    BrasFruits.OuvrirPinceHaut(false);
                    BrasFruits.OuvrirPinceBas(false);

                    /* COnfig en 30sec
                    BrasFruits.PositionCoude(105);
                    Thread.Sleep(500);
                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Reculer(36);
                    Robots.GrosRobot.Rapide();
                    BrasFruits.FermerPinceHaut();
                    Robots.GrosRobot.Avancer(36);

                    BrasFruits.PositionDeposeBouchon();
                    BrasFruits.PositionCoude(140);
                    Thread.Sleep(1000);
                    BrasFruits.BouchonHautBas();
                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();
                    BrasFruits.PositionCoude(140);
                    Thread.Sleep(300);

                    BrasFruits.FermerPinceHaut(false);
                    BrasFruits.FermerPinceBas(false);
                    BrasFruits.PositionEpaule(0);
                    BrasFruits.PositionCoude(90);
                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceHaut(false);
                    BrasFruits.OuvrirPinceBas(false);

                    Robots.GrosRobot.Reculer(124);
                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Reculer(7);
                    Robots.GrosRobot.Rapide();

                    BrasFruits.FermerPinceBas();
                    Robots.GrosRobot.Reculer(49);

                    BrasFruits.PositionCoude(105);
                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceHaut(false);

                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Reculer(45);
                    BrasFruits.FermerPinceHaut();
                    Robots.GrosRobot.Rapide();
                    Thread.Sleep(1000);

                    Robots.GrosRobot.Avancer(239);

                    BrasFruits.PositionDeposeBouchon();
                    BrasFruits.PositionCoude(140);

                    Robots.GrosRobot.PivotDroite(60);
                    Thread.Sleep(500);

                    CanonFruits.PousseBouchon();
                    CanonFruits.Tirer();

                    BrasFruits.PositionDeposeBouchon();

                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();

                    BrasFruits.PositionCoude(140);

                    Thread.Sleep(200);
                    CanonFruits.PousseBouchon();
                    CanonFruits.Tirer();

                    BrasFruits.BouchonHautBas();

                    BrasFruits.PositionDeposeBouchon();

                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();
                    BrasFruits.PositionCoude(140);

                    Thread.Sleep(200);

                    CanonFruits.PousseBouchon();
                    CanonFruits.Tirer();*/



                    /*BrasFruits.PositionEpaule(0);
                    BrasFruits.PositionCoude(105);

                    Thread.Sleep(1000);

                    Robots.GrosRobot.Reculer(60);

                    BrasFruits.FermerPinceHaut();
                    Thread.Sleep(1000);
                    Robots.GrosRobot.Avancer(60);
                    Thread.Sleep(1000);
                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);
                    BrasFruits.BouchonHautBas();
                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();
                    Thread.Sleep(1000);

                    BrasFruits.PositionEpaule(0);
                    BrasFruits.PositionCoude(90);
                    Thread.Sleep(1000);

                    Robots.GrosRobot.Reculer(170);

                    BrasFruits.FermerPinceBas();
                    Thread.Sleep(1000);

                    BrasFruits.PositionCoude(90);
                    Thread.Sleep(1000);
                    Robots.GrosRobot.Reculer(70);
                    Robots.GrosRobot.PivotDroite(10);
                    Thread.Sleep(1000);
                    BrasFruits.FermerPinceHaut();
                    Thread.Sleep(1000);
                    Robots.GrosRobot.PivotGauche(10);
                    Robots.GrosRobot.Avancer(240);

                    BrasFruits.PositionDeposeBouchon();
                    BrasFruits.PositionCoude(140);

                    Robots.GrosRobot.PivotDroite(60);

                    CanonFruits.PousseBouchon();
                    Thread.Sleep(1000);
                    CanonFruits.Tirer();
                    Thread.Sleep(1000);

                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();
                    Thread.Sleep(1000);
                    BrasFruits.PositionCoude(140);
                    Thread.Sleep(1000);
                    CanonFruits.PousseBouchon();
                    Thread.Sleep(1000);
                    CanonFruits.Tirer();
                    Thread.Sleep(1000);
                    BrasFruits.BouchonHautBas();
                    Thread.Sleep(1000);


                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();
                    Thread.Sleep(1000);
                    BrasFruits.PositionCoude(140);
                    Thread.Sleep(1000);
                    CanonFruits.PousseBouchon();
                    Thread.Sleep(1000);
                    CanonFruits.Tirer();
                    */

                    /* Config 60° 19sec
                    CanonFruits.Baisser();

                    BrasFruits.PositionEpaule(5);
                    BrasFruits.PositionCoude(90.58);
                    Thread.Sleep(500);
                    BrasFruits.OuvrirPinceBas(false);
                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Reculer(166);

                    BrasFruits.FermerPinceBas();
                    Robots.GrosRobot.Rapide();

                    Robots.GrosRobot.Avancer(90);
                    BrasFruits.PositionCoude(116.81);
                    BrasFruits.OuvrirPinceHaut(false);
                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Reculer(65);

                    BrasFruits.FermerPinceHaut();

                    Robots.GrosRobot.Rapide();

                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);

                    BrasFruits.OuvrirPinceBas();
                    BrasFruits.PositionCoude(140);
                    Thread.Sleep(300);

                    CanonFruits.PousseBouchon();

                    BrasFruits.BouchonHautBas();

                    Robots.GrosRobot.PivotDroite(16);
                    CanonFruits.Tirer();

                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(500);

                    BrasFruits.OuvrirPinceBas();
                    BrasFruits.PositionCoude(140);
                    Thread.Sleep(300);

                    CanonFruits.PousseBouchon();

                    CanonFruits.Tirer();
                    Robots.GrosRobot.PivotGauche(16);

                    BrasFruits.FermerPinceHaut(false);
                    BrasFruits.FermerPinceBas(false);

                    BrasFruits.PositionCoude(110.6);
                    BrasFruits.PositionEpaule(22.35);

                    Thread.Sleep(500);
                    BrasFruits.OuvrirPinceHaut(false);
                    BrasFruits.OuvrirPinceBas();

                    BrasFruits.PositionCoude(87.04);
                    BrasFruits.PositionEpaule(50.29);

                    Thread.Sleep(500);

                    BrasFruits.FermerPinceBas();

                    Robots.GrosRobot.BougeServo(ServomoteurID.GRCanonInclinaison, 600);

                    BrasFruits.PositionDeposeBouchon();

                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();

                    BrasFruits.PositionCoude(140);
                    CanonFruits.PousseBouchon();

                    Robots.GrosRobot.PivotDroite(16);
                    CanonFruits.Tirer();
                    Robots.GrosRobot.PivotGauche(16);
                     * */

                    // Attrapage fruit 1
                    BrasFruits.OuvrirPinceBas(false);
                    BrasFruits.OuvrirPinceHaut(false);
                    BrasFruits.PositionCoude(134.66);
                    Thread.Sleep(500);
                    Robots.GrosRobot.Reculer(77);
                    BrasFruits.FermerPinceHaut();
                    // Dépose fruit 1
                    Robots.GrosRobot.Avancer(77);
                    BrasFruits.BouchonHautBas();
                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();
                    Thread.Sleep(1000);
                    BrasFruits.PositionEpaule(0);
                    BrasFruits.PositionCoude(104.93);
                    CanonFruits.PousseBouchon();
                    CanonFruits.Tirer();

                    // Attapage fruit 2
                    Robots.GrosRobot.Reculer(51);
                    BrasFruits.PositionCoude(101.48);
                    Thread.Sleep(500);
                    BrasFruits.FermerPinceBas();

                    // Attrapage fruit 3
                    BrasFruits.PositionCoude(92.74);
                    Thread.Sleep(500);
                    Robots.GrosRobot.Reculer(110);
                    BrasFruits.FermerPinceHaut();

                    // Tirs
                    Robots.GrosRobot.Avancer(100);
                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);

                    // Tir bouchon 2
                    BrasFruits.OuvrirPinceBas();
                    Thread.Sleep(1000);
                    BrasFruits.PositionCoude(140);
                    Thread.Sleep(200);
                    CanonFruits.PousseBouchon();
                    CanonFruits.Tirer();
                    BrasFruits.BouchonHautBas();

                    // Tir bouchon 3
                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();
                    Thread.Sleep(1000);
                    BrasFruits.PositionCoude(140);
                    Thread.Sleep(200);
                    CanonFruits.PousseBouchon();
                    CanonFruits.Tirer();
                    vide = true;

                    Console.WriteLine((DateTime.Now - debut).TotalSeconds + " ms");
                    Robots.GrosRobot.Historique.Log("Fin arbre " + numeroArbre + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                }

                Plateau.ArbresVides[numeroArbre] = true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation arbre " + numeroArbre);
                return false;
            }
            return true;
        }

        public override int Score
        {
            get { return Plateau.ArbresVides[numeroArbre] ? 0 : 5; }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
    }
}
