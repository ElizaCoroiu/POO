using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstarct_Point
{
    class Point : AbstractPoint
    { 
        double r;
        double A;

        public Point(PointRepresentation represenation, double firstValue, double secondValue)
        {
            if (represenation == PointRepresentation.Rectangular)
            {
                this.r = Math.Sqrt(Math.Pow(firstValue, 2) + Math.Pow(secondValue, 2));
                this.A = Math.Atan2(secondValue, firstValue);
            }
            else
            {
                this.r = firstValue;
                this.A = secondValue;
            }
        }

        public override double abscissa 
        { 
            get => GetAbscissa(this.r, this.A);
        }

        public override double ordinate 
        { 
            get => GetOrdinate(this.r, this.A);
        }

        public override double radius 
        { 
            get => this.r;
            set => this.r = value;
        }

        public override double angle 
        {
            get => this.A;
            set => this.A = value;
        }
    }
}
