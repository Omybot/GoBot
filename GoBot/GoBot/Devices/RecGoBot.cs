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

namespace GoBot.Devices
{
    public class RecGoBot
    {
        private bool _switch1, _switch2, _switch3, _switch4;

        public delegate void ButtonChangeDelegate(CapteurOnOffID btn, Boolean state);
        public event ButtonChangeDelegate ButtonChange;

        public delegate void JackChangeDelegate(Boolean state);
        public event JackChangeDelegate JackChange;

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

        private UDPConnection connexion;
        private Dictionary<LedID, LedStatus> ledsStatus;

        private Dictionary<Connection, LedID> ledConnexionState;

        public RecGoBot(UDPConnection conn)
        {
            connexion = conn;
            connexion.FrameReceived += new Connection.NewFrameDelegate(connexion_NouvelleTrameRecue);

            ledConnexionState = new Dictionary<Connection, LedID>();

            LedID led = LedID.DebugA1;
            foreach (UDPConnection conLed in Connections.AllConnections.OrderBy(c => Connections.GetBoardByConnection(c).ToString()))
            {
                ledConnexionState.Add(conLed, led);
                conLed.ConnectionChecker.SendConnectionTest += ConnexionCheck_SendConnectionTest;
                led++;
            }

            ledsStatus = new Dictionary<LedID, LedStatus>();
            for (LedID i = 0; i <= (LedID)15; i++)
                ledsStatus.Add(i, LedStatus.Off);

            ButtonChange += RecGoBot_ButtonChange;

        }
        
        private void Button1Click()
        {
            while (Plateau.Detections?.Count > 0)
            {
                IShape target = Plateau.Detections.OrderBy(o=> o.Distance(Robots.GrosRobot.Position.Coordinates)).ToList()[0];

                Direction dir = Maths.GetDirection(Robots.GrosRobot.Position, target.Barycenter);

                Config.CurrentConfig.ServoElevation.SendPosition(Config.CurrentConfig.ServoElevation.PositionGround);
                Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionOpen);
                Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionOpen);
                Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionSwallow);

                Thread.Sleep(1000);

                if (dir.angle > 0)
                    Robots.GrosRobot.PivotGauche(dir.angle);
                else
                    Robots.GrosRobot.PivotDroite(-dir.angle);

                Robots.GrosRobot.Avancer((int)(dir.distance - 150));


                Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionClose);
                Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionClose);

                Thread.Sleep(1000);
                Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionStop);
                Config.CurrentConfig.ServoElevation.SendPosition(Config.CurrentConfig.ServoElevation.PositionInside);
                Thread.Sleep(1000);
                Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionOpen);
                Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionOpen);

                Robots.GrosRobot.Reculer(200);
                Thread.Sleep(500);
            }
        }

        private void Button2Click()
        {
            ThreadManager.CreateThread(link =>
            {
                Robots.GrosRobot.RangerActionneurs();
                Thread.Sleep(1000);
                Recallages.RecallageGrosRobot();
            }).StartThread();
        }
        private void Button3Click()
        {
        }
        private void Button4Click()
        {
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
        }
        private void Button7Click()
        {
        }
        private void Button8Click()
        {
        }
        private void Button9Click()
        {
        }
        private void Button10Click()
        {
            Robots.GrosRobot.Stop(Robots.GrosRobot.AsserActif ? StopMode.Freely : StopMode.Abrupt);
        }

        void RecGoBot_ButtonChange(CapteurOnOffID btn, bool state)
        {
            if (Plateau.Strategy == null || (Plateau.Strategy != null && !Plateau.Strategy.IsRunning))
            {
                if (state)
                {
                    switch (btn)
                    {
                        case CapteurOnOffID.Bouton1:
                            Button1Click();
                            break;
                        case CapteurOnOffID.Bouton2:
                            Button2Click();
                            break;
                        case CapteurOnOffID.Bouton3:
                            Button3Click();
                            break;
                        case CapteurOnOffID.Bouton4:
                            Button4Click();
                            break;
                        case CapteurOnOffID.Bouton5:
                            Button5Click();
                            break;
                        case CapteurOnOffID.Bouton6:
                            Button6Click();
                            break;
                        case CapteurOnOffID.Bouton7:
                            Button7Click();
                            break;
                        case CapteurOnOffID.Bouton8:
                            Button8Click();
                            break;
                        case CapteurOnOffID.Bouton9:
                            Button9Click();
                            break;
                        case CapteurOnOffID.Bouton10:
                            Button10Click();
                            break;
                        case CapteurOnOffID.LSwitch1:
                            _switch1 = true;
                            SwitchChanged();
                            break;
                        case CapteurOnOffID.LSwitch2:
                            _switch2 = true;
                            SwitchChanged();
                            break;
                        case CapteurOnOffID.LSwitch3:
                            _switch3 = true;
                            SwitchChanged();
                            break;
                        case CapteurOnOffID.LSwitch4:
                            _switch4 = true;
                            SwitchChanged();
                            break;
                    }
                }
                else
                {
                    switch (btn)
                    {
                        case CapteurOnOffID.LSwitch1:
                            _switch1 = false;
                            SwitchChanged();
                            break;
                        case CapteurOnOffID.LSwitch2:
                            _switch2 = false;
                            SwitchChanged();
                            break;
                        case CapteurOnOffID.LSwitch3:
                            _switch3 = false;
                            SwitchChanged();
                            break;
                        case CapteurOnOffID.LSwitch4:
                            _switch4 = false;
                            SwitchChanged();
                            break;
                    }
                }
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

            //Robots.GrosRobot.MajGraphFranchissable();
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

            }
        }

        void ConnexionCheck_SendConnectionTest(Connection sender)
        {
            ChangeLedConnection(sender.ConnectionChecker.Connected, ledConnexionState[sender]);
        }

        void connexion_NouvelleTrameRecue(Frame trameRecue)
        {
            if (trameRecue[1] == (byte)FrameFunction.RetourCapteurOnOff)
            {
                CapteurOnOffID but;

                switch (trameRecue[2])
                {
                    case 0:
                        but = CapteurOnOffID.Bouton2;
                        break;
                    case 1:
                        but = CapteurOnOffID.Bouton4;
                        break;
                    case 2:
                        but = CapteurOnOffID.Bouton1;
                        break;
                    case 3:
                        but = CapteurOnOffID.Bouton3;
                        break;
                    case 4:
                        but = CapteurOnOffID.Bouton10;
                        break;
                    case 5:
                        but = CapteurOnOffID.Bouton8;
                        break;
                    case 6:
                        but = CapteurOnOffID.Bouton9;
                        break;
                    case 7:
                        but = CapteurOnOffID.Bouton7;
                        break;
                    case 8:
                        but = CapteurOnOffID.Bouton6;
                        break;
                    case 9:
                        but = CapteurOnOffID.CouleurEquipe;
                        break;
                    case 10:
                        but = CapteurOnOffID.Jack;
                        break;
                    case 11:
                        but = CapteurOnOffID.Bouton5;
                        break;
                    case 12:
                        but = CapteurOnOffID.LSwitch1;
                        break;
                    case 13:
                        but = CapteurOnOffID.LSwitch2;
                        break;
                    case 14:
                        but = CapteurOnOffID.LSwitch3;
                        break;
                    case 15:
                        but = CapteurOnOffID.LSwitch4;
                        break;
                    case 16:
                        but = CapteurOnOffID.ChaiPas;
                        break;
                    case 17:
                        but = CapteurOnOffID.ChaiPlus;
                        break;
                    case 18:
                        but = CapteurOnOffID.PresenceDroite;
                        break;
                    case 19:
                        but = CapteurOnOffID.PresenceGauche;
                        break;
                    default:
                        return;
                }

                bool pushed = trameRecue[3] > 0;

                if (but == CapteurOnOffID.CouleurEquipe && ColorChange != null)
                    ColorChange((MatchColor)trameRecue[3]);

                else if (but == CapteurOnOffID.Jack && JackChange != null)
                    JackChange(pushed);

                else ButtonChange?.Invoke(but, pushed);
            }

            if (trameRecue[1] == (byte)FrameFunction.RetourPositionCodeur)
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
            connexion.SendMessage(FrameFactory.SetLed(led, state));
        }

        public void SetLedColor(Color color)
        {
            connexion.SendMessage(FrameFactory.SetLedColor(color));
        }

        public void Buzz(int frequency, byte volume)
        {
            connexion.SendMessage(FrameFactory.Buzz(frequency, volume));
        }

        public uint GetCodeurPosition()
        {
            Frame t = FrameFactory.CodeurPosition(Board.RecGB, CodeurID.Manuel);
            semCodeur = new Semaphore(0, int.MaxValue);
            Connections.ConnectionGB.SendMessage(t);

            semCodeur.WaitOne(100);
            semCodeur.Dispose();
            semCodeur = null;

            return PositionCodeur;
        }
    }
}
