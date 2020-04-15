using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Rational
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational();
            Rational r2 = new Rational(2);
            Rational r3 = new Rational(3, 4);
            Rational r4 = new Rational(1, 2);

            Console.WriteLine("Print fractions: ");
            r1.Print();
            r2.Print();
            r3.Print();
            r4.Print();
            Console.WriteLine();

            Console.WriteLine("The addition: ");
            Rational r5;
            r5 = r3.Add(r4);
            r5.Print();
            Console.WriteLine();

            Console.WriteLine("The subtraction: ");
            Rational r6;
            r6 = r4.Subtract(r3);
            r6.Print();
            Console.WriteLine();

            Console.WriteLine("The multiplication: ");
            Rational r7;
            r7 = r3.Multiply(r4);
            r7.Print();
            Console.WriteLine();

            Console.WriteLine("The division: ");
            Rational r8;
            r8 = r3.Divide(r4);
            r8.Print();
            Console.WriteLine();

            Console.WriteLine("The exponentiation: ");
            Rational r9;
            r9 = r3.Pow(2);
            r9.Print();
            Console.WriteLine();

            Console.WriteLine("The irreducible form: ");
            Rational r10=new Rational(12, 20);
            r10 = r10.SimplifyFraction();
            r10.Print();
            Console.WriteLine();

            Console.WriteLine("Relational operators: ");
            bool is_equal = (r3 == r4);
            bool is_smaller = (r3 < r4);
            bool is_greater = (r3 > r4);
            bool is_greater_or_equal = (r3 >= r3);
            bool is_less_or_equal = (r2 <= r3);
            Console.WriteLine($"Is {r3} = {r4}? {is_equal}");
            is_equal = (r4 == r4);
            Console.WriteLine($"Is {r4} = {r4}? {is_equal}");
            Console.WriteLine($"Is {r3} < {r4}? {is_smaller}");
            Console.WriteLine($"Is {r3} < {r4}? {is_greater}");
            Console.WriteLine($"Is {r3} >= {r3}? {is_greater_or_equal}");
            Console.WriteLine($"Is {r2} <= {r3}? {is_less_or_equal}");





            Console.ReadKey();

        }
    }
}
