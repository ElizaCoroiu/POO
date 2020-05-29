using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigBallGame
{
    public abstract class Ball
    {
        public float radius { get; set; }
        public PointF position { get; set; }
        public Color color { get; set; }
        public Speed speed { get; set; }
        public static Random rnd = new Random();

        public enum BallType
        {
            Regular, Monster, Repelant
        }

        public Ball(float radius, PointF position, Color color, Speed speed)
        {
            this.radius = radius;
            this.position = position;
            this.color = color;
            this.speed = speed;
        }

        public static Ball RandomInit(BallType t)
        {
            float radius = (float)rnd.NextDouble() * 50;
            PointF position = Engine.GetRndPoint();
            Color color = Engine.GetRndColor();
            Speed speed = new Speed(rnd.Next(100), rnd.Next(100));
            switch (t)
            {
                default:
                    {
                        return new RegularBall(radius, position, color, speed);
                    }
                case BallType.Monster:
                    {
                        return new MonsterBall(radius, position, color, speed);
                    }
                case BallType.Repelant:
                    {
                        return new RepelantBall(radius, position, color, speed);
                    }
            }
        }

        public abstract void draw();
    }

    public class RegularBall : Ball
    {
        public RegularBall(float radius, PointF position, Color color, Speed speed) :
            base(radius, position, color, speed) { }

        public override void draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(color), position.X, position.Y, radius, radius);
            Engine.grp.DrawEllipse(new Pen(Color.Black, 4), position.X, position.Y, radius, radius);
        }
    }

    public class MonsterBall : Ball
    {
        public MonsterBall(float radius, PointF position, Color color, Speed speed) :
            base(radius, position, color, speed)
        {
            speed.dx = 0;
            speed.dy = 0;
        }

        public override void draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(color), position.X, position.Y, radius, radius);
            Engine.grp.DrawEllipse(new Pen(Color.Red, 4), position.X, position.Y, radius, radius);
        }
    }

    public class RepelantBall : Ball
    {
        public RepelantBall(float radius, PointF position, Color color, Speed speed) :
            base(radius, position, color, speed) { }

        public override void draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(color), position.X, position.Y, radius, radius);
            Engine.grp.DrawEllipse(new Pen(Color.Yellow, 4), position.X, position.Y, radius, radius);
        }
    }
}

