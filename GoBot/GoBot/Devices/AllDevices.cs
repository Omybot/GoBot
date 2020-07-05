using Geometry;
using GoBot.Communications;
using GoBot.Devices.CAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GoBot.Devices
{
    static class AllDevices
    {
        private static CanServos _canServos;
        private static Lidar _lidarGround, _lidarAvoid;

        public static void Init()
        {
            try
            {
                _canServos = new CanServos(Connections.ConnectionCan);
                _lidarGround = new HokuyoRec(LidarID.Ground);

                if (Config.CurrentConfig.IsMiniRobot)
                {
                    _lidarAvoid = new Hokuyo(LidarID.Avoid, "COM3");
                }
                else
                {
                    _lidarAvoid = new Pepperl(IPAddress.Parse("10.1.0.50"));
                    ((Pepperl)_lidarAvoid).SetFrequency(PepperlFreq.Hz20);
                    ((Pepperl)_lidarAvoid).SetFilter(PepperlFilter.Average, 3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR INIT LIDAR : " + ex.Message);
            }
        }

        public static void InitSimu()
        {
            _canServos = new CanServos(Connections.ConnectionCan);
            _lidarGround = new LidarSimu();
            _lidarAvoid = new LidarSimu();
        }

        public static void Close()
        {
            _lidarAvoid?.StopLoopMeasure();
            _lidarGround?.StopLoopMeasure();
        }

        public static CanServos CanServos
        {
            get
            {
                return _canServos;
            }
        }

        public static Lidar LidarGround
        {
            get { return _lidarGround; }
            set { _lidarGround = value; }
        }

        public static Lidar LidarAvoid
        {
            get { return _lidarAvoid; }
            set { _lidarAvoid = value; }
        }

        private static Hokuyo CreateHokuyo(String portCom, LidarID id)
        {
            Hokuyo hok = null;

            try
            {
                hok = new Hokuyo(id, portCom);
            }
            catch (Exception)
            {
            }

            return hok;
        }

        public static void SetRobotPosition(Position pos)
        {
            if (Config.CurrentConfig.IsMiniRobot)
            {
                if (_lidarAvoid != null)
                    _lidarAvoid.Position = new Position(pos.Angle - new AngleDelta(90), pos.Coordinates);
            }
            else
            {
                if (_lidarAvoid != null)
                    _lidarAvoid.Position = new Position(pos.Angle - new AngleDelta(90), pos.Coordinates);
                if (_lidarGround != null)
                {
                    _lidarGround.Position.Coordinates = new Geometry.Shapes.RealPoint(pos.Coordinates.X + Math.Cos(pos.Angle) * 109, pos.Coordinates.Y + Math.Sin(pos.Angle) * 109);
                    _lidarGround.Position.Angle = pos.Angle;
                }
            }
        }
    }
}
