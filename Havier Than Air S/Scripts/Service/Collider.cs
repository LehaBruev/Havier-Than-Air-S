using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class Collider
    {
        public Shape shape;
        public Marker marker;
        bool MarkerOn = false;

        //Конструктор с Маркером
        public Collider(Shape sh, Color markerColor) 
        {
            shape = sh;

            MarkerOn = true;
            marker = new Marker(shape, markerColor, 5);
        }
        //конструктор без маркера
        public Collider(Shape sh)

        {
            shape = sh;
        }
        //Конструктор с оригином
        public Collider(Shape sh, Color markerColor, Vector2f origin)
        {
            shape = sh;

            MarkerOn = true;
            marker = new Marker(shape, markerColor, 5);
            shape.Origin = origin;
        }

        public void Update()
        {
            Program.window.Draw(shape);

            if (MarkerOn)
            {
                marker.Update();
            }

        }

    }
}
