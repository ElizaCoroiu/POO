using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyAgenda
{
    class ActivityRepository
    {
        private List<Activity> allActivities;

        public ActivityRepository()
        {
            allActivities = new List<Activity>();
        }

        public void AddActivity(Activity a)
        {
            allActivities.Add(a);
        }

        public void DeleteActivity(string name)
        {
            List<Activity> activitiesToBeRemoved = FindActivityByName(name);

            foreach (var a in activitiesToBeRemoved)
            {
                allActivities.Remove(a);
            }
        }

        public void FillAgendas()
        {
            foreach (Activity a in allActivities)
            {
                foreach (Person p in a.participants)
                {
                    p.agenda.AddActivity(a);
                }
            }
        }

        public static ActivityRepository activitiesDataLoad(string filepath, PersonRepository pr)
        {
            StreamReader sr = null;
            List<Activity> activities = new List<Activity>();
            try
            {
                sr = new StreamReader(new FileStream(filepath, FileMode.Open, FileAccess.Read));
                string line = string.Empty;

                line = sr.ReadLine();
                string[] activity_details = line.Split(',');
                line = sr.ReadLine();

                while (line != null)
                {
                    activity_details = line.Split(',');

                    DateTime start = DateTime.Parse(activity_details[3]);
                    DateTime end = DateTime.Parse(activity_details[4]);
                    string[] participantIDs = activity_details[5].Split(';');
                    List<Person> participants = new List<Person>();
                    foreach (var id in participantIDs)
                    {
                        Person p = pr.FindPersonByID(int.Parse(id));
                        participants.Add(p);
                    }
                    Activity a = new Activity(activity_details[0].Trim(), activity_details[1].Trim(),
                        activity_details[2].Trim(), start, end, participants);
                    activities.Add(a);
                    
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
            ActivityRepository ar = new ActivityRepository();
            ar.allActivities = activities;
            return ar;
        }

        public List<Activity> FindActivityByName(string name)
        {
            List<Activity> finalList = new List<Activity>();
            foreach (Activity a in allActivities)
            {
                if (a.Name == name)
                {
                    finalList.Add(a);
                }
            }

            return finalList;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var a in allActivities)
            {
                sb.Append(a + "\n" +"-----------------------------------------------------------------------------------------" + "\n");
            }
            return $"{sb}";
        }
    }
}
