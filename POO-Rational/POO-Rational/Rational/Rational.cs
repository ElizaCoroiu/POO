using System;

namespace POO_Rational
{
    public class Rational
    {
        private int numarator, numitor;

        private static int uuid = 1;

        private int id;

        public Rational()
        {
            this.numarator = 0;
            this.numitor = 1;
            this.id = uuid;

            uuid++;
        }

        public Rational(int numarator)
        {
            this.numarator = numarator;
            this.numitor = 1;
            this.id = uuid;

            uuid++;
        }

        public Rational(int numarator, int numitor)
        {
            this.numarator = numarator;
            this.numitor = numitor;

            if (this.numitor == 0)
            {
                throw new ArgumentException("Numitorul nu poate fi zero.", nameof(this.numitor));
            }

            this.id = uuid;
            uuid++;
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            if (r1.numarator * r2.numitor == r1.numitor * r2.numarator)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Rational r1, Rational r2)
        {
            if (r1.numarator * r2.numitor != r1.numitor * r2.numarator)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            if (r1.numarator * r2.numitor < r1.numitor * r2.numarator)
            {
                return true;
            }

            return false;
        }

        public static bool operator >(Rational r1, Rational r2)
        {
            if (r1.numarator * r2.numitor > r1.numitor * r2.numarator)
            {
                return true;
            }

            return false;
        }

        public static bool operator >=(Rational r1, Rational r2)
        {
            if (r1.numarator * r2.numitor >= r1.numitor * r2.numarator)
            {
                return true;
            }

            return false;
        }

        public static bool operator <=(Rational r1, Rational r2)
        {
            if (r1.numarator * r2.numitor <= r1.numitor * r2.numarator)
            {
                return true;
            }

            return false;
        }
        public Rational Add(Rational r4)
        {
            int numarator, numitor;

            numarator = this.numarator * r4.numitor + r4.numarator * this.numitor;
            numitor = this.numitor * r4.numitor;

            return new Rational(numarator, numitor);
        }

        public Rational Subtract(Rational r4)
        {
            int numarator, numitor;

            numarator = this.numarator * r4.numitor - r4.numarator * this.numitor;
            numitor = this.numitor * r4.numitor;

            return new Rational(numarator, numitor);
        }

        public Rational Divide(Rational r4)
        {
            int numarator, numitor;
            numarator = this.numarator * r4.numitor;
            numitor = this.numitor * r4.numarator;

            return new Rational(numarator, numitor);
        }

        public Rational SimplifyFraction()
        {
            int numarator, numitor;
            int d = Util.gcd(this.numarator, this.numitor); // gcd=greatest common divisor
          
            numarator = this.numarator / d;
            numitor = this.numitor / d;

            return new Rational(numarator, numitor);
        }

        internal class Util
        {
            private Util()
            {
            }

            public static int gcd(int a, int b)
            {
                int r;
                while (b != 0)
                {
                    r = a % b;
                    a = b;
                    b = r;
                }
                return a;
            }
        }

        public Rational Pow(int n)
        {
            int numarator, numitor;

            numarator = (int)Math.Pow(this.numarator, n);
            numitor = (int)Math.Pow(this.numitor, n);

            return new Rational(numarator, numitor);
        }

        public Rational Multiply(Rational r4)
        {
            int numarator, numitor;

            numarator = this.numarator * r4.numarator;
            numitor = this.numitor * r4.numitor;

            return new Rational(numarator, numitor);
        }

        public void Print()
        {
            Console.WriteLine($"r{this.id} = {numarator} / {numitor}; ");
        }

        public override string ToString() => $"{this.numarator}/{this.numitor}";
        
    }
}






