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

        private Timer TimerDisplay;
        private Color PreviousColor;
        private String PreviousText;

        public LabelPlus()
        {
            InitializeComponent();
        }

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
