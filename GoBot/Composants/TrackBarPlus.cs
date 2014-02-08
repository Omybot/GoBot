using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Composants
{
    public partial class TrackBarPlus : UserControl
    {
        private bool enDeplacement;
        private int intervalTimer;
        private Timer timer;
        private bool reverse;
        private bool focus;
        private bool vertical;
        public bool Vertical 
        { 
            get 
            {
                return vertical;
            }
            set
            {
                int ancienWidth = Width;
                int ancienHeight = Height;

                if (value)
                {
                    MaximumSize = new Size(15, 3000);
                    MinimumSize = new Size(15, 0);

                    imgBarre.Anchor = AnchorStyles.Bottom | AnchorStyles.Top;
                    imgBarre.Left = 5;
                    imgBarre.Top = 0;
                    imgBarre.Width = 5;
                    imgBarre.Height = Height;
                }
                else
                {
                    MaximumSize = new Size(3000, 15);
                    MinimumSize = new Size(0, 15);

                    imgBarre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    imgBarre.Left = 0;
                    imgBarre.Top = 5;
                    imgBarre.Height = 5;
                    imgBarre.Width = Width;
                }

                if (value)
                {
                    Height = Math.Max(ancienWidth, ancienHeight);
                    Width = Math.Min(ancienWidth, ancienHeight);
                }
                else
                {
                    Width = Math.Max(ancienWidth, ancienHeight);
                    Height = Math.Min(ancienWidth, ancienHeight);
                }

                vertical = value; 
                SetBackGround();
            }
        }
        private double derniereValeurTick = -1;

        public int NombreDecimales { get; set; }

        public event EventHandler TickValueChanged;
        public event EventHandler ValueChanged;

        public TrackBarPlus()
        {
            InitializeComponent();

            NombreDecimales = 0;
            vertical = false;
            reverse = false;
            intervalTimer = 1;
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);

            Min = 0;
            Max = 100;
            focus = false;
            enDeplacement = false;

            imgCurseur.MouseDown += new MouseEventHandler(imgCurseur_MouseDown);
            imgCurseur.MouseUp += new MouseEventHandler(imgCurseur_MouseUp);
            imgCurseur.MouseMove += new MouseEventHandler(imgCurseur_MouseMove);

            imgBarre.MouseDown += new MouseEventHandler(imgBarre_MouseDown);
            imgBarre.MouseUp += new MouseEventHandler(imgBarre_MouseUp);
            imgBarre.MouseMove += new MouseEventHandler(imgBarre_MouseMove);
        }

        public bool Reverse 
        {
	        get 
	        {
                return reverse;
	        }
	        set 
	        {
                reverse = value;

                SetBackGround();
	        }
        }

        #region Events

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if(!Reverse)
                    SetValue(Min);
                else
                    SetValue(Max);

                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (Reverse)
                    SetValue(Min);
                else
                    SetValue(Max);

                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (!Reverse)
                    SetValue(Value - Math.Ceiling((Max - Min) * 0.05));
                else
                    SetValue(Value + Math.Ceiling((Max - Min) * 0.05));

                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (Reverse)
                    SetValue(Value - Math.Ceiling((Max - Min) * 0.05));
                else
                    SetValue(Value + Math.Ceiling((Max - Min) * 0.05));

                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Add)
            {
                if (Reverse)
                    SetValue(Value - 1);
                else
                    SetValue(Value + 1);

                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                if (Reverse)
                    SetValue(Value + 1);
                else
                    SetValue(Value - 1);

                e.IsInputKey = true;
            }
            base.OnPreviewKeyDown(e);
        }

        void imgBarre_MouseMove(object sender, MouseEventArgs e)
        {
            Deplacement(this.PointToClient(Cursor.Position));
        }

        void imgBarre_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                FinDeplacement();
            }
        }

        void imgBarre_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DebutDeplacement();
                imgCurseur.Location = PointCentral(e.Location);
            }
        }

        void imgCurseur_MouseMove(object sender, MouseEventArgs e)
        {
            Deplacement(this.PointToClient(Cursor.Position));
        }

        void imgCurseur_MouseUp(object sender, MouseEventArgs e)
        {
            FinDeplacement();
        }

        void imgCurseur_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                imgCurseur.Location = PointCentral(this.PointToClient(Cursor.Position));
                DebutDeplacement();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DebutDeplacement();
                imgCurseur.Location = PointCentral(e.Location);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                FinDeplacement();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Deplacement(e.Location);
            base.OnMouseMove(e);
        }

        private void TrackBarPlus_Leave(object sender, EventArgs e)
        {
            focus = false;
            SetBackGround();
        }

        private void TrackBarPlus_Enter(object sender, EventArgs e)
        {
            focus = true;
            SetBackGround();
        }

        private void TrackBarPlus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SetValue(Min);
            }
            else if (e.KeyCode == Keys.Up)
            {
                SetValue(Max);
            }
            else if (e.KeyCode == Keys.Left)
            {
                SetValue(Value - (Max - Min) * 0.05);
            }
            else if (e.KeyCode == Keys.Right)
            {
                SetValue(Value + (Max - Min) * 0.05);
            }
            e.Handled = true;
        }

        #endregion

        public void SetBackGround()
        {
            if (!focus)
            {
                imgBarre.BackgroundImage = global::Composants.Properties.Resources.TrackBarFond;

                imgCurseur.Image = global::Composants.Properties.Resources.TrackBarCurseurNormal;
            }
            else
            {
                imgBarre.BackgroundImage = global::Composants.Properties.Resources.TrackBarFondSelected;

                imgCurseur.Image = global::Composants.Properties.Resources.TrackBarCurseurSelect;

                if(enDeplacement)
                    imgCurseur.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }

            if(!reverse) 
                imgBarre.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            if (Vertical)
                imgBarre.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        public double Min
        {
            get;
            set;

        }
        public double Max
        {
            get;
            set;
        }

        public void SetValue(double value, bool tickEvent = true)
        {
            if (value == value_)
                return;

            if (value < Min)
            {
                value_ = Min;
                DessineCurseur();
            }
            else if (value > Max)
            {
                value_ = Max;
                DessineCurseur();
            }
            else
            {
                value_ = value;
                DessineCurseur();
            }
            
            if (tickEvent && TickValueChanged != null)
                TickValueChanged(this, null);

            if (ValueChanged != null)
                ValueChanged(this, null);
        }

        private double value_;
        public double Value
        {
            get
            {
                return value_;
            }
        }
        
        public int IntervalTimer
        {
            get { return intervalTimer; }
            set { if (value > 0) { intervalTimer = value; } }
        }

        private void DebutDeplacement()
        {
            enDeplacement = true;

            Focus();

            // Le premier tick se fait un 1 milliseconde, les autres suivant l'intervalle
            timer.Interval = 1;
            timer.Start();
            SetBackGround();
        }

        private void FinDeplacement()
        {
            enDeplacement = false;

            SetBackGround();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            // les ticks suivants se font avec l'intervalle voulu
            timer.Interval = intervalTimer;
            if (derniereValeurTick != value_)
            {
                derniereValeurTick = value_;
                if (TickValueChanged != null)
                    TickValueChanged(this, null);
            }
            if (!enDeplacement)
                timer.Stop();
        }

        private Point PointCentral(Point gauche)
        {
            if(!Vertical)
                return new Point(gauche.X - (imgCurseur.Width / 2), imgCurseur.Location.Y);
            else
                return new Point(imgCurseur.Location.X, gauche.Y - (imgCurseur.Height / 2));
        }

        private void DessineCurseur()
        {
            if (!Vertical)
            {
                if (!reverse)
                    imgCurseur.Location = new Point((int)(((value_ - Min) * (Width - imgCurseur.Width)) / (Max - Min)), imgCurseur.Location.Y);
                else
                    imgCurseur.Location = new Point((int)(Width - imgCurseur.Width - (((value_ - Min) * (Width - imgCurseur.Width)) / (Max - Min))), imgCurseur.Location.Y);
            }
            else
            {
                if (!reverse)
                    imgCurseur.Location = new Point(imgCurseur.Location.X, (int)(((value_ - Min) * (Height - imgCurseur.Height)) / (Max - Min)));
                else
                    imgCurseur.Location = new Point(imgCurseur.Location.X, (int)(Height - imgCurseur.Height - ((value_ - Min) * (Height - imgCurseur.Height)) / (Max - Min)));
            }
        }

        private void Deplacement(Point e)
        {
            if (!Vertical)
            {
                if (enDeplacement)
                {
                    if (PointCentral(e).X <= 0)
                    {
                        value_ = (reverse) ? Max : Min;
                    }
                    else if (e.X >= this.Width - imgCurseur.Width / 2)
                    {
                        value_ = (reverse) ? Min : Max;
                    }
                    else
                    {
                        value_ = Math.Round(Min + (Max - Min) * e.X / (float)Width, NombreDecimales);

                        if (reverse)
                            value_ = Max - Min - value_;
                    }

                    if (ValueChanged != null)
                        ValueChanged(this, null);

                    DessineCurseur();
                }
            }
            else
            {
                if (enDeplacement)
                {
                    if (PointCentral(e).Y <= 0)
                    {
                        value_ = (reverse) ? Max : Min;
                    }
                    else if (e.Y >= this.Height - imgCurseur.Height / 2)
                    {
                        value_ = (reverse) ? Min : Max;
                    }
                    else
                    {
                        value_ = Math.Round(Min + (Max - Min) * e.Y / (float)Height);

                        if (reverse)
                            value_ = Max - Min - value_;
                    }

                    if (ValueChanged != null)
                        ValueChanged(this, null);

                    DessineCurseur();
                }
            }
        }
    }
}
