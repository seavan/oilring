using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Очищает текст от апострофов, кавычек, лишних пробелов и аббревиатур. Переводит его в нижний регистр
        /// </summary>
        public static string ClearText(this String str)
        {
            return str
                .Replace("'", "")
                .Replace("\"", "")
                .Replace("“", "")
                .Replace("”", "")
                .Replace("«", "")
                .Replace("»", "")
                .Replace("‘", "")
                .Replace("’", "")
                .Replace("ОАО ", "")
                .Replace("ЗАО ", "")
                .Replace("ООО ", "")
                .Replace("НО ", "")
                .Replace("ИП ", "")
                .Replace(" ", "")
                .Trim()
                .ToLower()
                ;
        }

        private static string TextChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ12346789abcdefghijklmnopqrstuvwxyz";
        public static string RandomString(int lengthString = 8)
        {
            StringBuilder sb = new StringBuilder(lengthString);
            int maxLength = TextChars.Length;
            Random _rand = new Random();
            for (int n = 0; n <= lengthString - 1; n++)
                sb.Append(TextChars.Substring(_rand.Next(maxLength), 1));

            return sb.ToString();
        }
    }
}
