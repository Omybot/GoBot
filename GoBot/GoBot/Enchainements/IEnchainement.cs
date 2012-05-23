using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GoBot.Enchainements
{
    interface IEnchainement
    {
        Color GetCouleur();
        void SetCouleur(Color couleur);
        void Executer();
        void Stop();
        void Reprendre(int reculade);
    }
}
