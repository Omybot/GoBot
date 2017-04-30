using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class Convoyeur
    {
        public void AvalerUnModule()
        {
            Avaler();
            Thread.Sleep(500);
            Arreter();
        }

        public void Avaler()
        {
            Config.CurrentConfig.MoteurConvoyeur.Positionner(Config.CurrentConfig.MoteurConvoyeur.ValeurAvale);
        }

        public void Recracher()
        {
            Config.CurrentConfig.MoteurConvoyeur.Positionner(Config.CurrentConfig.MoteurConvoyeur.ValeurRecrache);
        }

        public void Arreter()
        {
            Config.CurrentConfig.MoteurConvoyeur.Positionner(Config.CurrentConfig.MoteurConvoyeur.ValeurStop);
        }
    }
}
