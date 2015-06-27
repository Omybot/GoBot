using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.Calculs.Formes
{
    public interface IForme
    {
        /// <summary>
        /// Teste si la Forme courante croise la Forme donnée
        /// </summary>
        /// <param name="droite">Forme testés</param>
        /// <returns>Vrai si la Forme courante croise la Forme donnée</returns>
        bool Croise(IForme forme);

        /// <summary>
        /// Teste si la Forme courant contient la Forme donnée
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Vrai si le Cercle courant contient la Forme testée</returns>
        bool Contient(IForme forme);

        /// <summary>
        /// Retourne la distance minimum entre la Forme courante et la Forme donnée
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Distance entre la Forme actuelle et la Forme testée. Si les deux Formes se croisent la distance est de 0.</returns>
        double Distance(IForme forme);

        void Tourner(Angle angle, PointReel centreRotation = null);

        void Translater(double dx, double dy);

        List<PointReel> Croisements(IForme forme);

        double Surface { get; }

        PointReel BaryCentre { get; }
    }
}
