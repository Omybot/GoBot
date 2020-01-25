using System;
using System.Windows.Forms;

namespace GoBot.IHM.Pages
{
    public partial class PageServomotors : UserControl
    {
        public PageServomotors()
        {
            InitializeComponent();
        }

        private void panelCan_ServoClick(ServomoteurID servoNo)
        {
            panelServoCan.SetServo(servoNo);
        }

        private void PageServomotors_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                panelBoardCanServos1.SetBoardID(Communications.CAN.CanBoard.CanServo1);
                panelBoardCanServos2.SetBoardID(Communications.CAN.CanBoard.CanServo2);
                panelBoardCanServos3.SetBoardID(Communications.CAN.CanBoard.CanServo3);
                panelBoardCanServos4.SetBoardID(Communications.CAN.CanBoard.CanServo4);
                panelBoardCanServos5.SetBoardID(Communications.CAN.CanBoard.CanServo5);
                panelBoardCanServos6.SetBoardID(Communications.CAN.CanBoard.CanServo6);
            }
        }
    }
}
