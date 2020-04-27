using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAgenda
{
    class Activity
    {
        private string type;
        private string name;
        private string description;
        private Calendar schedule;
        private List<Person> participants;

        public Activity(string[] activity)
        {
            this.name = activity[0];
            this.type = activity[1];
            this.description = activity[2];
            string[] data = activity[3].Split(';');
            this.schedule = new Calendar(data);
        }

        public override string ToString()
        {
            return $"Activity: {this.name}-{this.type}-{this.description}-{this.schedule}";
        }
    }
}
