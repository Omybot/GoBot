using Geometry;
using Geometry.Shapes;
using GoBot.Actionneurs;
using GoBot.Movements;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GoBot.Strategies
{
    /// <summary>
    /// Stratégie qui consiste à marquer juste quelques points (pour homologuation de capacité à marquer des points par exemple)
    /// </summary>
    class StrategyMinimumScore : Strategy
    {
        private bool _avoidElements = true;

        public override bool AvoidElements => _avoidElements;

        List<Movement> mouvements = new List<Movement>();

        protected override void SequenceBegin()
        {
            // Sortir ICI de la zonde de départ

            Robots.GrosRobot.MajGraphFranchissable(Plateau.ListeObstacles);

            Actionneur.AtomHandler.DoDown();
            Actionneur.AtomHandler.DoOpen();
            Actionneur.AtomHandler.DoSwallow();
            Thread.Sleep(150);
            Robots.GrosRobot.Avancer(150);
            Actionneur.AtomHandler.DoClose();
            Thread.Sleep(200);
            Actionneur.AtomHandler.DoStop();
            Actionneur.AtomHandler.DoUp();

            Actionneur.AtomStacker.AtomsCount++;

            ThreadManager.CreateThread(link => StoreAtom()).StartThread();
            
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
            {
                mouvements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorYellow));
                mouvements.Add(new MoveGoldGrab(Plateau.Elements.GoldeniumYellow));
                mouvements.Add(new MoveBalance(Plateau.Elements.BalanceYellow));
                //new MoveVoidZone(Plateau.Elements.VoidZoneYellow).Execute();
            }
            else
            {
                mouvements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorViolet));
                mouvements.Add(new MoveGoldGrab(Plateau.Elements.GoldeniumViolet));
                mouvements.Add(new MoveBalance(Plateau.Elements.BalanceViolet));
                //new MoveVoidZone(Plateau.Elements.VoidZoneViolet).Execute();
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
            // TODOYEACHYEAR Ajouter ICI l'ordre de la strat fixe avant détection d'adversaire

            _avoidElements = true;

            foreach (Movement move in mouvements)
            {
                bool ok = false;
                while (!ok)
                {
                    ok = move.Execute();
                }
            }
            
            while (IsRunning)
            {
                while (!Robots.GrosRobot.GotoXYTeta(new Position(0, new RealPoint(700, 1250)))) ;
                while (!Robots.GrosRobot.GotoXYTeta(new Position(180, new RealPoint(3000 - 700, 1250)))) ;
            }
        }
    }
}
