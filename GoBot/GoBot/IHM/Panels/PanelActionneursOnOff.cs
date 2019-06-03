using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelActionneursOnOff : UserControl
    {
        public PanelActionneursOnOff()
        {
            InitializeComponent();
        }

        private void PanelActionneursOnOff_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                int y = 20;

                foreach (ActionneurOnOffID act in Enum.GetValues(typeof(ActionneurOnOffID)))
                {
                    PanelActionneurOnOff panel = new PanelActionneurOnOff();
                    panel.SetBounds(0, y, panel.Width, panel.Height);
                    panel.SetActionneur(act);
                    y += panel.Height;
                    this.Controls.Add(panel);
                }
            }
        }
    }
}
