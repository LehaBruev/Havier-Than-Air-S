using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{
    internal class Avionika
    {
        private Hely hely;
        Vector2f origin = new Vector2f(0,0);
        Vector2f panel1Posi = new Vector2f(10,10);
        Vector2f panel2Posi = new Vector2f(185.0f, 10.0f);
        Vector2f panel3Posi = new Vector2f(350.0f, 10.0f);
        Vector2f panel4Posi = new Vector2f(525.0f, 10.0f);

        Font font;

        Image imageAll = new Image("uh61all.png");
        Texture avionikaTexture;
        Sprite panelAvionikaSprite;
        Sprite panelAvionikaSprite2;
        Sprite panelAvionikaSprite3;
        Sprite panelAvionikaSprite4;
        Text aText;

        // Pricel mode 2
        float distance = 150;
        Texture pricMod2Texture;
        Texture pricMod3Texture;
        Sprite scopeSprite;
        Vector2f scopeOrigin = new Vector2f(350, 30);
        Vector2i scopeMemory;

        

        // scales
        Vector2f scaleVector = new Vector2f();


        public Avionika()
        {
            
            font = new Font("comic.ttf");
            avionikaTexture = new Texture(imageAll, new IntRect(new Vector2i(140, 679), new Vector2i(158, 131)));
            panelAvionikaSprite = new Sprite(avionikaTexture);
            panelAvionikaSprite.Position = new Vector2f(10.0f, 10.0f);

            panelAvionikaSprite2 = new Sprite(avionikaTexture);
            panelAvionikaSprite2.Position = new Vector2f(185.0f, 10.0f);

            panelAvionikaSprite3 = new Sprite(avionikaTexture);
            panelAvionikaSprite3.Position = panel3Posi;

            panelAvionikaSprite4 = new Sprite(avionikaTexture);
            panelAvionikaSprite4.Position = panel4Posi;

            aText = new Text();
            aText.FillColor = Color.White;


            // Priceles
            pricMod2Texture = new Texture("uh61all.png", new IntRect(305, 302, 37, 37));
            pricMod3Texture = new Texture("aim.png");
            scopeSprite = new Sprite(pricMod2Texture);
            scopeSprite.Color = Color.White;
            scopeSprite.Origin = new Vector2f(18.5f, 18.5f);
        }

        public void Update()
        {
            if (hely != null)
            {
                origin = Program.offset;
                panelAvionikaSprite.Position = origin -
                                                new Vector2f(Program.vMode.Width / 2, Program.vMode.Height / 2) + panel1Posi;
                panelAvionikaSprite2.Position = origin -
                                               new Vector2f(Program.vMode.Width / 2, Program.vMode.Height / 2) + panel2Posi;
                panelAvionikaSprite3.Position = origin -
                                               new Vector2f(Program.vMode.Width / 2, Program.vMode.Height / 2) + panel3Posi;
                panelAvionikaSprite4.Position = origin -
                                              new Vector2f(Program.vMode.Width / 2, Program.vMode.Height / 2) + panel4Posi;


                Program.window.Draw(panelAvionikaSprite);
                Program.window.Draw(panelAvionikaSprite2);
                Program.window.Draw(panelAvionikaSprite3);
                Program.window.Draw(panelAvionikaSprite4);

                
                Panel1Check();
                Panel2Check();
                Panel3Check();
                Panel4Check();

                PricelDraw();
                UpdateInertia();
            }            
        }


        public void Panel1Check()
        {
            Color lifeColor = Color.White;
            if (hely.helylifeCurrent < 90) lifeColor = Color.Red;
            DrawText("Heli Life: " + (int)hely.helylifeCurrent, new Vector2f(22, 15), lifeColor, 1);
            DrawText("Altitude: " + (int)hely.altitude, new Vector2f(22, 32), Color.White, 1);
            DrawText("Angle: " + (int)hely.angle, new Vector2f(22, 49), Color.White, 1);
            DrawText("RUD: " + (int)hely.currentRUDposition, new Vector2f(22, 66), Color.White, 1);
            DrawText("Автопилот H: ", new Vector2f(22, 83), Color.White, 1);

        }
        public void Panel2Check()
        {
            Color colorEngineSpeed = Color.White;
            if (hely.RPM > hely.RPMLimit) colorEngineSpeed = Color.Red;
            DrawText("Engine S.: " + (int)hely.RPM, new Vector2f(22, 15), colorEngineSpeed, 2);

            Color engSwithColor = Color.White;
            if (hely.engineswitch == 1) engSwithColor = Color.Green;
            DrawText("Engine Switch: " + hely.engineswitch, new Vector2f(22, 32), engSwithColor, 2);

            Color engLifeColor = Color.White;

            if (hely.currentEnginelife < 75 || hely.otkazpojardvig == 1) engLifeColor = Color.Yellow;
            if (hely.currentEnginelife < 53 || hely.otkazpojardvig == 1) engLifeColor = Color.Red;
            DrawText("Engine Life: " + (int)hely.currentEnginelife, new Vector2f(22, 49), engLifeColor, 2);

            Color fuelColor = Color.White;
            if (hely.helifuelCurrent < 150) fuelColor = Color.Yellow;
            DrawText("Fuel: " + (int)hely.helifuelCurrent, new Vector2f(22, 66), fuelColor, 2);
        }


        public void Panel3Check()
        {
            DrawText("hely X: " + (int)hely.positionOfHely.X + " Y: " + (int)hely.positionOfHely.Y, new Vector2f(22, 15), Color.Green, 3);
            DrawText("msGL X: " + (int)(Mouse.GetPosition(Program.window).X - Program.vMode.Width/2 + Program.offset.X ) + 
                     " Y: " + (int)(Mouse.GetPosition(Program.window).Y ), 
                     new Vector2f(22, 32), Color.Green, 3);
            DrawText("X: " + Mouse.GetPosition().X + " Y: " + Mouse.GetPosition().Y, new Vector2f(22, 49), Color.Green, 3);
            DrawText("msW X: " + Mouse.GetPosition(Program.window).X + " Y: " + Mouse.GetPosition(Program.window).Y, new Vector2f(22, 66), Color.Yellow, 3);
            DrawText("X: " + (Mouse.GetPosition(Program.window).X - hely.positionOfHely.X + Program.offset.X - Program.vMode.Width / 2) +
                " Y: " + (Mouse.GetPosition(Program.window).Y - hely.positionOfHely.Y + Program.offset.Y - Program.vMode.Height / 2), new Vector2f(22, 83), Color.White, 3);
            DrawText("offset X: " + Program.offset.X + " Y: " + Program.offset.Y, new Vector2f(22, 130), Color.Green, 3);


        }

        public void Panel4Check()
        {
            
            DrawText("RPM: " + (int)hely.RPM, new Vector2f(22, 15), Color.Green, 4);
            DrawText("currentRotorPower: " + (int)hely.currentRotorPower, new Vector2f(22, 32), Color.Green, 4);
            DrawText("gravityPower: " + (int)hely.gravityPower, new Vector2f(22, 49), Color.Green, 4);
            DrawText("airP: " + Program.m_Pogoda.GetCurrentAirP(hely.altitude), new Vector2f(22, 66), Color.Yellow, 4);
            DrawText("boost.Y: " + hely.boost.Y, new Vector2f(22, 83), Color.White, 4);
            DrawText("powerRTR.Y: " + hely.powerRTR.Y, new Vector2f(22, 130), Color.Green, 4);

        }

        public void SetHely(Hely helycopter)
        {
            hely = helycopter;

        }

        private void DrawText(string txt, Vector2f pos, Color color, int panelNumber)
        {
            Vector2f posGlobal = new Vector2f(0,0);
            if (panelNumber == 1)
            {
                posGlobal = new Vector2f(pos.X + panelAvionikaSprite.Position.X, 
                                pos.Y + panelAvionikaSprite.Position.Y + 5);
            }
            else if (panelNumber == 2)
            {
                posGlobal = new Vector2f(pos.X + panelAvionikaSprite2.Position.X,
                                pos.Y + panelAvionikaSprite2.Position.Y + 5);
            }
            else if (panelNumber == 3)
            {
                posGlobal = new Vector2f(pos.X + panelAvionikaSprite3.Position.X,
                                pos.Y + panelAvionikaSprite3.Position.Y + 5);
            }
            else if (panelNumber == 4)
            {
                posGlobal = new Vector2f(pos.X + panelAvionikaSprite4.Position.X,
                                pos.Y + panelAvionikaSprite4.Position.Y + 5);
            }
            aText = new Text(txt, font,14);
            aText.Position = posGlobal;
            aText.FillColor = color;


            Program.window.Draw(aText);
        }

        /*
            //Очки
            DrawText(800, 35, "Money: " + money, 18);
            DrawText(800, 55, "Record: " + hiscore, 18);
            DrawText(800, 15, "Flight: time " + flighttime, 18);

            */

        private void PricelDraw()
        {
            // Aiming Memoy
            if (Program.m_MouseController.LeftButton == true)
            {
                if (scopeMemory == new Vector2i(-2000, -2000))
                {
                    scopeMemory = Mouse.GetPosition(Program.window)  +  (Vector2i)Program.offset - 
                        new Vector2i((int)Program.vMode.Width/2, (int)Program.vMode.Height / 2);
                }
            }
            else
            {
                if (scopeMemory != new Vector2i(-2000, -2000)) scopeMemory = new Vector2i(-2000, -2000);
            }


            if (hely.m_Weapons[hely.currentWeapon].weaponType == TypeOfObject.gun)
            {
                Vector2f posOrujiya = Matematika.GlobalPointOfLocalPoint(hely.positionOfHely,
                                                                    new Vector2f(hely.weaponPositionsOrigins[0].X * hely.flip,
                                                                                   hely.weaponPositionsOrigins[0].Y),
                                                                   hely.angle);

                Vector2f pos = Matematika.GlobalPointOfLocalPoint(posOrujiya,
                                                                    new Vector2f(145*hely.flip,-15),
                                                                    hely.angle + (hely.m_Weapons[0] as GunLauncher).currentTrankAngle*hely.flip );
                
                scopeSprite.Position = pos;
                scopeSprite.Color = Color.Green;
                Program.window.Draw(scopeSprite);


            }
            else if (hely.m_Weapons[hely.currentWeapon].weaponType == TypeOfObject.nr )
            {
            Vector2f pos = Matematika.LocalPointOfRotationObject(new Vector2f(scopeOrigin.X*hely.flip, scopeOrigin.Y), hely.angle);
            scopeSprite.Position = new Vector2f(hely.positionOfHely.X + pos.X, hely.positionOfHely.Y + pos.Y);
                scopeSprite.Color = Color.White;
                Program.window.Draw(scopeSprite);
            }
            else if(hely.m_Weapons[hely.currentWeapon].weaponType == TypeOfObject.sr)
            {

                if (Program.m_MouseController.LeftButton)
                {
                    //Mouse.SetPosition(scopeMemory, Program.window);
                    scopeSprite.Position = (Vector2f)scopeMemory;
                }
                else
                {
                    scopeSprite.Position = Program.offset + (Vector2f)Mouse.GetPosition(Program.window) -
                                   new Vector2f(Program.vMode.Width / 2, Program.vMode.Height / 2);
                }

                scopeSprite.Color = Color.Red;
                Program.window.Draw(scopeSprite);

            }

        }

        Vertex inertiavector = new Vertex();
        Color vColor = Color.Green;
        private void UpdateInertia()
        {

            inertiavector.Position = new Vector2f(hely.positionOfHely.X, hely.positionOfHely.Y);

            vColor = Color.White;
            if (hely.speed.Y > 0.5f || hely.speed.Y < -0.5f) vColor = Color.Yellow;
            if (hely.speed.Y > 0.9f || hely.speed.Y < -0.9f) vColor = Color.Red;




            // ParkovkaAssistance
            Vertex[] line = new Vertex[]
            {
               new Vertex(new Vector2f(hely.positionOfHely.X, hely.positionOfHely.Y+10)),
               new Vertex(new Vector2f(hely.positionOfHely.X + hely.speed.X*40, hely.positionOfHely.Y + 10),vColor),
               new Vertex(new Vector2f(hely.positionOfHely.X, hely.positionOfHely.Y+10)),
               new Vertex(new Vector2f(hely.positionOfHely.X, hely.positionOfHely.Y-hely.speed.Y*60+10),vColor)
            };

            Program.window.Draw(line, PrimitiveType.Lines);


            // Вектор инерции общее направление
            /*
            inertiaVector = new Vector2f(speedx, speedy);
            inertiavector.Color = Color.Yellow;
            inertiavector.Position = new Vector2f(hely.position.X, hely.position.Y);
            */
            float scaleOfLine = 10;
            float longOfVehicle = 21.3f;
            Vertex[] linScale = new Vertex[]
            {
               new Vertex(new Vector2f(hely.positionOfHely.X-longOfVehicle/2*scaleOfLine-35, hely.positionOfHely.Y-15)),
               new Vertex(new Vector2f(hely.positionOfHely.X+ longOfVehicle/2*scaleOfLine, hely.positionOfHely.Y-15 ),Color.Yellow)
            };
            Program.window.Draw(linScale, PrimitiveType.Lines);


        }


    }
}
