using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiffrementHill
{
    class Decrypt
    {
        int c1, c2;
        char c;
        int[] cryptMatrice;

        /// <summary>
        /// Decrypt message with hill cipher
        /// with encryption 2*2 matrix
        /// </summary>
        /// <param name="charMessage">char array of the crypted message</param>
        /// <param name="cryptMatrice">2*2 matrix used of encryption</param>
        /// <returns></returns>
        public string DecryptMessage(char[] charMessage, int[] cryptMatrice)
        {
            this.cryptMatrice = cryptMatrice;
            //get the decryption matrix
            int[] decryptMatrice = DecryptMatrice();
            string finalMessage = "";

            //-96 and +96 used to get the letters numbers as A=1, B=2 etc... not the ASCII value
            for (int i = 0; i < charMessage.Count() - 1; i += 2)
            {
                c1 = (decryptMatrice[0] * (charMessage[i] - 96) + decryptMatrice[1] * (charMessage[i + 1] - 96)) % 26;
                c2 = (decryptMatrice[2] * (charMessage[i] - 96) + decryptMatrice[3] * (charMessage[i + 1] - 96)) % 26;

                c = Convert.ToChar(c1 + 96);
                finalMessage += c;
                c = Convert.ToChar(c2 + 96); ;
                finalMessage += c;
            }
            return finalMessage;
        }

        /// <summary>
        /// Calculation of the determinant of the 2*2 matrix
        /// </summary>
        /// <returns>Determinant</returns>
        private int DetM()
        {
            return cryptMatrice[0] * cryptMatrice[3] - cryptMatrice[1] * cryptMatrice[2];
        }

        /// <summary>
        /// Brute-force the determinant of the matrix 
        /// to get the prime number needed for the decryption matrix
        /// </summary>
        /// <returns></returns>
        private int InverseModuloK()
        {
            int[] primeNumbers = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
            int determinant = DetM();
            int result = 0;
            int i = 0;

            while (result != 1)
            {
                i++;
                result = determinant * primeNumbers[i] % 26;
            }
            return primeNumbers[i];
        }

        /// <summary>
        /// Inverse the given 2*2 matrix
        /// </summary>
        /// <returns>Inverse of the matrix</returns>
        private int[] InverseMatrice()
        {
            return new int[] { cryptMatrice[3], -cryptMatrice[1], -cryptMatrice[2], cryptMatrice[0] };
        }

        /// <summary>
        /// Calculation of the decryption matrix
        /// need : the inverse % 26 of the determinant and the inverse matrix
        /// </summary>
        /// <returns>decryption matrix</returns>
        private int[] DecryptMatrice()
        {
            int[] inverseMatrice = InverseMatrice();
            int inverseModuloK = InverseModuloK();
            int[] dMatrice = { inverseMatrice[0]* inverseModuloK % 26, inverseMatrice[1] * inverseModuloK % 26,
                inverseMatrice[2] * inverseModuloK % 26, inverseMatrice[3] * inverseModuloK % 26 };

            //%26 is bugged and can give negative number, we need to add 26 to get the right value
            for (int i = 0; i < dMatrice.Length; i++)
            {
                if (dMatrice[i] < 0)
                    dMatrice[i] = dMatrice[i] + 26;
            }
            return dMatrice;
        }
    }
}
