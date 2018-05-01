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
using GoBot.Geometry;
using AStarFolder;
using GoBot.Threading;

namespace GoBot.Strategies
{
    public abstract class Strategy
    {
        private System.Timers.Timer endMatchTimer;
        private ThreadLink _linkMatch;

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
            MatchDuration = new TimeSpan(0, 0, 100);

            Plateau.PoidActions = new PoidsTest();
            Movements = new List<Movement>();

            // Charger ICI dans les listes ListeMouvementsGros et ListeMouvementsPetit les mouvements possibles

            for (int i = 0; i < Plateau.Elements.CubesCrosses.Count; i++)
            {
                Movements.Add(new MovementsCubesFromBottom(Plateau.Elements.CubesCrosses[i]));
                Movements.Add(new MovementsCubesFromTop(Plateau.Elements.CubesCrosses[i]));
                Movements.Add(new MovementsCubesFromLeft(Plateau.Elements.CubesCrosses[i]));
                Movements.Add(new MovementsCubesFromRigth(Plateau.Elements.CubesCrosses[i]));
            }

            for (int i = 0; i < Plateau.Elements.ConstructionZones.Count; i++)
            {
                Movements.Add(new MovementBuilding(Plateau.Elements.ConstructionZones[i]));
            }

            for (int iMov = 0; iMov < Movements.Count; iMov++)
            {
                for(int iPos = 0; iPos < Movements[iMov].Positions.Count; iPos++)
                {
                    if(!Movements[iMov].Robot.Graph.Raccordable(new Node(Movements[iMov].Positions[iPos].Coordinates.X, Movements[iMov].Positions[iPos].Coordinates.Y, 0),
                        Plateau.ObstaclesPlateau,
                        Movements[iMov].Robot.Rayon,
                        200))
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
            Actionneurs.Actionneur.PatternReader.StopPolling();

            Robots.GrosRobot.Historique.Log("DEBUT DU MATCH", TypeLog.Strat);

            StartingDateTime = DateTime.Now;

            endMatchTimer = new System.Timers.Timer();
            endMatchTimer.Elapsed += new ElapsedEventHandler(endMatchTimer_Elapsed);
            endMatchTimer.Interval = MatchDuration.TotalMilliseconds;
            endMatchTimer.Start();

            _linkMatch = ThreadManager.StartThread(link => Execute(link));
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

        private void Execute(ThreadLink link)
        {
            link.RegisterName();

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
            // Couper ICI tous les actionneurs à la fin du match et lancer la Funny Action

            Robots.GrosRobot.Stop(StopMode.Freely);
            Plateau.Balise.VitesseRotation(0);
        }
    }
}
