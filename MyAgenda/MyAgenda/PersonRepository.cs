using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyAgenda
{
    class PersonRepository
    {
        private List<Person> allPersons;

        public PersonRepository()
        {
            allPersons = new List<Person>();
        }

        public static PersonRepository personDataLoad(string filepath)
        {
            StreamReader sr = null;
            List<Person> personsList = new List<Person>();

            try
            {
                sr = new StreamReader(new FileStream(filepath, FileMode.Open, FileAccess.Read));
                string line = string.Empty;
                string[] headers = sr.ReadLine().Split(',');

                line = sr.ReadLine();
                string[] personDatas;
                while (line != null)
                {
                    personDatas = line.Split(',');
                    Person p = new Person(personDatas[0].Trim(), int.Parse(personDatas[1]), personDatas[2].Trim(),
                        personDatas[3].Trim(), personDatas[4].Trim(), personDatas[5].Trim());
                    personsList.Add(p);
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sr.Dispose();
                sr.Close();
            }
            PersonRepository pr = new PersonRepository();
            pr.allPersons = personsList;
            return pr;
        }

        public Person FindPersonByID(int id)
        {
            foreach (var p in allPersons)
            {
                if (p.getID() == id)
                {
                    return p;
                }
            }
            return null;
        }

        public List<int> GetAllIds()
        {
            List<int> allIds = new List<int>();

            foreach (var p in allPersons)
            {
                allIds.Add(p.getID());
            }

            return allIds;
        }

        public List<Agenda> CreateAgendas()
        {
            List<Agenda> agendaList = new List<Agenda>();
            foreach (Person p in allPersons)
            {
                Agenda agenda = new Agenda(p);
                p.agenda = agenda;
                agendaList.Add(agenda);
            }
            return agendaList;   
        }
    }
}

    
