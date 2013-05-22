using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GoBot.IHM.Composants
{
    public partial class CtrlGraphique : UserControl
    {
        private Dictionary<String, List<double>> Donnees { get; set; }
        private Dictionary<String, Pen> Pens { get; set; }
        private Semaphore semaphore;

        /// <summary>
        /// Définit si toutes les courbes sont déssinnées sur la même échelle. Si ce n'est pas le cas alors chaque courbe est représentée sur l'intégralité de la hauteur avec son propre min et max.
        /// </summary>
        public bool EchelleCommune { get; set; }

        public CtrlGraphique()
        {
            InitializeComponent();
            Donnees = new Dictionary<string, List<double>>();
            Pens = new Dictionary<string, Pen>();
            EchelleCommune = true;
            BackColor = Color.White;
            semaphore = new Semaphore(1, 1);
        }

        /// <summary>
        /// Ajouter un point à la courbe spécifiée
        /// Ajoute la courbe si elle n'existe pas encore
        /// </summary>
        /// <param name="courbe">Nom de la courbe auquel ajouter un point</param>
        /// <param name="valeur">Valeur à ajouter à la courbe</param>
        /// <param name="couleur">Couleur à associer à la courbe (null pour ne pas changer la couleur)</param>
        public void AjouterPoint(String courbe, double valeur, Color? couleur = null)
        {
            semaphore.WaitOne();

            List<double> liste;
            if(Donnees.ContainsKey(courbe))
            {
                liste = Donnees[courbe];
                if(couleur != null)
                    Pens[courbe] = new Pen(couleur.Value);
            }
            else
            {
                liste = new List<double>();
                Donnees.Add(courbe, liste);
                if(couleur != null)
                    Pens.Add(courbe, new Pen(couleur.Value));
                else
                    Pens.Add(courbe, new Pen(Color.Black));
            }

            while (liste.Count >= pictureBox.Width)
                liste.RemoveAt(0);

            liste.Add(valeur);

            semaphore.Release();
        }

        /// <summary>
        /// Met à jour l'affichage des courbes
        /// </summary>
        public void DessineCourbes()
        {
            semaphore.WaitOne();

            Graphics g = pictureBox.CreateGraphics();

            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);

            Graphics gTemp = Graphics.FromImage(bmp);
            gTemp.Clear(BackColor);

            double min = double.MaxValue;
            double max = double.MinValue;
            double coef = 1;

            if (EchelleCommune)
            {
                foreach (KeyValuePair<String, List<double>> courbe in Donnees)
                {
                    if (courbe.Value.Count > 1)
                    {
                        min = Math.Min(min, courbe.Value.Min());
                        max = Math.Max(max, courbe.Value.Max());
                    }
                }

                lblMax.Text = max.ToString();
                lblMin.Text = min.ToString();
                coef = max == min ? 1 : (float)(pictureBox.Height - 1) / (max - min);
            }
            else
            {
                lblMax.Visible = false;
                lblMin.Visible = false;
            }

            foreach (KeyValuePair<String, List<double>> courbe in Donnees)
            {
                if (courbe.Value.Count > 1)
                {
                    if (!EchelleCommune)
                    {
                        coef = courbe.Value.Max() == courbe.Value.Min() ? 1 : (float)(pictureBox.Height - 1) / (courbe.Value.Max() - courbe.Value.Min());
                        min = courbe.Value.Min();
                    }

                    for (int i = 1; i < courbe.Value.Count; i++)
                    {
                        gTemp.DrawLine(Pens[courbe.Key], new Point(i - 1, (int)((pictureBox.Height - 1) - coef * (courbe.Value[i - 1] - min))), new Point(i, (int)((pictureBox.Height - 1) - coef * (courbe.Value[i] - min))));
                    }
                }
            }

            int y = pictureBox.Height - 20;
            foreach (KeyValuePair<String, List<double>> courbe in Donnees)
            {
                Font police = new System.Drawing.Font("Calibri", 9);
                gTemp.DrawString(courbe.Key, police, new SolidBrush(Pens[courbe.Key].Color), 2, y);
                y -= 10;
            }

            g.DrawImage(bmp, new Point(0, 0));

            semaphore.Release();
        }

        /// <summary>
        /// Supprimer une courbe
        /// </summary>
        /// <param name="nomCourbe">Nom de la courbe à supprimer</param>
        public void SupprimerCourbe(String nomCourbe)
        {
            if (Donnees.ContainsKey(nomCourbe))
            {
                Donnees.Remove(nomCourbe);
                Pens.Remove(nomCourbe);
            }
        }
    }
}
