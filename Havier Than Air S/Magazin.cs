using Havier_Than_Air_S.Scripts.Menu;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    internal class Magazin
    {


        //ПАРАМЕТРЫ МАГАЗИНА
        //Прайс
        int fuelcost = 900; //цена топлива
        int rocketcost = 800; //цена ракет
        int partscost = 350; //цена запчастей

        //корзина
         float fuelinbag = 100; //топливо на складе
         float nrrocketsinbag = 100; //ракеты на складе
         float partsinbag = 100; //Запчасти в корзине

        //Бэкграунд

        Shape backShape;
        Vector2f backGroundPos = new Vector2f(250,150);

        //Закупки
        int money = 0;
        int partsInBag = 0;
        int fuelInBag = 0;
        int rocketsInBag = 0;
        int bulletsInBag = 0;

        Sprite planshet;
        

        //Картинки и кнопки
        Button[] buttons;

        //Sounds
        SoundBuffer buttonActivateSoundBufer;
        Sound ButtonActivateSound;

        //Texts
        Text[] texts;
        public Magazin()
        {
            buttonActivateSoundBufer = new SoundBuffer("Sounds\\buttonclick.wav");
            ButtonActivateSound = new Sound(buttonActivateSoundBufer);
            ButtonActivateSound.Volume = Program.Mixer.MasterVolume / 100 * Program.Mixer.SoundsVolume / 100;

            Image img = new Image("Images\\Planshet1.png");
            img.CreateMaskFromColor(Color.White);
            planshet = new Sprite(new Texture(img));
            planshet.Position = new Vector2f(150, 55);
            

            backShape = new RectangleShape(new Vector2f(850,550));
            backShape.FillColor = new Color(47, 55, 68);
            backShape.Position = backGroundPos;

            buttons = new Button[3];

            //FUEL
            buttons[0] = new Button(new RectangleShape(new Vector2f(142,105)), "", backGroundPos + new Vector2f(400, 125), new Vector2f(), 201);
            buttons[0].SetButtonTexture(new Texture(Program.m_TextureManager.allImage,new IntRect(new Vector2i(967, 583), new Vector2i(142, 105))));
          
            //ROCKETS
            buttons[1] = new Button(new RectangleShape(new Vector2f(142, 105)), "", backGroundPos + new Vector2f(400, 250), new Vector2f(), 202);
            buttons[1].SetButtonTexture(new Texture(Program.m_TextureManager.allImage, new IntRect(972, 824, 134, 103)));
            
            //PARTS
            buttons[2] = new Button(new RectangleShape(new Vector2f(142, 105)), "", backGroundPos + new Vector2f(400, 375), new Vector2f(), 203);
            buttons[2].SetButtonTexture(new Texture(Program.m_TextureManager.allImage, new IntRect(971, 697, 130, 117)));
            
            for (int i = 0; i<buttons.Length;i++)
            {
                buttons[i].SetButtonColors(new Color(255, 255, 255, 255), Color.Green, new Color(255, 255, 255, 0), Color.Green);
                buttons[i].PRESS += ButtonClicked;
                buttons[i].PRESS += Program.m_MouseController.CheckButtonClick;
            }


        }

        Text aText;

        void DrawText(string txt, Vector2f pos, Color color, uint size)
        {
            
              Vector2f  posGlobal = new Vector2f(pos.X + backShape.Position.X,
                                pos.Y + backShape.Position.Y + 5);
            
            aText = new Text(txt, Program.font, size);
            aText.Position = posGlobal;
            aText.FillColor = color;


            Program.window.Draw(aText);
        }

        public void ButtonClicked(int code)
        {
            ButtonActivateSound.Play();
            switch (code)
            {
                case 201: fuelInBag += 100; money -= fuelcost; break;
                case 202: rocketsInBag += 1; money -= rocketcost; break;
                case 203: partsInBag += 10; money -= partscost; break;
            }

        }



        public void Update()
        {
            
            Program.window.Draw(backShape);
            Program.window.Draw(planshet);


            for (int i = 0;i< buttons.Length;i++)
            {
                buttons[i].Update();
            }

            //Шапка
            DrawText("At the Base " , new Vector2f(150, 75), Color.White,24);
            DrawText("Store " , new Vector2f(450, 75), Color.White,24);
            DrawText("Prise " , new Vector2f(625, 75), Color.White,24);


            DrawText("Fuel:" ,new Vector2f(50,155),Color.Green, 18);
            DrawText("Rockets:" ,new Vector2f(50,280),Color.Green, 18);
            DrawText("Parts:" ,new Vector2f(50,405),Color.Green, 18);

            DrawText( fuelInBag.ToString(), new Vector2f(175, 155), Color.Green, 20);
            DrawText( rocketsInBag.ToString(), new Vector2f(175, 280), Color.Green, 20);
            DrawText( partsInBag.ToString(), new Vector2f(175, 405), Color.Green, 20);

            DrawText("x100" , new Vector2f(550, 185), Color.White, 18);
            DrawText("x1" , new Vector2f(550, 310), Color.White, 18);
            DrawText("x10" , new Vector2f(550, 435), Color.White, 18);

            DrawText(fuelcost.ToString(), new Vector2f(650, 155), Color.White, 22);
            DrawText(rocketcost.ToString(), new Vector2f(650, 280), Color.White, 22);
            DrawText(partscost.ToString(), new Vector2f(650, 405), Color.White, 22);

            DrawText("$$$ Your Money: " + money, new Vector2f(470,20),Color.Green, 24);

        }



        /*

            

                //меню надписи
                SetFillColor(Color.White);
                DrawText(820, 220, "Store          Price", 22);
                DrawText(400, 220, "In Heli", 22);
                DrawText(601, 220, "At the Base", 22);
                DrawText(450, 170, "Your Money: " + money, 30);
                //прайс
                DrawText(950, 300, "" + (int)fuelcost, 18);
                DrawText(950, 430, "" + (int)rocketcost, 18);
                DrawText(950, 540, "" + (int)partscost, 18);


                if (engineswitch == 1)
                {
                    SetFillColor(Color.Red);
                    DrawText(380, 600, "Press \"i\" to turn off Engine", 28);
                }


        */


    }
}
