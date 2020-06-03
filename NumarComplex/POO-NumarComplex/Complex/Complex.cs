using System;

namespace POO_NumarComplex
{
    internal class Complex
    {
        private double real, imaginar;

        private static int uuid = 1;

        private int id;

        public Complex()
        {
            this.real = 0;
            this.imaginar = 0;
            this.id = uuid;

            uuid += 1;
        }
        
        public Complex(double real)
        {
            this.real = real;
            this.id = uuid;

            uuid += 1;
        }

        public Complex(double real, double imaginar)
        {
            this.real = real;
            this.imaginar = imaginar;
            this.id = uuid;

            uuid += 1;
        }

        public void Print()
        {
            if (real == 0 && imaginar == 0)
            {
                Console.WriteLine($"z{this.id} = 0");
            }
            else if (imaginar == 0)
            {
                Console.WriteLine($"z{this.id} = {real}");
            }
            else if (real == 0)
            {
                Console.WriteLine($"z{this.id} = {imaginar}i");
            }
            else
            {
                Console.WriteLine($"z{this.id} = {real} + {imaginar}i"); 
            }
        }

        public Complex Pow(int n)
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
                result = (z.Pow(n / 2)).Multiply(z.Pow(n / 2));

                return result;
            }
            else
            {
                result = z.Multiply(z.Pow(n / 2).Multiply(z.Pow(n / 2)));

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

            Console.WriteLine($"z = {r} (cos({argz}) + isin({argz})) ceea ce este echivalent cu: ");
            Console.WriteLine($"z = {r} ({Math.Cos(argz)} + i{(Math.Sin(argz))})");

            Console.WriteLine($"z = {r}^{n}(cos({n}*{argz}) + isin({n}*{argz})), ceea ce este echivalent cu:");
            Console.WriteLine($"z = {Math.Pow(r, n)}({Math.Cos(n*argz)} + i{Math.Sin(n*argz)})");
        }
           
           
        

        public Complex Multiply(Complex z4)
        {
            double real, imaginar;

            real = this.real * z4.real - this.imaginar * z4.imaginar;
            imaginar = this.real * z4.imaginar + this.imaginar * z4.real;

            return new Complex(real, imaginar);
        }

        public Complex Subtract(Complex z2)
        {
            double real, imaginar;

            real = this.real - z2.real;
            imaginar = this.imaginar - z2.imaginar;

            return new Complex(real, imaginar);
        }

        public Complex Add(Complex z4)
        {
            double real, imaginar;

            real = this.real + z4.real;
            imaginar = this.imaginar + z4.imaginar;

            return new Complex(real, imaginar);
        }

        public override string ToString()
        {
            return $"z{this.id} = {this.real} + {this.imaginar}i";
        }
    }
}