using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Actionneurs;
using System.Windows.Forms;
using GoBot.ElementsJeu;
using GoBot.Mouvements;

namespace GoBot.Enchainements
{
    class EnchainementHomologation : Enchainement
    {
        protected override void ThreadGros()
        {
            int iMeilleur = 0;

            // Ajouter ici les actions fixes avant le lancement de l'IA

            Robots.GrosRobot.VitesseDeplacement = 500;
            Actionneur.BarreDePompes.Stop();
            Robots.GrosRobot.Avancer(1000);
            Robots.GrosRobot.Reculer(600);
        }
    }
}
