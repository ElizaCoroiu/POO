using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherAndSubscribers
{
    public delegate void iteratie(int x);

    public class Publisher
    {
        public event iteratie eveniment;

        public void DeclansareEveniment()
        {
            for (int i = 0; i < 10; i++)
            {
                if (eveniment != null)
                {
                    eveniment(i);
                }
            }
        }
    }

    public class SubscriberA
    {
        public void GetInteger(int a)
        {
            Console.WriteLine(a);
        }
    }

    public class SubscriberB
    {
        public void GetNeighbors(int b)
        {
            Console.WriteLine($"Neighbors of {b} are: {b - 1}, {b + 1}");
        }
    }
}
