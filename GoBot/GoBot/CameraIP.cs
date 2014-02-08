using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;

namespace GoBot
{
    class CameraIP
    {
        public String URLImage { get; set; }

        public CameraIP(String url)
        {
            URLImage = url;
        }

        public CameraIP()
        {
            URLImage = "http://10.1.0.10/snapshot.jpg";
        }

        public Bitmap GetImage()
        {
            try
            {
                // Récupération de l'image
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URLImage);
                Stream stream = req.GetResponse().GetResponseStream();
                Bitmap img = (Bitmap)Bitmap.FromStream(stream);
                return img;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
