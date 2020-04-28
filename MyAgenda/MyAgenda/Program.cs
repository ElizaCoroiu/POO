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

            SearchActivityByName(activities);
            DeleteActivity(activities);
            DeleteAgenda(persons, agendas);
            GenerateReport(persons);
            FindFreeSlot(persons);

            Console.ReadKey();
        }

        private static void SearchActivityByName(ActivityRepository activities)
        {
            Console.WriteLine("\nSearch by activity name\n");

            // Search an activity by name.Return a list with activities that meet the search criteria
            Console.WriteLine("Type activity name: ");
            string activityName = Console.ReadLine();

            List<Activity> foundActivities = activities.FindActivityByName(activityName);

            Console.WriteLine($"There are {foundActivities.Count} activities with name <{activityName}>");
            Console.WriteLine();
        }

        private static void DeleteActivity (ActivityRepository activities)
        {
            Console.WriteLine("\nDelete activity\n");

            // Delete an activity
            Console.WriteLine("Type activity name to be deleted: ");
            string activityName = Console.ReadLine();

            activities.DeleteActivity(activityName);

            Console.WriteLine();
            Console.WriteLine(activities);
        }

        private static void DeleteAgenda (PersonRepository persons, List<Agenda> agendas)
        {
            Console.WriteLine("\nDelete agenda\n");

            // Delete an agenda
            Console.WriteLine("Type id of person for whom to delete the agenda: ");
            int id = int.Parse(Console.ReadLine());

            Person p = persons.FindPersonByID(id);

            if (p != null)
            {
                agendas.Remove(p.agenda);
                p.agenda = null;
            } else
            {
                Console.WriteLine($"No person with id {id} found");
            }
        }

        private static void GenerateReport (PersonRepository persons)
        {
            Console.WriteLine("\nGenerate report\n");

            // Generate a report with all the activities of a person in a certain time interval
            Console.WriteLine("Type id of the person for whom to generate report: ");

            int id = int.Parse(Console.ReadLine());
            Person person = persons.FindPersonByID(id);

            if (person != null)
            {
                Console.WriteLine("Type start time: ");
                DateTime start = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Type end time: ");
                DateTime end = DateTime.Parse(Console.ReadLine());

                List<Activity> activitiesByInterval = person.agenda.ShowAllActivitiesDuringInterval(start, end);
                Console.WriteLine($"There are {activitiesByInterval.Count} activities during {start} - {end}");
            } else
            {
                Console.WriteLine($"No person found with id {id}");
            }
        }

        private static void FindFreeSlot (PersonRepository persons)
        {
            Console.WriteLine("\nFind meeting slot\n");

            // Retrieve all ids for all persons in the system
            List<int> allPersonsIds = persons.GetAllIds();

            // Read meeting participant ids
            Console.WriteLine($"Type persons ids, separated by comma");
            Console.WriteLine($"Possible ids are: {string.Join(", ", allPersonsIds)}");

            string[] allIds = Console.ReadLine().Split(',');

            List<Person> meetingParticipants = new List<Person>();

            // Lookup participants by person id
            foreach (var personId in allIds)
            {
                Person participant = persons.FindPersonByID(int.Parse(personId));

                if (participant != null)
                {
                    meetingParticipants.Add(participant);
                }
            }

            if (meetingParticipants.Count > 0)
            {
                // Read start of lookup interval
                Console.WriteLine("Type interval start time (YYYY-MM-DDTHH:mm:ss): ");
                DateTime intervalStart = DateTime.Parse(Console.ReadLine());

                // Read end of lookup interval
                Console.WriteLine("Type interval end time (YYYY-MM-DDTHH:mm:ss): ");
                DateTime intervalEnd = DateTime.Parse(Console.ReadLine());

                // Make sure intervalEnd > intervalStart
                while (intervalEnd < intervalStart)
                {
                    Console.WriteLine("Interval end time must be after interval start time, please enter another end time (YYYY-MM-DDTHH:mm:ss): ");
                    intervalEnd = DateTime.Parse(Console.ReadLine());
                }

                // Read meeting duration
                Console.WriteLine("Type meeting duration (in minutes, multiple of 15):");
                double meetingDuration = Double.Parse(Console.ReadLine());
                double maxDuration = (intervalEnd - intervalStart).TotalMinutes;

                // Validate meeting duration is less or equal to the interval duration
                while (meetingDuration > maxDuration || meetingDuration % 15 != 0)
                {
                    Console.WriteLine($"Meeting duration cannot be more than {maxDuration} minutes and it must be multiple of 15, please enter another duration (in minutes, multiple of 15)");
                    meetingDuration = Double.Parse(Console.ReadLine());
                }

                // Try to find a slot where all participants are free
                List<DateTime> meetingInterval = GetMeetingInterval(meetingParticipants, intervalStart, intervalEnd, meetingDuration);

                if (meetingInterval != null)
                {
                    DateTime meetingStart = meetingInterval.ElementAt(0);
                    DateTime meetingEnd = meetingInterval.ElementAt(1);

                    Console.WriteLine($"Meeting possible between {meetingStart} - {meetingEnd}");
                } else
                {
                    Console.WriteLine($"No free slot for users {string.Join(", ", allIds)} of {meetingDuration} minutes duration found in interval {intervalStart} - {intervalEnd}");
                }
            } else
            {
                Console.WriteLine($"No persons found for ids {string.Join(", ", allIds)}");
            }
        }

        /**
         * We take the meeting duration and we take the interval m = [intervalStart, intervalStart + meetingDuration].
         * We iterate over all participants and we find if all participants are free in the interval m.
         * If all participants are free we return interval m, otherwise we shift interval m by increasing start
         * and end by 15 minutes and we redo the logic. We repeat these steps until we find a slot where all
         * participants are free or the end of m is after intervalEnd
         */
        private static List<DateTime> GetMeetingInterval (List<Person> participants, DateTime start, DateTime end, double duration)
        {
            bool found = false;

            // Start with the interval start
            DateTime lookupStart = start;
            DateTime lookupEnd = start;

            // Initially, interval end is start plus the meeting duration
            lookupEnd = lookupEnd.AddMinutes(duration);

            // While we didn't find a free slot and we're in the given interval
            while (!found && lookupEnd <= end)
            {
                // Reset number of free participants
                int numberOfFreeParticipants = 0;

                foreach (var participant in participants)
                {
                    bool isFree = participant.agenda.GetIsFree(lookupStart, lookupEnd);

                    if (!isFree)
                    {
                        lookupStart = lookupStart.AddMinutes(15);
                        lookupEnd = lookupEnd.AddMinutes(15);
                        break;
                    } else
                    {
                        numberOfFreeParticipants += 1;
                    }
                }

                if (numberOfFreeParticipants == participants.Count)
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                List<DateTime> meetingInterval = new List<DateTime>();

                meetingInterval.Add(lookupStart);
                meetingInterval.Add(lookupEnd);

                return meetingInterval;
            }

            return null;
        }
    }
}


        
                
        
                
        


            
                
