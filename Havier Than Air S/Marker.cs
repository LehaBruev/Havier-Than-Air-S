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
        Shape m_Shape;
        float size;

        Vector2f pointTextOrigin = new Vector2f(10, -10);
        Text text_1;

        public Marker(Shape shape,  Color color, float pointRadius) 
        {
            m_Shape = shape;
            pointsPositions = Program.collisions.GetShapePoints(m_Shape); 
            markerPoint = new CircleShape();
            markerPoint.FillColor = color;
            markerPoint.Radius = pointRadius;
            markerPoint.Origin = new Vector2f(pointRadius, pointRadius);

            text_1 = new Text();
        }

        public void UpdatePoints(Shape shape)
        {
            pointsPositions = Program.collisions.GetShapePoints(shape);

        }

        public void Update()
        {
            UpdatePoints(m_Shape);

            for (int i = 0; i < pointsPositions.Length; i++)
            {
                markerPoint.Position = pointsPositions[i];
                Program.window.Draw(markerPoint);
                text_1 = new Text(i.ToString(),Program.font,10);
                text_1.FillColor = Color.White;
                text_1.Position = pointsPositions[i]+pointTextOrigin;

                Program.window.Draw(text_1);
            }
        }

    }
}
