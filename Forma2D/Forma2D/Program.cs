using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma2D
{
    class Program
    {
        static void Main(string[] args)
        {
            Cerc cerc = new Cerc(4, "cerc");
            Console.WriteLine(cerc);
            F(cerc);
            
            Patrat patrat = new Patrat(10, "patrat");
            Console.WriteLine(patrat);
            F(patrat);

            Console.ReadKey();
        }

        static void F(IForma2D f)
        {
            Console.WriteLine($"Aria este egala cu {f.Aria()}");
            Console.WriteLine($"Perimetrul este egal cu {f.LungimeaFrontierei()}");
            Console.WriteLine();

        }
    }
}
