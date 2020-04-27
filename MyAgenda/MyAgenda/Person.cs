using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAgenda
{
    class Person
    {
        private string name;
        private string lastName;
        private string firstName;
        private string emailAdress;
        private string birthDate;
        private int ID;
        private Agenda _agenda;

        public int getID()
        {
            return this.ID;
        }

        public string Name { get => this.name; }
        public Agenda agenda { get => _agenda; set => _agenda = value; }
     
        public Person(string name, int ID, string lastName, string firtsName, string birthDate, string emailAdress)
        {
            this.name = name;
            this.ID = ID;
            this.lastName = lastName;
            this.firstName = firtsName;
            this.birthDate = birthDate;
            this.emailAdress = emailAdress;
        }

        public override string ToString()
        {
            return $"person: ID: {this.ID}, name: {this.name}, b'day: {this.birthDate}, email: {this.emailAdress}";
        }
    }
}
  

