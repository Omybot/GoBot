﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

using GoBot.Movements;
using AStarFolder;
using GoBot.Threading;
using System.Diagnostics;
using GoBot.BoardContext;
using GoBot.Devices;
using GoBot.Actionneurs;

namespace GoBot.Strategies
{
    public abstract class Strategy
    {
        private System.Timers.Timer endMatchTimer;
        private ThreadLink _linkMatch;

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
        /// Retourne le temps écoulé depuis le début du match
        /// </summary>
        public TimeSpan TimeSinceBegin
        {
            get
            {
                return DateTime.Now - StartingDateTime;
            }
        }
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

            Movements = new List<Movement>();

            // TODOEACHYEAR Charger ICI dans Movements les mouvements possibles

            for (int i = 0; i < GameBoard.Elements.GroundedZones.Count; i++)
                Movements.Add(new MovementGroundedZone(GameBoard.Elements.GroundedZones[i]));

            for (int i = 0; i < GameBoard.Elements.RandomDropoffs.Count; i++)
            {
                Movements.Add(new MovementRandomDropoff(GameBoard.Elements.RandomDropoffs[i]));
                Movements.Add(new MovementGreenDropoff(GameBoard.Elements.RandomDropoffs[i]));
                Movements.Add(new MovementRedDropoff(GameBoard.Elements.RandomDropoffs[i]));
            }

            for (int i = 0; i < GameBoard.Elements.ColorDropoffs.Count; i++)
                Movements.Add(new MovementColorDropoff(GameBoard.Elements.ColorDropoffs[i]));

            for (int i = 0; i < GameBoard.Elements.LightHouses.Count; i++)
                Movements.Add(new MovementLightHouse(GameBoard.Elements.LightHouses[i]));

            //Movements.Add(new MovementBuoy(GameBoard.Elements.FindBuoy(new Geometry.Shapes.RealPoint(300, 400))));
            //Movements.Add(new MovementBuoy(GameBoard.Elements.FindBuoy(new Geometry.Shapes.RealPoint(2700, 400))));

            if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
                for (int i = 0; i < GameBoard.Elements.BuoysForLeft.Count; i++)
                    Movements.Add(new MovementBuoy(GameBoard.Elements.BuoysForLeft[i]));
            else
                for (int i = 0; i < GameBoard.Elements.BuoysForRight.Count; i++)
                    Movements.Add(new MovementBuoy(GameBoard.Elements.BuoysForRight[i]));

            for (int iMov = 0; iMov < Movements.Count; iMov++)
            {
                for (int iPos = 0; iPos < Movements[iMov].Positions.Count; iPos++)
                {
                    if (!Movements[iMov].Robot.Graph.Raccordable(new Node(Movements[iMov].Positions[iPos].Coordinates),
                        GameBoard.ObstaclesAll,
                        Movements[iMov].Robot.Radius))
                    {
                        Movements[iMov].Positions.RemoveAt(iPos);
                        iPos--;
                    }
                }
            }

            Movements.Add(new MovementRandomPickup(GameBoard.Elements.RandomPickup));
        }

        /// <summary>
        /// Execute le match
        /// </summary>
        public void ExecuteMatch()
        {
            Robots.MainRobot.Historique.Log("DEBUT DU MATCH", TypeLog.Strat);

            StartingDateTime = DateTime.Now;

            GameBoard.StartMatch();

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
            Robots.MainRobot.Historique.Log("FIN DU MATCH", TypeLog.Strat);

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
            // TODOEACHYEAR Couper ICI tous les actionneurs à la fin du match et lancer la Funny Action / afficher le score

            Robots.MainRobot.Stop(StopMode.Freely);

            Actionneur.ElevatorLeft.DoElevatorFree();
            Actionneur.ElevatorRight.DoElevatorFree();

            MovementFlags moveFlags = new MovementFlags();
            if (moveFlags.ExecuteHere())
                GameBoard.Score += moveFlags.Score;

            System.Threading.Thread.Sleep(1000);

            AllDevices.CanServos.DisableAll();

            // On renvoie le score au cas où histoire d'assurer le truc...

            if (!Config.CurrentConfig.IsMiniRobot)
                Robots.MainRobot.ShowMessage("Estimation :", GameBoard.Score.ToString() + " points");
        }
    }
}
