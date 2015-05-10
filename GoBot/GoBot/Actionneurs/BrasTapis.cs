using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class BrasTapis
    {
        public void Descendre()
        {
            Config.CurrentConfig.ServoTapisBras.Positionner(Config.CurrentConfig.ServoTapisBras.PositionDepose);
        }

        public void Monter()
        {
            Config.CurrentConfig.ServoTapisBras.Positionner(Config.CurrentConfig.ServoTapisBras.PositionRange);
        }

        public void LacherTapisDroit()
        {
            Config.CurrentConfig.ServoTapisPinceDroite.Positionner(Config.CurrentConfig.ServoTapisPinceDroite.PositionOuvert);
        }

        public void LacherTapisGauche()
        {
            Config.CurrentConfig.ServoTapisPinceGauche.Positionner(Config.CurrentConfig.ServoTapisPinceGauche.PositionOuvert);
        }

        public void SerrerTapisDroit()
        {
            Config.CurrentConfig.ServoTapisPinceDroite.Positionner(Config.CurrentConfig.ServoTapisPinceDroite.PositionFerme);
        }

        public void SerrerTapisGauche()
        {
            Config.CurrentConfig.ServoTapisPinceGauche.Positionner(Config.CurrentConfig.ServoTapisPinceGauche.PositionFerme);
        }

        public void PoserTapisDroit()
        {
            Descendre();
            Thread.Sleep(100);
            LacherTapisDroit();
            Thread.Sleep(300);
            Monter();
            Thread.Sleep(50);
            Descendre();
            Thread.Sleep(50);
            Monter();
            Thread.Sleep(200);
        }

        public void PoserTapisGauche()
        {
            Descendre();
            Thread.Sleep(100);
            LacherTapisGauche();
            Thread.Sleep(300);
            Monter();
            Thread.Sleep(50);
            Descendre();
            Thread.Sleep(50);
            Monter();
            Thread.Sleep(200);
        }
    }
}
