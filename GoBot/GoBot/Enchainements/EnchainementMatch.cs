using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Enchainements
{
    class EnchainementMatch : Enchainement
    {
        protected override void ThreadGros()
        {
            int iMeilleur = 0;

            // Todo Ajouter ici les actions fixes avant le lancement de l'IA
            // Exemple : Robots.GrosRobot.Avancer(600);

            while (ListeMouvementsGros.Count > 0)
            {
                double meilleurCout = double.MaxValue;
                for (int j = 0; j < ListeMouvementsGros.Count; j++)
                {
                    double cout = ListeMouvementsGros[j].Cout;
                    if (meilleurCout > cout)
                    {
                        meilleurCout = cout;
                        iMeilleur = j;
                    }
                }

                if (ListeMouvementsGros[iMeilleur].ScorePondere != 0)
                    ListeMouvementsGros[iMeilleur].Executer();
            }
        }

        protected override void ThreadPetit()
        {
            int iMeilleur = 0;

            // Todo Ajouter ici les actions fixes avant le lancement de l'IA
            // Exemple : Robots.PetitRobot.Avancer(600);

            while (ListeMouvementsPetit.Count > 0)
            {
                double meilleurCout = double.MaxValue;
                for (int j = 0; j < ListeMouvementsPetit.Count; j++)
                {
                    double cout = ListeMouvementsPetit[j].Cout;
                    if (meilleurCout > cout)
                    {
                        meilleurCout = cout;
                        iMeilleur = j;
                    }
                }

                if (ListeMouvementsPetit[iMeilleur].Score != 0)
                    ListeMouvementsPetit[iMeilleur].Executer();
            }
        }
    }
}
