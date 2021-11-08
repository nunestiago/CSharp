using System;

namespace IreBank.Utils
{
    internal class LetterToNumber
    {
        public static int LetterFromNumber(string column)
        {
            int retVal = 0;
            string col = column.ToUpper();
            for (int iChar = col.Length - 1; iChar >= 0; iChar--)
            {
                char colPiece = col[iChar];
                int colNum = colPiece - 64;
                retVal += colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
            }
            return retVal;
        }
    }
}