using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Communications;
using System.Drawing;
using System.Threading;
using GoBot.Actionneurs;
using GoBot.Threading;
using Geometry.Shapes;
using Geometry;
using GoBot.Communications.UDP;
using GoBot.Communications.CAN;
using static GoBot.Actionneurs.AtomHandler;

namespace GoBot.Devices
{
    public class RecGoBot
    {
        private bool _switch1, _switch2, _switch3, _switch4;

        public delegate void ButtonChangeDelegate(SensorOnOffID btn, Boolean state);
        public event ButtonChangeDelegate ButtonChange;

        public delegate void JackChangeDelegate(Boolean state);
        public event JackChangeDelegate JackChange;

        public delegate void LedChangeDelegate(LedID led, LedStatus state);
        public event LedChangeDelegate LedChange;

        public delegate void ColorChangeDelegate(MatchColor state);
        public event ColorChangeDelegate ColorChange;

        private Semaphore semCodeur;
        public uint PositionCodeur { get; protected set; }

        public enum LedStatus
        {
            Off,
            Rouge,
            Orange,
            Vert
        }

        private Connection connexion;
        private Dictionary<LedID, LedStatus> ledsStatus;

        private Dictionary<Connection, LedID> ledConnexionState;

        public RecGoBot(Board board)
        {
            ledsStatus = new Dictionary<LedID, LedStatus>();
            for (LedID i = 0; i <= (LedID)15; i++)
                ledsStatus.Add(i, LedStatus.Off);

            connexion = Connections.UDPBoardConnection[board];
            connexion.FrameReceived += new Connection.NewFrameDelegate(connexion_NouvelleTrameRecue);

            ledConnexionState = new Dictionary<Connection, LedID>();

            LedID led = LedID.DebugA8;
            foreach (Connection conLed in Connections.AllConnections.OfType<UDPConnection>().OrderBy(c => Connections.GetUDPBoardByConnection(c).ToString()))
            {
                ledConnexionState.Add(conLed, led);
                conLed.ConnectionChecker.SendConnectionTest += ConnexionCheck_SendConnectionTest;
                led--;
            }

            foreach (Connection conLed in Connections.AllConnections.OfType<CanSubConnection>().OrderBy(c => Connections.GetCANBoardByConnection(c).ToString()))
            {
                ledConnexionState.Add(conLed, led);
                conLed.ConnectionChecker.SendConnectionTest += ConnexionCheck_SendConnectionTest;
                led--;
            }
            ButtonChange += RecGoBot_ButtonChange;

        }

        private void Button1Click()
        {

            ThreadManager.CreateThread(link => Robots.GrosRobot.RangerActionneurs()).StartThread();
            //while (Plateau.Detections?.Count > 0)
            //{
            //    IShape target = Plateau.Detections.OrderBy(o => o.Distance(Robots.GrosRobot.Position.Coordinates)).ToList()[0];

            //    Direction dir = Maths.GetDirection(Robots.GrosRobot.Position, target.Barycenter);

            //    Config.CurrentConfig.ServoElevation.SendPosition(Config.CurrentConfig.ServoElevation.PositionGround);
            //    Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionOpen);
            //    Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionOpen);
            //    Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionSwallow);

            //    Thread.Sleep(1000);

            //    if (dir.angle > 0)
            //        Robots.GrosRobot.PivotGauche(dir.angle);
            //    else
            //        Robots.GrosRobot.PivotDroite(-dir.angle);

            //    Robots.GrosRobot.Avancer((int)(dir.distance - 150));


            //    Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionClose);
            //    Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionClose);

            //    Thread.Sleep(1000);
            //    Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionStop);
            //    Config.CurrentConfig.ServoElevation.SendPosition(Config.CurrentConfig.ServoElevation.PositionInside);
            //    Thread.Sleep(1000);
            //    Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionOpen);
            //    Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionOpen);

            //    Robots.GrosRobot.Reculer(200);
            //    Thread.Sleep(500);
            //}
        }

        private void Button2Click()
        {
            ThreadManager.CreateThread(link => Recallages.RecallageGrosRobot()).StartThread();
        }

        private void Button3Click()
        {
            Robots.GrosRobot.Rapide();
        }

        private void Button4Click()
        {
            Robots.GrosRobot.Lent();
        }

        private void Button5Click()
        {
            Config.CurrentConfig.ServoElevation.SendPosition(Config.CurrentConfig.ServoElevation.PositionInside);
            Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionClose);
            Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionClose);

            Thread.Sleep(2000);
            Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionOpen);
            Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionOpen);
            Thread.Sleep(500);

            Config.CurrentConfig.ServoElevation.SendPosition(Config.CurrentConfig.ServoElevation.PositionGround);
            Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionClose);
            Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionClose);
        }
        private void Button6Click()
        {
            Actionneur.AtomHandler.DoGrabByDetect();
        }
        private void Button7Click()
        {
            bool retry = true;
            int fails = 0;
            int maxFails = 5;
            int atomsCount = 4;

            Robots.GrosRobot.Rapide();
            
            while (retry && Actionneur.AtomStacker.CanStoreMore && atomsCount > 0)
            {
                GrabResult res = Actionneur.AtomHandler.DoGrabByDetect();

                switch (res)
                {
                    case GrabResult.AtomGrabbed:
                        atomsCount -= 1;
                        retry = true;
                        Devices.AllDevices.RecGoBot.Buzz(".");
                        break;
                    case GrabResult.AtomTooClose:
                        Devices.AllDevices.RecGoBot.Buzz("..");
                        fails++;
                        if (fails < maxFails)
                        {
                            Thread.Sleep(500);
                            Robots.GrosRobot.Reculer(50);
                            retry = true;
                        }
                        else
                        {
                            retry = false;
                        }
                        break;
                    case GrabResult.GrabFail:
                        Devices.AllDevices.RecGoBot.Buzz("...");
                        fails += 2;
                        retry = fails < maxFails;
                        break;
                    case GrabResult.NoAtomDetected:
                        Devices.AllDevices.RecGoBot.Buzz("--");
                        fails = maxFails;
                        retry = false;
                        break;
                }
            }
        }
        private void Button8Click()
        {
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.PivotDroite(180);
            Actionneur.AtomUnloaderLeft.DoUnloaderUnload();
            Robots.GrosRobot.Reculer(50);
            Actionneur.AtomStacker.DoDropLeftAll();

            Robots.GrosRobot.Avancer(200);

            Actionneur.AtomUnloaderLeft.DoLauncherPrepare();
            Actionneur.AtomUnloaderLeft.DoLauncherInside();
            Actionneur.AtomUnloaderLeft.DoUnloaderStore();

            Actionneur.AtomStacker.DoBackBlock();

            Thread.Sleep(500);

            Robots.GrosRobot.PivotGauche(180);
        }

        int cpt9 = 0;

        private void Button9Click()
        {
            cpt9++;

            if(cpt9 % 2 == 0)
                Robots.GrosRobot.PivotGauche(360);
            else
                Robots.GrosRobot.PivotDroite(360);
        }
        private void Button10Click()
        {
            Robots.GrosRobot.Stop(Robots.GrosRobot.AsserActif ? StopMode.Freely : StopMode.Abrupt);
        }

        void RecGoBot_ButtonChange(SensorOnOffID btn, bool state)
        {
            if (Plateau.Strategy == null || (Plateau.Strategy != null && !Plateau.Strategy.IsRunning))
            {
                if (state)
                {
                    switch (btn)
                    {
                        case SensorOnOffID.Bouton1:
                            Button1Click();
                            break;
                        case SensorOnOffID.Bouton2:
                            Button2Click();
                            break;
                        case SensorOnOffID.Bouton3:
                            Button3Click();
                            break;
                        case SensorOnOffID.Bouton4:
                            Button4Click();
                            break;
                        case SensorOnOffID.Bouton5:
                            Button5Click();
                            break;
                        case SensorOnOffID.Bouton6:
                            Button6Click();
                            break;
                        case SensorOnOffID.Bouton7:
                            Button7Click();
                            break;
                        case SensorOnOffID.Bouton8:
                            Button8Click();
                            break;
                        case SensorOnOffID.Bouton9:
                            Button9Click();
                            break;
                        case SensorOnOffID.Bouton10:
                            Button10Click();
                            break;
                        case SensorOnOffID.LSwitch1:
                            _switch1 = true;
                            SwitchChanged();
                            break;
                        case SensorOnOffID.LSwitch2:
                            _switch2 = true;
                            SwitchChanged();
                            break;
                        case SensorOnOffID.LSwitch3:
                            _switch3 = true;
                            SwitchChanged();
                            break;
                        case SensorOnOffID.LSwitch4:
                            _switch4 = true;
                            SwitchChanged();
                            break;
                    }
                }
                else
                {
                    switch (btn)
                    {
                        case SensorOnOffID.LSwitch1:
                            _switch1 = false;
                            SwitchChanged();
                            break;
                        case SensorOnOffID.LSwitch2:
                            _switch2 = false;
                            SwitchChanged();
                            break;
                        case SensorOnOffID.LSwitch3:
                            _switch3 = false;
                            SwitchChanged();
                            break;
                        case SensorOnOffID.LSwitch4:
                            _switch4 = false;
                            SwitchChanged();
                            break;
                    }
                }
            }
        }

        internal void ChangeLed(LedID led)
        {
            try
            {
                SetLed(led, ledsStatus[led] == LedStatus.Vert ? LedStatus.Off : LedStatus.Vert);
            }
            catch (Exception e)
            {

            }
        }

        void SwitchChanged()
        {
            //if (!_switch1 && !_switch2 && !_switch3 && !_switch4)
            //{
            //    Plateau.Strategy = new Strategies.StrategyMatch();
            //    Buzz(0, 0);
            //}
            //else if (!_switch1 && !_switch2 && _switch3 && !_switch4)
            //{
            //    Plateau.Strategy = new Strategies.StrategyMinimumScore();
            //    Buzz(0, 0);
            //}
            //else if (!_switch1 && !_switch2 && !_switch3 && _switch4)
            //{
            //    Plateau.Strategy = new Strategies.StrategyRoundTrip();
            //    Buzz(0, 0);
            //}
            //else
            //{
            //    Buzz(5000, 200);
            //}

            //Robots.GrosRobot.MajGraphFranchissable(Plateau.ListeObstacles);
        }

        void ChangeLedConnection(bool connected, LedID led)
        {
            try
            {
                if (ledsStatus[led] == RecGoBot.LedStatus.Off)
                    SetLed(led, connected ? RecGoBot.LedStatus.Vert : RecGoBot.LedStatus.Rouge);
                else
                    SetLed(led, RecGoBot.LedStatus.Off);
            }
            catch (Exception)
            {
                Console.WriteLine("Problème LED");
            }
        }

        void ConnexionCheck_SendConnectionTest(Connection sender)
        {
            ChangeLedConnection(sender.ConnectionChecker.Connected, ledConnexionState[sender]);
        }

        void connexion_NouvelleTrameRecue(Frame trameRecue)
        {
            if (trameRecue[1] == (byte)UdpFrameFunction.RetourCapteurOnOff)
            {
                SensorOnOffID but;

                bool pushed = trameRecue[3] > 0;

                switch (trameRecue[2])
                {
                    case 0:
                        but = SensorOnOffID.Bouton2;
                        break;
                    case 1:
                        but = SensorOnOffID.Bouton4;
                        break;
                    case 2:
                        but = SensorOnOffID.Bouton1;
                        break;
                    case 3:
                        but = SensorOnOffID.Bouton3;
                        break;
                    case 4:
                        but = SensorOnOffID.Bouton10;
                        break;
                    case 5:
                        but = SensorOnOffID.Bouton8;
                        break;
                    case 6:
                        but = SensorOnOffID.Bouton9;
                        break;
                    case 7:
                        but = SensorOnOffID.Bouton7;
                        break;
                    case 8:
                        but = SensorOnOffID.Bouton6;
                        break;
                    case 9:
                        but = SensorOnOffID.CouleurEquipe;
                        break;
                    case 10:
                        but = SensorOnOffID.Jack;
                        break;
                    case 11:
                        but = SensorOnOffID.Bouton5;
                        break;
                    case 12:
                        but = SensorOnOffID.LSwitch1;
                        break;
                    case 13:
                        but = SensorOnOffID.LSwitch2;
                        break;
                    case 14:
                        but = SensorOnOffID.LSwitch3;
                        break;
                    case 15:
                        but = SensorOnOffID.LSwitch4;
                        break;
                    case 16:
                        but = SensorOnOffID.ChaiPas;
                        break;
                    case 17:
                        but = SensorOnOffID.ChaiPlus;
                        break;
                    case 18:
                        but = SensorOnOffID.PresenceDroite;
                        break;
                    case 19:
                        but = SensorOnOffID.PresenceGauche;
                        break;
                    default:
                        return;
                }

                if (but == SensorOnOffID.CouleurEquipe)
                    ColorChange?.Invoke((MatchColor)trameRecue[3]);

                else if (but == SensorOnOffID.Jack)
                {
                    AllDevices.RecGoBot.SetLed(LedID.DebugB1, pushed ? RecGoBot.LedStatus.Vert : RecGoBot.LedStatus.Rouge);
                    JackChange?.Invoke(pushed);
                }

                else ButtonChange?.Invoke(but, pushed);
            }

            if (trameRecue[1] == (byte)UdpFrameFunction.RetourPositionCodeur)
            {
                if (trameRecue[2] == (byte)CodeurID.Manuel)
                {
                    PositionCodeur = trameRecue[3];
                    PositionCodeur *= 256;
                    PositionCodeur += trameRecue[4];
                    PositionCodeur *= 256;
                    PositionCodeur += trameRecue[5];
                    PositionCodeur *= 256;
                    PositionCodeur += trameRecue[6];

                    if (semCodeur != null)
                        semCodeur.Release();
                }
            }
        }

        public void SetLed(LedID led, LedStatus state)
        {
            ledsStatus[led] = state;
            connexion.SendMessage(UdpFrameFactory.SetLed(led, state));

            LedChange?.Invoke(led, state);
        }

        public void SetLedColor(Color color)
        {
            connexion.SendMessage(UdpFrameFactory.SetLedColor(color));
        }

        public void Buzz(int frequency, byte volume)
        {
            connexion.SendMessage(UdpFrameFactory.Buzz(frequency, volume));
        }

        public void Buzz()
        {
            ThreadManager.CreateThread(link =>
            {
                link.Name = "Buzz";
                connexion.SendMessage(UdpFrameFactory.Buzz(5000, 200));
                Thread.Sleep(200);
                connexion.SendMessage(UdpFrameFactory.Buzz(0, 200));
            }).StartThread();
        }

        public void Buzz(String morse)
        {
            ThreadManager.CreateThread(link =>
            {
                link.Name = "Buzz " + morse;

                foreach (char c in morse)
                {
                    connexion.SendMessage(UdpFrameFactory.Buzz(5000, 200));
                    if (c == '.')
                        Thread.Sleep(100);
                    else
                        Thread.Sleep(200);
                    connexion.SendMessage(UdpFrameFactory.Buzz(0, 200));
                    Thread.Sleep(100);
                }
            }).StartThread();
        }

        public uint GetCodeurPosition()
        {
            Frame t = UdpFrameFactory.CodeurPosition(Board.RecGB, CodeurID.Manuel);
            semCodeur = new Semaphore(0, int.MaxValue);
            Connections.ConnectionGB.SendMessage(t);

            semCodeur.WaitOne(100);
            semCodeur.Dispose();
            semCodeur = null;

            return PositionCodeur;
        }
    }
}
