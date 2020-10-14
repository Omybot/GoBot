using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using GoBot.Threading;
using GoBot.Actionneurs;

namespace GoBot.IHM.Panels
{
    public partial class PanelStorage : UserControl
    {
        int _lateralPosition = 0;
        int _verticalPosition = 0;

        bool _isOnLeft = false;
        ThreadLink _linkAnimation;

        Color _red, _green;

        List<Color> _leftStorage, _rightStorage;

        Color _onGround;

        public PanelStorage()
        {
            InitializeComponent();

            _red = Color.FromArgb(150, 0, 0);
            _green = Color.FromArgb(0, 150, 0);

            _onGround = Color.Transparent;

            _rightStorage = new List<Color>
            {
                Color.Transparent,
                Color.Transparent,
                Color.Transparent
            };

            _leftStorage = new List<Color>
            {
                Color.Transparent,
                Color.Transparent,
                Color.Transparent
            };

            Bitmap img;
            img = new Bitmap(btnSpawnGreen.Width, btnSpawnGreen.Height);
            Graphics g = Graphics.FromImage(img);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Transparent);
            PaintBuoy(g, new PointF(img.Width / 2, 6), _green, 0.45f);
            g.Dispose();
            btnSpawnGreen.Image = img;

            img = new Bitmap(btnSpawnRed.Width, btnSpawnRed.Height);
            g = Graphics.FromImage(img);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Transparent);
            PaintBuoy(g, new PointF(img.Width / 2, 6), _red, 0.45f);
            g.Dispose();
            btnSpawnRed.Image = img;
        }

        private void picStorage_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle r = new Rectangle(50 + _lateralPosition, 143, 260, 300);

            Brush bsh = new LinearGradientBrush(r, Color.White, Color.WhiteSmoke, 30);
            e.Graphics.FillRectangle(bsh, r);
            e.Graphics.DrawRectangle(Pens.LightGray, r);

            PaintBuoy(e.Graphics, new PointF(250, 450 - _verticalPosition), _onGround, 1.2f);

            PaintBuoy(e.Graphics, new PointF(110 + _lateralPosition, 290), _leftStorage[2], 1.2f);
            PaintLocker(e.Graphics, new PointF(110 + _lateralPosition, 290), true);
            PaintBuoy(e.Graphics, new PointF(110 + _lateralPosition, 220), _leftStorage[1], 1.2f);
            PaintLocker(e.Graphics, new PointF(110 + _lateralPosition, 220), true);
            PaintBuoy(e.Graphics, new PointF(110 + _lateralPosition, 150), _leftStorage[0], 1.2f);
            PaintLocker(e.Graphics, new PointF(110 + _lateralPosition, 150), true);

            PaintBuoy(e.Graphics, new PointF(250 + _lateralPosition, 290), _rightStorage[2], 1.2f);
            PaintLocker(e.Graphics, new PointF(250 + _lateralPosition, 290), false);
            PaintBuoy(e.Graphics, new PointF(250 + _lateralPosition, 220), _rightStorage[1], 1.2f);
            PaintLocker(e.Graphics, new PointF(250 + _lateralPosition, 220), false);
            PaintBuoy(e.Graphics, new PointF(250 + _lateralPosition, 150), _rightStorage[0], 1.2f);
            PaintLocker(e.Graphics, new PointF(250 + _lateralPosition, 150), false);
        }

        private void PaintBuoy(Graphics g, PointF center, ColorPlus color, float scale)
        {
            if (color.Alpha != 0)
            {
                List<PointF> pts = BuoyPoints(center, scale);

                Brush bsh = new LinearGradientBrush(new PointF(pts.Min(o => o.X), pts.Min(o => o.Y)), new PointF(pts.Max(o => o.X), pts.Min(o => o.Y)), ColorPlus.FromAhsl(color.Alpha, color.Hue, color.Saturation, Math.Min(color.Lightness * 2, 1)), color);
                g.FillPolygon(bsh, pts.ToArray());
                bsh.Dispose();

                g.DrawPolygon(Pens.Black, pts.ToArray());
            }
        }

        private void PaintLocker(Graphics g, PointF center, bool onLeft)
        {
            List<PointF> pts = LockerPoints(center, onLeft);

            //g.DrawLines(Pens.Black, pts.ToArray());
            g.FillPolygon(Brushes.WhiteSmoke, pts.ToArray());
            g.DrawPolygon(Pens.Black, pts.ToArray());
        }

        private List<PointF> BuoyPoints(PointF topCenter, float scale)
        {
            float topWidth, bottomWidth, height;

            topWidth = 54;
            bottomWidth = 72;
            height = 115;

            List<PointF> pts = new List<PointF>();
            pts.Add(new PointF(topCenter.X - topWidth / 2, topCenter.Y + 0));
            pts.Add(new PointF(topCenter.X + topWidth / 2, topCenter.Y + 0));
            pts.Add(new PointF(topCenter.X + bottomWidth / 2, topCenter.Y + height));
            pts.Add(new PointF(topCenter.X - bottomWidth / 2, topCenter.Y + height));

            return pts.Select(o => new PointF((o.X - topCenter.X) * scale + topCenter.X, (o.Y - topCenter.Y) * scale + topCenter.Y)).ToList();
        }

        private List<PointF> LockerPoints(PointF topCenter, bool onLeft)
        {
            float scale, bottomWidth, height;

            scale = 1.2f;
            bottomWidth = 72;
            height = 115;

            PointF p;
            int factor;

            if (onLeft)
            {
                p = new PointF(topCenter.X - bottomWidth / 2 + 2, topCenter.Y + height + 1);
                factor = 1;
            }
            else
            {
                p = new PointF(topCenter.X + bottomWidth / 2 - 2, topCenter.Y + height + 1);
                factor = -1;
            }

            List<PointF> pts = new List<PointF>();
            pts.Add(p);

            pts.Add(new PointF(p.X - 4 * factor, p.Y + 8));
            pts.Add(new PointF(p.X - 11 * factor, p.Y + 8));
            pts.Add(new PointF(p.X - 12 * factor, p.Y + 7));
            pts.Add(new PointF(p.X - 12 * factor, p.Y - 10));
            pts.Add(new PointF(p.X - 8 * factor, p.Y - 10));
            pts.Add(new PointF(p.X - 6 * factor, p.Y));

            return pts.Select(o => new PointF((o.X - topCenter.X) * scale + topCenter.X, (o.Y - topCenter.Y) * scale + topCenter.Y)).ToList();
        }

        private void btnLateral_Click(object sender, EventArgs e)
        {
            _isOnLeft = !_isOnLeft;

            if (_linkAnimation != null)
            {
                _linkAnimation.Cancel();
                _linkAnimation.WaitEnd();
            }

            if (!_isOnLeft)
            {
                Actionneur.ElevatorRight.DoPushInside();
                btnLateral.Image = Properties.Resources.BigArrow;
            }
            else
            {
                Actionneur.ElevatorRight.DoPushOutside();
                Bitmap bmp = new Bitmap(Properties.Resources.BigArrow);
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                btnLateral.Image = bmp;
            }

            _linkAnimation = ThreadManager.CreateThread(link => ThreadLateral(!_isOnLeft ? -4 : 4));
            _linkAnimation.StartInfiniteLoop(15);

            picStorage.Focus();
        }

        private void ThreadLateral(int offset)
        {
            _lateralPosition += offset;
            picStorage.Invalidate();

            if (_lateralPosition >= 140)
            {
                _lateralPosition = 140;
                _linkAnimation.Cancel();
            }
            else if (_lateralPosition <= 0)
            {
                _lateralPosition = 0;
                _linkAnimation.Cancel();
            }
        }

        private void ThreadVertical(int offset)
        {
            int index = 0;
            int maxVertical = 0;

            _verticalPosition += offset;
            picStorage.Invalidate();

            if (_isOnLeft)
            {
                if (_leftStorage[0] == Color.Transparent)
                {
                    maxVertical = 450 - 150;
                    index = 0;
                }
                else if (_leftStorage[1] == Color.Transparent)
                {
                    maxVertical = 450 - 220;
                    index = 1;
                }
                else if (_leftStorage[2] == Color.Transparent)
                {
                    maxVertical = 450 - 290;
                    index = 2;
                }
            }
            else
            {
                if (_rightStorage[0] == Color.Transparent)
                {
                    maxVertical = 450 - 150;
                    index = 0;
                }
                else if (_rightStorage[1] == Color.Transparent)
                {
                    maxVertical = 450 - 220;
                    index = 1;
                }
                else if (_rightStorage[2] == Color.Transparent)
                {
                    maxVertical = 450 - 290;
                    index = 2;
                }
            }

            if (_verticalPosition >= maxVertical)
            {
                if (_isOnLeft)
                    _leftStorage[index] = _onGround;
                else
                    _rightStorage[index] = _onGround;

                _verticalPosition = 0;
                _linkAnimation.Cancel();

                _onGround = Color.Transparent;

                this.InvokeAuto(() =>
                {
                    btnSpawnGreen.Visible = true;
                    btnSpawnRed.Visible = true;
                });
            }
            else if (_verticalPosition <= 0)
            {
                _verticalPosition = 0;
                _linkAnimation.Cancel();
            }
        }

        private void btnSpawnGreen_Click(object sender, EventArgs e)
        {
            _onGround = _green;
            picStorage.Invalidate();
            picStorage.Focus();

            btnSpawnGreen.Visible = false;
            btnSpawnRed.Visible = false;
        }

        private void btnSpawnRed_Click(object sender, EventArgs e)
        {
            _onGround = _red;
            picStorage.Invalidate();
            picStorage.Focus();

            btnSpawnGreen.Visible = false;
            btnSpawnRed.Visible = false;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (_linkAnimation != null)
            {
                _linkAnimation.Cancel();
                _linkAnimation.WaitEnd();
            }

            _linkAnimation = ThreadManager.CreateThread(link => ThreadVertical(4));
            _linkAnimation.StartInfiniteLoop(10);

            picStorage.Focus();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (_linkAnimation != null)
            {
                _linkAnimation.Cancel();
                _linkAnimation.WaitEnd();
            }

            List<Color> colors = _isOnLeft ? _leftStorage : _rightStorage;
            int index = 0;

            if (colors[2] != Color.Transparent)
            {
                _verticalPosition = 450 - 290;
                index = 2;
            }
            else if (colors[1] != Color.Transparent)
            {
                _verticalPosition = 450 - 220;
                index = 1;
            }
            else if (colors[0] != Color.Transparent)
            {
                _verticalPosition = 450 - 150;
                index = 0;
            }

            btnSpawnGreen.Visible = false;
            btnSpawnRed.Visible = false;

            _onGround = colors[index];
            colors[index] = Color.Transparent;

            _linkAnimation = ThreadManager.CreateThread(link => ThreadVertical(-4));
            _linkAnimation.StartInfiniteLoop(10);

            picStorage.Focus();
        }
    }
}
