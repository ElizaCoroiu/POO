using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngajatProject
{
    public class Angajat
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Date { get; set; }

        public Angajat(string lastName, string firstName, DateTime date)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Date = date;
        }
    }
}
