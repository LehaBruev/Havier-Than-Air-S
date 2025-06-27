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

        Font font;

        Image imageAll = new Image("uh61all.png");
        Texture avionikaTexture;
        Sprite panelAvionikaSprite;
        Sprite panelAvionikaSprite2;
        Sprite panelAvionikaSprite3;
        Text aText;

        // Pricel mode 2
        float distance = 150;
        Texture pricMod2Texture;
        Texture pricMod3Texture;
        Sprite scopeSprite;
        Vector2f scopeOrigin = new Vector2f(350, 30);

        public Avionika(Hely helycopter)
        {
            hely = helycopter;

            font = new Font("comic.ttf");
            avionikaTexture = new Texture(imageAll, new IntRect(new Vector2i(140, 679), new Vector2i(158, 131)));
            panelAvionikaSprite = new Sprite(avionikaTexture);
            panelAvionikaSprite.Position = new Vector2f(10.0f, 10.0f);

            panelAvionikaSprite2 = new Sprite(avionikaTexture);
            panelAvionikaSprite2.Position = new Vector2f(185.0f, 10.0f);

            panelAvionikaSprite3 = new Sprite(avionikaTexture);
            panelAvionikaSprite3.Position = panel3Posi;

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
            origin = Program.offset;
            panelAvionikaSprite.Position = origin -
                                            new Vector2f( Program.vMode.Width/2,Program.vMode.Height/2) + panel1Posi;
            panelAvionikaSprite2.Position = origin -
                                           new Vector2f(Program.vMode.Width / 2, Program.vMode.Height / 2) + panel2Posi;
            panelAvionikaSprite3.Position = origin -
                                           new Vector2f(Program.vMode.Width / 2, Program.vMode.Height / 2) + panel3Posi;


            Program.window.Draw(panelAvionikaSprite);
            Program.window.Draw(panelAvionikaSprite2);
            Program.window.Draw(panelAvionikaSprite3);

            //Параметры верталета Panel_1
            Color lifeColor = Color.White;
            if (hely.helilifeCurrent < 90)  lifeColor = Color.Red; 
            DrawText("Heli Life: " + (int)hely.helilifeCurrent, new Vector2f(22, 15), lifeColor, 1);
            DrawText("Altitude: " + (int)hely.altitude, new Vector2f(22, 32), Color.White, 1);
            DrawText("Angle: " + (int)hely.angle, new Vector2f(22, 49), Color.White, 1);
            DrawText("Автопилот V: ", new Vector2f(22, 66), Color.White, 1);
            DrawText("Автопилот H: ", new Vector2f(22, 83), Color.White, 1);


            /*
            //DrawText(25, 15, "Heli Life: " + (int)helilife, 14);

            DrawText(200, 30, "Engine Switch: " + engineswitch, 14);
            DrawText(25, 30, "Altitude: " + (int)altitude * 10, 14);
            DrawText(25, 45, "Angle: " + (int)angle, 14);
            DrawText(25, 60, "Автопилот V: " + autopilotswitchX, 14);
            DrawText(25, 75, "Автопилот H: " + autopilotswitch, 14);
            */

            // Panel_2
            //Двигаетль
            Color colorEngineSpeed = Color.White;
            if (hely.enginespeed > hely.enginespeedlimit) colorEngineSpeed = Color.Red;
            DrawText("Engine S.: " + (int)hely.enginespeed, new Vector2f(22, 15) , colorEngineSpeed, 2);
            
            Color engSwithColor = Color.White;
            if (hely.engineswitch == 1) engSwithColor = Color.Green;
            DrawText("Engine Switch: " + hely.engineswitch, new Vector2f(22, 32), engSwithColor, 2);

            Color engLifeColor = Color.White;
            
            if (hely.helienginelife < 75 || hely.otkazpojardvig == 1) engLifeColor = Color.Yellow; 
            if (hely.helienginelife < 53 || hely.otkazpojardvig == 1) engLifeColor = Color.Red;
            DrawText( "Engine Life: " + (int)hely.helienginelife, new Vector2f(22, 49), engLifeColor, 2);

            Color fuelColor = Color.White;
            if (hely.helifuelCurrent < 150) fuelColor = Color.Yellow; 
            DrawText("Fuel: " + (int)hely.helifuelCurrent, new Vector2f(22, 66), fuelColor, 2);

            // Panel_3
            DrawText("X: " + (int)hely.position.X, new Vector2f(22, 15), Color.Green, 3);
            DrawText("Y: " + (int)hely.position.Y, new Vector2f(22, 32), Color.Green, 3);
            DrawText("X: " + Mouse.GetPosition().X + " Y: " + Mouse.GetPosition().Y, new Vector2f(22, 49), Color.Green, 3);
            DrawText("X: " + Mouse.GetPosition(Program.window).X + " Y: " + Mouse.GetPosition(Program.window).Y, new Vector2f(22, 66), Color.Yellow, 3);
            DrawText("X: " + (Mouse.GetPosition(Program.window).X  - hely.position.X + Program.offset.X  - Program.vMode.Width/2) +
                " Y: " + (Mouse.GetPosition(Program.window).Y - hely.position.Y  + Program.offset.Y  - Program.vMode.Height / 2), new Vector2f(22, 83), Color.White, 3);
            DrawText("X: " + Program.offset.X + " Y: " + Program.offset.Y, new Vector2f(22, 130), Color.Green, 3);


            if (hely != null)
            {
                PricelDraw();
                UpdateInertia();
            }
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
            aText = new Text(txt, font,14);
            aText.Position = posGlobal;
            aText.FillColor = color;


            Program.window.Draw(aText);
        }

        /*
        static void PanelInstrument() // параметры приборной панели и отрисовка
        {
            SetFillColor(Color.Red);

            
            
          
            //Вооружение
            DrawText(400, 5, "Режим: " + gunmode, 18);

            int n = 0;
            for (int i = 0; i < R.GetLength(1); i++)
            {
                if (R[5, i] == 1) n = n + 1;

            }
            DrawText(400, 20, "НР ракеты " + n + " из " + nrrocketsMaxquantity, 18);
            if (n <= 3) { SetFillColor(Color.Yellow); DrawText(400, 20, "НР ракеты " + n + " из " + nrrocketsMaxquantity, 18); SetFillColor(Color.White); }



            //Окруж среда
            DrawText(600, 5, "Плотность воздуха: " + gunmode, 14);
            DrawText(600, 20, "Ветер " + wind, 14);


            //Очки
            DrawText(800, 35, "Money: " + money, 18);
            DrawText(800, 55, "Record: " + hiscore, 18);
            DrawText(800, 15, "Flight: time " + flighttime, 18);

            

        }

*/

        private void PricelDraw()
        {
            if (hely.m_Weapons[hely.currentWeapon].weaponTyte == TypeOfObject.nr)
            {
            Vector2f pos = Matematika.LocalPointOfRotationObject(scopeOrigin, hely.angle);
            scopeSprite.Position = new Vector2f(hely.position.X + pos.X, hely.position.Y + pos.Y);
                scopeSprite.Color = Color.White;
                Program.window.Draw(scopeSprite);
            }


            if (hely.m_Weapons[hely.currentWeapon].weaponTyte == TypeOfObject.sr)
            {

                //scopeSprite.Position = (Vector2f)Mouse.GetPosition(Program.window);
                scopeSprite.Position = Program.offset + (Vector2f)Mouse.GetPosition(Program.window) -
                new Vector2f(Program.vMode.Width / 2, Program.vMode.Height / 2);


                scopeSprite.Color = Color.Red;
                Program.window.Draw(scopeSprite);

            }

        }

        Vertex inertiavector = new Vertex();
        Color vColor = Color.Green;
        private void UpdateInertia()
        {
            inertiavector.Position = new Vector2f(hely.position.X, hely.position.Y);

            vColor = Color.White;
            if (hely.speedy > 0.5f || hely.speedy < -0.5f) vColor = Color.Yellow;
            if (hely.speedy > 0.9f || hely.speedy < -0.9f) vColor = Color.Red;



            // ParkovkaAssistance
            Vertex[] line = new Vertex[]
            {
               new Vertex(new Vector2f(hely.position.X, hely.position.Y+10)),
               new Vertex(new Vector2f(hely.position.X + hely.speedx*40, hely.position.Y + 10),vColor),
               new Vertex(new Vector2f(hely.position.X, hely.position.Y+10)),
               new Vertex(new Vector2f(hely.position.X, hely.position.Y-hely.speedy*60+10),vColor)
            };

            Program.window.Draw(line, PrimitiveType.Lines);

            /*
            inertiaVector = new Vector2f(speedx, speedy);
            inertiavector.Color = Color.Yellow;
            inertiavector.Position = new Vector2f(hely.position.X, hely.position.Y);
            */

        }


    }
}
