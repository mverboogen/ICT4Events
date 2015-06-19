using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReserveringSysteem
{
    public class HashGenerator
    {
        /// <summary>
        /// Generates a random hash used for account activation
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string GenerateToken(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }
    }
}