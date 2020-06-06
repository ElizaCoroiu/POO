using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngajatProject
{
    public class MyList<T>
    {
        public List<Angajat> list = new List<Angajat>();

        public MyList() { }
        
        public MyList(Angajat employee)
        {
            this.list.Add(employee);
        }

        public void Add(Angajat employee)
        {
            this.list.Add(employee);
        }

        public void Remove(Angajat employee)
        {
            this.list.Remove(employee);
        }

        public void SortByName()
        {
            IComparer<Angajat> myComparer = new SortAlphabetically();
            this.list.Sort(myComparer);
        }

        public void SortBySeniority()
        {
            IComparer<Angajat> myComparer = new SortBySeniority();
            this.list.Sort(myComparer);
        }
    }

    internal class SortAlphabetically : IComparer<Angajat>
    {
        public int Compare(Angajat x, Angajat y)
        {
            int compareLastName=x.LastName.CompareTo(y.LastName);
            if (compareLastName == 0)
            {
                return x.FirstName.CompareTo(y.FirstName);
            }
            return compareLastName;
        }
    }

    internal class SortBySeniority : IComparer<Angajat>
    {
        public int Compare(Angajat x, Angajat y)
        {
            int compareYear = x.Date.Year.CompareTo(y.Date.Year);
            if (compareYear == 0)
            {
                return x.Date.Month.CompareTo(y.Date.Month);
            }
            return compareYear;
        }
    }
}
