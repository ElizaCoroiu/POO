using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAgenda
{
    class Calendar
    {
        private int year;
        private string month;
        private string startTime;
        private string endTime;

        public Calendar(string[] data)
        {
            this.month = data[0];
            this.year = int.Parse(data[1]);
            this.startTime = data[2];
            this.endTime = data[3];
        }
    }
}
