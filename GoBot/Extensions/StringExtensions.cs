using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions
{
    internal static class StringExtensions
    {
        public static String FirstCamelWord(this String txt)
        {
            string word = string.Empty;

            if (!string.IsNullOrEmpty(txt))
            {
                foreach (char ch in txt)
                {
                    if (char.IsLower(ch))
                        word += ch.ToString();
                    else
                        break;

                }
            }

            return word;
        }
    }
}
