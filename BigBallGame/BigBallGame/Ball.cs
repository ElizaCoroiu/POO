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
            b1.radius /= 2;
        }

        public void Reflect()
        {
            bool[] reflection = checkEdgeConditions();
            bool reflectX = reflection[0];
            bool reflectY = reflection[1];
            if (reflectX)
            {
                this.speed.dx *= (-1);
            }
            else if (reflectY)
            {
                this.speed.dy *= (-1);
            }
        }
        
        public bool[] checkEdgeConditions()
        {
            bool[] reflection = new bool[2];
            bool reflectX = false;
            bool reflectY = false;
            if (this.position.X <= this.radius)
            {
                reflectX = true;
                reflection[0] = reflectX;
            }
            else if (this.position.Y <= this.radius)
            {
                reflectY = true;
                reflection[1] = reflectY;
            }
            else if (this.position.X + this.radius >= Engine.width)
            {
                reflectX = true;
                reflection[0] = reflectX;
            }
            else if (this.position.Y + this.radius >= Engine.height)
            {
                reflectY = true;
                reflection[1] = reflectY;
            }
            return reflection;
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
            Engine.grp.DrawEllipse(new Pen(Color.Black, 5), position.X, position.Y, radius, radius);
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
            Engine.grp.DrawEllipse(new Pen(Color.Red, 5), position.X, position.Y, radius, radius);
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
            Engine.grp.DrawEllipse(new Pen(Color.Yellow, 5), position.X, position.Y, radius, radius);
        }
    }
}

