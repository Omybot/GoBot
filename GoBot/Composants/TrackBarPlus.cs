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
        private bool reverse;
        private bool vertical;
        private double max, min;

        private double lastTickedValue = -1;

        public delegate void ValueChangedDelegate(object sender, double value);

        public event ValueChangedDelegate TickValueChanged;
        public event ValueChangedDelegate ValueChanged;

        private Timer TimerTickValue { get; set; }
        private bool Moving { get; set; }
        private bool FocusedImage { get; set; }

        public double Value { get; private set; }
        public uint IntervalTimer { get; set; }
        public int DecimalPlaces { get; set; }

        public double Min
        {
            get { return min; }
            set
            {
                min = value;
                SetValue(Value);
            }
        }

        public double Max
        {
            get { return max; }
            set
            {
                max = value;
                SetValue(Value);
            }
        }

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
                    MinimumSize = new Size(15, 30);

                    imgBarre.Anchor = AnchorStyles.Bottom | AnchorStyles.Top;
                    imgBarre.Left = 5;
                    imgBarre.Top = 0;
                    imgBarre.Width = 5;
                    imgBarre.Height = Height;

                    Height = Math.Max(ancienWidth, ancienHeight);
                    Width = Math.Min(ancienWidth, ancienHeight);
                }
                else
                {
                    MaximumSize = new Size(3000, 15);
                    MinimumSize = new Size(30, 15);

                    imgBarre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    imgBarre.Left = 0;
                    imgBarre.Top = 5;
                    imgBarre.Height = 5;
                    imgBarre.Width = Width;

                    Width = Math.Max(ancienWidth, ancienHeight);
                    Height = Math.Min(ancienWidth, ancienHeight);
                }

                vertical = value;
                ChangeImages();
            }
        }

        public TrackBarPlus()
        {
            InitializeComponent();

            DecimalPlaces = 0;
            vertical = false;
            reverse = false;
            IntervalTimer = 1;
            TimerTickValue = new Timer();
            TimerTickValue.Tick += new EventHandler(timer_Tick);

            Min = 0;
            Max = 100;
            Moving = false;

            imgCurseur.MouseDown += new MouseEventHandler(img_MouseDown);
            imgCurseur.MouseUp += new MouseEventHandler(img_MouseUp);
            imgCurseur.MouseMove += new MouseEventHandler(img_MouseMove);

            imgBarre.MouseDown += new MouseEventHandler(img_MouseDown);
            imgBarre.MouseUp += new MouseEventHandler(img_MouseUp);
            imgBarre.MouseMove += new MouseEventHandler(img_MouseMove);
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

                ChangeImages();
            }
        }

        #region Events

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            int direction = Reverse ? -1 : 1;

            if (e.KeyCode == Keys.Down)
            {
                SetValue(Reverse ? Max : Min);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                SetValue(Reverse ? Min : Max);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                SetValue(Value - Math.Ceiling((Max - Min) * 0.05) * direction);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                SetValue(Value + Math.Ceiling((Max - Min) * 0.05) * direction);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Add)
            {
                SetValue(Value + direction);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                SetValue(Value - direction);
                e.IsInputKey = true;
            }
            base.OnPreviewKeyDown(e);
        }

        void img_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        void img_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        void img_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
        protected override void OnEnter(EventArgs e)
        {
            FocusedImage = true;
            ChangeImages();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            FocusedImage = false;
            ChangeImages();
            base.OnLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            if (e.Button == MouseButtons.Left)
            {
                StartMoving();
                SetCursorPosition(this.PointToClient(Cursor.Position));
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                EndMoving();

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Moving) SetCursorPosition(this.PointToClient(Cursor.Position));

            base.OnMouseMove(e);
        }

        private void TrackBarPlus_Leave(object sender, EventArgs e)
        {
            ChangeImages();
        }

        private void TrackBarPlus_Enter(object sender, EventArgs e)
        {
            ChangeImages();
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

        public void ChangeImages()
        {
            if (!FocusedImage)
            {
                imgBarre.BackgroundImage = Properties.Resources.TrackBarFond;
                imgCurseur.Image = Properties.Resources.TrackBarCurseurNormal;
            }
            else
            {
                imgBarre.BackgroundImage = Properties.Resources.TrackBarFondSelected;
                imgCurseur.Image = Properties.Resources.TrackBarCurseurSelect;

                if (Moving)
                    imgCurseur.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }

            if (!Reverse)
                imgBarre.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            if (Vertical)
                imgBarre.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        public void SetValue(double val, bool tickEvent = true)
        {
            val = Math.Max(Min, Math.Min(Max, val));

            if (Value != val)
            {
                Value = Math.Round(val, DecimalPlaces);

                if (tickEvent)
                    TickValueChanged?.Invoke(this, Value);

                ValueChanged?.Invoke(this, Value);
            }

            DrawImage();
        }

        private void StartMoving()
        {
            Moving = true;

            Focus();

            // Le premier tick se fait en 1 milliseconde, les autres suivant l'intervalle
            TimerTickValue.Interval = 1;
            TimerTickValue.Start();

            ChangeImages();
        }

        private void EndMoving()
        {
            Moving = false;

            ChangeImages();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            // les ticks suivants se font avec l'intervalle voulu
            TimerTickValue.Interval = (int)IntervalTimer;

            if (lastTickedValue != Value)
            {
                lastTickedValue = Value;
                TickValueChanged?.Invoke(this, Value);
            }

            if (!Moving)
                TimerTickValue.Stop();
        }

        private Point ImageTopLeft(Point centerPosition)
        {
            if (!Vertical)
                return new Point(centerPosition.X - (imgCurseur.Width / 2), imgCurseur.Location.Y);
            else
                return new Point(imgCurseur.Location.X, centerPosition.Y - (imgCurseur.Height / 2));
        }

        private void DrawImage()
        {
            if (!Vertical)
            {
                if (!Reverse)
                    imgCurseur.Location = new Point((int)(((Value - Min) * (Width - imgCurseur.Width)) / (Max - Min)), imgCurseur.Location.Y);
                else
                    imgCurseur.Location = new Point((int)(Width - imgCurseur.Width - (((Value - Min) * (Width - imgCurseur.Width)) / (Max - Min))), imgCurseur.Location.Y);
            }
            else
            {
                if (Reverse)
                    imgCurseur.Location = new Point(imgCurseur.Location.X, (int)(((Value - Min) * (Height - imgCurseur.Height)) / (Max - Min)));
                else
                    imgCurseur.Location = new Point(imgCurseur.Location.X, (int)(Height - imgCurseur.Height - ((Value - Min) * (Height - imgCurseur.Height)) / (Max - Min)));
            }
        }

        private void SetCursorPosition(Point pos)
        {
            double val;

            if (!Vertical)
            {
                if (pos.X - imgCurseur.Width / 2 <= 0)
                    val = (Reverse) ? Max : Min;
                else if (pos.X >= this.Width - imgCurseur.Width / 2)
                    val = (Reverse) ? Min : Max;
                else
                {
                    val = Min + (Max - Min) * (pos.X - imgCurseur.Width / 2) / (float)(Width - imgCurseur.Width);

                    if (Reverse)
                        val = Max - val + Min;
                }
            }
            else
            {
                if (ImageTopLeft(pos).Y <= 0)
                    val = (!Reverse) ? Max : Min;
                else if (pos.Y >= this.Height - imgCurseur.Height / 2)
                    val = (!Reverse) ? Min : Max;
                else
                {
                    val = Min + (Max - Min) * (pos.Y - imgCurseur.Height / 2) / (float)(Height - imgCurseur.Height);
                    Console.WriteLine(val);
                    if (!Reverse)
                        val = Max - val + Min;
                }
            }

            SetValue(val, false);
        }
    }
}
