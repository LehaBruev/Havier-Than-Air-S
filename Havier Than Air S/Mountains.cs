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
        Vector2i position = new Vector2i(50,50);

        //Текстура база
        Image mountainImage;
        Texture mountTexture;


        // Текстура сверху
        Image caveImage;
        Texture caveTexture;

        // Коллайдер для активации второй текстуры
        public ConvexShape ColliderActivation;


        // Коллайдеры столкновения
        public ConvexShape[] MountColliders;
        Marker mark_1;


        public Mountains()
        {
            caveImage = new Image("Пещера_01.jpg");

            caveTexture = new Texture(caveImage);

            MountColliders = new ConvexShape[3];

            ConvexShape MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(13);
            MountShape1.SetPoint(00, new Vector2f(556, 533));
            MountShape1.SetPoint(01, new Vector2f(609, 455));
            MountShape1.SetPoint(02, new Vector2f(648, 450));
            MountShape1.SetPoint(03, new Vector2f(778, 396));
            MountShape1.SetPoint(04, new Vector2f(849, 314));
            MountShape1.SetPoint(05, new Vector2f(957, 266));
            MountShape1.SetPoint(06, new Vector2f(1029, 192));
            MountShape1.SetPoint(07, new Vector2f(1076, 161));
            MountShape1.SetPoint(08, new Vector2f(1167, 245));
            MountShape1.SetPoint(09, new Vector2f(1233, 333));
            MountShape1.SetPoint(010, new Vector2f(1329, 426));
            MountShape1.SetPoint(011, new Vector2f(1358, 481));
            MountShape1.SetPoint(012, new Vector2f(1461, 524));

            //mount1.FillColor = Color.Blue;
            MountShape1.Position = new Vector2f(850,0);
            MountColliders[0] = MountShape1;

            mark_1 = new Marker(MountShape1, Color.Blue,5);
            
            MountShape1.Texture = caveTexture;
            MountShape1.Texture.Smooth = true;
        }

        public void Update()
        {

            mark_1.Update();


            Program.window.Draw(MountShape1);

            
        }


    }
}
