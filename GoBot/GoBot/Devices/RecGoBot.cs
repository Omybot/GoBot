using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Communications;
using System.Drawing;
using System.Threading;
using GoBot.Actionneurs;

namespace GoBot.Devices
{
    public class RecGoBot
    {
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

        void RecGoBot_ButtonChange(CapteurOnOffID btn, bool state)
        {
            if (Plateau.Enchainement == null || (Plateau.Enchainement != null && !Plateau.Enchainement.Started))
            {
                if (btn == CapteurOnOffID.Bouton1 && state)
                    Robots.GrosRobot.Stop(Robots.GrosRobot.AsserActif ? StopMode.Freely : StopMode.Abrupt);
                if (btn == CapteurOnOffID.Bouton3 && state)
                    Robots.GrosRobot.DeployerActionnneurs();
                if (btn == CapteurOnOffID.Bouton9 && state)
                    Robots.GrosRobot.RangerActionneurs();
                if (btn == CapteurOnOffID.Bouton8 && state)
                {
                    Actionneurs.Actionneur.BrasLunaire.Descendre();
                    Actionneurs.Actionneur.BrasLunaire.Ouvrir();
                    Actionneurs.Actionneur.BrasLunaire.Avancer();
                }
                if (btn == CapteurOnOffID.Bouton7 && state)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(AttraperUnModuleEtRangerParallel));
                if (btn == CapteurOnOffID.Bouton6 && state)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(EjecterUnModuleEtRangerParallel));
                if (btn == CapteurOnOffID.Bouton5 && state)
                    Recallages.RecallageGrosRobot();
                if (btn == CapteurOnOffID.Bouton4 && state)
                    Robots.GrosRobot.Diagnostic();
                if (btn == CapteurOnOffID.Bouton2 && state)
                {
                    if (Actionneur.Fusee.Armed)
                        Actionneur.Fusee.LancerLaFusee();
                    else
                        Actionneur.Fusee.Armer();
                }
                if (btn == CapteurOnOffID.Bouton10 && state)
                {
                    Actionneur.GestionModuleSupervisee.Reset();
                }
            }
        }

        private void AttraperUnModuleEtRangerParallel(object useless)
        {
            //Actionneurs.Actionneur.GestionModules.AttraperUnModuleEtRanger();
            Actionneur.BrasLunaire.Fermer();
            Thread.Sleep(250);
            Actionneur.GestionModuleSupervisee.AvalerModule();
        }

        private void EjecterUnModuleEtRangerParallel(object useless)
        {
            //Actionneurs.Actionneur.GestionModules.EjecterUnModuleEtRanger();
            Actionneur.GestionModuleSupervisee.DeposerModule();
        }

        void ChangeLedConnection(bool connected, LedID led)
        {
            if (ledsStatus[led] == RecGoBot.LedStatus.Off)
                SetLed(led, connected ? RecGoBot.LedStatus.Vert : RecGoBot.LedStatus.Rouge);
            else
                SetLed(led, RecGoBot.LedStatus.Off);
        }

        void ConnexionCheck_SendConnectionTest(Connection sender)
        {
            ChangeLedConnection(sender.ConnectionChecker.Connected, ledConnexionState[sender]);
        }

        void connexion_NouvelleTrameRecue(Frame trameRecue)
        {
            if (trameRecue[1] == (byte)FonctionTrame.RetourCapteurOnOff)
            {
                CapteurOnOffID but;
                
                switch(trameRecue[2])
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
                    default :
                        return;
                }

                bool pushed = trameRecue[3] > 0;

                if (but == CapteurOnOffID.CouleurEquipe && ColorChange != null)
                    ColorChange((MatchColor)trameRecue[3]);

                else if (but == CapteurOnOffID.Jack && JackChange != null)
                    JackChange(pushed);

                else ButtonChange?.Invoke(but, pushed);
            }

            if(trameRecue[1] == (byte)FonctionTrame.RetourPositionCodeur)
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
            Console.WriteLine(DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Millisecond.ToString("000") +  led.ToString() + " - " + state.ToString());
            ledsStatus[led] = state;
            connexion.SendMessage(TrameFactory.SetLed(led, state));
        }

        public void SetLedColor(Color color)
        {
            connexion.SendMessage(TrameFactory.SetLedColor(color));
        }

        public void Buzz(int frequency, byte volume)
        {
            connexion.SendMessage(TrameFactory.Buzz(frequency, volume));
        }

        public uint GetCodeurPosition()
        {
            Frame t = TrameFactory.CodeurPosition(Carte.RecGB, CodeurID.Manuel);
            semCodeur = new Semaphore(0, int.MaxValue);
            Connections.ConnectionGB.SendMessage(t);

            semCodeur.WaitOne(100);
            semCodeur.Dispose();
            semCodeur = null;

            return PositionCodeur;
        }
    }
}
