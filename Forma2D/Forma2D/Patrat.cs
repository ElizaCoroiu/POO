using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma2D
{
    public class Patrat : IForma2D
    {
        public int Latura { get; set; }
        public string Denumire { get; }

        public Patrat()
        {
            this.Latura = 1;
        }

        public Patrat(int Latura, string denumire)
        {
            this.Latura = Latura;
            this.Denumire = denumire;
        }

        public double Aria()
        {
            return Math.Pow(this.Latura, 2);
        }

        public double LungimeaFrontierei()
        {
            return 4 * this.Latura;
        }

        public override string ToString()
        {
            return $"Am creat un patrat de latura {this.Latura}";
        }
    }
}
