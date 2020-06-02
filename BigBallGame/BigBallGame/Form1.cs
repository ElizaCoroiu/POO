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

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGraph(pictureBox1);
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

        private void Turn()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                Ball b = balls[i];
                
                Move(b);
                b.Reflect();
                Move(b);
                

            }
            Engine.DrawBalls();
        }

        private void Move(Ball b)
        {
            PointF position = b.position;
            position.X += b.speed.dx;
            position.Y += b.speed.dy;
            b.position = position;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Turn();
            Engine.RefreshGraph();
        }

        private void btn_Turn_Click(object sender, EventArgs e)
        {

            //bool finished = false;
            //while (!finished)
            //{
            //    Turn();
            //}
            timer1.Enabled = true;
            Engine.RefreshGraph();
        }
    }
}
