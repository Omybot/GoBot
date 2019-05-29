using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Threading;
using System.Threading;
using GoBot.Devices.CAN;
using GoBot.Devices;

namespace GoBot.IHM
{
    public partial class PanelBoardCanServos : UserControl
    {
        private int _boardID;

        private CanServo _servo1, _servo2, _servo3, _servo4;

        public PanelBoardCanServos()
        {
            InitializeComponent();
        }

        public int BoardID
        {
            get { return _boardID; }
            set
            {
                if(_servo1 != null)
                {
                    _servo1.TorqueAlert -= PanelBoardCanServos_TorqueAlert1;
                    _servo2.TorqueAlert -= PanelBoardCanServos_TorqueAlert2;
                    _servo3.TorqueAlert -= PanelBoardCanServos_TorqueAlert3;
                    _servo4.TorqueAlert -= PanelBoardCanServos_TorqueAlert4;
                }

                _boardID = value;

                _servo1 = AllDevices.CanServos[(ServomoteurID)(200 + (_boardID - 1) * 4 + 0)];
                _servo2 = AllDevices.CanServos[(200 + (_boardID - 1) * 4 + 1)];
                _servo3 = AllDevices.CanServos[(200 + (_boardID - 1) * 4 + 2)];
                _servo4 = AllDevices.CanServos[(200 + (_boardID - 1) * 4 + 3)];

                lblTitle.Text = "CAN Servos " + _boardID.ToString();
                lblServo1.Text = Parse((ServomoteurID)(_servo1.ID +200));
                lblServo2.Text = Parse((ServomoteurID)(_servo2.ID + 200));
                lblServo3.Text = Parse((ServomoteurID)(_servo3.ID + 200));
                lblServo4.Text = Parse((ServomoteurID)(_servo4.ID + 200));

                if(!Execution.DesignMode)
                {
                    _servo1.TorqueAlert += PanelBoardCanServos_TorqueAlert1;
                    _servo2.TorqueAlert += PanelBoardCanServos_TorqueAlert2;
                    _servo3.TorqueAlert += PanelBoardCanServos_TorqueAlert3;
                    _servo4.TorqueAlert += PanelBoardCanServos_TorqueAlert4;
                }
            }
        }

        private void PanelBoardCanServos_TorqueAlert1()
        {
            ThreadManager.CreateThread(link =>
            {
                lblServo1.InvokeAuto(() => lblServo1.ForeColor = Color.Red);
                Thread.Sleep(2000);
                lblServo1.InvokeAuto(() => lblServo1.ForeColor = Color.Black);
            }).StartThread();
        }

        private void PanelBoardCanServos_TorqueAlert2()
        {
            ThreadManager.CreateThread(link =>
            {
                lblServo2.InvokeAuto(() => lblServo2.ForeColor = Color.Red);
                Thread.Sleep(2000);
                lblServo2.InvokeAuto(() => lblServo2.ForeColor = Color.Black);
            }).StartThread();
        }

        private void PanelBoardCanServos_TorqueAlert3()
        {
            ThreadManager.CreateThread(link =>
            {
                lblServo3.InvokeAuto(() => lblServo3.ForeColor = Color.Red);
                Thread.Sleep(2000);
                lblServo3.InvokeAuto(() => lblServo3.ForeColor = Color.Black);
            }).StartThread();
        }

        private void PanelBoardCanServos_TorqueAlert4()
        {
            ThreadManager.CreateThread(link =>
            {
                lblServo4.InvokeAuto(() => lblServo4.ForeColor = Color.Red);
                Thread.Sleep(2000);
                lblServo4.InvokeAuto(() => lblServo4.ForeColor = Color.Black);
            }).StartThread();
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
