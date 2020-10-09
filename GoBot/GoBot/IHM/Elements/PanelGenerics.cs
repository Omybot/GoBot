using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace GoBot.IHM
{
    public partial class PanelGenerics : UserControl
    {
        public PanelGenerics()
        {
            InitializeComponent();
            AutoSize = true;
        }

        private void PanelGenerics_Load(object sender, EventArgs e)
        {
            int x = 0;

            if (!Execution.DesignMode)
            {
                Type t = typeof(Actionneurs.Actionneur);

                foreach (PropertyInfo prop in t.GetProperties())
                {
                    PanelActionneurGeneric panel = new PanelActionneurGeneric();
                    Object item = prop.GetValue(null, null);
                    if (item != null)
                    {
                        panel.SetObject(item);
                        panel.SetBounds(x, 0, panel.Width, this.Height);
                        this.Controls.Add(panel);
                        x += 135;
                    }
                }
            }
        }
    }
}
