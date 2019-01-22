using Geometry;
using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    class HokuyoRec : Hokuyo
    {
        private double _deltaX, _deltaY;

        public HokuyoRec(LidarID id) : base(id)
        {
            //_model = "UBG-04LX-F01";
            //_pointsCount = 725;
            _scanRange = 240;
            //_pointsOffset = 44;
            _distanceMaxLimit = 400;
            _keepFrom = 200;
            _keepTo = 600;
            _invertRotation = true;

            _deltaX = 112;
            _deltaY = -82;
        }

        protected override void SendMessage(string msg)
        {
            // non...
        }

        protected override String GetResponse(int timeout = 5000)
        {
            Position robotPos;
            String mesure = Robots.GrosRobot.GetMesureLidar(ID, timeout, out robotPos);
            
            _position = new Position(robotPos.Angle, new RealPoint(robotPos.Coordinates.X + _deltaX, robotPos.Coordinates.Y + _deltaY).Rotation(new AngleDelta(robotPos.Angle), robotPos.Coordinates));

            return mesure;
        }
    }
}
