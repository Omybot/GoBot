using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace Composants
{
    public partial class GraphPanel : UserControl
    {
        public enum ScaleType
        {
            DynamicGlobal, // Le min et le max sont fixés par la courbe la plus haute et la courbe la plus basse
            DynamicPerCurve, // Le min et le max sont propre à chaque courbe qui a donc sa propre échelle. Min et max ne sont pas affichés dans ce cas
            Fixed // Le min et le max sont fixés par MinLimit et MaxLimit
        }

        private Dictionary<String, List<double>> CurvesData { get; set; }
        private Dictionary<String, bool> CurvesDisplayed { get; set; }
        private Dictionary<String, Pen> CurvesPen { get; set; }

        /// <summary>
        /// Définit le type d'échelle utilisée par le graph
        /// </summary>
        public ScaleType GraphScale {get;set;}
        
        /// <summary>
        /// Définit la limite inférieur du graph dans le cas où l'échelle est fixe
        /// </summary>
        public double MinLimit { get; set; }

        /// <summary>
        /// Définit la limite supérieure du graph dans le cas où l'échelle est fixe
        /// </summary>
        public double MaxLimit { get; set; }

        /// <summary>
        /// Définit si le nom des courbes est affiché
        /// </summary>
        public bool NamesVisible { get; set; }

        /// <summary>
        /// Définit si les limites de l'échelle sont affichées dans le cas où l'échelle est commune
        /// </summary>
        public bool LimitsVisible { get; set; }

        public GraphPanel()
        {
            InitializeComponent();
            CurvesData = new Dictionary<string, List<double>>();
            CurvesDisplayed = new Dictionary<string, bool>();

            CurvesPen = new Dictionary<string, Pen>();
            GraphScale = ScaleType.DynamicGlobal;
            BackColor = Color.White;
            MaxLimit = 1;
            MinLimit = 0;
        }

        /// <summary>
        /// Ajouter un point à la courbe spécifiée
        /// Ajoute la courbe si elle n'existe pas encore
        /// </summary>
        /// <param name="curveName">Nom de la courbe auquel ajouter un point</param>
        /// <param name="value">Valeur à ajouter à la courbe</param>
        /// <param name="col">Couleur à associer à la courbe (null pour ne pas changer la couleur)</param>
        public void AddPoint(String curveName, double value, Color? col = null)
        {
            lock (CurvesData)
            {
                List<double> data;
                if (CurvesData.ContainsKey(curveName))
                {
                    data = CurvesData[curveName];
                    if (col != null)
                        CurvesPen[curveName] = new Pen(col.Value);
                }
                else
                {
                    data = new List<double>();
                    CurvesData.Add(curveName, data);
                    CurvesDisplayed.Add(curveName, true);
                    if (col != null)
                        CurvesPen.Add(curveName, new Pen(col.Value));
                    else
                        CurvesPen.Add(curveName, new Pen(Color.Black));
                }

                data.Add(value);

                while (data.Count > pictureBox.Width)
                    data.RemoveAt(0);
            }
        }

        /// <summary>
        /// Met à jour l'affichage des courbes
        /// </summary>
        public void DrawCurves()
        {
            lock (CurvesData)
            {

                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics gTemp = Graphics.FromImage(bmp);

                gTemp.Clear(BackColor);

                double min = double.MaxValue;
                double max = double.MinValue;

                if (GraphScale == ScaleType.Fixed)
                {
                    min = MinLimit;
                    max = MaxLimit;
                }
                else if (GraphScale == ScaleType.DynamicGlobal)
                {
                    foreach (KeyValuePair<String, List<double>> courbe in CurvesData)
                    {
                        if (CurvesDisplayed[courbe.Key] && courbe.Value.Count > 1)
                        {
                            min = Math.Min(min, courbe.Value.Min());
                            max = Math.Max(max, courbe.Value.Max());
                        }
                    }
                }

                double coef = max == min ? 1 : (float)(pictureBox.Height - 1) / (max - min);

                gTemp.SmoothingMode = SmoothingMode.AntiAlias;

                foreach (KeyValuePair<String, List<double>> courbe in CurvesData)
                {
                    if (CurvesDisplayed[courbe.Key] && courbe.Value.Count > 1)
                    {
                        if (GraphScale == ScaleType.DynamicPerCurve)
                        {
                            coef = courbe.Value.Max() == courbe.Value.Min() ? 1 : (float)(pictureBox.Height - 1) / (courbe.Value.Max() - courbe.Value.Min());
                            min = courbe.Value.Min();
                        }

                        for (int i = 1; i < courbe.Value.Count; i++)
                        {
                            gTemp.DrawLine(CurvesPen[courbe.Key], new Point(i - 1, (int)((pictureBox.Height - 1) - coef * (courbe.Value[i - 1] - min))), new Point(i, (int)((pictureBox.Height - 1) - coef * (courbe.Value[i] - min))));
                        }
                    }
                }

                gTemp.SmoothingMode = SmoothingMode.None;

                Font myFont = new Font("Calibri", 9);

                if (NamesVisible)
                {
                    int y = pictureBox.Height - 20;
                    foreach (KeyValuePair<String, List<double>> courbe in CurvesData)
                    {
                        if (CurvesDisplayed[courbe.Key])
                        {
                            Brush b = new SolidBrush(CurvesPen[courbe.Key].Color);
                            gTemp.DrawString(courbe.Key, myFont, b, 2, y);
                            y -= 10;
                            b.Dispose();
                        }
                    }
                }

                if (GraphScale != ScaleType.DynamicPerCurve && LimitsVisible)
                {
                    String minText = min.ToString("G3");
                    String maxText = max.ToString("G3");
                    SizeF minSize = gTemp.MeasureString(minText, myFont);
                    SizeF maxSize = gTemp.MeasureString(maxText, myFont);

                    gTemp.DrawString(minText, myFont, Brushes.Black, 2 - minSize.Width, 2);
                    gTemp.DrawString(maxText, myFont, Brushes.Black, 2 - maxSize.Width, bmp.Height - maxSize.Height - 2);
                }

                pictureBox.Image = bmp;
                myFont.Dispose();
            }
        }

        /// <summary>
        /// Supprimer une courbe
        /// </summary>
        /// <param name="curveName">Nom de la courbe à supprimer</param>
        public void DeleteCurve(String curveName)
        {
            if (CurvesData.ContainsKey(curveName))
            {
                CurvesData.Remove(curveName);
                CurvesPen.Remove(curveName);
            }
            if (CurvesDisplayed.ContainsKey(curveName))
            {
                CurvesDisplayed.Remove(curveName);
            }
        }

        /// <summary>
        /// Masque ou affiche une courbe
        /// </summary>
        /// <param name="curveName">Nom de la courbe à masquer ou afficher</param>
        public void ShowCurve(String curveName, bool showed = true)
        {
            if (CurvesDisplayed.ContainsKey(curveName))
            {
                CurvesDisplayed[curveName] = !showed;
            }
        }
    }
}
