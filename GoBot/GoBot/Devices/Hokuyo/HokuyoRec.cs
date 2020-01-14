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
            _distanceMaxLimit = 1000;
            _keepFrom = 200;
            _keepTo = 600;
            _invertRotation = true;
            _resolution = 240 / 725.0;

            _deltaX = 112;
            _deltaY = -82;
        }

        protected override void SendMessage(string msg)
        {
            // non...
        }

        int offset = 0;

        protected override String GetResponse(int timeout = 5000)
        {
            Position robotPos;
            String mesure = Robots.MainRobot.ReadLidarMeasure(ID, timeout, out robotPos);

            // TODO2019 régler cet offset de 18° écrit là juste pour que ça marche
            _position = new Position(robotPos.Angle + 18, new RealPoint(robotPos.Coordinates.X + _deltaX, robotPos.Coordinates.Y + _deltaY).Rotation(new AngleDelta(robotPos.Angle), robotPos.Coordinates));

            return mesure;
        }
    }
}
