using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace GoBot.Actionneurs
{
    class BrasLunaire
    {
        public void Stocker()
        {
            Config.CurrentConfig.ServoLunaireMonte.Positionner(Config.CurrentConfig.ServoLunaireMonte.PositionMoyenne);
        }

        public void Sortir()
        {
            Config.CurrentConfig.ServoLunaireChariot.Positionner(Config.CurrentConfig.ServoLunaireChariot.PositionSortie);
        }

        public void Rentrer()
        {
            Config.CurrentConfig.ServoLunaireChariot.Positionner(Config.CurrentConfig.ServoLunaireChariot.PositionRange);
        }

        public void Monter()
        {
            Config.CurrentConfig.ServoLunaireMonte.Positionner(Config.CurrentConfig.ServoLunaireMonte.PositionHaut);
        }

        public void SemiMonter()
        {
            Config.CurrentConfig.ServoLunaireMonte.Positionner(Config.CurrentConfig.ServoLunaireMonte.PositionMoyenne);
        }

        public void Descendre()
        {
            Config.CurrentConfig.ServoLunaireMonte.Positionner(Config.CurrentConfig.ServoLunaireMonte.PositionBas);
        }

        public void Ouvrir()
        {
            Config.CurrentConfig.ServoPinceLunaireSerrageDroit.Positionner(Config.CurrentConfig.ServoPinceLunaireSerrageDroit.PositionOuvert);
            Config.CurrentConfig.ServoPinceLunaireSerrageGauche.Positionner(Config.CurrentConfig.ServoPinceLunaireSerrageGauche.PositionOuvert);
        }

        public void Ranger()
        {
            Config.CurrentConfig.ServoPinceLunaireSerrageDroit.Positionner(Config.CurrentConfig.ServoPinceLunaireSerrageDroit.PositionRange);
            Config.CurrentConfig.ServoPinceLunaireSerrageGauche.Positionner(Config.CurrentConfig.ServoPinceLunaireSerrageGauche.PositionRange);
        }

        public void Fermer()
        {
            Config.CurrentConfig.ServoPinceLunaireSerrageDroit.Positionner(Config.CurrentConfig.ServoPinceLunaireSerrageDroit.PositionFerme);
            Config.CurrentConfig.ServoPinceLunaireSerrageGauche.Positionner(Config.CurrentConfig.ServoPinceLunaireSerrageGauche.PositionFerme);
        }

        public void AttrapageFusee()
        {
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 4; i++)
            {
                Actionneur.BrasLunaire.Sortir();
                Actionneur.BrasLunaire.Ouvrir();
                Actionneur.BrasLunaire.Descendre();
                Thread.Sleep(200);
                Robots.GrosRobot.Reculer(50);
                Actionneur.BrasLunaire.Fermer();
                Thread.Sleep(200);
                Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(100);
                Actionneur.BrasLunaire.Sortir();
                Thread.Sleep(200);
                Actionneur.BrasLunaire.Ranger();
                Thread.Sleep(200);
                Robots.GrosRobot.Avancer(50);
                Actionneur.BrasLunaire.Rentrer();
                Actionneur.BrasLunaire.Monter();
                Thread.Sleep(500);
                Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(1000);
            }

            MessageBox.Show(sw.ElapsedMilliseconds + "ms");
        }

        public void AttrapeModule()
        {
            Ouvrir();
            Descendre();
            Thread.Sleep(300);
            Sortir();
            Thread.Sleep(400);
            Fermer();
            Thread.Sleep(400);
            Monter();
            Rentrer();
            Thread.Sleep(400);
            Ouvrir();
            Thread.Sleep(100);
        }
    }
}
