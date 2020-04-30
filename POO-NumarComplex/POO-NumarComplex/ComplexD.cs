using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_NumarComplex
{
    class ComplexD: Complex
    {
        public ComplexD(double real, double imaginar) : base(real, imaginar)
        {
        }

        public override void GetTrigonometricFormAndPow(double n)
        {
            base.GetTrigonometricFormAndPow(n);
        }

        public double GetDistance(List<Complex> listOfPoints)
        {
            double min = Int32.MaxValue;
            double distance = 0;

            foreach (var point in listOfPoints)
            {
                distance = FindDistance(this, point);
                if (distance < min)
                {
                    min = distance;
                }
            }

            return min;
        }

        private double FindDistance(ComplexD a, Complex b)
        {
            return Math.Sqrt(Math.Pow(b.real - a.real, 2) + Math.Pow(b.imaginar - a.imaginar, 2));
        }
    }
}
