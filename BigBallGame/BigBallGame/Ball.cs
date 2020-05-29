using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BigBallGame
{
    public class Ball
    {
        public double radius { get; set; }
        public Position position { get; set;}
        public Color color { get; set; }
        public Speed speed { get; set; }
        public static Random rnd;

        public Ball(double radius, Position position, Color color, Speed speed)
        {
            this.radius = radius;
            this.position = position;
            this.color = color;
            this.speed = speed;
        }

        public static Ball RandomInit()
        {
            double radius = rnd.NextDouble() * 10;
            Position position = new Position(rnd.Next(500), rnd.Next(500));
            Color color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Speed speed = new Speed(rnd.Next(100), rnd.Next(100));

            return new Ball(radius, position, color, speed);
        }
    }
}
