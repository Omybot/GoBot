﻿using System;
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
        private bool moving;
        private int intervalTimer;
        private Timer timer;
        private bool reverse;
        private bool focus;
        private bool vertical;
        private double value;

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
        private double lastTickedValue = -1;

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
            moving = false;

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
            MoveTo(this.PointToClient(Cursor.Position));
        }

        void imgBarre_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                EndMoving();
            }
        }

        void imgBarre_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                StartMoving();
                imgCurseur.Location = PointCentral(e.Location);
            }
        }

        void imgCurseur_MouseMove(object sender, MouseEventArgs e)
        {
            MoveTo(this.PointToClient(Cursor.Position));
        }

        void imgCurseur_MouseUp(object sender, MouseEventArgs e)
        {
            EndMoving();
        }

        void imgCurseur_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                imgCurseur.Location = PointCentral(this.PointToClient(Cursor.Position));
                StartMoving();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                StartMoving();
                imgCurseur.Location = PointCentral(e.Location);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                EndMoving();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            MoveTo(e.Location);
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

                if(moving)
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

        public void SetValue(double val, bool tickEvent = true)
        {
            if (value == val)
                return;

            if (value < Min)
            {
                value = Min;
                DrawImage();
            }
            else if (value > Max)
            {
                value = Max;
                DrawImage();
            }
            else
            {
                value = val;
                DrawImage();
            }
            
            if (tickEvent && TickValueChanged != null)
                TickValueChanged(this, null);

            if (ValueChanged != null)
                ValueChanged(this, null);
        }
        public double Value
        {
            get
            {
                return value;
            }
        }
        
        public int IntervalTimer
        {
            get { return intervalTimer; }
            set { if (value > 0) { intervalTimer = value; } }
        }

        private void StartMoving()
        {
            moving = true;

            Focus();

            // Le premier tick se fait un 1 milliseconde, les autres suivant l'intervalle
            timer.Interval = 1;
            timer.Start();

            SetBackGround();
        }

        private void EndMoving()
        {
            moving = false;

            SetBackGround();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            // les ticks suivants se font avec l'intervalle voulu
            timer.Interval = intervalTimer;

            if (lastTickedValue != value)
            {
                lastTickedValue = value;
                TickValueChanged?.Invoke(this, null);
            }

            if (!moving)
                timer.Stop();
        }

        private Point PointCentral(Point gauche)
        {
            if(!Vertical)
                return new Point(gauche.X - (imgCurseur.Width / 2), imgCurseur.Location.Y);
            else
                return new Point(imgCurseur.Location.X, gauche.Y - (imgCurseur.Height / 2));
        }

        private void DrawImage()
        {
            if (!Vertical)
            {
                if (!reverse)
                    imgCurseur.Location = new Point((int)(((value - Min) * (Width - imgCurseur.Width)) / (Max - Min)), imgCurseur.Location.Y);
                else
                    imgCurseur.Location = new Point((int)(Width - imgCurseur.Width - (((value - Min) * (Width - imgCurseur.Width)) / (Max - Min))), imgCurseur.Location.Y);
            }
            else
            {
                if (!reverse)
                    imgCurseur.Location = new Point(imgCurseur.Location.X, (int)(((value - Min) * (Height - imgCurseur.Height)) / (Max - Min)));
                else
                    imgCurseur.Location = new Point(imgCurseur.Location.X, (int)(Height - imgCurseur.Height - ((value - Min) * (Height - imgCurseur.Height)) / (Max - Min)));
            }
        }

        private void MoveTo(Point e)
        {
            if (!Vertical)
            {
                if (moving)
                {
                    if (PointCentral(e).X <= 0)
                    {
                        value = (reverse) ? Max : Min;
                    }
                    else if (e.X >= this.Width - imgCurseur.Width / 2)
                    {
                        value = (reverse) ? Min : Max;
                    }
                    else
                    {
                        value = Math.Round(Min + (Max - Min) * e.X / (float)Width, NombreDecimales);

                        if (reverse)
                            value = Max - Min - value;
                    }
                    
                    ValueChanged?.Invoke(this, null);

                    DrawImage();
                }
            }
            else
            {
                if (moving)
                {
                    if (PointCentral(e).Y <= 0)
                    {
                        value = (reverse) ? Max : Min;
                    }
                    else if (e.Y >= this.Height - imgCurseur.Height / 2)
                    {
                        value = (reverse) ? Min : Max;
                    }
                    else
                    {
                        value = Math.Round(Min + (Max - Min) * e.Y / (float)Height);

                        if (reverse)
                            value = Max - Min - value;
                    }
                    
                    ValueChanged?.Invoke(this, null);

                    DrawImage();
                }
            }
        }
    }
}
