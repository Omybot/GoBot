using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    class BrasAspirateur
    {
        public void PositionAspire()
        {
            Config.CurrentConfig.ServoAspirateurCoude.Positionner(Config.CurrentConfig.ServoAspirateurCoude.PositionAspiration);
            Config.CurrentConfig.ServoAspirateurEpaule.Positionner(Config.CurrentConfig.ServoAspirateurEpaule.PositionAspiration);
        }

        public void PositionRange()
        {
            Config.CurrentConfig.ServoAspirateurCoude.Positionner(Config.CurrentConfig.ServoAspirateurCoude.PositionRange);
            Config.CurrentConfig.ServoAspirateurEpaule.Positionner(Config.CurrentConfig.ServoAspirateurEpaule.PositionRange);
        }

        public void Aspirer()
        {
            Config.CurrentConfig.ServoAspirateurTurbine.Positionner(Config.CurrentConfig.ServoAspirateurTurbine.Aspiration);
        }

        public void Maintenir()
        {
            Config.CurrentConfig.ServoAspirateurTurbine.Positionner(Config.CurrentConfig.ServoAspirateurTurbine.Maintien);
        }

        public void Arreter()
        {
            Config.CurrentConfig.ServoAspirateurTurbine.Positionner(Config.CurrentConfig.ServoAspirateurTurbine.Eteint);
        }

        public void PositionDepose()
        {
            Config.CurrentConfig.ServoAspirateurCoude.Positionner(Config.CurrentConfig.ServoAspirateurCoude.PositionAspiration);
        }
    }
}
