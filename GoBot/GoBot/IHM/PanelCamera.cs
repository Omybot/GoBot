using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using DShowNET;
using DShowNET.Device;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing.Imaging;
using GoBot.Actionneurs;

namespace GoBot.IHM
{
    public partial class PanelCamera : UserControl, ISampleGrabberCB
    {
        private CameraIP Camera { get; set; }
        private Thread ThreadCapture { get; set; }
        public bool ContinuerCamera { get; set; }

        public PanelCamera()
        {
            InitializeComponent();
            ContinuerCamera = true;
            this.timer = new System.Windows.Forms.Timer();
            timer.Interval = 5;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);

            xStart = Config.CurrentConfig.CameraXMin;
            xEnd = Config.CurrentConfig.CameraXMax;
            yStart = Config.CurrentConfig.CameraYMin;
            yEnd = Config.CurrentConfig.CameraYMax;
        }

        private void Traitement()
        {
            if (imageCapture == null)
                return;

            Bitmap image = new Bitmap(imageCapture);
            Graphics gImage = Graphics.FromImage(image);
            Pen pen = new Pen(Color.FromArgb(250, 21, 128, 191), 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Brush brush = new SolidBrush(Color.FromArgb(100, 179, 221, 247));

            int r = 0;
            int g = 0;
            int b = 0;
            for (int xi = Math.Min(xStart, xEnd); xi < Math.Max(xStart, xEnd); xi++)
                for (int yi = Math.Min(yStart, yEnd); yi < Math.Max(yStart, yEnd); yi++)
                {
                    if (xi >= 0 && xi < image.Width && yi >= 0 && yi < image.Height)
                    {
                        Color pixelColor = image.GetPixel(xi, yi);
                        r += pixelColor.R;
                        g += pixelColor.G;
                        b += pixelColor.B;
                    }
                }

            int nbPoints = Math.Abs(xStart - xEnd) * Math.Abs(yStart - yEnd);

            if (nbPoints != 0)
            {
                r /= nbPoints;
                g /= nbPoints;
                b /= nbPoints;
            }

            if (!ContinuerCamera)
                return;

            lblCouleur.Text = r.ToString("###") + " " + g.ToString("###") + " " + b.ToString("###");

            // Pour le rouge, la composante R est deux fois plus élevée que la verte au minimum
            if (r > 1.35 * g)
                panelCouleurFeu.BackColor = Color.Red;
            else
                panelCouleurFeu.BackColor = Color.Yellow;

            // Pour le noir, toutes les composantes sont quasi égales ou la moyenne des composantes est inférieur à 40
            int moy = (r + g + b) / 3;
            if (moy < 40 ||
                (r < moy * 1.2 && r > moy * 0.80 &&
                g < moy * 1.2 && g > moy * 0.80 &&
                b < moy * 1.2 && b > moy * 0.80))
            {
                panelCouleurFruit.BackColor = Color.Black;
            }
            else
            {
                panelCouleurFruit.BackColor = Color.Purple;
            }

            panelCouleurMoyenne.BackColor = Color.FromArgb(r, g, b);

            gImage.FillRectangle(brush, Math.Min(xStart, xEnd), Math.Min(yStart, yEnd), Math.Abs(xStart - xEnd), Math.Abs(yStart - yEnd));
            gImage.DrawRectangle(pen, Math.Min(xStart, xEnd), Math.Min(yStart, yEnd), Math.Abs(xStart - xEnd), Math.Abs(yStart - yEnd));

            pictureBoxImage.Image = image;
        }

        public void btnCapture_Click(object sender, EventArgs e)
        {
             if (firstActive)
                return;
            firstActive = true;

            if (!DsUtils.IsCorrectDirectXVersion())
            {
                MessageBox.Show(this, "DirectX 8.1 NOT installed!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
                //this.Close(); return;
            }

            if (!DsDev.GetDevicesOfCat(FilterCategory.VideoInputDevice, out capDevices))
            {
                MessageBox.Show(this, "No video capture devices found!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //this.Close(); return;
            }

            DsDevice dev = null;
            if (capDevices.Count == 1)
                dev = capDevices[0] as DsDevice;
            else
            {
                /*DeviceSelector selector = new DeviceSelector(capDevices);
                selector.ShowDialog(this);
                dev = selector.SelectedDevice;*/

                MessageBox.Show(this, "Several video capture devices found!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //this.Close(); return;
            }

            if (dev == null)
            {
                //this.Close(); return;
            }

            if (!StartupVideo(dev.Mon))
            {
                //this.Close(); return;
            }


            ThreadCapture = new Thread(ThreadImage);
            ThreadCapture.Start();
        }

        /// <summary> start all the interfaces, graphs and preview window. </summary>
        bool StartupVideo(UCOMIMoniker mon)
        {
            int hr;
            try
            {
                if (!CreateCaptureDevice(mon))
                    return false;

                if (!GetInterfaces())
                    return false;

                if (!SetupGraph())
                    return false;

                if (!SetupVideoWindow())
                    return false;

#if DEBUG
                DsROT.AddGraphToRot(graphBuilder, out rotCookie);		// graphBuilder capGraph
#endif

                hr = mediaCtrl.Run();
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                timer.Enabled = true;

                return true;
            }
            catch
            {
                return false;
            }
        }
        // Non utilisé
        /// <summary> sample callback, NOT USED. </summary>
        int ISampleGrabberCB.SampleCB(double SampleTime, IMediaSample pSample)
        {
            //Trace.WriteLine( "!!CB: ISampleGrabberCB.SampleCB" );
            return 0;
        }


        // Non utilisé
        /// <summary> buffer callback, COULD BE FROM FOREIGN THREAD. </summary>

        int fpsTheorique = 0;
        int ISampleGrabberCB.BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
        {
            fpsTheorique++;
            if (captured || (savedArray == null))
            {
                //Trace.WriteLine("!!CB: ISampleGrabberCB.BufferCB");
                return 0;
            }

            captured = true;
            bufferedSize = BufferLen;
            //Trace.WriteLine( "!!CB: ISampleGrabberCB.BufferCB  !GRAB! size = " + BufferLen.ToString() );
            if ((pBuffer != IntPtr.Zero) && (BufferLen > 1000) && (BufferLen <= savedArray.Length))
                Marshal.Copy(pBuffer, savedArray, 0, BufferLen);
            else
                Trace.WriteLine("    !!!GRAB! failed ");
            this.BeginInvoke(new CaptureDone(this.OnCaptureDone));
            return 0;
        }
        /// <summary> make the video preview window to show in videoPanel. </summary>
        bool SetupVideoWindow()
        {

            int hr;
            try
            {
                // Set the video window to be a child of the main window
                //hr = videoWin.put_Owner(videoPanel.Handle);
                hr = videoWin.put_Owner(pictureBox1.Handle);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                // Set video window style
                hr = videoWin.put_WindowStyle(WS_CHILD | WS_CLIPCHILDREN);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                // Use helper function to position video window in client rect of owner window
                ResizeVideoWindow();

                // Make the video window visible, now that it is properly positioned
                hr = videoWin.put_Visible(DsHlp.OATRUE);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                hr = mediaEvt.SetNotifyWindow(this.Handle, WM_GRAPHNOTIFY, IntPtr.Zero);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary> build the capture graph for grabber. </summary>
        bool SetupGraph()
        {
            int hr;
            try
            {
                hr = capGraph.SetFiltergraph(graphBuilder);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                hr = graphBuilder.AddFilter(capFilter, "Ds.NET Video Capture Device");
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                //DsUtils.ShowCapPinDialog(capGraph, capFilter, this.Handle);

                AMMediaType media = new AMMediaType();
                media.majorType = MediaType.Video;
                media.subType = MediaSubType.RGB24;
                media.formatType = FormatType.VideoInfo;		// ???
                hr = sampGrabber.SetMediaType(media);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                hr = graphBuilder.AddFilter(baseGrabFlt, "Ds.NET Grabber");
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                Guid cat = PinCategory.Preview;
                Guid med = MediaType.Video;
                hr = capGraph.RenderStream(ref cat, ref med, capFilter, null, null); // baseGrabFlt 
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                cat = PinCategory.Capture;
                med = MediaType.Video;
                hr = capGraph.RenderStream(ref cat, ref med, capFilter, null, baseGrabFlt); // baseGrabFlt 
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                media = new AMMediaType();
                hr = sampGrabber.GetConnectedMediaType(media);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);
                if ((media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero))
                    throw new NotSupportedException("Unknown Grabber Media Format");

                videoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(media.formatPtr, typeof(VideoInfoHeader));
                Marshal.FreeCoTaskMem(media.formatPtr); media.formatPtr = IntPtr.Zero;

                hr = sampGrabber.SetBufferSamples(false);
                if (hr == 0)
                    hr = sampGrabber.SetOneShot(false);
                if (hr == 0)
                    hr = sampGrabber.SetCallback(null, 0);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary> create the used COM components and get the interfaces. </summary>
        bool GetInterfaces()
        {
            Type comType = null;
            object comObj = null;
            try
            {
                comType = Type.GetTypeFromCLSID(Clsid.FilterGraph);
                if (comType == null)
                    throw new NotImplementedException(@"DirectShow FilterGraph not installed/registered!");
                comObj = Activator.CreateInstance(comType);
                graphBuilder = (IGraphBuilder)comObj; comObj = null;

                Guid clsid = Clsid.CaptureGraphBuilder2;
                Guid riid = typeof(ICaptureGraphBuilder2).GUID;
                comObj = DsBugWO.CreateDsInstance(ref clsid, ref riid);
                capGraph = (ICaptureGraphBuilder2)comObj; comObj = null;

                comType = Type.GetTypeFromCLSID(Clsid.SampleGrabber);
                if (comType == null)
                    throw new NotImplementedException(@"DirectShow SampleGrabber not installed/registered!");
                comObj = Activator.CreateInstance(comType);
                sampGrabber = (ISampleGrabber)comObj; comObj = null;

                mediaCtrl = (IMediaControl)graphBuilder;
                videoWin = (IVideoWindow)graphBuilder;
                mediaEvt = (IMediaEventEx)graphBuilder;
                baseGrabFlt = (IBaseFilter)sampGrabber;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (comObj != null)
                    Marshal.ReleaseComObject(comObj); comObj = null;
            }
        }

        /// <summary> create the user selected capture device. </summary>
        bool CreateCaptureDevice(UCOMIMoniker mon)
        {
            object capObj = null;
            try
            {
                Guid gbf = typeof(IBaseFilter).GUID;
                mon.BindToObject(null, null, ref gbf, out capObj);
                capFilter = (IBaseFilter)capObj; capObj = null;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (capObj != null)
                    Marshal.ReleaseComObject(capObj); capObj = null;
            }

        }



        // Fonction de fermeture de la camera
        void CloseInterfaces()
        {
            int hr;
            try
            {
#if DEBUG
                if (rotCookie != 0)
                    DsROT.RemoveGraphFromRot(ref rotCookie);
#endif

                if (mediaCtrl != null)
                {
                    hr = mediaCtrl.Stop();
                    mediaCtrl = null;
                }

                if (mediaEvt != null)
                {
                    hr = mediaEvt.SetNotifyWindow(IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero);
                    mediaEvt = null;
                }

                if (videoWin != null)
                {
                    hr = videoWin.put_Visible(DsHlp.OAFALSE);
                    hr = videoWin.put_Owner(IntPtr.Zero);
                    videoWin = null;
                }

                baseGrabFlt = null;
                if (sampGrabber != null)
                    Marshal.ReleaseComObject(sampGrabber); sampGrabber = null;

                if (capGraph != null)
                    Marshal.ReleaseComObject(capGraph); capGraph = null;

                if (graphBuilder != null)
                    Marshal.ReleaseComObject(graphBuilder); graphBuilder = null;

                if (capFilter != null)
                    Marshal.ReleaseComObject(capFilter); capFilter = null;

                if (capDevices != null)
                {
                    foreach (DsDevice d in capDevices)
                        d.Dispose();
                    capDevices = null;
                }
            }
            catch
            { }
        }

        // Fonction de placement du flux video
        void ResizeVideoWindow()
        {
            if (videoWin != null)
            {
                //Rectangle rc = videoPanel.ClientRectangle;
                Rectangle rc = pictureBox1.ClientRectangle;
                videoWin.SetWindowPosition(0, 0, rc.Right, rc.Bottom);
            }
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            int hr;

            if (savedArray == null)
            {
                int size = videoInfoHeader.BmiHeader.ImageSize;
                if ((size < 1000) || (size > 16000000))
                    return;
                savedArray = new byte[size + 64000];
            }

            captured = false;
            hr = sampGrabber.SetCallback(this, 1);
        }
        private System.Windows.Forms.Timer timer;

        /*
        // Non utilisé
        /// <summary> sample callback, NOT USED. </summary>
        int ISampleGrabberCB.SampleCB(double SampleTime, IMediaSample pSample)
        {
            //Trace.WriteLine( "!!CB: ISampleGrabberCB.SampleCB" );
            return 0;
        }


        // Non utilisé
        /// <summary> buffer callback, COULD BE FROM FOREIGN THREAD. </summary>

        int fpsTheorique = 0;
        int ISampleGrabberCB.BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
        {
            fpsTheorique++;
            if (captured || (savedArray == null))
            {
                //Trace.WriteLine("!!CB: ISampleGrabberCB.BufferCB");
                return 0;
            }

            captured = true;
            bufferedSize = BufferLen;
            //Trace.WriteLine( "!!CB: ISampleGrabberCB.BufferCB  !GRAB! size = " + BufferLen.ToString() );
            if ((pBuffer != IntPtr.Zero) && (BufferLen > 1000) && (BufferLen <= savedArray.Length))
                Marshal.Copy(pBuffer, savedArray, 0, BufferLen);
            else
                Trace.WriteLine("    !!!GRAB! failed ");
            this.BeginInvoke(new CaptureDone(this.OnCaptureDone));
            return 0;
        }*/

        Bitmap imageCapture;
        void OnCaptureDone()
        {
            try
            {
                DateTime debut = DateTime.Now;
                //try 
                //{
                if (sampGrabber == null) return;
                int w = videoInfoHeader.BmiHeader.Width;
                int h = videoInfoHeader.BmiHeader.Height;
                int deltatime;
                if (((w & 0x03) != 0) || (w < 32) || (w > 4096) || (h < 32) || (h > 4096)) return;
                //get Image
                int stride = w * 3;
                GCHandle handle = GCHandle.Alloc(savedArray, GCHandleType.Pinned);
                int scan0 = (int)handle.AddrOfPinnedObject();
                scan0 += (h - 1) * stride;
                Bitmap b = new Bitmap(w, h, -stride, PixelFormat.Format24bppRgb, (IntPtr)scan0);

                imageCapture = new Bitmap(b, pictureBoxImage.Width, pictureBoxImage.Height);
                
                // Traitement image sur b2

                handle.Free();
            }
            catch (Exception)
            {
            }
        }


        /// <summary> flag to detect first Form appearance </summary>
        private bool firstActive;

        /// <summary> base filter of the actually used video devices. </summary>
        private IBaseFilter capFilter;

        /// <summary> graph builder interface. </summary>
        private IGraphBuilder graphBuilder;

        /// <summary> capture graph builder interface. </summary>
        private ICaptureGraphBuilder2 capGraph;
        private ISampleGrabber sampGrabber;

        /// <summary> control interface. </summary>
        private IMediaControl mediaCtrl;

        /// <summary> event interface. </summary>
        private IMediaEventEx mediaEvt;

        /// <summary> video window interface. </summary>
        private IVideoWindow videoWin;

        /// <summary> grabber filter interface. </summary>
        private IBaseFilter baseGrabFlt;

        /// <summary> structure describing the bitmap to grab. </summary>
        private VideoInfoHeader videoInfoHeader;
        private bool captured = true;
        private int bufferedSize;

        /// <summary> buffer for bitmap data. </summary>
        private byte[] savedArray;

        /// <summary> list of installed video devices. </summary>
        private ArrayList capDevices;

        private const int WM_GRAPHNOTIFY = 0x00008001;	// message from graph

        private const int WS_CHILD = 0x40000000;	// attributes for video window
        private const int WS_CLIPCHILDREN = 0x02000000;
        private const int WS_CLIPSIBLINGS = 0x04000000;

        /// <summary> event when callback has finished (ISampleGrabberCB.BufferCB). </summary>
        private delegate void CaptureDone();

#if DEBUG
        private int rotCookie = 0;

#endif


        private void ThreadImage()
        {
            do
            {
                Traitement();
            }
            while (ContinuerCamera);
        }

        bool definitionZone = false;
        bool definitionZoneStarted = false;
        private void btnDefinitionZone_Click(object sender, EventArgs e)
        {
            definitionZone = true;
        }

        int xStart, yStart, xEnd, yEnd;
        private void pictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (definitionZone)
            {
                xStart = e.X;
                yStart = e.Y;
                xEnd = e.X;
                yEnd = e.Y;
                definitionZoneStarted = true;
            }
        }

        private void pictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (definitionZone)
            {
                xEnd = e.X;
                yEnd = e.Y;

                Config.CurrentConfig.CameraXMin = xStart;
                Config.CurrentConfig.CameraXMax = xEnd;
                Config.CurrentConfig.CameraYMin = yStart;
                Config.CurrentConfig.CameraYMax = yEnd;

                Config.Save();

                definitionZone = false;
                definitionZoneStarted = false;
            }
        }

        private void pictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (definitionZone && definitionZoneStarted)
            {
                xEnd = e.X;
                yEnd = e.Y;
            }
        }
    }
}
