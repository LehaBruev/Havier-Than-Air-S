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
        public bool ShapeOn_ColliderWiev = false;

        //Конструктор с Маркером
        public Collider(Shape sh, Color markerColor) 
        {
            shape = sh;
            marker = new Marker(shape, markerColor, 5);
            marker.m_Shape.FillColor = new Color(127, 225, 0, 110);
        }
        //конструктор без маркера
        public Collider(Shape sh)
        {
            shape = sh;
        }
      

        public void Update()
        {
            if (ShapeOn_ColliderWiev == true)
            {
               Program.window.Draw(shape);
            }
            
            if (marker !=null)
            {
                marker.Update();
            }

        }

    }
}
