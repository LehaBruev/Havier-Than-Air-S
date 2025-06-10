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
            mount1.SetPointCount(19);
            mount1.SetPoint(0, new Vector2f(70, 807));
            mount1.SetPoint(1, new Vector2f(322, 543));
            mount1.SetPoint(2, new Vector2f(407, 446));
            mount1.SetPoint(3, new Vector2f(467, 435));
            mount1.SetPoint(4, new Vector2f(562, 396));
            mount1.SetPoint(5, new Vector2f(680, 294));
            mount1.SetPoint(6, new Vector2f(739, 267));
            mount1.SetPoint(7, new Vector2f(804, 193));
            mount1.SetPoint(8, new Vector2f(845, 182));
            mount1.SetPoint(9, new Vector2f(857, 163));
            mount1.SetPoint(10, new Vector2f(943, 251));
            mount1.SetPoint(11, new Vector2f(1183, 510));
            mount1.SetPoint(12, new Vector2f(1209, 508));
            mount1.SetPoint(13, new Vector2f(1265, 539));
            mount1.SetPoint(14, new Vector2f(1310, 537));
            mount1.SetPoint(15, new Vector2f(1329, 524));
            mount1.SetPoint(16, new Vector2f(1387, 559));
            mount1.SetPoint(17, new Vector2f(1486, 721));
            mount1.SetPoint(18, new Vector2f(1547, 833));
            mount1.FillColor = Color.Blue;
            mount1.Position = new Vector2f(1060,0);
            mark_1 = new Marker(mount1, Color.Blue,3);

        }

        public void Update()
        {

            mark_1.Update();


            Program.window.Draw(mount1);

        }


    }
}
