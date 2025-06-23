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
        Image mountImage;
        Texture mountTexture;
        public ConvexShape mount1;
        Marker mark_1;


        public Mountains()
        {
            mountImage = new Image("BackGroundLevel1.png");
            mountTexture = new Texture(mountImage);

            mount1 = new ConvexShape();
            mount1.SetPointCount(13);
            mount1.SetPoint(00, new Vector2f(556, 533));
            mount1.SetPoint(01, new Vector2f(609, 455));
            mount1.SetPoint(02, new Vector2f(648, 450));
            mount1.SetPoint(03, new Vector2f(778, 396));
            mount1.SetPoint(04, new Vector2f(849, 314));
            mount1.SetPoint(05, new Vector2f(957, 266));
            mount1.SetPoint(06, new Vector2f(1029, 192));
            mount1.SetPoint(07, new Vector2f(1076, 161));
            mount1.SetPoint(08, new Vector2f(1167, 245));
            mount1.SetPoint(09, new Vector2f(1233, 333));
            mount1.SetPoint(010, new Vector2f(1329, 426));
            mount1.SetPoint(011, new Vector2f(1358, 481));
            mount1.SetPoint(012, new Vector2f(1461, 524));

            mount1.FillColor = Color.Blue;
            mount1.Position = new Vector2f(850,0);
            mark_1 = new Marker(mount1, Color.Blue,5);
            
            mount1.Texture = mountTexture;
        }

        public void Update()
        {

            mark_1.Update();


            Program.window.Draw(mount1);

            
        }


    }
}
