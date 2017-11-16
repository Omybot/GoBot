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
        protected override void SequenceBegin()
        {
            // Sortir ICI de la zonde de départ
        }

        protected override void SequenceCore()
        {
            // Ecrire ICI la strat pour faire le minimum de points possible pour etre homologué
        }
    }
}
