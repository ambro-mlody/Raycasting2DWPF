using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Raycasting2DLibrary
{
    public class Particle
    {
        public Vector2 position { get; private set; }
        public List<Ray> rays { get; private set; }

        public Particle(float startX, float startY)
        {
            position = new Vector2(startX, startY);
            for (int i = 0; i < 360; i++)
                rays.Add(new Ray(position, i));
        }

        public List<Vector2> look(List<Boundary> walls)
        {
            List<Vector2> points = new List<Vector2>();
            Vector2 point = new Vector2(0);
            foreach (var ray in rays)
            {
                float closest = float.MaxValue;
                Vector2 bestPoint = new Vector2(0);
                foreach (var wall in walls)
                {
                    if(ray.cast(wall, point))
                    {
                        float d = Vector2.Distance(point, position);
                        if(d<closest)
                        {
                            closest = d;
                            bestPoint = point;
                        }
                    }
                }

                if(closest != float.MaxValue)
                {
                    points.Add(bestPoint);
                }
            }
            return points;
        }

        public void update(Vector2 pos)
        {
            position = pos;
            rays.Clear();
            for (int i = 0; i < 360; i++)
                rays.Add(new Ray(position, i));
        }
    }
}
