using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace GoBot.Enchainements
{
    class LignemEnchainement : Enchainement
    {
        private Thread th;
        Color couleur;

        public LignemEnchainement()
        {
            couleur = Color.Purple;
        }

        public Color GetCouleur()
        {
            return couleur;
        }

        public void SetCouleur(Color color)
        {
            couleur = color;
        }

        public void Executer()
        {
            if (couleur == Color.Red)
                th = new Thread(ThreadEnchainementRouge);
            else
                th = new Thread(ThreadEnchainementViolet);

            th.Start();
        }

        private void ThreadEnchainementViolet()
        {
            /*> Montoise bouge bras haut droite à ouvert
> Montoise bouge bras haut droite à fermé
> Montoise avance de 316mm
> Montoise pivote de 90° droite
> Montoise avance de 421mm
> Montoise bouge bras haut droite à ouvert
> Montoise bouge bras haut droite à fermé
> Montoise avance de 316mm
> Montoise pivote de 45° droite
> Montoise recule de 752mm
> Montoise pivote de 90° gauche
> Montoise avance de 430mm*/

            GrosRobot.VitesseDeplacement = 400;
            GrosRobot.VitessePivot = 400;
            GrosRobot.AccelerationDeplacement = 600;
            GrosRobot.AccelerationPivot = 600;

            PetitRobot.VitesseDeplacement = 400;
            PetitRobot.VitessePivot = 400;
            PetitRobot.AccelerationDeplacement = 600;
            PetitRobot.AccelerationPivot = 600;

            GrosRobot.Avancer(310);
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(1450);
            GrosRobot.PivotDroite(180);
            GrosRobot.VitesseDeplacement = 300;
            GrosRobot.AccelerationDeplacement = 300;
            GrosRobot.Recallage(SensAR.Arriere);

            PetitRobot.Avancer(550);
            PetitRobot.PivotDroite(90);
            PetitRobot.Avancer(640 );
            PetitRobot.PivotDroite(90);
            PetitRobot.Avancer(300);

            /*> Montoise recule de 340mm
> Montoise accélération ligne à 3000
> Montoise vitesse ligne à 3000
> Montoise pivote de 75° droite
> Montoise avance de 150mm
> Montoise pivote de 70° droite
> Montoise recule de 50mm
> Montoise bouge bras bas droite à fermé
> Montoise bouge bras bas gauche à fermé
> Montoise recule de 200mm
> Montoise avance de 850mm
> Montoise pivote de 125° droite
> Montoise bouge bras bas gauche à ouvert
> Montoise bouge bras bas droite à 602
> Montoise avance de 660mm
*/

            /*GrosRobot.Avancer(660);
            GrosRobot.PivotDroite(125);
            GrosRobot.Avancer(900);

            GrosRobot.Reculer(300);
            GrosRobot.PivotDroite(70);
            GrosRobot.Avancer(150);
            GrosRobot.PivotDroite(75);
            GrosRobot.VitesseDeplacement = 3000;
            GrosRobot.AccelerationDeplacement = 3000;
            GrosRobot.Reculer(340);*/
        }

        private void ThreadEnchainementRouge()
        {
            GrosRobot.VitesseDeplacement = 400;
            GrosRobot.VitessePivot = 400;
            GrosRobot.AccelerationDeplacement = 600;
            GrosRobot.AccelerationPivot = 600;

            PetitRobot.VitesseDeplacement = 400;
            PetitRobot.VitessePivot = 400;
            PetitRobot.AccelerationDeplacement = 600;
            PetitRobot.AccelerationPivot = 600;

            GrosRobot.Avancer(310);
            GrosRobot.PivotGauche(90);
            GrosRobot.Avancer(1450);
            GrosRobot.PivotGauche(180);
            GrosRobot.VitesseDeplacement = 300;
            GrosRobot.AccelerationDeplacement = 300;
            GrosRobot.Recallage(SensAR.Arriere);

            PetitRobot.Avancer(550);
            PetitRobot.PivotGauche(90);
            PetitRobot.Avancer(640);
            PetitRobot.PivotGauche(90);
            PetitRobot.Avancer(300);
        }
    }
}
