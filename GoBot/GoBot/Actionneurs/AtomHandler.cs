using Geometry;
using Geometry.Shapes;
using GoBot.Communications;
using GoBot.Devices;
using GoBot.Devices.CAN;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class AtomHandler
    {
        private CanServo _servoClampLeft;
        private CanServo _servoClampRight;
        private CanServo _servoElevation;

        private ServoClampLeft _posClampLeft;
        private ServoClampRight _posClampRight;
        private ServoElevation _posElevation;

        private Hokuyo _detector;

        public AtomHandler()
        {
            _servoClampLeft = AllDevices.CanServos[ServomoteurID.ClampLeft];
            _servoClampRight = AllDevices.CanServos[ServomoteurID.ClampRight];
            _servoElevation = AllDevices.CanServos[ServomoteurID.Elevation];

            _posClampLeft = Config.CurrentConfig.ServoClampLeft;
            _posClampRight = Config.CurrentConfig.ServoClampRight;
            _posElevation = Config.CurrentConfig.ServoElevation;

            _detector = AllDevices.HokuyoGround;
        }

        public void DoOpen()
        {
            _servoClampLeft.SetPosition(_posClampLeft.PositionOpen);
            _servoClampRight.SetPosition(_posClampRight.PositionOpen);

            Threading.ThreadManager.CreateThread(link =>
            {
                _servoClampRight.DisableOutput();
                _servoClampLeft.DisableOutput();
            }).StartDelayedThread(500);
        }

        public void DoClose()
        {
            _servoClampLeft.SetPosition(_posClampLeft.Minimum);
            _servoClampRight.SetPosition(_posClampRight.Maximum);
        }

        public void DoCloseAlmost()
        {
            _servoClampLeft.SetPosition(_posClampLeft.PositionAlmostClose);
            _servoClampRight.SetPosition(_posClampRight.PositionAlmostClose);
        }

        public void DoFree()
        {
            _servoClampLeft.SetPosition(_posClampLeft.PositionFree);
            _servoClampRight.SetPosition(_posClampRight.PositionFree);
        }

        public void DoFreeTorque()
        {
            _servoClampLeft.DisableOutput();
            _servoClampRight.DisableOutput();
        }

        public void DoUp()
        {
            _servoElevation.SetPosition(_posElevation.PositionInside);
        }

        public void DoDown()
        {
            _servoElevation.SetPosition(_posElevation.PositionGround);
        }

        public void DoSwallow()
        {
            Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionSwallow);
        }

        public void DoSpit()
        {
            Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionSpit);
        }

        public void DoStop()
        {
            Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionStop);
        }

        public void DoGrab()
        {
            Actionneur.AtomStacker.DoFrontOpen();
            Actionneur.AtomStacker.DoFrontPrepare(false);

            DoSwallow();
            DoClose();
            Thread.Sleep(500);
            Actionneur.AtomStacker.DoFrontPrepare();
            DoUp();
            Thread.Sleep(200);

            Threading.ThreadManager.CreateThread(link =>
            {
                Thread.Sleep(300);
                DoStop();
                link.Name = "Atom stocking";
                Actionneur.AtomStacker.MoveFingerFront(Config.CurrentConfig.MotorFingerFront.Maximum, true);

                Actionneur.AtomStacker.DoFrontClose();
                Thread.Sleep(200);
                DoFree();
                Thread.Sleep(100);

                Actionneur.AtomStacker.DoFrontStore(false);
            }).StartThread();
        }

        public void MoveClampLeft(int position)
        {
            _servoClampLeft.SetPosition(position);
        }

        public void MoveClampRight(int position)
        {
            _servoClampRight.SetPosition(position);
        }

        public void MoveElevation(int position)
        {
            _servoElevation.SetPosition(position);
        }

        public void DoInit()
        {
            _servoClampLeft.SetPosition(_posClampLeft.PositionFree);
            _servoClampLeft.SetPosition(_posClampRight.PositionFree);

            _servoElevation.SetPosition(_posElevation.PositionGround);
            Thread.Sleep(500);

            _servoClampLeft.SetPosition(_posClampLeft.PositionClose);
            Thread.Sleep(500);
            _servoClampLeft.SetPosition(_posClampLeft.PositionFree);
            Thread.Sleep(500);

            _servoClampRight.SetPosition(_posClampRight.PositionClose);
            Thread.Sleep(500);
            _servoClampRight.SetPosition(_posClampRight.PositionFree);
            Thread.Sleep(500);

            _servoElevation.SetPosition(_posElevation.PositionInside);
            Thread.Sleep(500);

            _servoClampRight.DisableOutput();
            _servoClampLeft.DisableOutput();
        }

        public void DoDetection()
        {
            DetectAtom(500);
        }

        public RealPoint DetectAtom(int maxDistance = 500)
        {
            List<RealPoint> rawPts = _detector.GetPoints();

            List<RealPoint> pts = rawPts.Where(o => Plateau.IsInside(o, 30)).ToList();
            pts = pts.Where(o => InRange(o.Distance(Robots.GrosRobot.Position.Coordinates), 200, maxDistance)).ToList();

            List<List<RealPoint>> groups = pts.GroupByDistance(50, 200);

            List<Circle> circles = new List<Circle>();

            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i].Count > 5)
                {
                    Circle circle = new Circle(groups[i].GetBarycenter(), 40);
                    if (!circles.Exists(o => o.Center.Distance(circle.Center) < 60))
                        circles.Add(circle);
                }
            }

            Circle detection = null;

            if(circles.Count > 0)
                detection = circles.OrderBy(o => o.Distance(Robots.GrosRobot.Position.Coordinates)).First();

            List<IShape> detections = new List<IShape>();

            detections.AddRange(circles);
            detections.AddRange(pts);

            Plateau.Detections = detections;

            return detection == null ? null : detection.Center;
        }

        private bool InRange(double value, double min, double max)
        {
            return value > min && value < max;
        }

        public bool DoSearchAtom()
        {
            bool ok = false;
            RealPoint target = DetectAtom(500);

            if(target != null)
            {
                Direction dir = Maths.GetDirection(Robots.GrosRobot.Position, target.Barycenter);

                DoDown();
                DoOpen();
                DoSwallow();

                Stopwatch sw = Stopwatch.StartNew();

                if (dir.angle > 0)
                    Robots.GrosRobot.PivotGauche(dir.angle);
                else
                    Robots.GrosRobot.PivotDroite(-dir.angle);

                int elapsed = (int)sw.ElapsedMilliseconds;
                if (elapsed < 500)
                    Thread.Sleep(500 - elapsed);

                Robots.GrosRobot.Avancer((int)(dir.distance) - 130);

                DoGrab();
                Actionneur.AtomStacker.AtomsCount++;

                Robots.GrosRobot.Reculer((int)(dir.distance) - 130);


                if (dir.angle > 0)
                    Robots.GrosRobot.PivotDroite(dir.angle);
                else
                    Robots.GrosRobot.PivotGauche(-dir.angle);

                ok = true;
            }

            return ok;
        }

        public void DoVoidZone()
        {
            bool found = true;

            for (int i = 0; i < 3 && found; i++)
            {
                DoDetection();
                found = DoSearchAtom();
            }
        }
    }
}
