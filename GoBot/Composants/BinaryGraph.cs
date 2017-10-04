using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Composants
{
    public partial class BinaryGraph : UserControl
    {
        public BinaryGraph()
        {
            InitializeComponent();
        }

        public void AddPoint(bool val)
        {
            if (val)
                led.CouleurVert();
            else
                led.CouleurRouge();

            graph.AjouterPoint("Bin", val ? 1 : 0, Color.DodgerBlue);
            graph.DessineCourbes();
        }
    }
}
