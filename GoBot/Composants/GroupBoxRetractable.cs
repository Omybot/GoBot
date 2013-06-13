using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Composants
{
    public partial class GroupBoxRetractable : GroupBox
    {
        private Button btnFleche;
        private bool deploye = true;
        private int hauteurTotale;
        private int hauteurReduite;

        public GroupBoxRetractable()
        {
            InitializeComponent();

            btnFleche = new Button();
            btnFleche.Visible = true;
            btnFleche.Image = Properties.Resources.FlecheHautGris;
            btnFleche.SetBounds(this.Width - 23 - 5, 10, 23, 23);
            btnFleche.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnFleche.Click += new EventHandler(btnFleche_Click);
            Controls.Add(btnFleche);
            hauteurReduite = 37;
            hauteurTotale = 0;
            deploye = true;

            this.SizeChanged += new EventHandler(GroupBoxRetractable_SizeChanged);
            this.DoubleBuffered = true;
        }

        void GroupBoxRetractable_SizeChanged(object sender, EventArgs e)
        {
            btnFleche.SetBounds(this.Width - 23 - 5, 10, 23, 23);
        }

        void btnFleche_Click(object sender, EventArgs e)
        {
            if (!deploye)
                Deployer();
            else
                Replier();
        }

        Timer timerDeploi;
        public void Deployer(bool deployer = true, bool animation = true)
        {
            if (!deployer)
            {
                Replier(animation);
                return;
            }

            deploye = true;

            if (hauteurTotale == 0)
                return;

            foreach (Control c in Controls)
                c.Visible = true;

            btnFleche.Image = Properties.Resources.FlecheHautGris;

            deploye = true;

            if (animation)
            {
                timerDeploi = new Timer();
                timerDeploi.Interval = 10;
                timerDeploi.Tick += new EventHandler(timerDeploi_Tick);
                timerDeploi.Start();
            }
            else
            {
                this.Height = hauteurTotale;
            }

            DeploiementChange(true);
        }

        void timerDeploi_Tick(object sender, EventArgs e)
        {
            if (deploye)
            {
                if (hauteurTotale - this.Height == 1)
                {
                    this.Height = hauteurTotale;
                    timerDeploi.Stop();
                }
                else
                {
                    this.Height += (int)Math.Ceiling((hauteurTotale - this.Height) / 15.0);
                }
            }
            else
            {
                if (this.Height - hauteurReduite == 1)
                {
                    this.Height = hauteurReduite;
                    timerDeploi.Stop();
                    foreach (Control c in Controls)
                        c.Visible = false;

                    btnFleche.Visible = true;
                    btnFleche.Focus();
                }
                else
                {
                    this.Height -= (int)Math.Ceiling((this.Height - hauteurReduite) / 15.0);
                }
            }
        }

        private void Replier(bool animation = true)
        {
            deploye = false;

            if(hauteurTotale == 0)
                hauteurTotale = this.Height;

            btnFleche.Image = Properties.Resources.FlecheBasGris;

            deploye = false;

            if (animation)
            {
                timerDeploi = new Timer();
                timerDeploi.Interval = 10;
                timerDeploi.Tick += new EventHandler(timerDeploi_Tick);
                timerDeploi.Start();
            }
            else
            {
                this.Height = hauteurReduite;
                foreach (Control c in Controls)
                    c.Visible = false;

                btnFleche.Visible = true;
            }

            DeploiementChange(false);
        }

        public delegate void DeploiementDelegate(bool deploye);
        public event DeploiementDelegate DeploiementChange;
    }
}
