using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace POO_SortareLocalizata
{
    internal class MyComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return string.Compare(x.ToString(), y.ToString(), new CultureInfo("ro-RO"), CompareOptions.None);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                List<Person> listOfPersons = new List<Person>();
                string fileName = @"..\..\nume.txt";

                StreamReader sr = new StreamReader(fileName);
                string line = sr.ReadLine();

                while (line != null)
                {
                    Person currentPerson = new Person(line);
                    listOfPersons.Add(currentPerson);

                    line = sr.ReadLine();
                }

                Console.WriteLine("Before sorting: ");
                Console.WriteLine();
                foreach (var persona in listOfPersons)
                {
                    Console.WriteLine(persona);
                }

                listOfPersons.Sort(new MyComparer());

                Console.WriteLine();
                Console.WriteLine("After sorting: ");
                Console.WriteLine();

                foreach (var person in listOfPersons)
                {
                    Console.WriteLine(person);
                }

                fileName = @"..\..\output.txt";
                StreamWriter sw = new StreamWriter(fileName);

                foreach (var persona in listOfPersons)
                {
                    sw.WriteLine(persona);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("This file could not be read: ");
                Console.WriteLine(e.Message);
            }
            
            Console.ReadKey();
        }
    }
}

