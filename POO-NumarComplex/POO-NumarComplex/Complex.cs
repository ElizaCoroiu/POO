using System;

namespace POO_NumarComplex
{
    internal class Complex
    {
        public double real, imaginar;

        public Complex()
        {
            this.real = 0;
            this.imaginar = 0;
        }
        
        public Complex(double real)
        {
            this.real = real;
        }

        public Complex(double real, double imaginar)
        {
            this.real = real;
            this.imaginar = imaginar;
        }

        public double r { get => Math.Sqrt(Math.Pow(this.real, 2) + Math.Pow(this.imaginar, 2)); }
        public double argz
        {
            get
            {
                try
                {
                    return Math.Atan(this.imaginar / this.real);
                }
                catch (Exception)
                {
                    throw new DenominatorIsZero(this.real);
                }
            }
        }

        public void Print()
        {
            if (real == 0 && imaginar == 0)
            {
                Console.WriteLine($"z = 0");
            }
            else if (imaginar == 0)
            {
                Console.WriteLine($"z = {real}");
            }
            else if (real == 0)
            {
                Console.WriteLine($"z = {imaginar}i");
            }
            else
            {
                Console.WriteLine($"z = {real} + {imaginar}i"); 
            }
        }

        public virtual Complex Pow(int n)
        {
            Complex z = new Complex(this.real, this.imaginar);
            Complex result = new Complex();

            if (n == 0)
            {
                result.real = 1;
                result.imaginar = 0;

                return result;
            }
            else if (n % 2 == 0)
            {
                result = (z.Pow(n / 2))*(z.Pow(n / 2));

                return result;
            }
            else
            {
                result = z * (z.Pow(n / 2) * (z.Pow(n / 2)));

                return result;
            }
        }

        public void GetTrigonometricFormAndPow(double n)
        {

            double r = Math.Sqrt(Math.Pow(this.real, 2) + Math.Pow(this.imaginar, 2));
            double argz;

            try
            {
                argz = Math.Atan(this.imaginar / this.real);
            }
            catch (Exception)
            {
                throw new DenominatorIsZero(this.real);
            }

            Console.WriteLine($"z = {r} (cos({argz}) + isin({argz}))");

            Console.WriteLine($"z = {r}^{n}(cos({n}*{argz}) + isin({n}*{argz}))");
        }

        public static Complex operator *(Complex a, Complex b)
        {
            double real, imaginar;

            real = a.real * b.real - a.imaginar * b.imaginar;
            imaginar = a.real * b.imaginar + a.imaginar * b.real;

            return new Complex(real, imaginar);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.real-b.real, a.imaginar-b.imaginar);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.real + b.real, a.imaginar + b.imaginar);
        }

        public override string ToString()
        {
            return $"z = {this.real} + {this.imaginar}i";
        }
    }
}


