using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamesListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Names n = new Names();
            // The initial list contains a default name: 
            Console.WriteLine("Initial list contains a default name: ");
            n.Print();

            // We can add names to the list
            n.Add("Sandra Izbasa");
            n.Add("Catalina Ponor");
            Console.WriteLine("Added some other names: ");
            n.Print();

            // Using the integer type indexer we cand replace a name 
            // If there isn't any name at specified indexer, we will recieve an error
            Console.WriteLine($"We will replace <{n[1]}> with <Diana Chelaru> using integer type indexer: ");
            n[1] = "Diana Chelaru";
            n.Print();

            // We can search a name in the list by string type indexer
            // If the name doesn't exist, we will recieve an error
            Console.WriteLine("Searching for name: ");
            Console.WriteLine(n["Catalina Ponor"]);

            // We are now looking for a name that doesn't exist
            // Console.WriteLine(n["Maria"]);

            Console.ReadKey();
        }
    }
}
