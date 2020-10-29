using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using GoBot.BoardContext;
using GoBot.Communications;
using GoBot.Threading;

namespace GoBot.IHM.Pages
{
    public partial class PagePandaTable : UserControl
    {
        public PagePandaTable()
        {
            InitializeComponent();
        }

        private void PagePandaTable_Load(object sender, System.EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                btnTrap.Focus();

                Dessinateur.TableDessinee += Dessinateur_TableDessinee;
            }
        }

        private void Dessinateur_TableDessinee(Image img)
        {
            picTable.BackgroundImage = img;
        }
    }
}
