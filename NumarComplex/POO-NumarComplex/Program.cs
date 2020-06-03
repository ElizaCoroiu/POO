using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_NumarComplex
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex z1 = new Complex();
            Complex z2 = new Complex(2);
            Complex z3 = new Complex(1, 1);
            Complex z4 = new Complex(2, 3);

            z1.Print(); 
            z2.Print();
            z3.Print();
            z4.Print();
            Console.WriteLine();

            Console.WriteLine("Adunare: ");
            Complex z5;
            z5 = z3 + z4;
            z5.Print();
            Console.WriteLine();

            Console.WriteLine("Scădere: ");
            Complex z6;
            z6 = z4 - z2;
            z6.Print();
            Console.WriteLine();

            Console.WriteLine("Inmulțire: ");
            Complex z7;
            z7 = z3 * z4;
            z7.Print();
            Console.WriteLine();

            Console.WriteLine("Ridicare la putere: ");
            Complex z8;
            z8 = z3.Pow(2);
            z8.Print();
            Console.WriteLine();

            Console.WriteLine("Forma trigonometrică și ridicarea la putere: ");
            z3.GetTrigonometricFormAndPow(3);
            Console.WriteLine();

            Console.WriteLine("Ridicare la putere in clasa derivata: ");
            ComplexD z9 = new ComplexD(1, 1);
            Complex z10= z9.Pow(2);
            z10.Print();
            Console.WriteLine();

            List<Complex> points = new List<Complex>() { new Complex(1,1), new Complex(5, 4), new Complex(2, 3)};
            ComplexD z = new ComplexD(8, 1);
            double distance = z.GetDistance(points);
            Console.WriteLine($"The distance from point {z} to the given list of points is: {distance}");
        
            Console.ReadKey();
        }
    }
}

            
           

           

