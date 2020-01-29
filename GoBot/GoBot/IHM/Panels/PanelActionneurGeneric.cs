using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace GoBot.IHM
{
    public partial class PanelActionneurGeneric : UserControl
    {
        private object obj;

        public PanelActionneurGeneric()
        {
            InitializeComponent();
        }

        public void SetObject(Object o)
        {
            Type t = o.GetType();
            obj = o;
            int i = 25;

            lblName.Text = t.Name;
            
            foreach (MethodInfo method in t.GetMethods().Where(m => m.Name.StartsWith("Do")).OrderBy(s => s.Name))
            {
                Button b = new Button();
                b.SetBounds(5, i, 120, 22);
                b.Tag = method;
                b.Text = method.Name.Substring(2);
                b.Click += b_Click;
                Controls.Add(b);
                i += 26;
            }
        }

        void b_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Color oldColor = b.BackColor;

            b.BackColor = Color.LightGreen;
            Threading.ThreadManager.CreateThread(link =>
            {
                link.Name = b.Text;
                MethodInfo method = ((MethodInfo)((Button)sender).Tag);
                object[] parameters = method.GetParameters().Count() > 0 ? new Object[] { false } : null;
                method.Invoke(obj, parameters);
                b.InvokeAuto(() => b.BackColor = oldColor);
            }).StartThread();
        }

        private void PanelActionneurGeneric_Load(object sender, EventArgs e)
        {
            BorderStyle = BorderStyle.None;
        }
    }
}
