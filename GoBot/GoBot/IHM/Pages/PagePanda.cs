using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using GoBot.Communications;
using GoBot.Devices;
using GoBot.IHM.Forms;
using GoBot.Threading;

namespace GoBot.IHM.Pages
{
    public partial class PagePanda : UserControl
    {
        private ThreadLink _linkBattery;

        public PagePanda()
        {
            InitializeComponent();
        }

        private void PagePanda_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                Connections.AllConnections.ForEach(c => c.ConnectionChecker.ConnectionStatusChange += ConnectionChecker_ConnectionStatusChange);
                AllDevices.LidarAvoid.ConnectionChecker.ConnectionStatusChange += LidarAvoid_ConnectionStatusChange;

                SetPicImage(picLidar, Devices.AllDevices.LidarAvoid.ConnectionChecker.Connected);
                SetPicImage(picIO, Connections.ConnectionIO.ConnectionChecker.Connected);
                SetPicImage(picMove, Connections.ConnectionMove.ConnectionChecker.Connected);
                SetPicImage(picCAN, Connections.ConnectionCanBridge.ConnectionChecker.Connected);
                SetPicImage(picServo1, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo1].ConnectionChecker.Connected);
                SetPicImage(picServo2, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo2].ConnectionChecker.Connected);
                SetPicImage(picServo3, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo3].ConnectionChecker.Connected);
                SetPicImage(picServo4, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo4].ConnectionChecker.Connected);
                SetPicImage(picServo5, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo5].ConnectionChecker.Connected);
                SetPicImage(picServo6, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo6].ConnectionChecker.Connected);

                _linkBattery = ThreadManager.CreateThread(link => UpdateBatteryIcon());
                _linkBattery.StartInfiniteLoop(1000);

                pagePandaMatch.CalibrationDone += PagePandaMatch_CalibrationDone;
            }
        }

        private void PagePandaMatch_CalibrationDone()
        {
            tabControlPanda.InvokeAuto(() => ChangePageDelay());
        }

        private void ChangePageDelay(int delayMs = 500)
        {
            Thread.Sleep(500); tabControlPanda.SelectedIndex += 1;
        }

        private void UpdateBatteryIcon()
        {
            _linkBattery?.RegisterName();

            picBattery.InvokeAuto(() =>
            {
                if (!Robots.Simulation && !Connections.ConnectionIO.ConnectionChecker.Connected)
                {
                    picBattery.Image = Properties.Resources.BatteryUnknow96;
                    lblBattery.Text = ("--,--") + "V";
                }
                else
                {
                    double voltage = Robots.MainRobot.BatterieVoltage;

                    if (voltage > Config.CurrentConfig.BatterieRobotVert)
                        picBattery.Image = Properties.Resources.BatteryFull96;
                    else if (voltage > Config.CurrentConfig.BatterieRobotOrange)
                        picBattery.Image = Properties.Resources.BatteryMid96;
                    else if (voltage > Config.CurrentConfig.BatterieRobotRouge)
                        picBattery.Image = Properties.Resources.BatteryLow96;
                    else if (voltage > Config.CurrentConfig.BatterieRobotCritique)
                        picBattery.Image = Properties.Resources.BatteryCritical96;
                    else
                        picBattery.Image = Properties.Resources.BatteryUnknow96;

                    lblBattery.Text = voltage.ToString("00.00") + "V";
                }
            });
        }

        private void LidarAvoid_ConnectionStatusChange(Connection sender, bool connected)
        {
            SetPicImage(picLidar, connected);
        }

        private void ConnectionChecker_ConnectionStatusChange(Connection sender, bool connected)
        {
            if (sender == Connections.ConnectionIO)
                SetPicImage(picIO, connected);
            else if (sender == Connections.ConnectionMove)
                SetPicImage(picMove, connected);
            else if (sender == Connections.ConnectionCanBridge)
                SetPicImage(picCAN, connected);
            else if (sender == Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo1])
                SetPicImage(picServo1, connected);
            else if (sender == Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo2])
                SetPicImage(picServo2, connected);
            else if (sender == Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo3])
                SetPicImage(picServo3, connected);
            else if (sender == Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo4])
                SetPicImage(picServo4, connected);
            else if (sender == Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo5])
                SetPicImage(picServo5, connected);
            else if (sender == Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo6])
                SetPicImage(picServo6, connected);
        }

        private static void SetPicImage(PictureBox pic, bool ok)
        {
            pic.Image = ok ? Properties.Resources.ValidOk48 : Properties.Resources.ValidNok48;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FormConfirm form = new FormConfirm();

            if (form.ShowDialog() == DialogResult.Yes)
                this.ParentForm.Close();

            form.Dispose();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            tabControlPanda.SelectedIndex = (tabControlPanda.SelectedIndex + 1) % tabControlPanda.TabCount;
        }

        #region Buttons style

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            btnClose.Location = new Point(btnClose.Location.X + 2, btnClose.Location.Y + 2);
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            btnClose.Location = new Point(btnClose.Location.X - 2, btnClose.Location.Y - 2);
        }

        private void btnNextPage_MouseDown(object sender, MouseEventArgs e)
        {
            btnNextPage.Location = new Point(btnNextPage.Location.X + 2, btnNextPage.Location.Y + 2);
        }

        private void btnNextPage_MouseUp(object sender, MouseEventArgs e)
        {
            btnNextPage.Location = new Point(btnNextPage.Location.X - 2, btnNextPage.Location.Y - 2);
        }

        #endregion

        private void tabControlPanda_SelectedIndexChanged(object sender, EventArgs e)
        {
            pagePandaLidar.LidarEnable(tabControlPanda.SelectedTab == tabPandaLidar);
        }
    }
}
