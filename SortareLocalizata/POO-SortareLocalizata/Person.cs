using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace POO_SortareLocalizata
{
    internal class Person
    {
        private string line;
        private string[] names;

        public Person(string line)
        {
            this.line = line;
            char[] seps = { ' ', ',' };
            names = line.Split(seps, StringSplitOptions.RemoveEmptyEntries);

            CultureInfo myCIintl = new CultureInfo("ro-RO", false);

            for (int i = 0; i < names.Length; i++)
            {
                string allLower = names[i].ToLower(myCIintl);

                names[i] = $"{char.ToUpper(allLower[0], myCIintl)}{allLower.Substring(1)}";
            }
        }

        public override string ToString()
        {
            string firstName = "";

            for (int i = 1; i < names.Length; i++)
            {
                firstName += names[i] + " ";
            }
           
            return $"{names[0]} {firstName}";
        }    
    }
}
        

        
            

        