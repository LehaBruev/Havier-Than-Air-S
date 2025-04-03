using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{
    internal class Program
    {
        static SoundManager soundManager;
        static TextureManager mTextureManager;
        static void Main(string[] args)
        {
            
            soundManager = new SoundManager();
            soundManager.playSound();
            mTextureManager = new TextureManager();

            VideoMode vMode = new VideoMode(800, 600);
            RenderWindow win = new SFML.Graphics.RenderWindow(vMode, "Havier Than Air SFML");
            win.Closed += Win_Closed;

            GameController mGameController = new GameController();

            Game mGame = new Game(mGameController, mTextureManager);
            Magnitola mMagnitola = new Magnitola();

            while (win.IsOpen)
            {
                win.Clear();
                win.DispatchEvents();

                mGame.Update();
                win.Display();
            }

            


        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            (sender as RenderWindow).Close();
        }


        //////
        ///
        static void Main(string[] args) // ПРОГРАММА
        {
            //Настройки экрана
            InitWindow(1024, 768, "Havier Than Air"); // Экран
            SetFont("comic.ttf"); // Шрифт
            PlayMusic(mainmenumusic, volume);
            playingmusic = mainmenumusic;


            // GAME
            while (true) // Цикл начиная от меню ВСЯ ИГРА
            {


                ClearWindow();
                DispatchEvents();

                while (mainmenuSwitch == 1 || mainmenuSwitch == 2) // ТОЛЬКО ГЛАВНОЕ МЕНЮ или ПОДМЕНЮ выбор мышью
                {

                    DispatchEvents();
                    ClearWindow();
                    mainmenuDraw();

                    magnitola();



                    if (menudelay <= 0)
                    {
                        if (GetMouseButtonDown(Mouse.Button.Left) == true && levelchoise != 0)
                        {
                            if (mainmenuSwitch == 1)
                            {
                                mainmenuSwitch = 0;
                                StopMusic(mainmenumusic);
                                newgame = 1;
                                gameplaying = 1;
                                Delay(500);
                            }

                            if (mainmenuSwitch == 2) // меню во время игры
                            {
                                if (menuchoise2 == 2) // выход
                                {
                                    mainmenuSwitch = 0;
                                    resultsmenuswitch = 1;
                                    gameplaying = 0;
                                    Delay(500);
                                }
                                if (menuchoise2 == 1) //продолжаем
                                {
                                    mainmenuSwitch = 0;
                                    resultsmenuswitch = 0;
                                    Delay(500);
                                    StopMusic(mainmenumusic);
                                }
                            }

                        }


                    }
                    menudelay = menudelay - 1;
                    DisplayWindow();
                    Delay(15);

                }

                while (resultsmenuswitch == 1) //меню РЕЗУЛЬТАТОВ
                {

                    DispatchEvents();
                    ClearWindow();

                    resultsDraw();

                    if (GetMouseButtonDown(Mouse.Button.Left) == true)
                    {
                        if (resultmenuchoise == 1) // в меню
                        {
                            mainmenuSwitch = 1;
                            resultmenuchoise = 0;
                            resultsmenuswitch = 0;
                            gameplaying = 0;
                        }
                        if (resultmenuchoise == 2) // переиграть
                        {
                            mainmenuSwitch = 0;
                            resultmenuchoise = 0;
                            resultsmenuswitch = 0;
                            newgame = 1;
                            gameplaying = 1;
                            break;
                        }

                    }


                    DisplayWindow();


                }

            } //Цикл меню
        } // Игра 


    }
}
