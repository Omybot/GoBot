using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace GoBot.Enchainements
{
    class EvitementEnchainement : Enchainement
    {
        private Thread th;
        Color couleur;

        public System.Drawing.Color GetCouleur()
        {
            return couleur;
        }

        public void SetCouleur(System.Drawing.Color couleur)
        {
            this.couleur = couleur;
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
            GrosRobot.VitesseDeplacement = 600;
            GrosRobot.AccelerationDeplacement = 2200;

            GrosRobot.Avancer(520);
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(1450);
            GrosRobot.PivotGauche(90);
            GrosRobot.Avancer(530);
            GrosRobot.PivotGauche(90);
            GrosRobot.Recallage(SensAR.Arriere);
        }

        private void ThreadEnchainementRouge()
        {
            GrosRobot.VitesseDeplacement = 600;
            GrosRobot.AccelerationDeplacement = 2200;

            GrosRobot.Avancer(520);
            GrosRobot.PivotGauche(90);
            GrosRobot.Avancer(1450);
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(530);
            GrosRobot.PivotDroite(90);
            GrosRobot.Recallage(SensAR.Arriere);
        }


        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Reprendre(int reculade)
        {
            throw new NotImplementedException();
        }
    }
}
