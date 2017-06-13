using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications
{
    [Serializable]
    public class Frame
    {
        /// <summary>
        /// Liste des octets de la trame
        /// </summary>
        private List<Byte> Bytes { get; set; }

        /// <summary>
        /// Liste des séparateurs entre les différents octets dans une chaine à convertir en trame
        /// </summary>
        private static char[] _separators = { '.', ' ', ':', ';', '-', '_', ',', '/', '\\' };

        /// <summary>
        /// Construit une trame à partir d'un tableau d'octets
        /// </summary>
        /// <param name="message">Octets à convertir</param>
        public Frame(Byte[] message)
        {
            Bytes = new List<Byte>();

            foreach (Byte b in message)
                Bytes.Add((Byte)b);
        }

        /// <summary>
        /// Construit une trame à partir d'une chaine de caractères (Format "01 23 45 67 89 AB CD EF")
        /// </summary>
        /// <param name="message">Message à convertir</param>
        public Frame(String message)
        {
            Bytes = new List<Byte>();

            String[] splits = message.Split(_separators,StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splits.Length; i++)
            {
                try
                {
                    Bytes.Add(byte.Parse(splits[i], System.Globalization.NumberStyles.HexNumber));
                }
                catch (Exception)
                {
                    Bytes.Add(0);
                }
            }
        }

        /// <summary>
        /// Retourne l'octet à l'index i
        /// </summary>
        /// <param name="i">Index de l'octet à retourner</param>
        /// <returns>Octet à l'index i</returns>
        public Byte this[int i]
        {
            get
            {
                return At(i);
            }
        }

        /// <summary>
        /// Retourne l'octet à l'index i
        /// </summary>
        /// <param name="i">Index de l'octet à retourner</param>
        /// <returns>Octet à l'index i</returns>
        public Byte At(int i)
        {
            int num = Bytes.ElementAt(i);

            if(num >= 0 && num <= 255)
                return (Byte)num;

            return 0;
        }

        override public String ToString()
        {
            String output = "";

            foreach (byte b in Bytes)
            {
                String val = String.Format("{0:x}", b);
                if (val.Length == 1)
                    val = "0" + val;

                output = output + val + " ";
            }

            output = output.TrimEnd().ToUpper();

            return output;
        }

        /// <summary>
        /// Convertit la trame en tableau d'octets
        /// </summary>
        /// <returns>Tableau d'octets correspondant à la trame</returns>
        public byte[] ToBytes()
        {
            byte[] retour = new byte[Bytes.Count];

            for(int i = 0; i < Bytes.Count; i++)
            {
                retour[i] = Bytes[i];
            }

            return retour;
        }

        /// <summary>
        /// Longueur de la trame
        /// </summary>
        public int Length
        {
            get
            {
                return Bytes.Count;
            }
        }

        /// <summary>
        /// Carte concernée par la trame (Information contenue dans le premier octet de la trale)
        /// </summary>
        public Carte Board
        {
            get
            {
                try
                {
                    return (Carte)this[0];
                }
                catch (Exception)
                {
                    return Carte.PC;
                }
            }
        }

        /// <summary>
        /// Retourne un message textuel contenant l'information compréhensible véhiculée par la trame
        /// </summary>
        /// <returns>Message de la trame décodée</returns>
        public String Decode()
        {
            return DecodeurTrames.Decode(this);
        }
    }
}
