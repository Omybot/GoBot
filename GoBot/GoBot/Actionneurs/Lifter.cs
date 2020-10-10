using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class Lifter
    {
        private List<ServoClamp> _clamps;

        public Lifter()
        {
            _clamps = new List<ServoClamp> { Config.CurrentConfig.ServoClamp1, Config.CurrentConfig.ServoClamp2, Config.CurrentConfig.ServoClamp3, Config.CurrentConfig.ServoClamp4, Config.CurrentConfig.ServoClamp5 };
        }

        public void DoOpenAll()
        {
            _clamps.ForEach(o => o.SendPosition(o.PositionOpen));
        }

        public void DoMaintainAll()
        {
            _clamps.ForEach(o => o.SendPosition(o.PositionMaintain));
        }

        public void DoCloseAll()
        {
            _clamps.ForEach(o => o.SendPosition(o.PositionClose));
        }

        public void DoStoreAll()
        {
            _clamps.ForEach(o => o.SendPosition(o.PositionStore));
        }

        public void DoLoop()
        {
            for (int i = 0; i < 10; i++)
            {
                _clamps.ForEach(o =>
                {
                    o.SendPosition(o.PositionOpen);
                    Thread.Sleep(100);
                });

                _clamps.ForEach(o =>
                {
                    o.SendPosition(o.PositionStore);
                    Thread.Sleep(100);
                });
            }
        }
    }
}
