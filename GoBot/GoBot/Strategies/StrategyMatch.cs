using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using GoBot.Movements;
using GoBot.Threading;
using GoBot.Actionneurs;

namespace GoBot.Strategies
{
    class StrategyMatch : Strategy
    {
        private List<Movement> fixedMovements;

        public override bool AvoidElements => true;

        protected override void SequenceBegin()
        {
            // TODOEACHYEAR

            fixedMovements = new List<Movement>();

            // Sortir ICI de la zonde de départ

            // Experience posée + Experience OK + Atome OK + Atome vert + bleu + rouge du petit robot dans la balance
            Plateau.Score = 5 + 15 + 20 + 44 + 12;

            Robots.GrosRobot.MajGraphFranchissable(Plateau.ListeObstacles);

            Actionneur.AtomHandler.DoDown();
            Actionneur.AtomHandler.DoOpen();
            Actionneur.AtomHandler.DoSwallow();
            Thread.Sleep(350);

            ThreadManager.CreateThread(link => Actionneur.AtomHandler.DoGrab()).StartDelayedThread(400);
            Robots.GrosRobot.Avancer(500);

            if (Plateau.NotreCouleur == Plateau.ColorLeftBlue)
                Plateau.Elements.LayingAtoms[0].IsAvailable = false;
            else
                Plateau.Elements.LayingAtoms[4].IsAvailable = false;

            // Ajouter ICI l'ordre de la strat fixe avant détection d'adversaire

            if (Plateau.NotreCouleur == Plateau.ColorLeftBlue)
            {
                fixedMovements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorYellow));
                fixedMovements.Add(new MoveGoldGrab(Plateau.Elements.GoldeniumYellow));
                fixedMovements.Add(new MoveBalance(Plateau.Elements.BalanceYellow));
                //fixedMovements.Add(new MoveVoidZone(Plateau.Elements.VoidZoneYellow));
                //fixedMovements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorYellow));
                // 
            }
            else
            {
                fixedMovements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorViolet));
                fixedMovements.Add(new MoveGoldGrab(Plateau.Elements.GoldeniumViolet));
                fixedMovements.Add(new MoveBalance(Plateau.Elements.BalanceViolet));
                //fixedMovements.Add(new MoveVoidZone(Plateau.Elements.VoidZoneViolet));
                //fixedMovements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorViolet));
                // 
            }
        }


        private void StoreAtom()
        {
            Thread.Sleep(500);
            Actionneur.AtomHandler.DoCloseAlmost();
            Actionneur.AtomStacker.DoFrontOpen();
            Actionneur.AtomStacker.DoFrontPrepare();

            Actionneur.AtomStacker.MoveFingerFront(Config.CurrentConfig.MotorFingerFront.Maximum, true);

            Actionneur.AtomStacker.DoFrontClose();
            Thread.Sleep(200);
            Actionneur.AtomHandler.DoFree();
            Thread.Sleep(100);

            Actionneur.AtomStacker.DoFrontStore(false);
            Thread.Sleep(1000);
            Actionneur.AtomHandler.DoFree();
            Actionneur.AtomStacker.DoFrontStore(true);
        }

        protected override void SequenceCore()
        {
            Movement bestMovement;

            int iMovement = 0;

            // Execution de la strat fixe tant que rien n'échoue
            while (iMovement < fixedMovements.Count && fixedMovements[iMovement].Execute())
                iMovement++;

            // Passage en mode recherche de la meilleure action
            while (IsRunning)
            {
                List<Movement> sorted = Movements.Where(m => m.IsCorrectColor() && m.CanExecute).OrderBy(m => m.GlobalCost).ToList();

                if (sorted.Count > 0)
                {
                    bestMovement = sorted[0];

                    if (bestMovement.GlobalCost != double.MaxValue && bestMovement.Value != 0)
                    {
                        if (!bestMovement.Execute())
                            bestMovement.Deactivate(new TimeSpan(0, 0, 1));
                    }
                    else
                    {
                        Robots.GrosRobot.Historique.Log("Aucune action à effectuer");
                        Thread.Sleep(500);
                    }
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
