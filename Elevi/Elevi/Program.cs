using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Elevi
{
    class Program
    {
        static List<Elev> studentsAverage = new List<Elev>();
        static void Main(string[] args)
        {
            List<Elev> students = DataLoad(@"..\..\input.txt");
            
            studentsAverage = Average(students);

            IComparer<Elev> comparer = new MyOrder();
            studentsAverage.Sort(comparer);

            foreach (Elev student in studentsAverage)
            {
                Console.WriteLine($"{student.Name} has the average: {student.Average}");
            }

            DataOutput(@"..\..\output.txt");

            Console.ReadKey();
        }

        private static void DataOutput(string filepath)
        {
            StreamWriter sw = new StreamWriter(filepath);
            foreach (var student in studentsAverage)
            {
                sw.WriteLine(student);
            }
            sw.Close();
        }

        private static List<Elev> Average(List<Elev> students)
        {
            double average = 0;
            foreach (var student in students)
            {
                average = student.GetAverage(student.Grades);
                Elev elev = new Elev(student.lastName, student.firstName, average);
                studentsAverage.Add(elev);
            }
            
            return studentsAverage;
        }
                


        public static List<Elev> DataLoad(string filepath)
        {
            List<Elev> students = new List<Elev>();
            StreamReader sr = sr = new StreamReader(filepath);
            Elev elev = new Elev();

            string line = sr.ReadLine();
            while(line!=null)
            {
                string[] datas = line.Split(',');
                string[] grades = datas[3].Split(' ');
                elev = new Elev(datas[0], datas[1], datas[2], grades);
                students.Add(elev);
                line = sr.ReadLine();
            }
            
            return students;
        }
    }
           
}
