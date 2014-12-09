using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Actionneurs;
using System.Windows.Forms;
using GoBot.ElementsJeu;

namespace GoBot.Enchainements
{
    class EnchainementMatch : Enchainement
    {
        protected override void ThreadGros()
        {
            int iMeilleur = 0;

            // Ajouter ici les actions fixes avant le lancement de l'IA
            
        }

        protected override void ThreadPetit()
        {
            int iMeilleur = 0;
            return;
            // Ajouter ici les actions fixes avant le lancement de l'IA

        }
    }
}
