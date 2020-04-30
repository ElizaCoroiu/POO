using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevi
{
    public class Elev
    {
        public string firstName;
        public string lastName;
        private int numberOfGrades;
        private string[] grades;
        private double average;
        public string Name => lastName + firstName;
        public string[] Grades => grades;
        public double Average => average;

        public Elev()
        {
            
        }

        

        public Elev (string lastName, string firstName, string numberOfGrades, string[] grades)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.numberOfGrades = int.Parse(numberOfGrades);
            this.grades = grades;
        }

        public Elev (string lastName, string firstName, double average)
        {
            this.lastName=lastName;
            this.firstName = firstName;
            this.average = average;
        }

        public double GetAverage(string[] grades)
        {
            double average = 0;
            foreach (var grade in grades)
            {
                average += int.Parse(grade);
            }
            average /= grades.Length;

            return average;
        }

        public override string ToString()
        {
            return $"{this.Name} - average: {this.average}";
        }
    }
}
