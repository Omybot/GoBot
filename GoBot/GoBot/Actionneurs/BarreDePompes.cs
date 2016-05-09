using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    class BarreDePompes
    {
        public void Aspirer()
        {
            Robots.GrosRobot.MoteurVitesse(MoteurID.PompeBarre, Config.CurrentConfig.PompeBarre.ValeurAspiration);
        }

        public void Stop()
        {
            Robots.GrosRobot.MoteurVitesse(MoteurID.PompeBarre, Config.CurrentConfig.PompeBarre.ValeurStop);
        }

        public void Maintien()
        {
            Robots.GrosRobot.MoteurVitesse(MoteurID.PompeBarre, Config.CurrentConfig.PompeBarre.ValeurMaintien);
        }
    }
}
