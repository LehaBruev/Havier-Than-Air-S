using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havier_Than_Air_S.Scripts.Menu;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{
   

    public  class MainMenuController
    {

        //ДЕЛЕГАТЫ
        public delegate void StartGame(int missionCode, int helycode);
        public event StartGame StartGameEvent;

        //Текстуры 
        //Спрайты
        private Texture mainmenutexture = new Texture("Images\\mainmenu.png");
        private Sprite mainMenuSprite; //mainmenutexture);
    
        //Звуки
        SoundBuffer buttonActivateSoundBufer;
        Sound ButtonActitateSound;


        //КНОПКИ
        Button[] mainMenuButtons;

        //ВЫБОР ДЛЯ GAME
        int missionCode = 0;
        //int helyCode = 0;

        public MainMenuController()
        {
            
            buttonActivateSoundBufer = new SoundBuffer("Sounds\\buttonclick.wav");
            ButtonActitateSound = new Sound(buttonActivateSoundBufer);
            ButtonActitateSound.Volume = Program.Mixer.MasterVolume/100 * Program.Mixer.SoundsVolume/100;



            //Спрайты
            mainMenuSprite = new Sprite(mainmenutexture);
            /*

            //Тексты
            ObuchenieText = new Text("1. Get pilot license", font);
            ObuchenieText.Position = new Vector2f(220, 330);
            SetTextSettings(ObuchenieText);
            

            MissionsText = new Text("2. Mission Test", font);
            MissionsText.Position = new Vector2f(222, 370);
            SetTextSettings(MissionsText);

            FreeFlightText = new Text("3. Free flight", font);
            FreeFlightText.Position = new Vector2f(224, 410);
            SetTextSettings(FreeFlightText);
            */

            mainMenuButtons = new Button[7];
            mainMenuButtons[0] = new Button(new RectangleShape(new Vector2f(200, 25)), "1. Get pilot license", new Vector2f(220, 330), new Vector2f(10, -4),1); // 1-3 миссии
            mainMenuButtons[1] = new Button(new RectangleShape(new Vector2f(200, 25)), "2. Mission Test", new Vector2f(220, 370), new Vector2f(10, -4),2);
            mainMenuButtons[2] = new Button(new RectangleShape(new Vector2f(200, 25)), "3. Free flight", new Vector2f(220, 410), new Vector2f(10, -4),3);

            mainMenuButtons[3] = new Button(new RectangleShape(new Vector2f(150, 25)), "1. UH-1", new Vector2f(220, 330), new Vector2f(10, -4), 11);            // 11-14 вертолеты
            mainMenuButtons[4] = new Button(new RectangleShape(new Vector2f(150, 25)), "2. AH-1 Cobra", new Vector2f(220, 370), new Vector2f(10, -4), 12);
            mainMenuButtons[5] = new Button(new RectangleShape(new Vector2f(150, 25)), "3. Mi-24", new Vector2f(220, 410), new Vector2f(10, -4), 13);
            mainMenuButtons[6] = new Button(new RectangleShape(new Vector2f(150, 25)), "3. OH-58", new Vector2f(220, 450), new Vector2f(10, -4), 14);



            for (int i = 0; i < mainMenuButtons.Length; i++)
            {
                mainMenuButtons[i].PRESS += ButtonActivity;
                mainMenuButtons[i].PRESS += Program.m_MouseController.CheckButton;
            }

        }



        bool helyChoiseTime = false;
        private void ButtonActivity(int code)
        {
            switch(code)
            {
                case 108:
                    ButtonActitateSound.Play(); break;

                case 1:
                    helyChoiseTime = true; missionCode = 1; helyChoiseTime = true; break;
                case 2:
                    helyChoiseTime = true; missionCode = 2; helyChoiseTime = true; break;
                case 3:
                    helyChoiseTime = true; missionCode = 3; helyChoiseTime = true; break;
                case 11:
                     StartGameEvent?.Invoke(missionCode,11); break;
                case 12:
                    StartGameEvent?.Invoke(missionCode, 12); break;
                case 13:
                    StartGameEvent?.Invoke(missionCode, 13); break;
                case 14:
                    StartGameEvent?.Invoke(missionCode, 14); break;



            }



        }


        public void Update()
        {

            Program.window.Draw(mainMenuSprite);

            if (helyChoiseTime == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    mainMenuButtons[i].Update();

                }
            }
            else
            {
                for (int i = 3; i < mainMenuButtons.Length; i++)
                {
                    mainMenuButtons[i].Update();

                }
            }

            if (Program.m_MouseController.CheckKeyboardKey(Keyboard.Key.Escape) == true && helyChoiseTime == true)
            {
                helyChoiseTime = false;
                ButtonActivity(108);
            }

        }



        /*
        private void CheckMousePosition()
        {
            
            float x = Program.m_MouseController.x;
            float y = Program.m_MouseController.y;

            if (x > 217 && x < 423 && y > 332 && y < 353 ) //1
            {

                if (currentButton != menuButtons.learning)
                {
                    ButtonMouseIn(ObuchenieText);
                    currentButton = menuButtons.learning;
                }

                if(Program.m_MouseController.LeftButtonIsPressed == true)
                {
                    Program.Game.StartGame(0);
                }
            }
            else if (x > 221 && x < 341 && y> 369 && y < 388) //2
            {
                if (currentButton != menuButtons.missionTest)
                {
                    ButtonMouseIn(MissionsText);
                    currentButton = menuButtons.missionTest;
                }
                if (Program.m_MouseController.LeftButtonIsPressed == true)
                {
                    Program.Game.StartGame(1);
                }
            }

            else if (x > 221 && x< 370 && y > 410 && y < 430) //3
            {
                if (currentButton != menuButtons.freeFlight)
                {
                    ButtonMouseIn(FreeFlightText);
                    currentButton = menuButtons.freeFlight;
                }
                if (Program.m_MouseController.LeftButtonIsPressed == true)
                {
                    Program.Game.StartGame(2);
                }
            }

            else if (currentButton != menuButtons.none)
            {
                ObuchenieText.FillColor = new Color(Color.Green);
                currentButton = menuButtons.none;
                SetTextSettings(ObuchenieText);
                SetTextSettings(MissionsText);
                SetTextSettings(FreeFlightText);
            }
        }



        /*

      
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
