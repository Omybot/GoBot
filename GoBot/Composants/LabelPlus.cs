using System;
using System.Windows.Forms;
using System.Drawing;

namespace Composants
{
    public partial class LabelPlus : Label
    {        
        
        // Fonctionnalités supplémentaires :
        //
        //      - Afficher un texte pendant une certaine durée
        //              Fonction TextDuring(texte, durée)

        private Timer TimerDisplay { get; set; }
        private Color PreviousColor { get; set; }
        private String PreviousText { get; set; }

        public LabelPlus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permet d'afficher un texte donné dans une couleur donnée pendant un temps donné. Après quoi le texte et la couelru d'origine seront rétablis.
        /// </summary>
        /// <param name="text">Texte à afficher momentanément</param>
        /// <param name="during">Durée d'affichage du texte (ms)</param>
        /// <param name="color">Couleur du texte affiché momentanément</param>
        public void ShowText(String text, int during = 2000, Color? color = null)
        {
            PreviousColor = ForeColor;
            PreviousText = Text;

            if (color.HasValue)
                ForeColor = color.Value;

            Text = text;

            if (TimerDisplay != null)
            {
                if (TimerDisplay.Enabled)
                {
                    TimerDisplay.Stop();
                }
                TimerDisplay.Dispose();
            }

            TimerDisplay = new Timer();
            TimerDisplay.Interval = during;
            TimerDisplay.Tick += new EventHandler(TimerDisplay_Tick);
            TimerDisplay.Enabled = true;
            TimerDisplay.Start();
        }

        void TimerDisplay_Tick(object sender, EventArgs e)
        {
            ForeColor = PreviousColor;
            Text = PreviousText;
            TimerDisplay.Stop();
            Text = "";
        }
    }
}
