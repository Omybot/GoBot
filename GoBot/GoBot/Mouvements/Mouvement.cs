using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;

namespace GoBot.Mouvements
{
    public abstract class Mouvement
    {
        public abstract bool Executer(int timeOut = 0);
        public abstract double Cout { get; }
        public abstract int Score { get; }
        public abstract double ScorePondere { get; }
        public abstract Position Position { get; protected set; }
    }
}
