using System.Drawing;
using System.Windows.Forms;

namespace Composants
{
    public partial class BinaryGraph : UserControl
    {
        public BinaryGraph()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ajoute un point au graph
        /// </summary>
        /// <param name="value">Valeur binaire à ajouter</param>
        public void AddPoint(bool value)
        {
            if (value)
                led.Color = Color.LimeGreen;
            else
                led.Color = Color.Red;

            graph.AddPoint("Bin", value ? 1 : 0, Color.DodgerBlue);
            graph.DrawCurves();
        }
    }
}
