using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using GoBot.Mouvements;

namespace GoBot.Strategies
{
    class StrategyMatch : Strategy
    {
        private List<Mouvement> fixedMovements;

        protected override void SequenceBegin()
        {
            fixedMovements = new List<Mouvement>();

            // Ajouter ICI l'ordre de la strat fixe avant détection d'adversaire

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
            {
                //fixedMovements.Add(new MouvementFusee(1));
            }
            else
            {
                //fixedMovements.Add(new MouvementFusee(2));
            }

            // Sortir ICI de la zonde de départ
        }

        protected override void SequenceCore()
        {
            Mouvement bestMovement;

            int iMovement = 0;

            // Execution de la strat fixe tant que rien n'échoue
            while (iMovement < fixedMovements.Count && fixedMovements[iMovement].Executer())
                iMovement++;

            // Passage en mode recherche de la meilleure action
            while (IsRunning)
            {
                bestMovement = Mouvements.OrderBy(m => m.Cout).ElementAt(0);

                if (bestMovement.Cout != double.MaxValue && bestMovement.ValeurAction != 0)
                {
                    if (!bestMovement.Executer())
                        bestMovement.DateMinimum = DateTime.Now + new TimeSpan(0, 0, 1);
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Aucune action à effectuer");
                    Thread.Sleep(500);
                }
            }
        }
    }
}
