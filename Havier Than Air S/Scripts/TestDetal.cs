using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Havier_Than_Air_S.Scripts
{
    public class TestDetal:Detal
    {



        public TestDetal()
        {
            Shape sh= new RectangleShape(new Vector2f(10, 10));
            sh.Origin = new Vector2f(5, 5);
            sh.FillColor = Color.Red;
            _Collider = new Collider(sh);
            _Collider.ShapeOn_ColliderWiev = true;


        }





    }
}
