using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma2D
{
    interface IForma2D
    { 
        string Denumire 
        {
            get;
        }

        double Aria();
        double LungimeaFrontierei();
    }
}
