using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace GoBot.Communications
{
    /// <summary>
    /// Association d'une trame et de son heure de réception
    /// </summary>
    public class TimedFrame : IComparable
    {
        /// <summary>
        /// Trame contenant les données
        /// </summary>
        public Frame Frame { get; set; }
        
        /// <summary>
        /// Date de la trame
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Vrai si la trame a été reçue, faux si elle a été envoyée
        /// </summary>
        public bool IsInputFrame { get; set; }

        public TimedFrame(Frame frame, DateTime date, bool input = true)
        {
            Frame = frame;
            Date = date;
            IsInputFrame = input;
        }

        int IComparable.CompareTo(object obj)
        {
            return Date.CompareTo(((TimedFrame)obj).Date);
        }

        public void Export(StreamWriter writer)
        {
            writer.WriteLine(Date.ToString("dd/MM/yyyy hh:mm:ss.fff"));
            writer.WriteLine(Frame);
            writer.WriteLine(IsInputFrame);
        }

        public static TimedFrame Import(StreamReader reader)
        {
            DateTime date = DateTime.ParseExact(reader.ReadLine(), "dd/MM/yyyy hh:mm:ss.fff", null);
            Frame frame = new Frame(reader.ReadLine());
            Boolean isInput = Boolean.Parse(reader.ReadLine());

            return new TimedFrame(frame, date, isInput);
        }
    }

    /// <summary>
    /// Permet de sauvegarder l'historique des trames reçue ainsi que leur heure d'arrivée
    /// </summary>
    public class FramesLog
    {
        /// <summary>
        /// Extension du fichier de sauvegarde
        /// </summary>
        public static String FileExtension { get; } = ".tlog";

        /// <summary>
        /// Liste des trames
        /// </summary>
        public List<TimedFrame> Frames { get; private set; }

        public FramesLog()
        {
            Frames = new List<TimedFrame>();
        }

        /// <summary>
        /// Ajoute une trame reçue avec l'heure actuelle
        /// </summary>
        /// <param name="frame">Trame à ajouter</param>
        public void AddFrame(Frame frame, bool isInput, DateTime? date = null)
        {
            if (!date.HasValue)
                date = DateTime.Now;

            lock (Frames)
            {
                Frames.Add(new TimedFrame(frame, date.Value, isInput));
            }
        }

        /// <summary>
        /// Charge une sauvegarde de Replay
        /// </summary>
        /// <param name="fileName">Chemin du fichier</param>
        /// <returns>Vrai si la sauvegarde a été correctement chargée</returns>
        public bool Import(String fileName)
        {
            try
            {
                StreamReader reader = new StreamReader(fileName);

                int version = int.Parse(reader.ReadLine().Split(':')[1]);

                lock (Frames)
                {
                    while (!reader.EndOfStream)
                        Frames.Add(TimedFrame.Import(reader));
                }

                reader.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Erreur lors de la lecture de " + this.GetType().Name + " : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Sauvegarde l'ensemble des trames dans un fichier
        /// </summary>
        /// <param name="fileName">Chemin du fichier</param>
        /// <returns>Vrai si la sauvegarde s'est correctement déroulée</returns>
        public bool Export(String fileName)
        {
            try
            {
                StreamWriter writer = new StreamWriter(fileName);

                writer.WriteLine("Format:1");

                lock (Frames)
                {
                    foreach (TimedFrame frame in Frames)
                        frame.Export(writer);
                }

                writer.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Erreur lors de l'enregistrement de " + this.GetType().Name + " : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Permet de simuler la réception des trames enregistrées en respectant les intervalles de temps entre chaque trame
        /// </summary>
        public void ReplayInputFrames()
        {
            // Attention ça ne marche que pour l'UDP !
            for (int i = 0; i < Frames.Count;i++)
            {
                if (Frames[i].IsInputFrame)
                    Connections.UDPBoardConnection[UDP.UdpFrameFactory.ExtractBoard(Frames[i].Frame)].OnFrameReceived(Frames[i].Frame);

                if (i - 1 > 0)
                    Thread.Sleep(Frames[i].Date - Frames[i - 1].Date);
            }
        }

        /// <summary>
        /// Trie les trames par heure de réception
        /// </summary>
        public void Sort()
        {
            lock (Frames)
            {
                Frames.Sort();
            }
        }
    }
}
