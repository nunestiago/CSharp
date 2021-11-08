using System;
using System.Linq;

namespace IreBank.Utils
{
    internal class FileName
    {
        public FileName()
        {
        }

        public FileName(string custName, string custSurname)
        {
            CustName = custName;
            CustSurname = custSurname;
        }

        public string CustName { get; }
        public string CustSurname { get; }

        public string NameConverter(string name, string surname)
        {
    
            string first = (Char.ToString(name[0])).ToLower();
            string second = Char.ToString(surname[0]).ToLower();
            int fullName = ($"{name}{surname}").Count(c => !Char.IsWhiteSpace(c));

            int one = LetterToNumber.LetterFromNumber(first);
            int two = LetterToNumber.LetterFromNumber(second);

            return $"{first}{second}-{fullName}-{one}-{two}";
        }
    }
}