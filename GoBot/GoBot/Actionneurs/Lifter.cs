using Geometry;
using Geometry.Shapes;
using GoBot.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GoBot.Actionneurs
{
    class Lifter
    {
        private List<ServoClamp> _clamps;
        private ServoLifter _lifter;
        private ServoTilter _tilter;

        private List<Color> _load;

        public Lifter()
        {
            _clamps = new List<ServoClamp> { Config.CurrentConfig.ServoClamp1, Config.CurrentConfig.ServoClamp2, Config.CurrentConfig.ServoClamp3, Config.CurrentConfig.ServoClamp4, Config.CurrentConfig.ServoClamp5 };
            _lifter = Config.CurrentConfig.ServoLifter;
            _tilter = Config.CurrentConfig.ServoTilter;
        }

        public bool Loaded => _load != null;

        public List<Color> Load
        {
            get { return _load; }
            set { _load = value; }
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

        public void DoDisableAll()
        {
            _clamps.ForEach(o => o.DisableTorque());
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

        public void DoLifterPositionExtract()
        {
            _lifter.SendPosition(_lifter.PositionExtract);
        }

        public void DoLifterPositionStore()
        {
            _lifter.SendPosition(_lifter.PositionStore);
        }

        public void DoTilterPositionStore()
        {
            _tilter.SendPosition(_tilter.PositionStore);
        }

        public void DoTilterPositionPickup()
        {
            _tilter.SendPosition(_tilter.PositionPickup);
        }

        public void DoTilterPositionExtract()
        {
            _tilter.SendPosition(_tilter.PositionExtract);
        }

        public void DoTilterPositionDropoff()
        {
            _tilter.SendPosition(_tilter.PositionDropoff);
        }

        public void DoSequencePickup()
        {
            Robots.MainRobot.SetSpeedVerySlow();
            Robots.MainRobot.Recalibration(SensAR.Arriere, true, true);

            Robots.MainRobot.SetSpeedSlow();
            Robots.MainRobot.Move(20);
            DoOpenAll();
            DoTilterPositionPickup();
            Thread.Sleep(500);
            DoCloseAll();
            Thread.Sleep(400);
            DoLifterPositionExtract();
            Thread.Sleep(450);
            Robots.MainRobot.Move(100);
            DoLifterPositionStore();
            Thread.Sleep(150);
            DoTilterPositionStore();
            Robots.MainRobot.SetSpeedFast();
        }

        public void DoSequenceDropOff()
        {
            DoTilterPositionDropoff();
            Thread.Sleep(500);
            DoOpenAll();
            DoTilterPositionStore();
            Thread.Sleep(150);
            DoStoreAll();
        }
    }
}
