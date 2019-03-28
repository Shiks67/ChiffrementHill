using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiffrementHill
{
    class Encrypt
    {
        int c1, c2;
        char c;

        /// <summary>
        /// Encryption with Hill cipher
        /// 2*2 matrix
        /// </summary>
        /// <param name="charMessage">char array with the message</param>
        /// <param name="cryptMatrice">int array with matrix (0=a, 1=b, 2=c, 3=d)</param>
        /// <returns>crypted message</returns>
        public string EncryptMessage(char[] charMessage, int[] cryptMatrice)
        {
            string finalMessage = "";
            //-96 and +96 used to get the letters numbers as A=1, B=2 etc... not the ASCII value
            for (int i = 0; i < charMessage.Count(); i += 2)
            {
                //in case of odd number of letters, for the last char add an a
                if (i + 2 > charMessage.Count())
                {
                    c1 = (cryptMatrice[0] * (charMessage[i] - 96) + cryptMatrice[1] * ('a' - 96)) % 26;
                    c2 = (cryptMatrice[2] * (charMessage[i] - 96) + cryptMatrice[3] * ('a' - 96)) % 26;
                }
                else
                {
                    c1 = (cryptMatrice[0] * (charMessage[i] - 96) + cryptMatrice[1] * (charMessage[i + 1] - 96)) % 26;
                    c2 = (cryptMatrice[2] * (charMessage[i] - 96) + cryptMatrice[3] * (charMessage[i + 1] - 96)) % 26;
                }
                c = Convert.ToChar(c1 + 96);
                finalMessage += c;
                c = Convert.ToChar(c2 + 96); ;
                finalMessage += c;
            }
            return finalMessage;
        }
    }
}
