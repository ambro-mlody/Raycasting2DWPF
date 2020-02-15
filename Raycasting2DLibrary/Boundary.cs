using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Raycasting2DLibrary
{
    public class Boundary
    {
        public Vector2 a { get; private set; }
        public Vector2 b { get; private set; }

        public Boundary(float x1, float y1, float x2, float y2)
        {
            a = new Vector2(x1, y1);
            b = new Vector2(x2, y2);
        }

    }
}
