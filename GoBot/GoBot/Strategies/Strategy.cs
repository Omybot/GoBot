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

namespace GoBot.Strategies
{
    public abstract class Strategy
    {
        private System.Timers.Timer endMatchTimer;
        private Thread sequenceThread;

        /// <summary>
        /// Obtient ou définit la durée d'un match
        /// </summary>
        public TimeSpan MatchDuration { get; set; }
        
        /// <summary>
        /// Retourne vrai si le match est en cours d'execution
        /// </summary>
        public bool IsRunning { get; protected set; }

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
        public List<Movement> Mouvements { get; protected set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Strategy()
        {
            MatchDuration = new TimeSpan(0, 0, 100);
            IsRunning = false;
            Plateau.PoidActions = new PoidsTest();
            Mouvements = new List<Movement>();

            // Charger ICI dans les listes ListeMouvementsGros et ListeMouvementsPetit les mouvements possibles

            for (int i = 0; i < Plateau.Elements.CubesCrosses.Count; i++)
            {
                Mouvements.Add(new MovementsCubesFromTop(Plateau.Elements.CubesCrosses[i]));
                Mouvements.Add(new MovementsCubesFromBottom(Plateau.Elements.CubesCrosses[i]));
                Mouvements.Add(new MovementsCubesFromLeft(Plateau.Elements.CubesCrosses[i]));
                Mouvements.Add(new MovementsCubesFromRigth(Plateau.Elements.CubesCrosses[i]));
            }
        }

        /// <summary>
        /// Execute le match
        /// </summary>
        public void Execute()
        {
            IsRunning = true;

            Robots.GrosRobot.Historique.Log("DEBUT DU MATCH", TypeLog.Strat);

            StartingDateTime = DateTime.Now;

            endMatchTimer = new System.Timers.Timer();
            endMatchTimer.Elapsed += new ElapsedEventHandler(endMatchTimer_Elapsed);
            endMatchTimer.Interval = MatchDuration.TotalMilliseconds;
            endMatchTimer.Start();

            sequenceThread = new Thread(Sequence);
            sequenceThread.Start();
        }

        /// <summary>
        /// Interrompt le match
        /// </summary>
        public void Stop()
        {
            IsRunning = false;
            sequenceThread.Abort();
        }

        private void endMatchTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            IsRunning = false;

            Robots.GrosRobot.Historique.Log("FIN DU MATCH", TypeLog.Strat);
            
            endMatchTimer.Stop();
            sequenceThread.Abort();

        }

        private void Sequence()
        {
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
