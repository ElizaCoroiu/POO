using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace MyAgenda
{
    class Program
    {
        //static List<Agenda> agendaList;

        static void Main(string[] args)
        {
            PersonRepository persons = PersonRepository.personDataLoad(@"..\..\personData.csv");
            ActivityRepository activities = ActivityRepository.activitiesDataLoad(@"..\..\activities.csv", persons);
            Console.WriteLine(activities);

            // Create an agenda for each person of the list
            List<Agenda> agendas = persons.CreateAgendas();

            // Add activities to each agenda they belong to
            activities.FillAgendas();
            Console.WriteLine();

            //// Search an activity by name. Return a list with activities that meet the search criteria
            //Console.WriteLine("Search for activity name: ");
            //string activityName = Console.ReadLine();
            //List<Activity> foundActivities = activities.FindActivityByName(activityName);
            //Console.WriteLine($"There are {foundActivities.Count} activities with name <{activityName}>");
            //Console.WriteLine();

            //// Delete an activity
            //Console.WriteLine("Give activity name to be deleted: ");
            //activityName = Console.ReadLine();
            //activities.DeleteActivity(activityName);
            //Console.WriteLine();
            //Console.WriteLine(activities);

            //// Delete an agenda
            //Console.WriteLine("Give id of person for whom to delete the agenda: ");
            //int id = int.Parse(Console.ReadLine());
            //Person p = persons.FindPersonByID(id);
            //if (p != null)
            //{
            //    agendas.Remove(p.agenda);
            //    p.agenda = null;
            //}

            // Generate a report with all the activities of a person in a certain time interval
            Console.WriteLine("Give id of the person for whom to generate report: ");
            int id = int.Parse(Console.ReadLine());
            Person p = persons.FindPersonByID(id);
            Console.WriteLine("Give start time: ");
            DateTime start = DateTime.Parse("1800-01-01T14:00:00");// Console.ReadLine());
            Console.WriteLine("Give end time: ");
            DateTime end = DateTime.Parse("2000-12-31T23:59:59"); //Console.ReadLine());
            List<Activity> activitiesByInterval = p.agenda.ShowAllActivitiesDuringInterval(start, end);
            Console.WriteLine($"There are {activitiesByInterval.Count} activities during {start}-{end}");

            Console.ReadKey();
        }
    }
}


        
                
        
                
        


            
                
