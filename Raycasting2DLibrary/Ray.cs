using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Raycasting2DLibrary
{
    public class Ray
    {
        public Vector2 position { get; private set; }
        public Vector2 direction { get; private set; }

        public Ray(Vector2 pos, float angle)
        {
            position = pos;
            angle = Raycasting.ToRadians(angle);
            direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            direction = Vector2.Normalize(direction);
        }

        public bool cast(Boundary wall, ref Vector2 point)
        {
            float x1 = wall.a.X;
            float y1 = wall.a.Y;
            float x2 = wall.b.X;
            float y2 = wall.b.Y;

            float x3 = position.X;
            float y3 = position.Y;
            float x4 = position.X + direction.X;
            float y4 = position.Y + direction.Y;

            float den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (den == 0)
                return false;

            float t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
            float u = -((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / den;

            if (t > 0 && t < 1 && u > 0)
            {
                point.X = x1 + t * (x2 - x1);
                point.Y = y1 + t * (y2 - y1);
                return true;
            }

            return false;
        }

        public void lookAt(Vector2 point)
        {
            direction = point - position;
            direction = Vector2.Normalize(direction);
        }
    }
}
