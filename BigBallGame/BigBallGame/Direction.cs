namespace BigBallGame
{
    public class Direction
    {
        public int dx { get; set; }
        public int dy { get; set; }

        public Direction()
        {
            this.dx = 0;
            this.dy = 0;
        }

        public Direction(int dx, int dy)
        {
            this.dx = dx;
            this.dy = dy;
        }
    }
}