using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{
   

    internal class MaiMenuController
    {

        public enum menuButtons
        {
            none,
            learning,
            missions,
            freeFlight


        }

        public menuButtons currentButton;

        //Меню бэкграунд
        private Texture mainmenutexture = new Texture("mainmenu.png");
        private Sprite mainMenuSprite; //mainmenutexture);

        //Тексты
        Font font;
        Text ObuchenieText;
        Text MissionsText;
        Text FreeFlightText;

        //Звуки
        SoundBuffer buttonActivate;
        Sound ButtonActitateSound;

        private void SetTextSettings(Text _text)
        {
            _text.Scale = new Vector2f(0.7f, 0.7f);
            _text.FillColor = new Color(Color.Green);

        }

        public MaiMenuController()
        {
            buttonActivate = new SoundBuffer("buttonclick.wav");
            ButtonActitateSound = new Sound(buttonActivate);
            currentButton = menuButtons.none;

            font = new Font("comic.ttf");
            mainMenuSprite = new Sprite(mainmenutexture);



            //Тексты
            ObuchenieText = new Text("1. Get pilot license", font);
            ObuchenieText.Position = new Vector2f(220, 330);
            SetTextSettings(ObuchenieText);
            

            MissionsText = new Text("2. Missions", font);
            MissionsText.Position = new Vector2f(222, 370);
            SetTextSettings(MissionsText);

            FreeFlightText = new Text("3. Free flight", font);
            FreeFlightText.Position = new Vector2f(224, 410);
            SetTextSettings(FreeFlightText);


        }


        private void ButtonMouseIn(Text text)
        {
            text.FillColor = new Color(Color.Red);
            ButtonActitateSound.Play();

        }

        private void CheckMousePosition()
        {
            if (Mouse.GetPosition(Program.window).X > 217 && Mouse.GetPosition(Program.window).X < 423 && //1
                Mouse.GetPosition(Program.window).Y > 332 && Mouse.GetPosition(Program.window).Y < 353)
            {
                if (currentButton != menuButtons.learning)
                {
                    ButtonMouseIn(ObuchenieText);
                    currentButton = menuButtons.learning;
                }
                


            }
            else if (Mouse.GetPosition(Program.window).X > 221 && Mouse.GetPosition(Program.window).X < 341 && //2
                Mouse.GetPosition(Program.window).Y > 369 && Mouse.GetPosition(Program.window).Y < 388)
            {
                if (currentButton != menuButtons.missions)
                {
                    ButtonMouseIn(MissionsText);
                    currentButton = menuButtons.missions;
                }



            }

            else if (Mouse.GetPosition(Program.window).X > 221 && Mouse.GetPosition(Program.window).X < 370 && //3
                Mouse.GetPosition(Program.window).Y > 410 && Mouse.GetPosition(Program.window).Y < 430)
            {
                if (currentButton != menuButtons.freeFlight)
                {
                    ButtonMouseIn(FreeFlightText);
                    currentButton = menuButtons.freeFlight;
                }



            }

            else if(currentButton != menuButtons.none)
            {
                ObuchenieText.FillColor = new Color(Color.Green);
                currentButton = menuButtons.none;
                SetTextSettings(ObuchenieText);
                SetTextSettings(MissionsText);
                SetTextSettings(FreeFlightText);
            }
            
            
        }

        public void Update()
        {

            CheckMousePosition();

            Program.window.Draw(mainMenuSprite);
            Program.window.Draw(ObuchenieText);
            Program.window.Draw(MissionsText);
            Program.window.Draw(FreeFlightText);


        }




        /*

        //РЕЗУЛЬТАТЫ РЕЗУЛЬТАТЫ РЕЗУЛЬТАТЫ
        static void resultsDraw()
        {

            DrawSprite(scoresprite, 0, 0);
            SetFillColor(Color.White);

            DrawText(500, 310, "Results", 30);
            DrawText(400, 345, "Score: " + money, 20); //score
            DrawText(400, 365, "Flight Time: " + flighttime, 20); //полетное время
            DrawText(400, 385, "NR ракет запущено: " + NRrocketslaunched, 20);
            DrawText(400, 405, "Попаданий ракетами: " + targetbingos, 20);
            DrawText(400, 425, "Поражено ПВО: " + buk1destroyes, 20);
            DrawText(400, 445, "Поражено Танков: " + tank1destroyes, 20);
            DrawText(400, 465, "Израсходовано топлива: " + fuelusedup, 20);
            DrawText(400, 485, "Получено повреждений: " + getdamages, 20);

            DrawText(380, 644, "В МЕНЮ ", 24);
            DrawText(725, 644, "ПОВТОРИТЬ", 24);

            if (MouseX > 377 && MouseX < 495 && MouseY > 641 && MouseY < 673)  // в меню
            {
                if (resultmenuchoise != 1) PlaySound(click);

                resultmenuchoise = 1;

                SetFillColor(Color.Green);
                DrawText(380, 644, "В МЕНЮ ", 24);
            }

            else
            {
                if (MouseX > 714 && MouseX < 878 && MouseY > 642 && MouseY < 673)  // переиграть
                {
                    if (resultmenuchoise != 2) PlaySound(click);

                    resultmenuchoise = 2;
                    SetFillColor(Color.Green);
                    DrawText(725, 644, "ПОВТОРИТЬ", 24);



                }
                else resultmenuchoise = 0;

            }
        }



        */


    }
}
