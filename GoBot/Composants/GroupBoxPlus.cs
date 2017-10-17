using System;
using System.Windows.Forms;

namespace Composants
{
    public partial class GroupBoxPlus : GroupBox
    {
        private Button ButtonArrow { get; set; }
        private Timer TimerAnimation { get; set; }
        private int OriginalHeight { get; set; }
        private int ReducedHeight { get; set; }

        /// <summary>
        /// Vrai si le panel est actuellement ouvert
        /// </summary>
        public bool Deployed { get; private set; }
        
        public delegate void DeployedChangedDelegate(bool deployed);

        /// <summary>
        /// Se produit lorsque le déploiement du panel change
        /// </summary>
        public event DeployedChangedDelegate DeployedChanged;

        public GroupBoxPlus()
        {
            InitializeComponent();

            ButtonArrow = new Button();
            ButtonArrow.Visible = true;
            ButtonArrow.Image = Properties.Resources.ArrowUp;
            ButtonArrow.SetBounds(this.Width - 23 - 5, 10, 23, 23);
            ButtonArrow.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ButtonArrow.Click += new EventHandler(ButtonArrow_Click);
            Controls.Add(ButtonArrow);
            ReducedHeight = 37;
            OriginalHeight = 0;
            Deployed = true;

            this.SizeChanged += new EventHandler(GroupBoxPlus_SizeChanged);
            this.DoubleBuffered = true;
        }
        
        /// <summary>
        /// Ouvre ou ferme le panel
        /// </summary>
        /// <param name="open">Ouvre le panel si vrai, sinon le ferme</param>
        /// <param name="animation">Vrai si l'animation smooth doit être utilisée, faux si l'action doit être instantanée</param>
        public void Deploy(bool open = true, bool animation = false)
        {
            if (open)
                Open(animation);
            else
                Close(animation);
        }

        void GroupBoxPlus_SizeChanged(object sender, EventArgs e)
        {
            ButtonArrow.SetBounds(this.Width - ButtonArrow.Width - 5, 10, ButtonArrow.Width, ButtonArrow.Height);
        }

        void ButtonArrow_Click(object sender, EventArgs e)
        {
            Deploy(!Deployed, true);
        }

        private void Open(bool animation = false)
        {
            Deployed = true;

            if (OriginalHeight == 0)
                return;

            foreach (Control c in Controls)
                c.Visible = true;

            ButtonArrow.Image = Properties.Resources.ArrowUp;

            Deployed = true;

            if (animation)
            {
                TimerAnimation = new Timer();
                TimerAnimation.Interval = 20;
                TimerAnimation.Tick += new EventHandler(TimerAnimation_Tick);
                TimerAnimation.Start();
            }
            else
            {
                this.Height = OriginalHeight;
            }
            
            DeployedChanged?.Invoke(true);
        }

        private void Close(bool animation = false)
        {
            Deployed = false;

            if(OriginalHeight == 0)
                OriginalHeight = this.Height;

            ButtonArrow.Image = Properties.Resources.ArrowBottom;

            Deployed = false;

            if (animation)
            {
                TimerAnimation = new Timer();
                TimerAnimation.Interval = 20;
                TimerAnimation.Tick += new EventHandler(TimerAnimation_Tick);
                TimerAnimation.Start();
            }
            else
            {
                this.Height = ReducedHeight;
                foreach (Control c in Controls)
                    c.Visible = false;

                ButtonArrow.Visible = true;
            }
            
            DeployedChanged?.Invoke(false);
        }

        void TimerAnimation_Tick(object sender, EventArgs e)
        {
            if (Deployed)
            {
                if (OriginalHeight - this.Height == 1)
                {
                    this.Height = OriginalHeight;
                    TimerAnimation.Stop();
                }
                else
                {
                    this.Height += (int)Math.Ceiling((OriginalHeight - this.Height) / 5.0);
                }
            }
            else
            {
                if (this.Height - ReducedHeight == 1)
                {
                    this.Height = ReducedHeight;
                    TimerAnimation.Stop();
                    foreach (Control c in Controls)
                        c.Visible = false;

                    ButtonArrow.Visible = true;
                    ButtonArrow.Focus();
                }
                else
                {
                    this.Height -= (int)Math.Ceiling((this.Height - ReducedHeight) / 5.0);
                }
            }
        }
    }
}
