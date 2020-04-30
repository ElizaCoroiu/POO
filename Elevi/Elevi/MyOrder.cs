using System.Collections.Generic;

namespace Elevi
{
    public class MyOrder : IComparer<Elev>
    {
        public int Compare(Elev a, Elev b)
        {
            int compareAverage = a.Average.CompareTo(b.Average);
            if (compareAverage == 0)
            {
                int compareLastName = a.lastName.CompareTo(b.lastName);
                if (compareLastName == 0)
                {
                    return a.firstName.CompareTo(b.firstName);
                }
                return compareLastName;
            }
            return compareAverage;
        }

    }
}