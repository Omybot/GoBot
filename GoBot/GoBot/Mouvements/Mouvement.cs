using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Mouvements
{
    abstract class Mouvement
    {
        public abstract bool Executer(int timeOut = 0);
        public abstract double Cout { get; }
        public abstract int Score { get; }
    }
}
