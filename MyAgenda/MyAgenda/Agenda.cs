using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAgenda
{
    class Agenda
    {
        private Person person;
        private List<Activity> activities;

        public Agenda(Person p)
        {
            this.person = p;

            activities = new List<Activity>();
        }

        public override string ToString()
        {
            return $"This agenda belongs to {this.person}";
        }

        public void AddActivity(Activity a)
        {
            activities.Add(a);
        }

        public List<Activity> ShowAllActivitiesDuringInterval(DateTime start, DateTime end)
        {
            List<Activity> activitiesDuringInterval = new List<Activity>();
            foreach (var activity in activities)
            {
                if (activity.startTime >= start && activity.endTime <= end)
                {
                    activitiesDuringInterval.Add(activity);
                }
            }

            return activitiesDuringInterval;
        }
    }
}
