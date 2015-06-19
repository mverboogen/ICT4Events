using System;

namespace ReserveringSysteem
{
    public class HashGenerator
    {
        /// <summary>
        ///     Generates a random hash used for account activation
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string GenerateToken(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new string(stringChars);

            return finalString;
        }
    }
}