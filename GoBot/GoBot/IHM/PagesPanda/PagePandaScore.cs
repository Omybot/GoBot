using GoBot.Threading;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GoBot.IHM.Pages
{
    public partial class PagePandaScore : UserControl
    {
        public PagePandaScore()
        {
            InitializeComponent();
        }

        private void picLogo_MouseDown(object sender, MouseEventArgs e)
        {
            picLogo.Location = new Point(picLogo.Location.X + 2, picLogo.Location.Y + 2);
        }

        private void picLogo_MouseUp(object sender, MouseEventArgs e)
        {
            picLogo.Location = new Point(picLogo.Location.X - 2, picLogo.Location.Y - 2);
        }

        private void picLogo_MouseClick(object sender, MouseEventArgs e)
        {
            picLogo.Visible = false;
            pnlDetails.Location = new Point(pnlDetails.Left, this.Height);
            pnlDetails.Visible = true;
            //lblSlogan.Visible = false;
            //lblSubSlogan.Visible = false;

            ThreadManager.CreateThread(link => ScoreAnimation(link)).StartThread();
        }

        private void ScoreAnimation(ThreadLink link)
        {
            link.RegisterName();

            double progress = 0;
            int startYScore = 600;
            int endYScore = 241;

            int startYSlogan = 507;
            int endYSlogan = startYSlogan + (startYScore - endYScore);

            int startYSubSlogan = 555;
            int endYSubSlogan = startYSubSlogan + (startYScore - endYScore);

            int startYLogo = 301;
            int endYLogo = startYLogo + (startYScore - endYScore);

            int animDuration = 1000;
            int fps = 30;

            do
            {
                progress += 1f / fps;
                progress = Math.Min(1, progress);
                this.InvokeAuto(() =>
                {
                    Font f = new Font(lblScore.Font.Name, (float)(172 - (172 - 124) * Math.Max(0, (progress - 0.5) * 2)));
                    lblScore.Font = f;
                    pnlDetails.Location = new Point(pnlDetails.Left, (int)(startYScore - progress * (startYScore - endYScore)));
                    lblSlogan.Location = new Point(lblSlogan.Left, (int)(startYSlogan - progress * (startYSlogan - endYSlogan)));
                    lblSubSlogan.Location = new Point(lblSubSlogan.Left, (int)(startYSubSlogan - progress * (startYSubSlogan - endYSubSlogan)));
                });
                Thread.Sleep(animDuration / fps);
            } while (progress < 1);
        }
    }
}
