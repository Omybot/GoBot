using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace GoBot.IHM
{
    /// <summary>
    /// Fenêtre de lancement de l'application avec image et messages personnalisés.
    /// </summary>
    public static class SplashScreen
    {
        private static SplashForm _form;
        private static Thread _formThread;

        private static Bitmap _image;
        private static Rectangle _messageRect;

        /// <summary>
        /// Affiche l'écran de lancement.
        /// </summary>
        /// <param name="image">Image de fond de l'écran de lancement.</param>
        /// <param name="messageRect">Coordonnée du rectangle d'affichage de messages.</param>
        /// <param name="speed">L'image apparait par fondu en gagnant une opacité équivalente au paramètre speed à chaque itération.</param>
        public static void ShowSplash(Bitmap image, Rectangle messageRect, int speed = 7)
        {
            _image = image;
            _messageRect = messageRect;

            _formThread = new Thread(Open);
            _formThread.SetApartmentState(ApartmentState.STA);
            _formThread.Start(speed);

            while (_form == null) ;
        }

        /// <summary>
        /// Ferme l'écran de lancement.
        /// </summary>
        /// <param name="speed">L'image disparait par fondu en perdant une opacité équivalente au paramètre speed à chaque itération.</param>
        public static void CloseSplash(int speed = 10)
        {
            if (speed == -1)
                _form.InvokeAuto(() => _form.Close());
            else
            {
                _form.Speed = -speed;
                _form.StartTimer();
            }
        }

        public static void SetImage(Image img)
        {
            _form.SetImage(img);
            Thread.Sleep(500);
        }

        /// <summary>
        /// Affiche le message donné dans la couleur choisie.
        /// </summary>
        /// <param name="text">Message à afficher.</param>
        /// <param name="color">Couleur du message à afficher.</param>
        public static void SetMessage(String text, Color color)
        {
            _form.SetText(text, color);
        }

        private static void Open(object speed)
        {
            _form = new SplashForm(_image);
            _form.Speed = (int)speed;
            _form.MessageRect = _messageRect;
            _form.ShowDialog();
        }

        private class SplashForm : Form
        {
            private int _speed;
            private int _oppacity;

            private Image _currentBitmap;
            private Image _originalBitmap;

            private string _text;
            private Color _textColor;

            private Rectangle _messageRect;

            private System.Timers.Timer _timerOpacity;

            public int Speed
            {
                get
                {
                    return _speed;
                }
                set
                {
                    _speed = value;
                }
            }

            public Rectangle MessageRect
            {
                get
                {
                    return _messageRect;
                }
                set
                {
                    _messageRect = value;
                }
            }

            public SplashForm(Bitmap img)
            {
                InitializeComponent(img.Size);

                //img = WriteVersion(img);

                _oppacity = 0;
                _originalBitmap = img;

                _text = "";
                _textColor = Color.Black;

                _currentBitmap = new Bitmap(_originalBitmap);

                _timerOpacity = new System.Timers.Timer(15);
                _timerOpacity.Elapsed += _timerOpacity_Elapsed;
                _timerOpacity.Interval = 15;

                this.StartTimer();
            }

            public void SetImage(Image img)
            {
                _originalBitmap = new Bitmap(img);

                Image lastImage;

                lock (_form)
                {
                    _currentBitmap.Dispose();
                    _currentBitmap = GenerateImage();
                    lastImage = _currentBitmap;
                }

                this.ShowBitmap(lastImage, (byte)_oppacity);
            }

            public void SetText(String text, Color color)
            {
                _text = text;
                _textColor = color;

                Image lastImage;

                lock (_form)
                {
                    _currentBitmap.Dispose();
                    _currentBitmap = GenerateImage();
                    lastImage = _currentBitmap;
                }

                this.ShowBitmap(lastImage, (byte)_oppacity);
            }

            public void StartTimer()
            {
                _timerOpacity.Start();
            }

            private Image GenerateImage()
            {
                Bitmap newBitmap = new Bitmap(_originalBitmap);
                Graphics g = Graphics.FromImage(newBitmap);
                StringFormat fmt = new StringFormat();
                fmt.LineAlignment = StringAlignment.Center;
                fmt.Alignment = StringAlignment.Center;

                g.DrawString(_text, new Font("Ink free", 22, FontStyle.Bold), new SolidBrush(_textColor), _messageRect, fmt);
                g.Dispose();

                return newBitmap;
            }

            private void InitializeComponent(Size sz)
            {
                this.SuspendLayout();
                this.Size = sz;
                this.Cursor = Cursors.AppStarting;
                this.FormBorderStyle = FormBorderStyle.None;
                this.ShowInTaskbar = false;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.ResumeLayout(false);
            }

            private void _timerOpacity_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                Image lastImg;

                _oppacity += _speed;

                if (_oppacity < 0)
                {
                    _timerOpacity.Stop();
                    _oppacity = 0;
                    this.InvokeAuto(() => this.Close());
                }
                else if (_oppacity > 255)
                {
                    _timerOpacity.Stop();
                    _oppacity = 255;

                    lock (_form)
                        lastImg = _currentBitmap;

                    this.ShowBitmap(lastImg, (byte)(_oppacity));
                }
                else
                {
                    lock (_form)
                        lastImg = _currentBitmap;

                    this.ShowBitmap(lastImg, (byte)(_oppacity));
                }
            }

            private Bitmap WriteVersion(Bitmap img)
            {
                Graphics g = Graphics.FromImage(img);
                g.DrawString(Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf('.')), new Font("Calibri", 16, FontStyle.Bold), new SolidBrush(Color.FromArgb(67, 78, 84)), new PointF(82, 212));

                return img;
            }

            private void ShowBitmap(Image bitmap, byte opacity)
            {
                Bitmap copyBmp;

                // The idea of this is very simple,
                // 1. Create a compatible DC with screen;
                // 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
                // 3. Call the UpdateLayeredWindow.

                try
                {

                    lock (_form)
                    {
                        // On copie l'image parce qu'avec l'invocation on sait pas trop quand ça va être executé et l'image aura peut être été détruite.
                        copyBmp = new Bitmap(bitmap);
                    }

                    IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
                    IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
                    IntPtr hBitmap = IntPtr.Zero;
                    IntPtr oldBitmap = IntPtr.Zero;

                    try
                    {
                        hBitmap = copyBmp.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                        oldBitmap = Win32.SelectObject(memDc, hBitmap);

                        Win32.Size size = new Win32.Size(copyBmp.Width, copyBmp.Height);
                        Win32.Point pointSource = new Win32.Point(0, 0);
                        Win32.Point topPos = new Win32.Point(Left, Top);
                        Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                        blend.BlendOp = Win32.AC_SRC_OVER;
                        blend.BlendFlags = 0;
                        blend.SourceConstantAlpha = opacity;
                        blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                        this.InvokeAuto(() => Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA));
                    }
                    finally
                    {
                        Win32.ReleaseDC(IntPtr.Zero, screenDc);
                        if (hBitmap != IntPtr.Zero)
                        {
                            Win32.SelectObject(memDc, oldBitmap);
                            Win32.DeleteObject(hBitmap);
                        }
                        Win32.DeleteDC(memDc);

                        copyBmp.Dispose();
                    }
                }
                catch { }
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x00080000; // This form has to have the WS_EX_LAYERED extended style
                    cp.ExStyle |= 0x00000008; // WS_EX_TOPMOST
                    return cp;
                }
            }

            private class Win32
            {
                public enum Bool
                {
                    False = 0,
                    True
                };

                [StructLayout(LayoutKind.Sequential)]
                public struct Point
                {
                    public Int32 x;
                    public Int32 y;

                    public Point(Int32 x, Int32 y) { this.x = x; this.y = y; }
                }

                [StructLayout(LayoutKind.Sequential)]
                public struct Size
                {
                    public Int32 cx;
                    public Int32 cy;

                    public Size(Int32 cx, Int32 cy) { this.cx = cx; this.cy = cy; }
                }

                [StructLayout(LayoutKind.Sequential, Pack = 1)]
                struct ARGB
                {
                    public byte Blue;
                    public byte Green;
                    public byte Red;
                    public byte Alpha;
                }

                [StructLayout(LayoutKind.Sequential, Pack = 1)]
                public struct BLENDFUNCTION
                {
                    public byte BlendOp;
                    public byte BlendFlags;
                    public byte SourceConstantAlpha;
                    public byte AlphaFormat;
                }

                public const Int32 ULW_COLORKEY = 0x00000001;
                public const Int32 ULW_ALPHA = 0x00000002;
                public const Int32 ULW_OPAQUE = 0x00000004;

                public const byte AC_SRC_OVER = 0x00;
                public const byte AC_SRC_ALPHA = 0x01;

                [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
                public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

                [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
                public static extern IntPtr GetDC(IntPtr hWnd);

                [DllImport("user32.dll", ExactSpelling = true)]
                public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

                [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
                public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

                [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
                public static extern Bool DeleteDC(IntPtr hdc);

                [DllImport("gdi32.dll", ExactSpelling = true)]
                public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

                [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
                public static extern Bool DeleteObject(IntPtr hObject);
            }
        }
    }
}
