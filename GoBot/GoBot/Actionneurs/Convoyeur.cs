using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class Convoyeur
    {
        public bool ModuleCharge { get; private set; }

        public Convoyeur()
        {
            ModuleCharge = false;
        }

        public void AvalerUnModule()
        {
            Bloque();
            Avaler();
            Thread.Sleep(500);
            Arreter();
            ModuleCharge = true;
        }

        public void RecracherUnModule()
        {
            Avaler();
            Thread.Sleep(500);
            Arreter();
            Libere();
            ModuleCharge = false;
        }

        public void Bloque()
        {
            Config.CurrentConfig.ServoPlaqueur.Positionner(Config.CurrentConfig.ServoPlaqueur.PositionPlaque);
        }

        public void Libere()
        {
            Config.CurrentConfig.ServoPlaqueur.Positionner(Config.CurrentConfig.ServoPlaqueur.PositionRange);
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

        public void AvaleModule()
        {
            Bloque();
            Thread.Sleep(300);
            Avaler();
            Thread.Sleep(1300);
            Libere();
            Arreter();
        }
    }
}
