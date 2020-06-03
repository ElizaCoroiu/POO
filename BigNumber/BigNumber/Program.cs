using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Clasa NumarMare");
            NumarMare n1 = new NumarMare("1204");
            NumarMare n2 = new NumarMare("202");
            Console.WriteLine();

            NumarMare n3 = n1 + n2;
            Console.WriteLine($"{n1} + {n2} = {n3}");
            Console.WriteLine();

            //NumarMare n4 = new NumarMare("908765434");
            //NumarMare n5 = new NumarMare("456");
            //NumarMare n6 = n4 * n5;
            //Console.WriteLine($"{n4} * {n5} = {n6}");
            //Console.WriteLine();

            //NumarMare F100 = GetFibonacciNumber(100);
            //Console.WriteLine($"The 100th Fibonacci number is: {F100}");
            //Console.WriteLine();

            //NumarMare x = new NumarMare("1000");
            //NumarMare y = x.GetFactorial(1000);
            //Console.WriteLine($"1000! = {y}");

            Console.ReadKey();
        }

        private static NumarMare GetFibonacciNumber(int n)
        {
            NumarMare F0 = new NumarMare("0");
            NumarMare F1 = new NumarMare("1");
            NumarMare Fn = new NumarMare("0");

            for (int i = 2; i <= n; i++)
            {
                Fn = F0 + F1;
                F0 = F1;
                F1 = Fn;
            }
            
            return Fn;
        }
    }
}

        

            
