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
            _distanceMinLimit = 50;
            _distanceMaxLimit = 600;
            _keepFrom = 175;
            _keepTo = 575;
            _invertRotation = false;
            _resolution = 240 / 725.0;

            _deltaX = 112;
            _deltaY = 0;
        }

        protected override void SendMessage(string msg)
        {
            // non...
        }

        protected override String GetResponse(int timeout = 5000)
        {
            Position robotPos;

            String mesure = Robots.MainRobot.ReadLidarMeasure(ID, timeout, out robotPos);

            if (robotPos != null)
                _position = new Position(robotPos.Angle, new RealPoint(robotPos.Coordinates.X + _deltaX, robotPos.Coordinates.Y + _deltaY).Rotation(new AngleDelta(robotPos.Angle), robotPos.Coordinates));

            return mesure;
        }

        public string ReadMessage()
        {
            return GetResponse();
        }
    }
}
