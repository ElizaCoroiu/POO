using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigBallGame
{
    public class Ball
    {
        public enum BallType
        {
            Regular,
            Monster,
            Repelent
        }

        public double radius { get; set; }
        public Position position { get; set;}
        public Color color { get; set; }
        public Direction direction { get; set; }
    }
}
