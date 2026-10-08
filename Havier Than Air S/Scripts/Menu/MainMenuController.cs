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


    public class MainMenuController
    {

        //ДЕЛЕГАТЫ
        public delegate void StartGame(int missionCode, int helycode);
        public event StartGame StartGameEvent;

        //Текстуры 
        //Спрайты
        private Texture mainmenutexture = new Texture("Images\\mainmenu.png");
        private Texture endMenuTexture = new Texture("Images\\score1back.png");
        private Sprite mainMenuSprite; //mainmenutexture
        private Sprite endMenuSprite;

        //Звуки
        SoundBuffer buttonActivateSoundBufer;
        Sound ButtonActitateSound;


        //КНОПКИ
        Button[] mainMenuButtons;
        Button[] endMenuButtons;

        //ВЫБОР ДЛЯ GAME
        int missionCode = 0;
        //int helyCode = 0;

        public MainMenuController()
        {

            buttonActivateSoundBufer = new SoundBuffer("Sounds\\buttonclick.wav");
            ButtonActitateSound = new Sound(buttonActivateSoundBufer);
            ButtonActitateSound.Volume = Program.Mixer.MasterVolume / 100 * Program.Mixer.SoundsVolume / 100;



            //Спрайты
            mainMenuSprite = new Sprite(mainmenutexture);
            endMenuSprite = new Sprite(endMenuTexture);

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
            mainMenuButtons[0] = new Button(new RectangleShape(new Vector2f(200, 25)), "1. Get pilot license", new Vector2f(220, 330), new Vector2f(10, -4), 1); // 1-3 миссии
            mainMenuButtons[1] = new Button(new RectangleShape(new Vector2f(200, 25)), "2. Mission Test", new Vector2f(220, 370), new Vector2f(10, -4), 2);
            mainMenuButtons[2] = new Button(new RectangleShape(new Vector2f(200, 25)), "3. Free flight", new Vector2f(220, 410), new Vector2f(10, -4), 3);

            mainMenuButtons[3] = new Button(new RectangleShape(new Vector2f(150, 25)), "1. UH-1", new Vector2f(220, 330), new Vector2f(10, -4), 11);            // 11-14 вертолеты
            mainMenuButtons[4] = new Button(new RectangleShape(new Vector2f(150, 25)), "2. AH-1 Cobra", new Vector2f(220, 370), new Vector2f(10, -4), 12);
            mainMenuButtons[5] = new Button(new RectangleShape(new Vector2f(150, 25)), "3. Mi-24", new Vector2f(220, 410), new Vector2f(10, -4), 13);
            mainMenuButtons[6] = new Button(new RectangleShape(new Vector2f(150, 25)), "3. OH-58", new Vector2f(220, 450), new Vector2f(10, -4), 14);



            for (int i = 0; i < mainMenuButtons.Length; i++)
            {
                mainMenuButtons[i].PRESS += ButtonActivity;
                mainMenuButtons[i].PRESS += Program.m_MouseController.CheckButtonClick;
            }

            //EndMenu
            endMenuButtons = new Button[2];
            endMenuButtons[0] = new Button(new RectangleShape(new Vector2f(200, 25)), "Выход", new Vector2f(370, 640), new Vector2f(10, -4), 1); // 1-3 миссии
            endMenuButtons[1] = new Button(new RectangleShape(new Vector2f(200, 25)), "Продолжить", new Vector2f(720, 640), new Vector2f(10, -4), 2);
            
            for (int i = 0; i < endMenuButtons.Length; i++)
            {
                endMenuButtons[i].PRESS += ButtonActivity;
                endMenuButtons[i].PRESS += Program.m_MouseController.CheckButtonClick;
            }
            
        }



        bool helyChoiseTime = false;
        private void ButtonActivity(int code)
        {
            switch (code)
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
                    StartGameEvent?.Invoke(missionCode, 11); break;
                case 12:
                    StartGameEvent?.Invoke(missionCode, 12); break;
                case 13:
                    StartGameEvent?.Invoke(missionCode, 13); break;
                case 14:
                    StartGameEvent?.Invoke(missionCode, 14); break;

            }

        }

        public bool endMenuOn = false;

        public void Update()
        {
            if (endMenuOn == true)
            {
                Program.window.Draw(endMenuSprite);

                DrawText("Results", new Vector2f(500, 310),Color.Green,30);
                DrawText("Score: ", new Vector2f(400, 345),Color.Green, 20);
                DrawText("Flight Time: ", new Vector2f(400, 365),Color.Green,20);
                DrawText("NR ракет запущено: ", new Vector2f(400, 385),Color.Green,20);
                DrawText("Попаданий ракетами: ", new Vector2f(400, 405),Color.Green,20);
                DrawText("Поражено ПВО: ", new Vector2f(400, 425),Color.Green,20);
                DrawText("Поражено Танков: ", new Vector2f(400, 445),Color.Green,20);
                DrawText("Израсходовано топлива: ", new Vector2f(400, 465),Color.Green,20);
                DrawText("Получено повреждений: ", new Vector2f(400, 485),Color.Green,20);
                
                for (int i = 0; i < endMenuButtons.Length; i++)
                {
                    endMenuButtons[i].Update();

                }
                
            }
            else
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
            }
            if (Program.m_MouseController.CheckKeyboardKey(Keyboard.Key.Escape, true) == true && helyChoiseTime == true)
            {
                helyChoiseTime = false;
                ButtonActivity(108);
            }

        }

        Text aText;
        private void DrawText(string txt, Vector2f pos, Color color, uint size)
        {
            aText = new Text(txt, Program.font, size);
            aText.Position = pos;
            aText.FillColor = color;

            
            Program.window.Draw(aText);
        }

      

    }
}
