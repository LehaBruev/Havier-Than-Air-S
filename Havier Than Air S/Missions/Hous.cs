using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S.Missions
{
    public class Hous
    {

        public RectangleShape rectShape;
        Marker Marker;
        public Hous() 
        {
            rectShape = new RectangleShape();
        rectShape.FillColor = Color.Green;
        rectShape.Size = new Vector2f(20, 50);
        rectShape.Origin = new Vector2f(0,rectShape.Size.Y);
            Marker = new Marker(rectShape,Color.Red,2);
        }

        
         
        public void Update()
        {
            Program.window.Draw(rectShape);

        }


    }
}
