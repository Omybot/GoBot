using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Threading;

using GoBot.Movements;
using GoBot.Ponderations;
using GoBot.Actionneurs;
using Geometry;
using AStarFolder;
using GoBot.Threading;
using System.Diagnostics;

namespace GoBot.Strategies
{
    public abstract class Strategy
    {
        private System.Timers.Timer endMatchTimer;
        private ThreadLink _linkMatch;

        private bool _goldFree = false;

        public bool GoldFree
        {
            get { return _goldFree; }
            set { _goldFree = value; }
        }

        private bool _goldGrabed = false;

        public bool GoldGrabed
        {
            get { return _goldGrabed; }
            set { _goldGrabed = value; }
        }

        public abstract bool AvoidElements { get; }

        /// <summary>
        /// Obtient ou définit la durée d'un match
        /// </summary>
        public TimeSpan MatchDuration { get; set; }
        
        /// <summary>
        /// Retourne vrai si le match est en cours d'execution
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return _linkMatch != null && _linkMatch.Running;
            }
        }

        /// <summary>
        /// Retourne l'heure de début du match
        /// </summary>
        public DateTime StartingDateTime { get; protected set; }

        /// <summary>
        /// Retourne le temps restant avant la fin du match
        /// </summary>
        public TimeSpan TimeBeforeEnd
        {
            get
            {
                return (StartingDateTime + MatchDuration) - DateTime.Now;
            }
        }

        /// <summary>
        /// Contient la liste de tous les mouvements du match
        /// </summary>
        public List<Movement> Movements { get; protected set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Strategy()
        {
            if (Debugger.IsAttached)
            {
                MatchDuration = new TimeSpan(0, 0, 100);
            }
            else
            {
                MatchDuration = new TimeSpan(0, 0, 100);
            }

            Plateau.PoidActions = new PoidsTest();
            Movements = new List<Movement>();

            // TODOEACHYEAR Charger ICI dans Movements les mouvements possibles

            //for (int i = 0; i < Plateau.Elements.ConstructionZones.Count; i++)
            //{
            //    Movements.Add(new MovementBuilding(Plateau.Elements.ConstructionZones[i]));
            //}

            Movements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorViolet));
            Movements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorYellow));

            Movements.Add(new MoveGoldGrab(Plateau.Elements.GoldeniumViolet));
            Movements.Add(new MoveGoldGrab(Plateau.Elements.GoldeniumYellow));

            Movements.Add(new MoveBalance(Plateau.Elements.BalanceViolet));
            Movements.Add(new MoveBalance(Plateau.Elements.BalanceYellow));

            Movements.Add(new MoveVoidZone(Plateau.Elements.VoidZoneViolet));
            Movements.Add(new MoveVoidZone(Plateau.Elements.VoidZoneYellow));

            Movements.Add(new MoveAtomsToSlope(Plateau.Elements.SlopeViolet));
            Movements.Add(new MoveAtomsToSlope(Plateau.Elements.SlopeYellow));

            Movements.Add(new MoveCalibration(Plateau.Elements.CalibrationZoneViolet));
            Movements.Add(new MoveCalibration(Plateau.Elements.CalibrationZoneYellow));

            //Movements.Add(new MoveAtomGrab(Plateau.Elements.LayingAtoms[0]));
            Movements.Add(new MoveAtomGrab(Plateau.Elements.LayingAtoms[1]));
            //Movements.Add(new MoveAtomGrab(Plateau.Elements.LayingAtoms[2]));

            //Movements.Add(new MoveAtomGrab(Plateau.Elements.LayingAtoms[4]));
            Movements.Add(new MoveAtomGrab(Plateau.Elements.LayingAtoms[5]));
            //Movements.Add(new MoveAtomGrab(Plateau.Elements.LayingAtoms[6]));

            for (int iMov = 0; iMov < Movements.Count; iMov++)
            {
                for(int iPos = 0; iPos < Movements[iMov].Positions.Count; iPos++)
                {
                    if(!Movements[iMov].Robot.Graph.Raccordable(new Node(Movements[iMov].Positions[iPos].Coordinates),
                        Plateau.ListeObstacles.Except(Plateau.ObstaclesCouleur),
                        Movements[iMov].Robot.Rayon))
                    {
                        Movements[iMov].Positions.RemoveAt(iPos);
                        iPos--;
                    }
                }
            }
        }

        /// <summary>
        /// Execute le match
        /// </summary>
        public void ExecuteMatch()
        {
            Robots.GrosRobot.Historique.Log("DEBUT DU MATCH", TypeLog.Strat);

            StartingDateTime = DateTime.Now;

            Plateau.StartMatch();

            endMatchTimer = new System.Timers.Timer();
            endMatchTimer.Elapsed += new ElapsedEventHandler(endMatchTimer_Elapsed);
            endMatchTimer.Interval = MatchDuration.TotalMilliseconds;
            endMatchTimer.Start();

            _linkMatch = ThreadManager.CreateThread(link => Execute());
            _linkMatch.StartThread();
        }

        /// <summary>
        /// Interrompt le match
        /// </summary>
        public void Stop()
        {
            _linkMatch.Kill();

            SequenceEnd();
        }

        private void endMatchTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Robots.GrosRobot.Historique.Log("FIN DU MATCH", TypeLog.Strat);
            
            endMatchTimer.Stop();
            _linkMatch.Kill();

            SequenceEnd();
        }

        private void Execute()
        {
            _linkMatch.RegisterName();

            SequenceBegin();
            SequenceCore();
        }

        /// <summary>
        /// Contient l'execution des actions au début du match
        /// </summary>
        protected abstract void SequenceBegin();

        /// <summary>
        /// Contient l'execution des actions du match
        /// </summary>
        protected abstract void SequenceCore();

        /// <summary>
        /// Contient l'execution des actions à la fin du match
        /// </summary>
        protected virtual void SequenceEnd()
        {
            // TODOEACHYEAR Couper ICI tous les actionneurs à la fin du match et lancer la Funny Action

            Robots.GrosRobot.Stop(StopMode.Freely);
            //Plateau.Balise.VitesseRotation(0);

            // On renvoie le score au cas où histoire d'assurer le truc...
            //Devices.AllDevices.CanDisplay.SetScore(Plateau.Score);
            Devices.AllDevices.CanDisplay.SetScore((int)(Plateau.Score * 0.8)); // Sous estimation pour essaye de se rapprocher su score réel
        }
    }
}
