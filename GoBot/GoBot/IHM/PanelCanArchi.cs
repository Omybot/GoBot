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
    public partial class PanelCanArchi : UserControl
    {
        public delegate void ServoClickDelegate(ServomoteurID servoNo);
        public event ServoClickDelegate ServoClick;

        public PanelCanArchi()
        {
            InitializeComponent();
        }

        private void panelBoardCanServos_ServoClick(ServomoteurID servoNo)
        {
            ServoClick?.Invoke(servoNo);
        }
    }
}
