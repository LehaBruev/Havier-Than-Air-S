using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    internal class Aerodrom
    {
        Vector2f position = new Vector2f(70,740);

        Collider collider;

        Texture PadTexture = new Texture(Program.m_TextureManager.allImage, new IntRect(new Vector2i(147, 603), new Vector2i(137, 66)));
        Sprite spr;

        public Aerodrom() 
        {
            spr = new Sprite(PadTexture);
            spr.Position = position;

            collider = new Collider(new RectangleShape(new Vector2f(137,100)), new Color(0,255,0,150),position-new Vector2f(0,35)); //цвет коллайдера
            
        }

        public void Update()
        {
            Program.window.Draw(spr);
            collider.UpdateViewOfCollider();

        }

        /*
         *  //ДОЗАПРАВКА и ремонт
                if (enginespeed < 1 && engineswitch == 0)
                {
                    if (helienginelife < 100 && partsinbag > 0) //мотор
                    {
                        helienginelife = helienginelife + 0.01f;
                        partsinbag = partsinbag - 0.1f;
                        PlaySound(enginerepairsound, volume - 30);
                        otkazpojardvig = 0;
                    }

                    if (helilife < helilifemax && partsinbag > 0) //жизни верталета
                    {
                        helilife = helilife + 0.1f;
                        partsinbag = partsinbag - 0.1f;
                        PlaySound(zapmachine, volume - 50);
                    }

                    if (helifuel < helifuelmax && fuelinbag > 0) //топливо
                    {
                        helifuel = helifuel + 0.5f;
                        fuelinbag = fuelinbag - 0.5f;
                        PlaySound(pumper, volume);

                    }
                    paddelay = paddelay - 1;

                    for (int i = 0; i < nrrocketsMaxquantity; i++) // ракеты
                    {
                        if (R[5, i] == 0 && paddelay < 1 && nrrocketsinbag >= 1)
                        {

                            R[5, i] = 1;
                            paddelay = 50;
                            nrrocketsinbag = nrrocketsinbag - 1;
                            PlaySound(nrrocketreloadsound, volume - 20);
                            break;
                        }

                    }

                }
                NRrocketchecklaunch = 0;
                for (int i = 0; i < R.GetLength(1); i++)
                {
                    if (R[5, i] == 1) NRrocketchecklaunch = NRrocketchecklaunch + 1;
                }
                SetFillColor(47, 55, 68);
                FillRectangle(350, 150, 1024 - 350, 500);
        */

    }
}
