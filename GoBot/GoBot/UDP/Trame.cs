using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDP
{
    [Serializable]
    public class Trame
    {
        private List<Byte> donnees;
        static char[] separators = { '.', ' ', ':', ';', '-', '_', ',', '/', '\\' };

        public Trame(Byte[] message)
        {
            donnees = new List<Byte>();

            foreach (Byte b in message)
                donnees.Add((Byte)b);
        }

        public Trame(String chaine)
        {
            donnees = new List<Byte>();

            String[] message = chaine.Split(separators);

            for (int i = 0; i < message.Length; i++)
            {
                try
                {
                    donnees.Add(byte.Parse(message[i], System.Globalization.NumberStyles.HexNumber));
                }
                catch (Exception)
                {
                    donnees.Add(0);
                }
            }

        }

        public Byte this[int i]
        {
            get
            {
                return At(i);
            }
        }

        public Byte At(int i)
        {
            int num = donnees.ElementAt(i);

            if(num >= 0 && num <= 255)
                return (Byte)num;

            return 0;
        }

        override public String ToString()
        {
            String trameString = "";

            foreach (byte b in donnees)
            {
                String val = String.Format("{0:x}", b);
                if (val.Length == 1)
                    val = "0" + val;

                trameString = trameString + val + " ";
            }

            trameString = trameString.TrimEnd().ToUpper();

            return trameString;
        }

        public byte[] ToTabBytes()
        {
            byte[] retour = new byte[donnees.Count];

            for(int i = 0; i < donnees.Count; i++)
            {
                retour[i] = donnees[i];
            }

            return retour;
        }

        public int Length
        {
            get
            {
                return donnees.Count;
            }
        }
    }
}
