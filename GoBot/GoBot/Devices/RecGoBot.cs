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
        public int PositionCodeur { get; protected set; }

        public enum LedStatus
        {
            Off,
            Rouge,
            Orange,
            Vert
        }

        private ConnexionUDP connexion;
        private Dictionary<LedID, LedStatus> ledsStatus;

        public RecGoBot(ConnexionUDP conn)
        {
            connexion = conn;
            connexion.NouvelleTrameRecue += new Connexion.ReceptionDelegate(connexion_NouvelleTrameRecue);

            Connexions.ConnexionIO.ConnexionCheck.TestConnexion += ConnexionCheck_TestConnexionIO;
            Connexions.ConnexionMove.ConnexionCheck.TestConnexion += ConnexionCheck_TestConnexionMove;
            Connexions.ConnexionGB.ConnexionCheck.TestConnexion += ConnexionCheck_TestConnexionGB;

            ledsStatus = new Dictionary<LedID, LedStatus>();
            for (LedID i = LedID.DebugB1; i <= LedID.DebugA1; i++)
                ledsStatus.Add(i, LedStatus.Off);

            ButtonChange += RecGoBot_ButtonChange;
        }

        void RecGoBot_ButtonChange(CapteurOnOffID btn, bool state)
        {
            if (Plateau.Enchainement == null || ( Plateau.Enchainement != null && !Plateau.Enchainement.Started))
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
                    Actionneurs.Actionneur.GestionModules.EjecterUnModuleEtRanger();
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
            }
        }

        private void AttraperUnModuleEtRangerParallel(object useless)
        {
            Actionneurs.Actionneur.GestionModules.AttraperUnModuleEtRanger();
        }

        void ChangeLedConnection(ConnexionUDP conn, LedID led)
        {
            if (ledsStatus[led] == RecGoBot.LedStatus.Off)
                SetLed(led, conn.ConnexionCheck.Connecte ? RecGoBot.LedStatus.Vert : RecGoBot.LedStatus.Rouge);
            else
                SetLed(led, RecGoBot.LedStatus.Off);
        }

        void ConnexionCheck_TestConnexionIO()
        {
            ChangeLedConnection(Connexions.ConnexionIO, LedID.DebugA1);
        }

        void ConnexionCheck_TestConnexionMove()
        {
            ChangeLedConnection(Connexions.ConnexionMove, LedID.DebugA2);
        }

        void ConnexionCheck_TestConnexionGB()
        {
            ChangeLedConnection(Connexions.ConnexionGB, LedID.DebugA3);
        }

        void connexion_NouvelleTrameRecue(Trame trameRecue)
        {
            if (trameRecue[1] == (byte)FonctionTrame.RetourCapteurOnOff)
            {
                CapteurOnOffID but;

                Console.WriteLine(trameRecue[2] + (trameRecue[3]>0 ? " On" : " Off"));

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

                else if (ButtonChange != null)
                    ButtonChange(but, pushed);
            }

            if(trameRecue[1] == (byte)FonctionTrame.RetourPositionCodeur)
            {
                if (trameRecue[2] == (byte)CodeurID.Manuel)
                {
                    PositionCodeur = trameRecue[3];
                    PositionCodeur *= 256;
                    PositionCodeur = trameRecue[4];
                    PositionCodeur *= 256;
                    PositionCodeur = trameRecue[5];
                    PositionCodeur *= 256;
                    PositionCodeur = trameRecue[6];

                    if (semCodeur != null)
                        semCodeur.Release();
                }
            }
        }

        public void SetLed(LedID led, LedStatus state)
        {
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

        public int GetCodeurPosition()
        {
            Trame t = TrameFactory.CodeurPosition(Carte.RecGB, CodeurID.Manuel);
            semCodeur = new Semaphore(0, int.MaxValue);
            Connexions.ConnexionGB.SendMessage(t);

            semCodeur.WaitOne(100);
            semCodeur.Dispose();
            semCodeur = null;

            return PositionCodeur;
        }
    }
}
