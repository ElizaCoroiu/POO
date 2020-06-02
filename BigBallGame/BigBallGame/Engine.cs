using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static BigBallGame.Ball;

namespace BigBallGame
{
    public static class Engine
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static int width;
        public static int height;
        public static Color backColor = Color.White;
        public static PictureBox display;
        public static Random rnd = new Random();
        public static List<Ball> balls = new List<Ball>();
        #region Graph
        public static void InitGraph(PictureBox T)
        {
            display = T;
            width = T.Width;
            height = T.Height;

            bmp = new Bitmap(width, height);
            grp = Graphics.FromImage(bmp);

            ClearGraph();
            RefreshGraph();
        }

        public static void ClearGraph()
        {
            grp.Clear(backColor);
        }

        public static void RefreshGraph()
        {
            display.Image = bmp;
        }
        #endregion

        #region Random
        public static PointF GetRndPoint(float r)
        {
            return new PointF(rnd.Next((int)r, (int)(width-r)), rnd.Next((int)r, (int)(height-r)));
        }

        public static Color GetRndColor()
        {
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
        #endregion
        public static List<Ball> RandomInitBalls()
        {
            for (int i = 0; i < 8; i++)
            {
                BallType b = (BallType)rnd.Next(3);
                balls.Add(Ball.RandomInit(b));
            }
            return balls;
        }

        public static void DrawBalls()
        {
            foreach (Ball b in balls)
            {
                b.draw();
            }
        }
    }
}







