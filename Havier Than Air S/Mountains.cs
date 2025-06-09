using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class Mountains
    {

        ConvexShape mount1;
        Marker mark_1;
        public Mountains()
        {
            mount1 = new ConvexShape();
            mount1.SetPointCount(7);
            mount1.Position = new Vector2f(500, 500);
            mount1.SetPoint(0, new Vector2f(0, 300));
            mount1.SetPoint(1, new Vector2f(100, 0));
            mount1.SetPoint(2, new Vector2f(300, 100));
            mount1.SetPoint(3, new Vector2f(500, 150));
            mount1.SetPoint(4, new Vector2f(600, 300));
            mount1.SetPoint(5, new Vector2f(650, 350));
            mount1.SetPoint(6, new Vector2f(0, 350));
            mount1.FillColor = Color.Blue;

            mark_1 = new Marker(mount1, Color.Blue,3);

        }

        public void Update()
        {

            mark_1.Update();


            Program.window.Draw(mount1);

        }


    }
}
