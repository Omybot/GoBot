using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using GoBot.Communications;

namespace GoBot.IHM
{
    public partial class PanelNumeric : UserControl
    {
        public PanelNumeric()
        {
            InitializeComponent();
        }
        
        public void SetValues(byte mask1, byte mask2)
        {
            graph1.SetValue(mask1);
            graph2.SetValue(mask2);
        }
    }
}
