﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBallGame
{
    public class Speed
    {
        public int dx { get; set; }
        public int dy { get; set; }

        public Speed()
        {
            this.dx = 0;
            this.dy = 0;
        }

        public Speed(int dx, int dy)
        {
            this.dx = dx;
            this.dy = dy;
        }
    }
}
