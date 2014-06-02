using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace GoBot.IHM
{
    /// <summary>
    /// classe form qui affiche le splash screen : image 32bits avec alpha sur 8 bits
    /// </summary>
    public partial class SplashScreen : Form
    {
        private static SplashScreen frm;
        private static Thread th;

        public static void ShowSplash(int vitesse = 10)
        {
            VitesseOuverture = vitesse;
            th = new Thread(new ThreadStart(Lancement));
            th.IsBackground = true;
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            while (frm == null) ;
        }

        private static void Lancement()
        {
            frm = new SplashScreen(global::GoBot.Properties.Resources.Splash);
            frm.ShowDialog();
        }

        public static void SetMessage(String texte, Color couleur)
        {
            frm.SetText(texte, couleur);
        }

        public static void CloseSplash(int vitesse = 30)
        {

            frm.Close();
            //VitesseFermeture = vitesse;
            //frm.Fermeture();
        }

        public SplashScreen(Bitmap image)
        {
            VitesseFermeture = 30;
            VitesseFermeture = 10;

            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            Graphics g = Graphics.FromImage(image);
            g.DrawString(Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf('.')), new System.Drawing.Font("Calibri", 16, FontStyle.Bold), new SolidBrush(Color.FromArgb(67, 78, 84)), new PointF(82, 212));

            m_bitmapOrigine = new Bitmap(image, image.Width, image.Height);
            m_bitmapOrigine.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            m_bitmap = image;

            this.Left   = Screen.PrimaryScreen.WorkingArea.X + ((Screen.PrimaryScreen.WorkingArea.Width - m_bitmap.Width) / 2);
            this.Top    = Screen.PrimaryScreen.WorkingArea.Y + ((Screen.PrimaryScreen.WorkingArea.Height - m_bitmap.Height) / 2);

            theTimer.Tick += new System.EventHandler(this.theTimer_Tick);
            theTimer.Interval = 15;
            opaciteCourante = 0;

            Ouverture();
        }
        
        String message = "";
        Color couleurMess = Color.Black;
        bool changement = false;
        public void SetText(String texte, Color couleur)
        {
            message = texte;
            couleurMess = couleur;

            changement = true;

            if (!bOuverture && !bFermeture)
                SetBitmap(m_bitmap, 255);
        }

        private void Fermeture()
        {
            bOuverture = false;
            bFermeture = true;
            theTimer.Start();
        }

        private void Ouverture()
        {
            bOuverture = true;
            bFermeture = false;
            theTimer.Start();
        }

        private void theTimer_Tick(object sender, EventArgs e)
        {
            if (bFermeture)
            {
                opaciteCourante -= VitesseFermeture;

                if (opaciteCourante < 0)
                {
                    theTimer.Stop();
                    opaciteCourante = 0;
                    bFermeture = false;
                    this.Close();
                }
                else
                    this.SetBitmap(m_bitmap, (byte)(opaciteCourante));
            }
            else if (bOuverture)
            {
                opaciteCourante += VitesseOuverture;

                if (opaciteCourante > 255)
                {
                    theTimer.Stop();
                    opaciteCourante = 255;
                    bOuverture = false;
                }
                this.SetBitmap(m_bitmap, (byte)(opaciteCourante));
            }
        }

        public void SetBitmap(Bitmap bitmap, byte opacity)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

            // The idea of this is very simple,
            // 1. Create a compatible DC with screen;
            // 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
            // 3. Call the UpdateLayeredWindow.

            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                if (changement)
                {
                    Graphics g = Graphics.FromImage(m_bitmap);
                    g.DrawImage(m_bitmapOrigine, 0, 0);

                    g.DrawString(message, new System.Drawing.Font("Jokerman", 20, FontStyle.Bold), new SolidBrush(couleurMess), new PointF(230, 30));
                    changement = false;
                }


                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.Point pointSource = new Win32.Point(0, 0);
                Win32.Point topPos = new Win32.Point(Left, Top);
                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                blend.BlendOp = Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
            }
            finally
            {
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    //Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
                    Win32.DeleteObject(hBitmap);
                }
                Win32.DeleteDC(memDc);
            }
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

        private int opaciteCourante;

        private bool bFermeture = false;
        private bool bOuverture = false;

        private Bitmap m_bitmap;
        private Bitmap m_bitmapOrigine;

        private static int VitesseOuverture { get; set; }
        private static int VitesseFermeture { get; set; }
    }

    // class that exposes needed win32 gdi functions.
    class Win32
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