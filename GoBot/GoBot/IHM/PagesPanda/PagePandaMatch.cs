using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using GoBot.BoardContext;
using GoBot.Communications;
using GoBot.Threading;

namespace GoBot.IHM.Pages
{
    public partial class PagePandaMatch : UserControl
    {
        public PagePandaMatch()
        {
            InitializeComponent();

            GameBoard.MyColorChange += GameBoard_MyColorChange;
            btnColorLeft.BackColor = GameBoard.ColorLeftBlue;
            btnColorRight.BackColor = GameBoard.ColorRightYellow;
        }

        private void PageMatch_Load(object sender, System.EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                btnTrap.Focus();

                Dessinateur.TableDessinee += Dessinateur_TableDessinee;
                Robots.MainRobot.SensorOnOffChanged += MainRobot_SensorOnOffChanged;
                Connections.AllConnections.ForEach(c => c.ConnectionChecker.ConnectionStatusChange += ConnectionChecker_ConnectionStatusChange);
                Devices.AllDevices.LidarAvoid.ConnectionChecker.ConnectionStatusChange += LidarAvoid_ConnectionStatusChange;
                Devices.AllDevices.LidarGround.ConnectionChecker.ConnectionStatusChange += LidarGround_ConnectionStatusChange;

                SetPicImage(picLidar, Devices.AllDevices.LidarAvoid.ConnectionChecker.Connected);
                //SetPicImage(picLidar2, Devices.AllDevices.LidarGround.ConnectionChecker.Connected);
                SetPicImage(picIO, Connections.ConnectionIO.ConnectionChecker.Connected);
                SetPicImage(picMove, Connections.ConnectionMove.ConnectionChecker.Connected);
                SetPicImage(picCAN, Connections.ConnectionCanBridge.ConnectionChecker.Connected);
                SetPicImage(picServo1, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo1].ConnectionChecker.Connected);
                SetPicImage(picServo2, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo2].ConnectionChecker.Connected);
                SetPicImage(picServo3, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo3].ConnectionChecker.Connected);
                SetPicImage(picServo4, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo4].ConnectionChecker.Connected);
                SetPicImage(picServo5, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo5].ConnectionChecker.Connected);
                SetPicImage(picServo6, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanServo6].ConnectionChecker.Connected);
                //SetPicImage(picAlim, Connections.ConnectionsCan[Communications.CAN.CanBoard.CanAlim].ConnectionChecker.Connected);

                bool jack = Robots.MainRobot.ReadStartTrigger();
                SetPicImage(picStartTrigger, jack);
                btnCalib.Enabled = jack;
            }
        }

        private void LidarAvoid_ConnectionStatusChange(Connection sender, bool connected)
        {
            SetPicImage(picLidar, connected);
        }

        private void LidarGround_ConnectionStatusChange(Connection sender, bool connected)
        {
            //SetPicImage(picLidar2, connected);
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
            //else if (sender == Connections.ConnectionsCan[Communications.CAN.CanBoard.CanAlim])
            //    SetPicImage(picAlim, connected);
        }

        private void MainRobot_SensorOnOffChanged(SensorOnOffID capteur, bool etat)
        {
            if (capteur == SensorOnOffID.StartTrigger)
            {
                SetPicImage(picStartTrigger, etat);
                picCalibration.InvokeAuto(() => picCalibration.Enabled = etat);
            }
        }

        private static void SetPicImage(PictureBox pic, bool ok)
        {
            if (pic.Width > 50)
                pic.Image = ok ? Properties.Resources.ValidOk96 : Properties.Resources.ValidNok96;
            else
                pic.Image = ok ? Properties.Resources.ValidOk48 : Properties.Resources.ValidNok48;
        }

        private void GameBoard_MyColorChange(object sender, EventArgs e)
        {
            Rectangle r = new Rectangle(8, 8, 78, 78);

            Bitmap img = new Bitmap(picColor.Width, picColor.Height);
            Graphics g = Graphics.FromImage(img);
            Brush brush = new LinearGradientBrush(r, ColorPlus.GetIntense(GameBoard.MyColor), ColorPlus.GetPastel(GameBoard.MyColor), 24);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillEllipse(brush, r);
            g.DrawImage(Properties.Resources.Circle96, 0, 0, 96, 96);

            brush.Dispose();
            g.Dispose();

            picColor.Image = img;
        }

        private void Dessinateur_TableDessinee(Image img)
        {
            picTable.BackgroundImage = img;
        }

        private void btnCalib_Click(object sender, System.EventArgs e)
        {
            ThreadManager.CreateThread(link =>
            {
                link.Name = "Calibration";
                Recalibration.Calibration();
                picCalibration.InvokeAuto(() => picCalibration.Image = Properties.Resources.ValidOk96);
            }).StartThread();
            btnTrap.Focus();
        }

        private void btnColorLeft_Click(object sender, EventArgs e)
        {
            GameBoard.MyColor = GameBoard.ColorLeftBlue;
            btnTrap.Focus();
        }

        private void btnColorRight_Click(object sender, EventArgs e)
        {
            GameBoard.MyColor = GameBoard.ColorRightYellow;
            btnTrap.Focus();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            btnTrap.Focus();
            Robots.MainRobot.ActuatorsStore();
            SetPicImage(picInit, true);
        }
    }
}
