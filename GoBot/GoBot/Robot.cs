﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;

namespace GoBot
{
    public abstract class Robot
    {
        public Historique Historique { get; protected set; }
        public bool DeplacementLigne { get; protected set; }

        public abstract Position Position { get; protected set; }

        public abstract void Avancer(int distance, bool attendre = true);
        public abstract void Reculer(int distance, bool attendre = true);
        public abstract void PivotGauche(double angle, bool attendre = true);
        public abstract void PivotDroite(double angle, bool attendre = true);
        public abstract void Stop(StopMode mode = StopMode.Smooth);
        public abstract void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true);
        public abstract void ReglerOffsetAsserv(int offsetX, int offsetY, int offsetTeta);
        public abstract void Recallage(SensAR sens, bool attendre = true);
        public abstract void Init();
        public abstract void BougeServo(ServomoteurID servo, int position);
        public abstract void EnvoyerPID(int p, int i, int d);
        public abstract void CoupureAlim();

        public abstract int VitesseDeplacement { get; set; }
        public abstract int AccelerationDeplacement { get; set; }
        public abstract int VitessePivot { get; set; }
        public abstract int AccelerationPivot { get; set; }

        public abstract int Taille { get; }
        public int Rayon { get { return (int)Math.Sqrt(Taille * Taille * 2) / 2; } }
    }
}
