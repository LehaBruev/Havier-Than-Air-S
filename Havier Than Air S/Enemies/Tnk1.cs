﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Enemies
{
    public class Tnk1
    {


        //Параметры Танка1
         
         float tank1sizex = 82;
         float tank1sizey = 30;
         float tank1live = 250;
         float tank1speed = 1;
         float tank1cource = 790;
         float tank1destroy = 0;
         int tank1maxquantity = 62;
        Vector2f tankPosition = new Vector2f(1400,750);

        Image allImage = new Image("uh61all.png");
        Texture body;
        Texture head;
        Texture Gun;

        Sprite bodySprite;
        Sprite headSprite;
        Sprite gunSprite;

        Vector2f headPosition = new Vector2f(35,-10); 
        Vector2f gunPosition = new Vector2f(5,8);
        float gunAngle = 35;

        int napravlenie = 1;


        public Tnk1()
        {
            body = new Texture(allImage, new IntRect(39, 884, 85, 24));
            head = new Texture(allImage, new IntRect(159, 878, 45, 12));
            Gun = new Texture(allImage, new IntRect(154, 857, 59, 6));

            bodySprite = new Sprite(body);
            headSprite = new Sprite(head);
            gunSprite = new Sprite(Gun);
            gunSprite.Origin = new Vector2f(58, 3);
        }

        public void Update()
        {
            tankPosition = new Vector2f(tankPosition.X - tank1speed*Program.deltaTimer.Delta(),tankPosition.Y);

            bodySprite.Position = tankPosition;
            headSprite.Position = bodySprite.Position + headPosition;
            gunSprite.Position = headSprite.Position + gunPosition;
            gunSprite.Rotation = gunAngle;
            Program.window.Draw(bodySprite);
            Program.window.Draw(headSprite);
            Program.window.Draw(gunSprite);
        }

        public void Start(Vector2f pos)
        {



        }
        /*
        static void tank1Draw() // Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=жизни танка) [1=проявлен 2=побдит]
        {

            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) // танк целый
                {
                    PlaySound(tank1motorsound2, volume);
                    DrawSprite(uh61, Tank1cicles[1, i] - 30, Tank1cicles[2, i], 8, 462, 120, 42); // спрайт танка
                                                                                                  //FillCircle(Tank1cicles[1, i], Tank1cicles[2, i], 3);
                                                                                                  //FillCircle(Tank1cicles[1, i] + tank1sizex, Tank1cicles[2, i] + tank1sizey, 3);
                    SetFillColor(Color.Yellow);
                    DrawText((int)Tank1cicles[1, i] - 20, (int)Tank1cicles[2, i] - 20, "" + Tank1cicles[7, i], 12);
                }

                if (Tank1cicles[3, i] == 2) //танк разрушен
                {

                    DrawSprite(uh61, Tank1cicles[1, i] - 30, Tank1cicles[2, i], 135, 519, 114, 35); // спрайт танка разрушенного
                                                                                                    //FillCircle(Tank1cicles[1, i], Tank1cicles[2, i], 3);
                                                                                                    // FillCircle(Tank1cicles[1, i] + tank1sizex, Tank1cicles[2, i] + tank1sizey, 3);

                }

            }

        }
        */
    }
}
