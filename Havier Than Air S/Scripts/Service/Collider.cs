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

        public Collider(Shape sh, Color color, Vector2f pos) 
        
        {
            shape = sh;
            shape.FillColor = color;
            shape.Position = pos;
        }
        
        public void UpdateViewOfCollider()
        {
            Program.window.Draw(shape);

        }

    }
}
