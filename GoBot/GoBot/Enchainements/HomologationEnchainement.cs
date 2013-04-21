using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using GoBot.Actions;

namespace GoBot.Enchainements
{
    class HomologationEnchainement : Enchainement
    {
        private Thread th;
        Color couleur;

        public HomologationEnchainement()
        {
            couleur = Color.Red;
        }

        public Color GetCouleur()
        {
            return couleur;
        }

        public void SetCouleur(Color color)
        {
            couleur = color;
        }

        public new void Executer()
        {
            if (couleur == Color.Red)
                th = new Thread(ThreadEnchainementRouge);
            else
                th = new Thread(ThreadEnchainementViolet);

            th.Start();
        }


        private void ThreadEnchainementViolet()
        {
            DateTime debut = DateTime.Now;

            Console.WriteLine((DateTime.Now - debut).TotalSeconds + "s");
        }

        private void ThreadEnchainementRouge()
        {

        }
    }
}
