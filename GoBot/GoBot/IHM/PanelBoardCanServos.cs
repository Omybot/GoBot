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
    public partial class PanelBoardCanServos : UserControl
    {
        private int _boardID;

        public PanelBoardCanServos()
        {
            InitializeComponent();
        }

        public int BoardID
        {
            get { return _boardID; }
            set
            {
                _boardID = value;
                lblTitle.Text = "CAN Servos " + _boardID.ToString();
                lblServo1.Text = Parse((ServomoteurID)(200 + (_boardID - 1) * 4 + 0));
                lblServo2.Text = Parse((ServomoteurID)(200 + (_boardID - 1) * 4 + 1));
                lblServo3.Text = Parse((ServomoteurID)(200 + (_boardID - 1) * 4 + 2));
                lblServo4.Text = Parse((ServomoteurID)(200 + (_boardID - 1) * 4 + 3));
            }
        }

        private String Parse(ServomoteurID servo)
        {
            return servo.ToString().Replace("Unused", "");
        }
        
        public delegate void ServoClickDelegate(ServomoteurID servoNo);
        public event ServoClickDelegate ServoClick;

        private void lblServo1_Click(object sender, EventArgs e)
        {
            ServoClick?.Invoke((ServomoteurID)(200 + (_boardID - 1) * 4 + 0));
        }

        private void lblServo2_Click(object sender, EventArgs e)
        {
            ServoClick?.Invoke((ServomoteurID)(200 + (_boardID - 1) * 4 + 1));
        }

        private void lblServo3_Click(object sender, EventArgs e)
        {
            ServoClick?.Invoke((ServomoteurID)(200 + (_boardID - 1) * 4 + 2));
        }

        private void lblServo4_Click(object sender, EventArgs e)
        {
            ServoClick?.Invoke((ServomoteurID)(200 + (_boardID - 1) * 4 + 3));
        }
    }
}
