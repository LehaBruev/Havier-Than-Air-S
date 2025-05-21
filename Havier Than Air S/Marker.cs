using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S
{
    public class Marker
    {

        private Vector2f[] pointsPositions;
        CircleShape markerPoint;
        float size;


        public Marker(Vector2f[] pointsPos,  Color color, float pointRadius) 
        {
            pointsPositions = pointsPos;
            markerPoint = new CircleShape();
            markerPoint.FillColor = color;
            markerPoint.Radius = pointRadius;
            markerPoint.Origin = new Vector2f(pointRadius, pointRadius);
        }

        public void Update()
        {
            for (int i = 0; i < pointsPositions.Length; i++)
            {
                markerPoint.Position = pointsPositions[i];
                Program.window.Draw(markerPoint);
            }
        }

    }
}
