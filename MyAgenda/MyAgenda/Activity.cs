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
        private DateTime _startTime;
        private DateTime _endTime;
        private List<Person> _participants;

        public List<Person> participants { get => _participants; }
        public string Name { get => name; }
        public DateTime startTime { get => _startTime; }
        public DateTime endTime { get => _endTime; }

        public Activity(string name, string type, string description, DateTime start, DateTime end, List<Person> participants)
        {
            this.type = type;
            this.name = name;
            this.description = description;
            this._startTime = start;
            this._endTime = end;
            this._participants = participants;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var p in participants)
            {
                sb.Append(p.Name + ", ");
            }
            return $"Activity name: {this.name}, type: {this.type}, description: {this.description}, " +
                $"date: {this.startTime}-{this.endTime}\n"
                + $"participants: {sb}";
        }
    }
}
