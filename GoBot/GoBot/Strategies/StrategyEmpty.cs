using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Strategies
{
    class StrategyEmpty : Strategy
    {
        public override bool AvoidElements => false;

        protected override void SequenceBegin()
        {
        }

        protected override void SequenceCore()
        {
        }
    }
}
