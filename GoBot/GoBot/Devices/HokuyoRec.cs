using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    class HokuyoRec : Hokuyo
    {
        public HokuyoRec(LidarID id) : base(id)
        {
            _model = "UBG-04LX-F01";
            _pointsCount = 725;
            _scanRange = 240;
            _pointsOffset = 44;
            _maxDistance = 400;
            _keepFrom = 200;
            _keepTo = 600;
            _invertRotation = true;
        }

        protected override void SendMessage(string msg)
        {
            // non...
        }

        protected override String GetResponse(int timeout = 5000)
        {
            Position refPosition;
            String mesure = Robots.GrosRobot.GetMesureLidar(ID, timeout, out refPosition);
            //refPosition = PositionDepuisRobot(Robots.GrosRobot.Position);
            return mesure;
        }
    }
}
