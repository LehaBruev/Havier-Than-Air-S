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

        Font font;

        Image imageAll = new Image("uh61all.png");
        Texture avionikaTexture;
        Sprite panelAvionikaSprite;
        Sprite panelAvionikaSprite2;
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


            Program.window.Draw(panelAvionikaSprite);
            Program.window.Draw(panelAvionikaSprite2);

            //Параметры верталета
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
            if (hely.helifuel < 150) fuelColor = Color.Yellow; 
            DrawText("Fuel: " + (int)hely.helifuel, new Vector2f(22, 66), fuelColor, 2);


            PricelDraw();
        }




        private void DrawText(string txt, Vector2f pos, Color color, int displayNumber)
        {
            Vector2f posGlobal = new Vector2f(0,0);
            if (displayNumber == 1)
            {
                posGlobal = new Vector2f(pos.X + panelAvionikaSprite.Position.X, 
                                pos.Y + panelAvionikaSprite.Position.Y + 5);
            }
            else if (displayNumber == 2)
            {
                posGlobal = new Vector2f(pos.X + panelAvionikaSprite2.Position.X,
                                pos.Y + panelAvionikaSprite.Position.Y + 5);
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

                scopeSprite.Position = (Vector2f)Mouse.GetPosition(Program.window);
                scopeSprite.Color = Color.Red;
                Program.window.Draw(scopeSprite);

            }

        }
    }
}
