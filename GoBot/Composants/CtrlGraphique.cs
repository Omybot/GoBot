using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Composants
{
    public partial class CtrlGraphique : UserControl
    {
        private Dictionary<String, List<double>> Donnees { get; set; }
        private Dictionary<String, bool> DonneesAffichees { get; set; }
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
            DonneesAffichees = new Dictionary<string, bool>();

            Pens = new Dictionary<string, Pen>();
            EchelleCommune = true;
            BackColor = Color.White;
            semaphore = new Semaphore(1, 1);
            EchelleFixe = false;
            EchelleMax = 1;
            EchelleMin = 0;
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
                DonneesAffichees.Add(courbe, true);
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

            if (EchelleFixe)
            {
                min = EchelleMin;
                max = EchelleMax;
            }
            else
            {

                if (EchelleCommune)
                {
                        foreach (KeyValuePair<String, List<double>> courbe in Donnees)
                        {
                            if (DonneesAffichees[courbe.Key] && courbe.Value.Count > 1)
                            {
                                min = Math.Min(min, courbe.Value.Min());
                                max = Math.Max(max, courbe.Value.Max());
                            }
                        }
                }
                else
                {
                    lblMax.Visible = false;
                    lblMin.Visible = false;
                }
            }

            lblMax.Text = max.ToString();
            lblMin.Text = min.ToString();
            
            double coef = max == min ? 1 : (float)(pictureBox.Height - 1) / (max - min);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (KeyValuePair<String, List<double>> courbe in Donnees)
            {
                if (DonneesAffichees[courbe.Key] && courbe.Value.Count > 1)
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

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            int y = pictureBox.Height - 20;
            foreach (KeyValuePair<String, List<double>> courbe in Donnees)
            {
                if (DonneesAffichees[courbe.Key])
                {
                    Font police = new System.Drawing.Font("Calibri", 9);
                    gTemp.DrawString(courbe.Key, police, new SolidBrush(Pens[courbe.Key].Color), 2, y);
                    y -= 10;
                    police.Dispose();
                }
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
            if (DonneesAffichees.ContainsKey(nomCourbe))
            {
                DonneesAffichees.Remove(nomCourbe);
            }
        }

        /// <summary>
        /// Masque ou affiche une courbe
        /// </summary>
        /// <param name="nomCourbe">Nom de la courbe à masquer ou afficher</param>
        public void MasquerCourbe(String nomCourbe, bool masque = true)
        {
            if (DonneesAffichees.ContainsKey(nomCourbe))
            {
                DonneesAffichees[nomCourbe] = !masque;
            }
        }

        public bool EchelleFixe { get; set; }
        public double EchelleMin { get; set; }
        public double EchelleMax { get; set; }
    }
}
