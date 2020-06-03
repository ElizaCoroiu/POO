using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherAndSubscribers
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher p = new Publisher();

            SubscriberA a = new SubscriberA();
            SubscriberB b = new SubscriberB();

            p.eveniment += new iteratie(a.GetInteger);
            p.eveniment += new iteratie(b.GetNeighbors);

            p.DeclansareEveniment();


            Console.ReadKey();
        }
    }
}
