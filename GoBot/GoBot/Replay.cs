using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDP;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace GoBot
{
    [Serializable]
    public class TrameReplay
    {
        public String Trame { get; set; }
        public DateTime Date { get; set; }

        public TrameReplay(Trame trame, DateTime date)
        {
            Trame = trame.ToString();
            Date = date;
        }

        public TrameReplay()
        {
        }
    }

    [Serializable]
    public class Replay
    {
        List<TrameReplay> tramesEntrantes;

        public Replay()
        {
            tramesEntrantes = new List<TrameReplay>();
        }

        public void AjouterTrameEntrante(Trame trame)
        {
            AjouterTrameEntrante(trame, DateTime.Now);
        }

        public void AjouterTrameEntrante(Trame trame, DateTime date)
        {
            tramesEntrantes.Add(new TrameReplay(trame, date));
        }

        public bool Load(String nomFichier)
        {
            try
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<TrameReplay>));
                FileStream myFileStream = new FileStream(nomFichier, FileMode.Open);
                tramesEntrantes = (List<TrameReplay>)mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save(String nomFichier)
        {
            try
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<TrameReplay>));
                StreamWriter myWriter = new StreamWriter(nomFichier);
                mySerializer.Serialize(myWriter, tramesEntrantes);
                myWriter.Close();
                /*XmlSerializer mySerializer = new XmlSerializer(typeof(Replay));
                StreamWriter myWriter = new StreamWriter(nomFichier);
                mySerializer.Serialize(myWriter, this);
                myWriter.Close();*/
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Rejouer()
        {
            ReceptionTrame += new ReceptionTrameDelegate(GrosRobot.connexionIo.TrameRecue);

            for (int i = tramesEntrantes.Count - 1; i > 0; i--)
            {
                ReceptionTrame(new Trame(tramesEntrantes[i].Trame));
                if (i - 1 > 0)
                    Thread.Sleep(tramesEntrantes[i].Date - tramesEntrantes[i - 1].Date);
            }
        }

        public delegate void ReceptionTrameDelegate(Trame t);
        public event ReceptionTrameDelegate ReceptionTrame;
    }
}
