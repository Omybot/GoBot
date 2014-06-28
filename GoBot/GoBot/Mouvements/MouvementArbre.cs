using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using System.Threading;
using GoBot.Actionneurs;

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

                //if (numeroArbre == 1 || numeroArbre == 2)
                {
                    Servomoteur servoEpaule = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFruitsEpaule, 0);
                    Servomoteur servoCoude = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFruitsCoude, 0);

                    servoCoude.VitesseMax = 200;
                    servoEpaule.VitesseMax = 200;

                    CanonFruits.Baisser();

                    //initialiser le bras
                    BrasFruits.PositionRange();
                    BrasFeux.PositionInterne3();
                    /*BrasFruits.FermerPinceBas(false);
                    BrasFruits.FermerPinceHaut(false);
                    Thread.Sleep(500);
#endif

                    BrasFruits.OuvrirPinceHaut(false);
                    BrasFruits.OuvrirPinceBas(false);*/

                    // Attrapage fruit 1

                    CanonFruits.Armer();

                    BrasFruits.OuvrirPinceBas(false);
                    BrasFruits.OuvrirPinceHaut(true);
                    BrasFruits.PositionCoude(134.66);
                    Thread.Sleep(500);
                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Reculer(77);
                    Robots.GrosRobot.Rapide();
                    BrasFruits.FermerPinceHaut();
                    // Dépose fruit 1
                    Robots.GrosRobot.Avancer(77);
                    //Thread.Sleep(500);
#if false
                    BrasFruits.BouchonHautBas();
                    Thread.Sleep(500);
                    BrasFruits.PositionDeposeBouchon();
#else //kudo
                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);
                    BrasFruits.BouchonHautBas();
#endif
                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();
                    Thread.Sleep(1000);
                    BrasFruits.PositionEpaule(0);
#if false
                    BrasFruits.PositionCoude(104.93);
#else
                    BrasFruits.PositionCoude(130);
#endif
                    CanonFruits.PousseBouchon();
#if false
                    CanonFruits.Tirer();
#else
                    CanonFruits.Monter();

                    if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                        Robots.GrosRobot.PivotGauche(29.19);

                    Thread.Sleep(200);
                    CanonFruits.Tirer();
                    CanonFruits.Baisser();

                    if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                        Robots.GrosRobot.PivotDroite(29.19);
#endif
                    // Attapage fruit 2

#if true
                    BrasFruits.PositionCoude(92.74);
                    Thread.Sleep(1000);
#else
                    BrasFruits.PositionCoude(101.48);
#endif
                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Reculer(60);
                    Robots.GrosRobot.Rapide();
                    Thread.Sleep(500);
                    BrasFruits.FermerPinceBas();

                    // Attrapage fruit 3
                    BrasFruits.PositionCoude(92.74);
                    Thread.Sleep(500);
                    Robots.GrosRobot.Reculer(100);
                    Robots.GrosRobot.Lent();
                    BrasFruits.FermerPinceHaut();
                    Robots.GrosRobot.Rapide();

                    // Tirs
                    //Robots.GrosRobot.Avancer(100);
                    Robots.GrosRobot.Avancer(160);
                    Thread.Sleep(500);
                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);

                    // Tir bouchon 2
                    BrasFruits.BouchonRecalagePinceBas();
                    BrasFruits.OuvrirPinceBas();
                    Thread.Sleep(1000);
                    BrasFruits.PositionCoude(140);
                    Thread.Sleep(200);
                    CanonFruits.PousseBouchon();

                    if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                        Robots.GrosRobot.PivotGauche(29.19);
#if false
                    CanonFruits.Tirer();
#else
                    CanonFruits.Monter();
                    Thread.Sleep(200);
                    CanonFruits.Tirer();
                    CanonFruits.Baisser();
#endif
                    BrasFruits.BouchonHautBas();

                    // Tir bouchon 3
                    BrasFruits.PositionDeposeBouchon();
                    Thread.Sleep(1000);
                    BrasFruits.OuvrirPinceBas();
                    Thread.Sleep(1000);
                    BrasFruits.PositionCoude(140);
                    Thread.Sleep(200);
                    CanonFruits.PousseBouchon();
#if false
                    CanonFruits.Tirer();
#else
                    CanonFruits.Monter();
                    Thread.Sleep(200);
                    CanonFruits.Tirer();
                    CanonFruits.Baisser();
#endif
                    vide = true;

                    BrasFruits.PositionRange();
                    if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                        Robots.GrosRobot.PivotDroite(29.19);

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
