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
        public void Sortir()
        {
            Config.CurrentConfig.ServoLunaireAvance.Positionner(Config.CurrentConfig.ServoLunaireAvance.PositionSortie);
        }
        public void SemiSortir()
        {
            Config.CurrentConfig.ServoLunaireAvance.Positionner(Config.CurrentConfig.ServoLunaireAvance.PositionSemiSortie);
        }

        public void Rentrer()
        {
            Config.CurrentConfig.ServoLunaireAvance.Positionner(Config.CurrentConfig.ServoLunaireAvance.PositionRange);
        }

        public void Monter()
        {
            Config.CurrentConfig.ServoLunaireMonte.Positionner(Config.CurrentConfig.ServoLunaireMonte.PositionHaut);
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

        public void Fermer()
        {
            Config.CurrentConfig.ServoPinceLunaireSerrageDroit.Positionner(Config.CurrentConfig.ServoPinceLunaireSerrageDroit.PositionFerme);
            Config.CurrentConfig.ServoPinceLunaireSerrageGauche.Positionner(Config.CurrentConfig.ServoPinceLunaireSerrageGauche.PositionFerme);
        }

        public void SemiOuvrir()
        {
            Config.CurrentConfig.ServoPinceLunaireSerrageDroit.Positionner(Config.CurrentConfig.ServoPinceLunaireSerrageDroit.PositionSemiOuvert);
            Config.CurrentConfig.ServoPinceLunaireSerrageGauche.Positionner(Config.CurrentConfig.ServoPinceLunaireSerrageGauche.PositionSemiOuvert);
        }

        public void SemiFermer()
        {
            SemiOuvrir();
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
                Actionneur.BrasLunaire.SemiFermer();
                Thread.Sleep(200);
                Actionneur.BrasLunaire.SemiSortir();
                Thread.Sleep(200);
                Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(100);
                Actionneur.BrasLunaire.Sortir();
                Thread.Sleep(200);
                Actionneur.BrasLunaire.Fermer();
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
    }
}
