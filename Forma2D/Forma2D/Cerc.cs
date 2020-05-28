using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma2D
{
    public class Cerc : IForma2D
    {
        public double Raza { get; set; }
        public string Denumire { get; }

        public Cerc()
        {
            this.Raza = 1;
        }

        public Cerc(double raza, string denumire)
        {
            this.Raza = raza;
            this.Denumire = denumire;
        }

        public double Aria()
        {
            return Math.PI * Math.Pow(Raza, 2);
        }

        public double LungimeaFrontierei()
        {
            return 2 * Math.PI * Raza;
        }

        public override string ToString()
        {
            return $"Am creat un cerc de raza {this.Raza}";
        }
    }
}
