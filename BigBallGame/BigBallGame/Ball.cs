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
        public double id;
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
            this.id = rnd.NextDouble();
            this.radius = radius;
            this.position = position;
            this.color = color;
            this.speed = speed;
        }

        public static Ball RandomInit(BallType t)
        {
            float radius = (float)rnd.Next(10, 50);
            PointF position = Engine.GetRndPoint(radius);
            Color color = Engine.GetRndColor();
            Speed speed = new Speed(rnd.Next(1, 5), rnd.Next(1, 5));
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
                        return new RepelentBall(radius, position, color, speed);
                    }
            }
        }

        public abstract void draw();

        public abstract void collide(Ball other);

        public static void collideRegularAndMonster(RegularBall b1, MonsterBall b2)
        {
            b2.radius += b1.radius;
            Engine.balls.Remove(b1);
        }

        public static void collideRegularAndRepelent(RegularBall b1, RepelentBall b2)
        {
            b2.color = b1.color;
            b1.speed.dx *= (-1);
            b1.speed.dy *= (-1);
        }

        public static void collideRepelentAndMonster(RepelentBall b1, MonsterBall b2)
        {
            float newRadius = b1.radius / 2;

            b1.radius = Math.Max(1, newRadius);
        }

        public bool collides (Ball otherBall)
        {
            float dx = this.position.X - otherBall.position.X;
            float dy = this.position.Y - otherBall.position.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance < this.radius + otherBall.radius)
            {
                return true;
            }

            return false;
        }
    }

    public class RegularBall : Ball
    {
        public RegularBall(float radius, PointF position, Color color, Speed speed) :
            base(radius, position, color, speed) { }

        public override void collide(Ball other)
        {
            switch (other)
            {
                case RepelentBall b:
                    {
                        collideRegularAndRepelent(this, b);
                        break;
                    }
                case MonsterBall b:
                    {
                        collideRegularAndMonster(this, b);
                        break;
                    }
                case RegularBall b:
                    {
                        int R = (this.color.R + b.color.R) / 2;
                        int G = (this.color.G + b.color.G) / 2;
                        int B = (this.color.B + b.color.B) / 2;
                        if (this.radius > b.radius)
                        {
                            this.radius += b.radius;
                            this.color = Color.FromArgb (R, G, B);
                            Engine.balls.Remove(b);
                        }
                        else
                        {
                            b.radius += this.radius;
                            b.color = Color.FromArgb(R, G, B);
                            Engine.balls.Remove(this);
                        }
                        break;
                    }
            }
        }

        public override void draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(color), position.X, position.Y, radius, radius);
            Engine.grp.DrawEllipse(new Pen(Color.Black, 2), position.X, position.Y, radius, radius);
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

        public override void collide(Ball other)
        {
            switch (other)
            {
                case RepelentBall b:
                    {
                        collideRepelentAndMonster(b, this);
                        break;
                    }
                case MonsterBall b:
                    {
                        break;
                    }
                case RegularBall b:
                    {
                        collideRegularAndMonster(b, this);
                        break;
                    }
            }
        }

        public override void draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(color), position.X, position.Y, radius, radius);
            Engine.grp.DrawEllipse(new Pen(Color.Red, 2), position.X, position.Y, radius, radius);
        }
    }

    public class RepelentBall : Ball
    {
        public RepelentBall(float radius, PointF position, Color color, Speed speed) :
            base(radius, position, color, speed) { }

        public override void collide(Ball other)
        {
            switch (other)
            {
                case RepelentBall b:
                    {
                        Color aux = this.color;
                        this.color = b.color;
                        b.color = aux;
                        break;
                    }
                case MonsterBall b:
                    {
                        collideRepelentAndMonster(this, b);
                        break;
                    }
                case RegularBall b:
                    {
                        collideRegularAndRepelent(b, this);
                        break;
                    }
            }
        }

        public override void draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(color), position.X, position.Y, radius, radius);
            Engine.grp.DrawEllipse(new Pen(Color.DarkGreen, 2), position.X, position.Y, radius, radius);
        }
    }
}

