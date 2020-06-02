using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBallGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string getNow ()
        {
            DateTime localDate = DateTime.Now;

            return localDate.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGraph(pictureBox1);

            textBox2.Text = $"[{getNow()}] Width = {Engine.width}, Height = {Engine.height}";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static List<Ball> balls = new List<Ball>();

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Engine.ClearGraph();

            balls = Engine.RandomInitBalls();

            Engine.DrawBalls();
            Engine.RefreshGraph();
        }

        private void OnTick()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                Ball ball = balls[i];
                PointF nextPosition = GetNextPosition(ball);
                ball.position = nextPosition;
            }

            for (int i = 0; i < balls.Count; i++)
            {
                Ball ball = balls[i];

                for (int j = 0; j < balls.Count; j++)
                {
                    if (ball.id != balls[j].id)
                    {
                        Ball otherBall = balls[j];

                        if (ball.collides(otherBall))
                        {
                            //textBox2.Text = $"{textBox2.Text}\r\nCollision detected between ball {i} and {j}";
                            ball.collide(otherBall);
                        }
                    }
                }

            }

            Engine.DrawBalls();
        }

        private PointF GetNextPosition(Ball ball)
        {
            PointF currentPosition = ball.position;
            PointF nextPossiblePosition = new PointF(currentPosition.X + ball.speed.dx, currentPosition.Y + ball.speed.dy);

            bool reflectOnX = false;
            bool reflectOnY = false;

            if (nextPossiblePosition.X <= 0 || nextPossiblePosition.X >= Engine.width - ball.radius)
            {
                reflectOnX = true;
            }

            if (nextPossiblePosition.Y <= 0 || nextPossiblePosition.Y >= Engine.height - ball.radius)
            {
                reflectOnY = true;
            }

            if (reflectOnX)
            {
                ball.speed.dx *= -1;
                nextPossiblePosition.X = currentPosition.X + ball.speed.dx;
            }

            if (reflectOnY)
            {
                ball.speed.dy *= -1;
                nextPossiblePosition.Y = currentPosition.Y + ball.speed.dy;
            }

            return nextPossiblePosition;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.ClearGraph();

            OnTick();

            Engine.RefreshGraph();
        }

        private void btn_Turn_Click(object sender, EventArgs e)
        {
            //bool finished = false;
            //while (!finished)
            //{
            //    Turn();
            //}
            int millisInSecond = 1000;
            int framesPerSecond = 24;

            timer1.Enabled = true;
            timer1.Interval = millisInSecond / framesPerSecond;
            //timer1.Interval = 300;
            Engine.RefreshGraph();
        }
    }
}
