using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AngajatProject
{
    class Program
    {
        public static MyList<Angajat> staff = new MyList<Angajat>();

        static void Main(string[] args)
        {
            DataLoad(@"..\..\input.txt");
            staff.SortByName();
            DataOutput1(@"..\..\output1.txt");
            staff.SortBySeniority();
            DataOutput2(@"..\..\output2.txt");

            Console.ReadKey();
        }

        private static void DataOutput2(string filepath)
        {
            StreamWriter dataOutput = new StreamWriter(filepath);
            foreach (Angajat employee in staff.list)
            {
                dataOutput.WriteLine($"{employee.LastName} {employee.FirstName} " +
                    $"{employee.Date.Year} {employee.Date.Month}");
            }
            dataOutput.Close();
        }

        private static void DataOutput1(string filepath)
        {
            StreamWriter dataOutput = new StreamWriter(filepath);
            foreach (Angajat employee in staff.list)
            {
                dataOutput.WriteLine($"{employee.LastName} {employee.FirstName}");
            }
            dataOutput.Close();
        }

        private static void DataLoad(string filepath)
        {
            staff = new MyList<Angajat>();
            StreamReader dataLoad = new StreamReader(filepath);
            string line = dataLoad.ReadLine();

            while (line != null)
            {
                string[] datas = line.Split(' ');
                string lastName = datas[0];
                string firstName = datas[1];
                string[] fullDate = datas[2].Split('/');
                DateTime date = new DateTime(int.Parse(fullDate[0]), int.Parse(fullDate[1]), int.Parse(fullDate[2]));
                
                Angajat employee = new Angajat(lastName, firstName, date);
                staff.Add(employee);

                line = dataLoad.ReadLine();
            }
        }
    }
}
