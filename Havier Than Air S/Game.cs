using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Havier_Than_Air_S
{
    public enum MissionSwitch
    {
        mis1,
        mis2,
        mis3

    }
   
    public class Game 
    {
        GameState mGameState;
        
        public static SoundManager soundManager;
        static TextureManager mTextureManager;
        static Magnitola mMagnitola = new Magnitola();
        private MissionSwitch mMissinSwitch;

        private Sprite mBackgroundSprite;

        public Game()
        {
            StartGame();
        }

        private void StartGame()
        {
            mGameState = new GameState();
            soundManager = new SoundManager();
            
            mTextureManager = new TextureManager(Program.mGameMode );
            mMissinSwitch = MissionSwitch.mis1;
            ;
        }


        // SetFont("comic.ttf"); // Шрифт
        // PlayMusic(mainmenumusic, volume);
        //playingmusic = mainmenumusic;
        //Меню
        int mainmenuSwitch = 1;
         int levelchoise = 0;
         int menuchoise2 = 0;
         int newgame = 0;
         int gameplaying = 0;
         int menudelay = 50;
         int podskazkaswitch = 1;

        //Миссии
         int checkdelay = 50;
         int missionswitch = 0;
         int volnadelay = 0;
         int volnadelay2 = 0;
         int basedurability = 10;
         int winpobeda = 0;



        //результаты
         float resultsmenuswitch = 0; //меню результатов
         float resultmenuchoise = 0; //меню результатов ывбор кнопки
         float money = 0; //очки
         float hiscore = 0; //рекорд очков
         float flighttime = 0; //время нахождения в воздухе
         float flighttimerecord = 0; //рекорд нахождения в воздухе
         float landingquantity = 0; //количество посадок
         float NRrocketslaunched = 0; //выпущено NR ракет количество
         float targetbingos = 0; //попаданий по цели
         float buk1destroyes = 0; //уничтожено буков1
         float tank1destroyes = 0; //уничтожено танков1
         float fuelusedup = 0; //израсходовано топлива
         float repairings = 0; //Отремонтирован вертолет
         float getdamages = 0; //Получено повреждений


        public void Update()
        {
            mTextureManager.DrawBackground();
            


            if (mGameState.CurrentMode == GameMode.MainMenu)
            {
                

            }
            else if (mGameState.CurrentMode == GameMode.Play)
            {
                MooveObjects();
                DrawObjects();
            }

        }


        public void MooveObjects()
        {
            

        }

        public void DrawObjects()
        {
           

        }


        //награды
        float tank1reward = 10000; //Получено повреждений
         float buk1reward = 30000; //Получено повреждений
                                         //static float repairings = 0; //Отремонтирован вертолет
/*
                 while (mainmenuSwitch == 1 || mainmenuSwitch == 2) // ТОЛЬКО ГЛАВНОЕ МЕНЮ или ПОДМЕНЮ выбор мышью
                {

                
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

*/
    /*
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
    */

        /*/
}


                    }
                    menudelay = menudelay - 1;
DisplayWindow();
Delay(15);

                }

                while (resultsmenuswitch == 1) //меню РЕЗУЛЬТАТОВ
{



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

public Game(GameController gameController, TextureManager textureManager)
        {

            mGameController = gameController;
            mTextureManager = textureManager;

        }



        public void Update()
        {
        

            if (mGameController.CurrentMode  == GameMode.Play)
            {
                MooveObjects();
                DrawObjects();
            }
            else if (mGameController.CurrentMode == GameMode.MainMenu) 
            {
                DrawMenu();
            
            }


        }



        private void MooveObjects()
        { 
        
        }

        private void DrawObjects()
        {

        }

        private void DrawMenu()
        {

        }




        //МИССИИ МИССИИ МИССИИ
        static void Mission1() // 1. ТРЕНИРОВКА Взлет, полет, посадка. 2. Дозаправка 3. Облет препятствий 4. Стрельба по мишеням
                               // Значения: 0 - задание провалено, 1 - задание скрыто, 2 - задание выполняется, 3 - задание выполнено
        {
            //checkpoints[0] = 3;
            // checkpoints[1] = 3;
            //checkpoints[2] = 3;
            //checkpoints[3] = 3;
            //checkpoints[4] = 3;
            //checkpoints[5] = 3;
            //checkpoints[6] = 3;



            for (int i = 0; i < checkpoints.GetLength(0); i++)
            {
                if (checkpoints[i] == 2) break;
                if (checkpoints[i] == 1)
                {
                    if (checkdelay < 0)
                    {
                        checkpoints[i] = 2;
                    }

                    break;
                }

            }
            checkdelay = checkdelay - 1;
            // ЗАДАНИЯ НА МИССИЮ
            // 1. Вкл двигатель
            if (checkpoints[0] == 2)
            {
                SetFillColor(Color.Blue);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);

                DrawText(330, 265, "Включи двигатель! Нажми \"i\"", 32);

                // Условие победы
                if (engineswitch == 1) { checkpoints[0] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); }

            }
            // 2. Подняться на высоту 5000

            if (checkpoints[1] == 2)
            {
                SetFillColor(Color.Blue);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);

                DrawText(330, 265, "Подними вертолет на 4000,", 32);
                DrawText(330, 300, "     клавиша \"W\"", 32);


                // Условие победы
                if (altitude > 400) { checkpoints[1] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); }


            }

            // 3. Приземлить верталет и заглушить двигатель

            if (checkpoints[2] == 2)
            {
                SetFillColor(Color.Blue);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 265, "Приземли вертолет на базе. (S)", 32);
                DrawText(330, 300, "и заглуши двигатель. (i)", 32);



                // Условие победы
                if (padswitch == 1 && engineswitch == 0) { checkpoints[2] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); }

            }

            // 4. Купить топливо и ракеты

            if (checkpoints[3] == 2)
            {
                SetFillColor(Color.Blue);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 265, "Заправься и купи ракеты,", 32);
                DrawText(330, 300, "почини вертолет. Жми \"R\"", 32);

                // Условие победы
                if (padstoreswitch == 1) { checkpoints[3] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); }


            }

            //5. Выход из магазина
            if (checkpoints[4] == 2 && helifuel >= helifuelmax - 10)
            {
                SetFillColor(Color.Blue);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 265, "Заведи мотор, клавиша \"i\"", 32);
                DrawText(330, 300, "Выходи из магазина, \"R\"", 32);

                // Условие победы
                if (engineswitch == 1 && padstoreswitch == 0) { checkpoints[4] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); }


            }

            //6. Облететь воздушные шары

            if (checkpoints[5] == 2)
            {
                SetFillColor(Color.Blue);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                if (podskazkaswitch == 1)
                {

                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    DrawText(330, 265, "Облети все воздушные шары.", 32);
                    DrawText(330, 300, "Столкнешься - чинись на базе. ", 32);
                    DrawText(330, 340, "(Понял! - жми \"Y\", не понял... жми \"Y\".)", 16);

                }
                if (missionswitch == 0)
                {
                    airballonscicle[1, 1] = 1100; //1
                    airballonscicle[2, 1] = 700;  //1
                    airballonscicle[4, 1] = 270;  //1
                    airballonscicle[5, 1] = 570;  //1
                    airballonscicle[3, 1] = 1;  //1

                    airballonscicle[1, 2] = 1100; //2
                    airballonscicle[2, 2] = 700;  //2
                    airballonscicle[4, 2] = 310;  //2
                    airballonscicle[5, 2] = 310;  //2
                    airballonscicle[3, 2] = 1;  //2

                    airballonscicle[1, 3] = 1100; //3
                    airballonscicle[2, 3] = 700;  //3
                    airballonscicle[4, 3] = 480;  //3
                    airballonscicle[5, 3] = 300;  //3
                    airballonscicle[3, 3] = 1;  //3

                    airballonscicle[1, 4] = 1100; //4
                    airballonscicle[2, 4] = 700;  //4
                    airballonscicle[4, 4] = 700;  //4
                    airballonscicle[5, 4] = 166;  //4
                    airballonscicle[3, 4] = 1;  //4

                    missionswitch = 1;
                }

                airballondraw();

                if (checkpoints2[3] == 1)
                {
                    SetFillColor(Color.Cyan);
                    FillCircle(670, 560, 70);
                    SetFillColor(Color.Black);
                    DrawText(612, 562, "Лети сюда 3", 18);
                }


                if (checkpoints2[2] == 1)
                {
                    SetFillColor(Color.Cyan);
                    FillCircle(880, 50, 70);
                    SetFillColor(Color.Black);
                    DrawText(825, 50, "Лети сюда 2", 18);
                }
                if (checkpoints2[1] == 1)
                {
                    SetFillColor(Color.Cyan);
                    FillCircle(100, 240, 70);
                    SetFillColor(Color.Black);
                    DrawText(40, 240, "Лети сюда 1", 18);
                }

                if (0 < playerx + playerl && 200 > playerx && 200 < playery + playerh && 350 > playery && helidestroy != 1 && checkpoints2[1] == 1) { checkpoints2[1] = 0; money = money + 5000; PlaySound(checkpointsound, volume); }
                if (800 < playerx + playerl && 1000 > playerx && 0 < playery + playerh && 150 > playery && helidestroy != 1 && checkpoints2[2] == 1) { checkpoints2[2] = 0; money = money + 5000; PlaySound(checkpointsound, volume); }
                if (550 < playerx + playerl && 700 > playerx && 500 < playery + playerh && 650 > playery && helidestroy != 1 && checkpoints2[3] == 1) { checkpoints2[3] = 0; money = money + 5000; PlaySound(checkpointsound, volume); }

                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                if (podskazkaswitch == 1)
                {

                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    SetFillColor(Color.Blue);
                    DrawText(330, 265, "Облети все воздушные шары.", 32);
                    DrawText(330, 300, "Столкнешься - чинись на базе. ", 32);
                    DrawText(330, 340, "(Понял! - жми \"Y\", не понял... жми \"Y\".)", 16);

                }

                // Шары улетают влево вверх
                if (checkpoints2[1] == 0 && checkpoints2[2] == 0 && checkpoints2[3] == 0)
                {
                    airballonscicle[4, 1] = -400;
                    airballonscicle[5, 1] = -400;
                    airballonscicle[4, 2] = -400;
                    airballonscicle[5, 2] = -400;
                    airballonscicle[4, 3] = -400;
                    airballonscicle[5, 3] = -400;
                    airballonscicle[4, 4] = -400;
                    airballonscicle[5, 4] = -400;


                }
                // Условие победы чек 6

                if (checkpoints2[1] == 0 && checkpoints2[2] == 0 && checkpoints2[3] == 0 && airballonscicle[1, 1] <= -300)
                {
                    checkpoints[5] = 3; checkdelay = 200; missionswitch = 0; PlaySound(checkpointsound, volume); podskazkaswitch = 1;
                }
            }

            //7. Выбрать режим 2 и разнести два танка

            if (checkpoints[6] == 2)
            {
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                if (podskazkaswitch == 1)
                {
                    SetFillColor(Color.Blue);

                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    DrawText(330, 260, "Выбери ракеты Воздух-Земля,", 32);
                    DrawText(330, 295, "нажми цифру \"2\".", 32);
                    DrawText(330, 335, "(Перезарядка на базе)", 26);
                    DrawText(330, 372, "(Убрать сообщение Y, магазин на базе R)", 16);
                }

                //танки едут  // Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения,6=скорость)
                if (missionswitch == 0)
                {
                    Tank1cicles[3, 1] = 1;
                    Tank1cicles[6, 1] = 1;    //скорость танка
                    Tank1cicles[1, 1] = 1100; //где появится танк
                    Tank1cicles[2, 1] = 698;
                    Tank1cicles[4, 1] = 800; //куда поедет танк
                    Tank1cicles[7, 1] = 100; //жизни


                    Tank1cicles[3, 2] = 1;
                    Tank1cicles[6, 2] = 0.2f; //скорость танка
                    Tank1cicles[1, 2] = 1100; //где появится танк
                    Tank1cicles[2, 2] = 700;
                    Tank1cicles[4, 2] = 300; //куда поедет танк
                    Tank1cicles[7, 2] = 400; //жизни


                    Tank1cicles[3, 3] = 1;
                    Tank1cicles[6, 3] = 0.5f; //скорость танка
                    Tank1cicles[1, 3] = 1100; //где появится танк
                    Tank1cicles[2, 3] = 703;
                    Tank1cicles[4, 3] = 500; //куда поедет танк
                    Tank1cicles[7, 3] = 200; //жизни


                    missionswitch = 1;


                }
                tank1move();


                // Условие победы
                int n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;

                }
                if (n == 0)
                { checkpoints[6] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }



            }

            //8. Окончание тренировки

            if (checkpoints[7] == 2)
            {
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                if (podskazkaswitch == 1)
                {
                    SetFillColor(Color.Blue);

                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    DrawText(330, 260, "Можно взять 16 ракет,", 32);
                    DrawText(330, 295, "Окончить обучение - жми \"L\"", 32);

                    DrawText(330, 372, "(Убрать сообщение Y, магазин на базе R)", 16);
                }

                //танки едут  // Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения,6=скорость)
                if (missionswitch == 0)
                {
                    nrrocketsMaxquantity = 16;


                    Tank1cicles[3, 1] = 1;
                    Tank1cicles[6, 1] = 1;    //скорость танка
                    Tank1cicles[1, 1] = 1100; //где появится танк
                    Tank1cicles[2, 1] = 698;
                    Tank1cicles[4, 1] = 800; //куда поедет танк
                    Tank1cicles[7, 1] = 100; //жизни


                    Tank1cicles[3, 2] = 1;
                    Tank1cicles[6, 2] = 0.2f; //скорость танка
                    Tank1cicles[1, 2] = 1100; //где появится танк
                    Tank1cicles[2, 2] = 700;
                    Tank1cicles[4, 2] = 300; //куда поедет танк
                    Tank1cicles[7, 2] = 400; //жизни


                    Tank1cicles[3, 3] = 1;
                    Tank1cicles[6, 3] = 0.5f; //скорость танка
                    Tank1cicles[1, 3] = 1100; //где появится танк
                    Tank1cicles[2, 3] = 703;
                    Tank1cicles[4, 3] = 500; //куда поедет танк
                    Tank1cicles[7, 3] = 200; //жизни

                    Tank1cicles[3, 4] = 1;
                    Tank1cicles[6, 4] = 3; //скорость танка
                    Tank1cicles[1, 4] = -200; //где появится танк
                    Tank1cicles[2, 4] = 703;
                    Tank1cicles[4, 4] = 600; //куда поедет танк
                    Tank1cicles[7, 4] = 100; //жизни

                    Tank1cicles[3, 5] = 1;
                    Tank1cicles[6, 5] = 0.3f; //скорость танка
                    Tank1cicles[1, 5] = -300; //где появится танк
                    Tank1cicles[2, 5] = 703;
                    Tank1cicles[4, 5] = 900; //куда поедет танк
                    Tank1cicles[7, 5] = 350; //жизни

                    Tank1cicles[3, 6] = 1;
                    Tank1cicles[6, 6] = 0.5f; //скорость танка
                    Tank1cicles[1, 6] = 1100; //где появится танк
                    Tank1cicles[2, 6] = 703;
                    Tank1cicles[4, 6] = 800; //куда поедет танк
                    Tank1cicles[7, 6] = 100; //жизни

                    Tank1cicles[3, 7] = 1;
                    Tank1cicles[6, 7] = 0.5f; //скорость танка
                    Tank1cicles[1, 7] = 1100; //где появится танк
                    Tank1cicles[2, 7] = 703;
                    Tank1cicles[4, 7] = 500; //куда поедет танк
                    Tank1cicles[7, 7] = 300; //жизни


                    missionswitch = 1;


                }
                tank1move();


                // Условие победы
                int n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;

                }

                if (n == 0 || GetKeyDown(Keyboard.Key.L) == true)
                {
                    checkpoints[7] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0;
                    resultsmenuswitch = 1; gameplaying = 0;

                }


            }
        }

        static void Mission2() // 2. МИССИИ 
        {



        }

        static void Mission3() // 3. Волны врагов
        {
            if (basedurability < 0) for (int i = 0; i < checkpoints.GetLength(0); i++) checkpoints[i] = 0;

            //checkpoints[0] = 3;
            //checkpoints[1] = 3;
            //checkpoints[2] = 3;
            //checkpoints[3] = 3;
            //checkpoints[4] = 3;
            //checkpoints[5] = 3;
            //checkpoints[6] = 3;
            //checkpoints[7] = 3;

            int n = 0;
            int m = 0;

            for (int i = 0; i < checkpoints.GetLength(0); i++)
            {
                if (checkpoints[i] == 2) break;
                if (checkpoints[i] == 1)
                {
                    if (checkdelay < 0)
                    {
                        checkpoints[i] = 2;
                    }

                    break;
                }

            }
            checkdelay = checkdelay - 1;

            // Волны противника
            // 1.  2 слабых танка Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
            if (checkpoints[0] == 2)
            {
                if (missionswitch == 0)
                {
                    tank1reward = 5000;
                    volnadelay = 4000;
                    nrrocketsMaxquantity = 8;

                    Tank1cicles[3, 1] = 1;
                    Tank1cicles[1, 1] = 1100; //х
                    Tank1cicles[2, 1] = 698; //у
                    Tank1cicles[4, 1] = -200; //куда едет
                    Tank1cicles[6, 1] = 0.5f; // скорость
                    Tank1cicles[7, 1] = 100;


                    Tank1cicles[3, 2] = 1;
                    Tank1cicles[1, 2] = 1200; //х
                    Tank1cicles[2, 2] = 698; //у
                    Tank1cicles[4, 2] = -200; //куда едет
                    Tank1cicles[6, 2] = 0.5f; // скорость
                    Tank1cicles[7, 2] = 100;
                    missionswitch = 1;
                }

                volnadelay = volnadelay - 1;
                SetFillColor(Color.White);
                DrawText(25, 150, "Волна: " + 1, 16);
                DrawText(25, 170, "След волна через: " + volnadelay, 16);

                tank1move();

                n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;
                }
                if (n == 0)
                    DrawText(25, 190, "Следующий! Жми \"G\" ", 16);

                // Условие победы
                if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0)) { checkpoints[0] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

            }

            //2. 3 слабых танка Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
            if (checkpoints[1] == 2)
            {
                if (missionswitch == 0)
                {
                    tank1reward = 6000;
                    volnadelay = 5000;
                    nrrocketsMaxquantity = 16;

                    Tank1cicles[3, 3] = 1;
                    Tank1cicles[1, 3] = 1100; //х
                    Tank1cicles[2, 3] = 698; //у
                    Tank1cicles[4, 3] = -200; //куда едет
                    Tank1cicles[6, 3] = 0.5f; // скорость
                    Tank1cicles[7, 3] = 100;


                    Tank1cicles[3, 4] = 1;
                    Tank1cicles[1, 4] = 1200; //х
                    Tank1cicles[2, 4] = 700; //у
                    Tank1cicles[4, 4] = -200; //куда едет
                    Tank1cicles[6, 4] = 0.5f; // скорость
                    Tank1cicles[7, 4] = 100;

                    Tank1cicles[3, 5] = 1;
                    Tank1cicles[1, 5] = 1200; //х
                    Tank1cicles[2, 5] = 703; //у
                    Tank1cicles[4, 5] = -200; //куда едет
                    Tank1cicles[6, 5] = 1f; // скорость
                    Tank1cicles[7, 5] = 80; //жизней
                    missionswitch = 1;
                }

                volnadelay = volnadelay - 1;
                SetFillColor(Color.White);
                DrawText(25, 150, "Волна: " + 2, 16);

                tank1move();

                n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;
                }
                if (n == 0)
                    DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
                // Условие победы
                if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0)) { checkpoints[1] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

            }

            // 3. 5 слабых танка Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
            if (checkpoints[2] == 2)
            {
                if (missionswitch == 0)
                {
                    tank1reward = 6000;
                    volnadelay = 5000;
                    nrrocketsMaxquantity = 24;

                    Tank1cicles[3, 6] = 1;
                    Tank1cicles[1, 6] = 1100; //х
                    Tank1cicles[2, 6] = 698; //у
                    Tank1cicles[4, 6] = -200; //куда едет
                    Tank1cicles[6, 6] = 0.5f; // скорость
                    Tank1cicles[7, 6] = 110;


                    Tank1cicles[3, 7] = 1;
                    Tank1cicles[1, 7] = 1200; //х
                    Tank1cicles[2, 7] = 700; //у
                    Tank1cicles[4, 7] = -200; //куда едет
                    Tank1cicles[6, 7] = 0.5f; // скорость
                    Tank1cicles[7, 7] = 110;

                    Tank1cicles[3, 8] = 1;
                    Tank1cicles[1, 8] = 1200; //х
                    Tank1cicles[2, 8] = 703; //у
                    Tank1cicles[4, 8] = -200; //куда едет
                    Tank1cicles[6, 8] = 1f; // скорость
                    Tank1cicles[7, 8] = 80; //жизней

                    Tank1cicles[3, 9] = 1;
                    Tank1cicles[1, 9] = 1250; //х
                    Tank1cicles[2, 9] = 702; //у
                    Tank1cicles[4, 9] = -200; //куда едет
                    Tank1cicles[6, 9] = 0.3f; // скорость
                    Tank1cicles[7, 9] = 180; //жизней

                    Tank1cicles[3, 10] = 1;
                    Tank1cicles[1, 10] = 1300; //х
                    Tank1cicles[2, 10] = 695; //у
                    Tank1cicles[4, 10] = -200; //куда едет
                    Tank1cicles[6, 10] = 0.3f; // скорость
                    Tank1cicles[7, 10] = 180; //жизней


                    missionswitch = 1;
                }

                volnadelay = volnadelay - 1;
                SetFillColor(Color.White);
                DrawText(25, 150, "Волна: " + 3, 16);

                tank1move();

                n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;
                }
                if (n == 0)
                    DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
                // Условие победы
                if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0)) { checkpoints[2] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

            }

            // 4. 10 танков  (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
            if (checkpoints[3] == 2)
            {
                if (missionswitch == 0)
                {
                    tank1reward = 6000;
                    volnadelay = 7000;
                    nrrocketsMaxquantity = 64;

                    Tank1cicles[3, 16] = 1;
                    Tank1cicles[1, 16] = 1100; //х
                    Tank1cicles[2, 16] = 698; //у
                    Tank1cicles[4, 16] = -200; //куда едет
                    Tank1cicles[6, 16] = 0.5f; // скорость
                    Tank1cicles[7, 16] = 110;


                    Tank1cicles[3, 17] = 1;
                    Tank1cicles[1, 17] = 1200; //х
                    Tank1cicles[2, 17] = 700; //у
                    Tank1cicles[4, 17] = -200; //куда едет
                    Tank1cicles[6, 17] = 0.5f; // скорость
                    Tank1cicles[7, 17] = 110;

                    Tank1cicles[3, 18] = 1;
                    Tank1cicles[1, 18] = 1200; //х
                    Tank1cicles[2, 18] = 703; //у
                    Tank1cicles[4, 18] = -200; //куда едет
                    Tank1cicles[6, 18] = 1f; // скорость
                    Tank1cicles[7, 18] = 80; //жизней

                    Tank1cicles[3, 19] = 1;
                    Tank1cicles[1, 19] = 1250; //х
                    Tank1cicles[2, 19] = 702; //у
                    Tank1cicles[4, 19] = -200; //куда едет
                    Tank1cicles[6, 19] = 0.3f; // скорость
                    Tank1cicles[7, 19] = 220; //жизней

                    Tank1cicles[3, 30] = 1;
                    Tank1cicles[1, 30] = 1300; //х
                    Tank1cicles[2, 30] = 695; //у
                    Tank1cicles[4, 30] = -200; //куда едет
                    Tank1cicles[6, 30] = 0.3f; // скорость
                    Tank1cicles[7, 30] = 280; //жизней

                    Tank1cicles[3, 11] = 1;
                    Tank1cicles[1, 11] = 1100; //х
                    Tank1cicles[2, 11] = 698; //у
                    Tank1cicles[4, 11] = -200; //куда едет
                    Tank1cicles[6, 11] = 0.5f; // скорость
                    Tank1cicles[7, 11] = 120;

                    Tank1cicles[3, 12] = 1;
                    Tank1cicles[1, 12] = 1200; //х
                    Tank1cicles[2, 12] = 700; //у
                    Tank1cicles[4, 12] = -200; //куда едет
                    Tank1cicles[6, 12] = 0.5f; // скорость
                    Tank1cicles[7, 12] = 130;

                    Tank1cicles[3, 13] = 1;
                    Tank1cicles[1, 13] = 1200; //х
                    Tank1cicles[2, 13] = 703; //у
                    Tank1cicles[4, 13] = -200; //куда едет
                    Tank1cicles[6, 13] = 1.1f; // скорость
                    Tank1cicles[7, 13] = 80; //жизней

                    Tank1cicles[3, 14] = 1;
                    Tank1cicles[1, 14] = 1100; //х
                    Tank1cicles[2, 14] = 702; //у
                    Tank1cicles[4, 14] = -200; //куда едет
                    Tank1cicles[6, 14] = 1.6f; // скорость
                    Tank1cicles[7, 14] = 70; //жизней

                    Tank1cicles[3, 15] = 1;
                    Tank1cicles[1, 15] = 1100; //х
                    Tank1cicles[2, 15] = 695; //у
                    Tank1cicles[4, 15] = -200; //куда едет
                    Tank1cicles[6, 15] = 1.5f; // скорость
                    Tank1cicles[7, 15] = 90; //жизней


                    missionswitch = 1;
                }

                volnadelay = volnadelay - 1;
                SetFillColor(Color.White);
                DrawText(25, 150, "Волна: " + 4, 16);

                tank1move();

                n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;
                }
                if (n == 0)
                    DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
                // Условие победы
                if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0)) { checkpoints[3] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

            }

            // 5. 5 быстрых танков и бук (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
            if (checkpoints[4] == 2)
            {
                if (missionswitch == 0)
                {
                    tank1reward = 6000;
                    volnadelay = 8000;
                    nrrocketsMaxquantity = 64;

                    Tank1cicles[3, 46] = 1;
                    Tank1cicles[1, 46] = 1100; //х
                    Tank1cicles[2, 46] = 698; //у
                    Tank1cicles[4, 46] = -200; //куда едет
                    Tank1cicles[6, 46] = 1.5f; // скорость
                    Tank1cicles[7, 46] = 70;

                    Tank1cicles[3, 47] = 1;
                    Tank1cicles[1, 47] = 1200; //х
                    Tank1cicles[2, 47] = 700; //у
                    Tank1cicles[4, 47] = -200; //куда едет
                    Tank1cicles[6, 47] = 2f; // скорость
                    Tank1cicles[7, 47] = 50;

                    Tank1cicles[3, 48] = 1;
                    Tank1cicles[1, 48] = 1200; //х
                    Tank1cicles[2, 48] = 703; //у
                    Tank1cicles[4, 48] = -200; //куда едет
                    Tank1cicles[6, 48] = 1.4f; // скорость
                    Tank1cicles[7, 48] = 80; //жизней

                    Tank1cicles[3, 49] = 1;
                    Tank1cicles[1, 49] = 1250; //х
                    Tank1cicles[2, 49] = 702; //у
                    Tank1cicles[4, 49] = -200; //куда едет
                    Tank1cicles[6, 49] = 1.3f; // скорость
                    Tank1cicles[7, 49] = 110; //жизней

                    Tank1cicles[3, 50] = 1;
                    Tank1cicles[1, 50] = 1300; //х
                    Tank1cicles[2, 50] = 695; //у
                    Tank1cicles[4, 50] = -200; //куда едет
                    Tank1cicles[6, 50] = 1.3f; // скорость
                    Tank1cicles[7, 50] = 100; //жизней

                    Buk1cicles[3, 1] = 1; //БУК1 проявлен
                    Buk1cicles[1, 1] = 1200; //х
                    Buk1cicles[2, 1] = 691; //у
                    Buk1cicles[4, 1] = 400; //куда едет
                    Buk1cicles[6, 1] = 1.7f; //скорость
                    Buk1cicles[7, 1] = 500; //жизней
                    Buk1cicles[8, 1] = 0; //задержка перед выстрелом


                    missionswitch = 1;
                }

                volnadelay = volnadelay - 1;
                SetFillColor(Color.White);
                DrawText(25, 150, "Волна: " + 5, 16);

                tank1move();
                buk1Move();

                n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;
                }
                if (n == 0)
                    DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
                // Условие победы
                if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0)) { checkpoints[4] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

            }

            // 6. 2 бука (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
            if (checkpoints[5] == 2)
            {
                if (missionswitch == 0)
                {
                    tank1reward = 6000;
                    volnadelay = 8000;
                    nrrocketsMaxquantity = 64;



                    Buk1cicles[3, 2] = 1; //БУК1 проявлен
                    Buk1cicles[1, 2] = 1150; //x
                    Buk1cicles[2, 2] = 690; //у
                    Buk1cicles[4, 2] = 700; //куда едет
                    Buk1cicles[6, 2] = 1.7f; //скорость
                    Buk1cicles[7, 2] = 500; //жизней
                    Buk1cicles[8, 2] = 0; //задержка перед выстрелом

                    Buk1cicles[3, 3] = 1; //БУК1 проявлен
                    Buk1cicles[1, 3] = 1300; //ч
                    Buk1cicles[2, 3] = 693; //у
                    Buk1cicles[4, 3] = 400; //куда едет
                    Buk1cicles[6, 3] = 2.5f; //скорость
                    Buk1cicles[7, 3] = 500; //жизней
                    Buk1cicles[8, 3] = 0; //задержка перед выстрелом


                    missionswitch = 1;
                }

                volnadelay = volnadelay - 1;
                SetFillColor(Color.White);
                DrawText(25, 150, "Волна: " + 6, 16);

                tank1move();
                buk1Move();

                n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;
                }
                m = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) m = m + 1;
                }
                if (n == 0 && m == 0)
                    DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
                // Условие победы
                if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0 && m == 0)) { checkpoints[5] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

            }

            // 7. Самолет и 10 танков (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
            if (checkpoints[6] == 2)
            {
                if (missionswitch == 0)
                {
                    tank1reward = 6000;
                    volnadelay = 8000;
                    nrrocketsMaxquantity = 64;

                    tank1reward = 6000;
                    volnadelay = 7000;
                    nrrocketsMaxquantity = 64;
                    a10rocketquantity = 2;

                    Tank1cicles[3, 20] = 1;
                    Tank1cicles[1, 20] = 1100; //х
                    Tank1cicles[2, 20] = 698; //у
                    Tank1cicles[4, 20] = -200; //куда едет
                    Tank1cicles[6, 20] = 0.5f; // скорость
                    Tank1cicles[7, 20] = 110;


                    Tank1cicles[3, 21] = 1;
                    Tank1cicles[1, 21] = 1200; //х
                    Tank1cicles[2, 21] = 700; //у
                    Tank1cicles[4, 21] = -200; //куда едет
                    Tank1cicles[6, 21] = 0.5f; // скорость
                    Tank1cicles[7, 21] = 110;

                    Tank1cicles[3, 22] = 1;
                    Tank1cicles[1, 22] = 1200; //х
                    Tank1cicles[2, 22] = 703; //у
                    Tank1cicles[4, 22] = -200; //куда едет
                    Tank1cicles[6, 22] = 1f; // скорость
                    Tank1cicles[7, 22] = 80; //жизней

                    Tank1cicles[3, 23] = 1;
                    Tank1cicles[1, 23] = 1250; //х
                    Tank1cicles[2, 23] = 702; //у
                    Tank1cicles[4, 23] = -200; //куда едет
                    Tank1cicles[6, 23] = 0.3f; // скорость
                    Tank1cicles[7, 23] = 220; //жизней

                    Tank1cicles[3, 24] = 1;
                    Tank1cicles[1, 24] = 1300; //х
                    Tank1cicles[2, 24] = 695; //у
                    Tank1cicles[4, 24] = -200; //куда едет
                    Tank1cicles[6, 24] = 0.3f; // скорость
                    Tank1cicles[7, 24] = 280; //жизней

                    Tank1cicles[3, 25] = 1;
                    Tank1cicles[1, 25] = 1100; //х
                    Tank1cicles[2, 25] = 698; //у
                    Tank1cicles[4, 25] = -200; //куда едет
                    Tank1cicles[6, 25] = 0.5f; // скорость
                    Tank1cicles[7, 25] = 120;

                    Tank1cicles[3, 26] = 1;
                    Tank1cicles[1, 26] = 1200; //х
                    Tank1cicles[2, 26] = 700; //у
                    Tank1cicles[4, 26] = -200; //куда едет
                    Tank1cicles[6, 26] = 0.5f; // скорость
                    Tank1cicles[7, 26] = 130;

                    Tank1cicles[3, 27] = 1;
                    Tank1cicles[1, 27] = 1200; //х
                    Tank1cicles[2, 27] = 703; //у
                    Tank1cicles[4, 27] = -200; //куда едет
                    Tank1cicles[6, 27] = 1.1f; // скорость
                    Tank1cicles[7, 27] = 80; //жизней

                    Tank1cicles[3, 28] = 1;
                    Tank1cicles[1, 28] = 1100; //х
                    Tank1cicles[2, 28] = 702; //у
                    Tank1cicles[4, 28] = -200; //куда едет
                    Tank1cicles[6, 28] = 1.6f; // скорость
                    Tank1cicles[7, 28] = 70; //жизней

                    Tank1cicles[3, 29] = 1;
                    Tank1cicles[1, 29] = 1100; //х
                    Tank1cicles[2, 29] = 695; //у
                    Tank1cicles[4, 29] = -200; //куда едет
                    Tank1cicles[6, 29] = 1.5f; // скорость
                    Tank1cicles[7, 29] = 90; //жизней



                    missionswitch = 1;
                }

                volnadelay = volnadelay - 1;
                SetFillColor(Color.White);
                DrawText(25, 150, "Волна: " + 7, 16);

                tank1move();
                buk1Move();

                //Противник А10

                if (a10x < -400)
                {
                    for (int i = 0; i < a10rocketquantity; i++)
                    {
                        R10[4, i] = 1;

                    }
                    a10x = 1500;
                    a10delay = 0; // задержка между ракетами
                    a10y = rnd.Next(30, 250);
                }
                if (a10x < 1100) // А10 сброс ракет 
                {
                    a10delay = a10delay - 1;
                    for (int i = 0; i < R10.GetLongLength(1); i++) // Ракета А10(1 = x ракеты, 2 = y ракеты, 3 = высота полета ракеты ракеты, 4 = ракета проявлена)
                    {
                        if (R10[4, i] == 1 && a10delay <= 0)
                        {
                            R10[1, i] = a10x;
                            R10[2, i] = a10y;
                            R10[3, i] = rnd.Next(5, 550);
                            R10[4, i] = 2;
                            a10delay = rnd.Next(10, 60); // задержа до следующего пуска
                            break;
                        }
                    }

                }
                a10move();

                n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;
                }
                m = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) m = m + 1;
                }
                if (n == 0 && m == 0)
                    DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
                // Условие победы
                if (volnadelay <= 0 || (GetKeyDown(Keyboard.Key.G) && n == 0 && m == 0)) { checkpoints[6] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

            }

            // 8. Самолет и 10 танков и 2 зенитки (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
            if (checkpoints[7] == 2)
            {
                if (missionswitch == 0)
                {
                    tank1reward = 6000;
                    volnadelay = 8000;
                    nrrocketsMaxquantity = 64;

                    tank1reward = 6000;
                    volnadelay = 7000;
                    nrrocketsMaxquantity = 64;
                    a10rocketquantity = 5;

                    Tank1cicles[3, 20] = 1;
                    Tank1cicles[1, 20] = 1100; //х
                    Tank1cicles[2, 20] = 698; //у
                    Tank1cicles[4, 20] = -200; //куда едет
                    Tank1cicles[6, 20] = 0.5f; // скорость
                    Tank1cicles[7, 20] = 110;


                    Tank1cicles[3, 21] = 1;
                    Tank1cicles[1, 21] = 1200; //х
                    Tank1cicles[2, 21] = 700; //у
                    Tank1cicles[4, 21] = -200; //куда едет
                    Tank1cicles[6, 21] = 0.5f; // скорость
                    Tank1cicles[7, 21] = 110;

                    Tank1cicles[3, 22] = 1;
                    Tank1cicles[1, 22] = 1200; //х
                    Tank1cicles[2, 22] = 703; //у
                    Tank1cicles[4, 22] = -200; //куда едет
                    Tank1cicles[6, 22] = 1f; // скорость
                    Tank1cicles[7, 22] = 80; //жизней

                    Tank1cicles[3, 23] = 1;
                    Tank1cicles[1, 23] = 1250; //х
                    Tank1cicles[2, 23] = 702; //у
                    Tank1cicles[4, 23] = -200; //куда едет
                    Tank1cicles[6, 23] = 0.3f; // скорость
                    Tank1cicles[7, 23] = 220; //жизней

                    Tank1cicles[3, 24] = 1;
                    Tank1cicles[1, 24] = 1300; //х
                    Tank1cicles[2, 24] = 695; //у
                    Tank1cicles[4, 24] = -200; //куда едет
                    Tank1cicles[6, 24] = 0.3f; // скорость
                    Tank1cicles[7, 24] = 280; //жизней

                    Tank1cicles[3, 25] = 1;
                    Tank1cicles[1, 25] = 1100; //х
                    Tank1cicles[2, 25] = 698; //у
                    Tank1cicles[4, 25] = -200; //куда едет
                    Tank1cicles[6, 25] = 0.5f; // скорость
                    Tank1cicles[7, 25] = 120;

                    Tank1cicles[3, 26] = 1;
                    Tank1cicles[1, 26] = 1200; //х
                    Tank1cicles[2, 26] = 700; //у
                    Tank1cicles[4, 26] = -200; //куда едет
                    Tank1cicles[6, 26] = 0.5f; // скорость
                    Tank1cicles[7, 26] = 130;

                    Tank1cicles[3, 27] = 1;
                    Tank1cicles[1, 27] = 1200; //х
                    Tank1cicles[2, 27] = 703; //у
                    Tank1cicles[4, 27] = -200; //куда едет
                    Tank1cicles[6, 27] = 1.1f; // скорость
                    Tank1cicles[7, 27] = 80; //жизней

                    Tank1cicles[3, 28] = 1;
                    Tank1cicles[1, 28] = 1100; //х
                    Tank1cicles[2, 28] = 702; //у
                    Tank1cicles[4, 28] = -200; //куда едет
                    Tank1cicles[6, 28] = 1.6f; // скорость
                    Tank1cicles[7, 28] = 70; //жизней

                    Tank1cicles[3, 29] = 1;
                    Tank1cicles[1, 29] = 1100; //х
                    Tank1cicles[2, 29] = 695; //у
                    Tank1cicles[4, 29] = -200; //куда едет
                    Tank1cicles[6, 29] = 1.5f; // скорость
                    Tank1cicles[7, 29] = 90; //жизней

                    Buk1cicles[3, 4] = 1; //БУК1 проявлен
                    Buk1cicles[1, 4] = 1300; //ч
                    Buk1cicles[2, 4] = 693; //у
                    Buk1cicles[4, 4] = 400; //куда едет
                    Buk1cicles[6, 4] = 3f; //скорость
                    Buk1cicles[7, 4] = 500; //жизней
                    Buk1cicles[8, 4] = 0; //задержка перед выстрелом


                    missionswitch = 1;
                }

                volnadelay = volnadelay - 1;
                SetFillColor(Color.White);
                DrawText(25, 150, "Волна: " + 8, 16);

                tank1move();
                buk1Move();

                //Противник А10

                if (a10x < -400)
                {
                    for (int i = 0; i < a10rocketquantity; i++)
                    {
                        R10[4, i] = 1;

                    }
                    a10x = 1500;
                    a10delay = 0; // задержка между ракетами
                    a10y = rnd.Next(30, 250);
                }
                if (a10x < 1100) // А10 сброс ракет 
                {
                    a10delay = a10delay - 1;
                    for (int i = 0; i < R10.GetLongLength(1); i++) // Ракета А10(1 = x ракеты, 2 = y ракеты, 3 = высота полета ракеты ракеты, 4 = ракета проявлена)
                    {
                        if (R10[4, i] == 1 && a10delay <= 0)
                        {
                            R10[1, i] = a10x;
                            R10[2, i] = a10y;
                            R10[3, i] = rnd.Next(5, 550);
                            R10[4, i] = 2;
                            a10delay = rnd.Next(10, 60); // задержа до следующего пуска
                            break;
                        }
                    }

                }
                a10move();

                n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;
                }
                m = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) m = m + 1;
                }
                if (n == 0 && m == 0)
                    DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
                // Условие победы
                if (volnadelay <= 0 || (n == 0 && m == 0)) { checkpoints[7] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

            }

            // 9. Победа! (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость танка, 7=жизни)
            if (checkpoints[8] == 2)
            {
                if (missionswitch == 0)
                {
                    checkpoints2[1] = 0;
                    winpobeda = 1;
                    missionswitch = 1;
                }

                volnadelay = volnadelay - 1;
                SetFillColor(Color.White);
                DrawText(25, 150, "Победа!", 16);

                tank1move();
                buk1Move();



                n = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) n = n + 1;
                }
                m = 0;
                for (int i = 0; i < Tank1cicles.GetLength(1); i++)
                {
                    if (Tank1cicles[3, i] == 1) m = m + 1;
                }
                if (n == 0 && m == 0)
                    DrawText(25, 190, "Следующий! Жми \"G\" ", 16);
                // Условие победы
                if (GetKeyDown(Keyboard.Key.G) && n == 0 && m == 0) { checkpoints[8] = 3; checkdelay = 200; PlaySound(checkpointsound, volume); missionswitch = 0; }

            }
            DrawText(25, 170, "След волна через: " + volnadelay, 16);
            DrawText(25, 215, "Теперь можете загрузить " + nrrocketsMaxquantity + " ракет!", 16);
            DrawText(25, 240, "Оборона базы выдержит: " + basedurability + " танков!", 16);


            if (checkpoints2[1] == 0)
            {
                SetFillColor(Color.Green);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 265, "Вы победили всех врагов!", 32);
                DrawText(330, 300, "Нажми Escape, для выхода. ", 32);


            }


            if (basedurability < 0 || helidestroy == 1)
            {

                gitadelay = 200;
                gitaswitch = 1;
                G = rnd.Next(1, 6);
                SetFillColor(Color.Green);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 265, "Танки захватили Вашу базу.", 32);
                DrawText(330, 300, "Нажми Escape, для выхода. ", 32);

            }

        }



        

            //Левел1
            if (levelchoise == 1 && mainmenuSwitch == 0 && gameplaying == 1) // Левел 1 Тренировка НАЧАЛО
            {
                if (newgame == 1)
                {
                    //Начальные настройки верталета
                    playerx = 120;
                    playery = 700;
                    engineswitch = 0;
                    enginespeed = 0;
                    helistop = 1;
                    helifuel = 900;
                    helifuelmax = 900;
                    helilife = 300;
                    speedxmax = 2.5f;
                    manageability = 10; //управляемость
                    shagAngle = 1.5f; // угол атаки
                    nrrocketsMaxquantity = 8; //максимально ракет
                    padstoreswitch = 0;
                    helidestroy = 0;
                    donatswitch = 0;
                    money = 0;
                    missionswitch = 0;
                    podskazkaswitch = 0;
                    otkazcicle[1] = manageability;
                    otkazcicle[2] = shagAngle;
                    otkazcicle[3] = 0;
                    winpobeda = 0;
                    enginespeedlimit = 35000;


                    flighttime = 0; //время нахождения в воздухе


                    //Поломки
                    helienginelife = 100;
                    otkazhydrosis = 0; // Гидросистема
                    otkazmasterwarning = 0; // Матерсвитч
                    otkazols = 0; // Оптико локационная станция
                    otkazraketasprava = 0; //ракета справа
                    otkazraketasleva = 0; //Ракета слева
                    otkazpojardvig = 0; // Пожар двигателя
                    otkazsbrosoboroti = 0; //Пожар двигателя

                    peregruzkamotora = 0; //Пожар двигателя начнется
                    ritarandom = 1; //рандом для прицела

                    //результаты
                    landingquantity = 0; //количество посадок
                    NRrocketslaunched = 0; //выпущено NR ракет количество
                    targetbingos = 0; //попаданий по цели
                    buk1destroyes = 0; //уничтожено буков1
                    tank1destroyes = 0; //уничтожено танков1
                    fuelusedup = 0; //израсходовано топлива
                    repairings = 0; //Отремонтирован вертолет
                    getdamages = 0; //Получено повреждений
                    //Начальное вооружение 0
                    //for (int i = 0; i < R.GetLongLength(1); i++) R[5, i] = 1; // 5. Моде 2 NR Ракеты готовы к пуску
                    //Начальные задания
                    for (int i = 0; i<checkpoints.GetLength(0); i++) checkpoints[i] = 1;
                    for (int i = 0; i<checkpoints2.GetLength(0); i++) checkpoints2[i] = 1;
                    for (int i = 0; i<Buk1cicles.GetLength(1); i++) Buk1cicles[3, i] = 0;
                    for (int i = 0; i<Tank1cicles.GetLength(1); i++) Tank1cicles[3, i] = 0;
                    for (int i = 0; i<R.GetLength(1); i++) R[5, i] = 0;
                    for (int i = 0; i<R10.GetLength(1); i++) R10[4, i] = 0;
                    newgame = 0;

                    //запасы склада
                    fuelinbag = 0; //топливо на складе
                    nrrocketsinbag = 0; //ракеты на складе
                    partsinbag = 0; //Запчасти в корзине


                }


                while (gameplaying == 1)
                {
                    playlistmusic = Level1Music;

                    magnitola();

    DispatchEvents();
    ClearWindow();
    //mainmenuSwitch = 1;
    DrawSprite(backgroundLevel1, 0, 0);

    PlayerMove();

    PlayerDraw();


    //Задания

    Mission1();
    SearchConflict();

                    //Перезарядка
                    if (GetKeyDown(Keyboard.Key.R) == true)
                    {
                        int s = padstoreswitch;
                        if (s == 1)
                        {
                            padstoreswitch = 0;
                            gitaswitch = 0;


                        }
if (s == 0 && padswitch == 1)
{
    padstoreswitch = 1;
    gitadelay = 2000;
    gitaswitch = 1;
    G = rnd.Next(1, 6);
    podskazkaswitch = 1;
}

                    }
                    gitadelay = gitadelay - 1;
padstoredraw();

if (gitaswitch == 1 && gitadelay < 0)
{


    if (G == 1)
    {

        if (podskazkaswitch == 1)

        {
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            SetFillColor(Color.Red);
            DrawText(330, 265, "Знай же: то, чем пронизано материальное тело, неразрушимо.", 14);
            DrawText(330, 285, "Никто не может уничтожить бессмертную душу. ", 14);
            DrawText(330, 340, "(\"Y\" чтобы скрыть наставление.)", 14);

        }

    }
    if (G == 2)
    {

        if (podskazkaswitch == 1)

        {
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            SetFillColor(Color.Red);
            DrawText(330, 260, "Материальное тело вечного, неуничтожимого и", 16);
            DrawText(330, 290, "неизмеримого живого существа обречено на смерть. ", 16);
            DrawText(330, 320, "Поэтому сражайся, о потомок Бхараты! ", 16);
            DrawText(330, 370, "(\"Y\" чтобы скрыть наставление.)", 14);

        }

    }
    if (G == 3)
    {

        if (podskazkaswitch == 1)

        {
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            SetFillColor(Color.Red);
            DrawText(330, 240, "Душа не рождается и не умирает.", 16);
            DrawText(330, 270, "Она никогда не возникала, не возникает и не возникнет. ", 16);
            DrawText(330, 300, "Она нерожденная, вечная, всегда существующая и изначальная. ", 16);
            DrawText(330, 330, "Она не гибнет, когда погибает тело. ", 16);
            DrawText(330, 370, "(\"Y\" чтобы скрыть наставление.)", 14);

        }

    }
    if (G == 4)
    {

        if (podskazkaswitch == 1)

        {
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            SetFillColor(Color.Red);
            DrawText(330, 245, "Как человек, снимая старые одежды, надевает новые,", 14);
            DrawText(330, 270, "так и душа входит в новые материальные тела, ", 14);
            DrawText(330, 305, "оставляя старые и бесполезные. ", 14);

            DrawText(330, 335, "(\"Y\" чтобы скрыть наставление.)", 14);

        }

    }
    if (G == 5)
    {

        if (podskazkaswitch == 1)

        {
            DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            SetFillColor(Color.Red);
            DrawText(330, 245, "Душу нельзя рассечь никаким оружием,", 16);
            DrawText(330, 275, "сжечь огнем, намочить водой ", 16);
            DrawText(330, 310, "или иссушить ветром.", 16);

            DrawText(330, 335, "(\"Y\" чтобы скрыть наставление.)", 14);

        }

    }
    //string g1 = "Знай же: то, чем пронизано материальное тело, неразрушимо. Никто не может уничтожить бессмертную душу.";
    //string g2 = "Материальное тело вечного, неуничтожимого и неизмеримого живого существа обречено на смерть. Поэтому сражайся, о потомок Бхараты!";
    // string g3 = "Душа не рождается и не умирает. Она никогда не возникала, не возникает и не возникнет. Она нерожденная, вечная, всегда существующая и изначальная. Она не гибнет, когда погибает тело.";
    // string g4 = "Как человек, снимая старые одежды, надевает новые, так и душа входит в новые материальные тела, оставляя старые и бесполезные.";
    // string g4 = "Душу нельзя рассечь никаким оружием, сжечь огнем, намочить водой или иссушить ветром.";


}


rita();

if (GetKeyDown(Keyboard.Key.Y) == true)
{
    int u = podskazkaswitch;
    if (u == 0) podskazkaswitch = 1;
    if (u == 1) podskazkaswitch = 0;

}




tank1Draw();

explosion();
padstoredraw();
//Оружие и прицеливание


if (GetKeyDown(Keyboard.Key.Num1) == true) // Моде 1 ВЫБОР
{
    gunmode = 1; // пулемет
    PlaySound(click);
}

if (GetKeyDown(Keyboard.Key.Num2) == true) // Моде 2 ВЫБОР
{
    gunmode = 2; // ракета
    PlaySound(click);
    int PRNR = 0; // Пуск Разрешен
    for (int i = 0; i < R.GetLongLength(1); i++)
    {
        if (R[5, i] == 1)
        {
            PlaySound(puskrazreshen);
            PRNR = 1;
            break;

        }

    }
    if (PRNR == 0) PlaySound(proverpokazaniya);

}// Моде 2 ВЫБОР

if (GetKeyDown(Keyboard.Key.Num3) == true)
{
    gunmode = 3; // самонаводящаяся ракета 
    PlaySound(click);

}

if (GetMouseButtonDown(Mouse.Button.Left) == true) // ОГОНЬ!
{
    if (gunmode == 1)
    {



    }
    if (gunmode == 2) //(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена)
    {
        NRrocketchecklaunch = 0;
        for (int i = 0; i < R.GetLongLength(1); i++)
        {

            if (R[5, i] == 0 || R[5, i] == 2) continue;
            if (R[5, i] == 1)
            {
                R[1, i] = playerx;
                R[2, i] = playery;
                R[3, i] = angle;
                R[4, i] = nrfuel;
                R[5, i] = 2; // ракета отрисовывается
                NRrocketchecklaunch = 1;
                PlaySound(rocketsound);
                break;
            }

        }
        if (NRrocketchecklaunch == 0)
        {
            PlaySound(click);
            PlaySound(proverpokazaniya);
        }
    }//(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена)
    if (gunmode == 3)
    {

        PlaySound(rocketsound);

    }

}
MoveNRrocket();
SearchConflict();

//Выход в меню
if (GetKeyDown(Keyboard.Key.Escape) == true)
{
    mainmenuSwitch = 2;
    break;


}


PanelInstrument();

if (donatswitch == 1)
{
    SetFillColor(Color.Blue);
    DrawSprite(uh61, 840, 300, 1215, 575, 221, 235);
    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
    DrawText(330, 240, "Не хватает денег,", 30);
    DrawText(330, 268, "я дарю Тебе 20000 money. ", 30);
    DrawText(330, 296, "Cкоро разбогатеешь!;) Жми \"K\"!", 30);
    DrawText(330, 335, "Донат и обраная связь  ", 18);
    DrawText(330, 350, "по телефону 89500808627  ", 18);
    DrawText(330, 365, "(сбер: Алексей тимофеевич Б.)", 18);

    if (GetKeyDown(Keyboard.Key.K) == true)
    {
        money = money + 20000;
        donatswitch = 0;
    }
}

DisplayWindow();
Delay(5);




                }

            } // Левел 1 Тренировка



            // Левел 2 Миссии не прописана
            if (levelchoise == 2 && gameplaying == 1) // Левел 2 Миссии

{
    DispatchEvents();
    PlaySound(grass1);
    mainmenuSwitch = 1;
    gameplaying = 0;
    //Ландшафт

    //Противники

    //Верталет игрока
    // 2. Вооружение - взведение ракет (1=x ракеты, 2=y ракеты, 3=angle ракеты, 4=fuel ракеты, 5=ракета проявлена)




}// Левел 2 Миссии



// Левел 3 Свободный полет
if (levelchoise == 3 && mainmenuSwitch == 0 && gameplaying == 1) // Левел 3 Свободный полет
{

    if (newgame == 1)
    {
        //Начальные настройки верталета
        playerx = 120;
        playery = 700;
        engineswitch = 0;
        enginespeed = 0;
        helistop = 1;
        helifuel = 1000;
        helifuelmax = 1300;
        helilife = 300;
        helilifemax = 300;
        speedxmax = 3f;
        manageability = 9; //управляемость
        shagAngle = 1.7f; // угол атаки
        nrrocketsMaxquantity = 8; //максимально ракет
        padstoreswitch = 0;
        helidestroy = 0;
        money = 0;
        volnadelay = 0;
        basedurability = 12;
        missionswitch = 0;
        podskazkaswitch = 0;
        NRrocketslaunched = 0;
        shagengine = 75; //шаг увелич мощности двигателя
        enginespeedlimit = 35000; //лимит оборотов двигателя
        fuelrashod = 1.7f; // расход топлива
        otkazcicle[1] = manageability;
        otkazcicle[2] = shagAngle;
        otkazcicle[3] = 0;
        winpobeda = 0;

        //результаты
        //Поломки
        helienginelife = 100;
        otkazhydrosis = 0; // Гидросистема
        otkazmasterwarning = 0; // Матерсвитч
        otkazols = 0; // Оптико локационная станция
        otkazraketasprava = 0; //ракета справа
        otkazraketasleva = 0; //Ракета слева
        otkazpojardvig = 0; // Пожар двигателя
        otkazsbrosoboroti = 0; //Пожар двигателя

        peregruzkamotora = 0; //Пожар двигателя начнется
        ritarandom = 1; //рандом для прицела


        flighttime = 0; //время нахождения в воздухе

        landingquantity = 0; //количество посадок
        NRrocketslaunched = 0; //выпущено NR ракет количество
        targetbingos = 0; //попаданий по цели
        buk1destroyes = 0; //уничтожено буков1
        tank1destroyes = 0; //уничтожено танков1
        fuelusedup = 0; //израсходовано топлива
        repairings = 0; //Отремонтирован вертолет
        getdamages = 0; //Получено повреждений


        //Начальное вооружение 8
        for (int i = 0; i < nrrocketsMaxquantity; i++) R[5, i] = 1; // 5. Моде 2 NR Ракеты готовы к пуску
                                                                    //Начальные задания
        for (int i = 0; i < checkpoints.GetLength(0); i++) checkpoints[i] = 1;
        for (int i = 0; i < checkpoints2.GetLength(0); i++) checkpoints2[i] = 1;


        for (int i = 0; i < Buk1cicles.GetLength(1); i++) { Buk1cicles[3, i] = 0; Buk1cicles[1, i] = 1200; }
        for (int i = 0; i < Tank1cicles.GetLength(1); i++) { Tank1cicles[3, i] = 0; Tank1cicles[1, i] = 1200; }
        for (int i = 0; i < R.GetLength(1); i++) R[5, i] = 0;
        for (int i = 0; i < R10.GetLength(1); i++) R10[4, i] = 0;
        newgame = 0;

        //запасы склада
        fuelinbag = 2000; //топливо на складе
        nrrocketsinbag = 20; //ракеты на складе
        partsinbag = 500; //Запчасти в корзине


    }



    while (true)
    {

        DispatchEvents();
        //Расчеты 

        //Очистка буфера

        ClearWindow();
        DrawSprite(backgroundLevel3, 0, 0);

        //Музыка
        magnitola();

        PlayerMove();
        PlayerDraw();


        //Оружие и прицеливание


        if (GetKeyDown(Keyboard.Key.Num1) == true) // Моде 1 ВЫБОР
        {
            gunmode = 1; // пулемет
            PlaySound(click);
        }

        if (GetKeyDown(Keyboard.Key.Num2) == true) // Моде 2 ВЫБОР
        {
            gunmode = 2; // ракета
            PlaySound(click);
            int PRNR = 0; // Пуск Разрешен
            for (int i = 0; i < R.GetLongLength(1); i++)
            {
                if (R[5, i] == 1)
                {
                    PlaySound(puskrazreshen);
                    PRNR = 1;
                    break;

                }

            }
            if (PRNR == 0) PlaySound(proverpokazaniya);

        }// Моде 2 ВЫБОР

        if (GetKeyDown(Keyboard.Key.Num3) == true)
        {
            gunmode = 3; // самонаводящаяся ракета 
            PlaySound(click);

        }

        // Выстрел
        if (GetMouseButtonDown(Mouse.Button.Left) == true) // ОГОНЬ!
        {
            if (gunmode == 1)
            {



            }
            if (gunmode == 2) //(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена)
            {
                NRrocketchecklaunch = 0;
                for (int i = 0; i < R.GetLongLength(1); i++)
                {

                    if (R[5, i] == 0 || R[5, i] == 2) continue;
                    if (R[5, i] == 1)
                    {
                        R[1, i] = playerx;
                        R[2, i] = playery;
                        R[3, i] = angle;
                        R[4, i] = nrfuel;
                        R[5, i] = 2; // ракета отрисовывается
                        NRrocketchecklaunch = 1;
                        PlaySound(rocketsound);
                        NRrocketslaunched = NRrocketslaunched + 1;
                        break;
                    }

                }
                if (NRrocketchecklaunch == 0)
                {
                    PlaySound(click);
                    PlaySound(proverpokazaniya);
                }
            }//(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена)
            if (gunmode == 3)
            {

                PlaySound(rocketsound);

            }

        }

        MoveNRrocket();

        Mission3();
        tank1Draw();
        buk1Draw();
        pvomoveANDdraw();
        explosion();

        //Проверка соприкосновений
        SearchConflict();




        //Перезарядка
        if (GetKeyDown(Keyboard.Key.R) == true)
        {
            int s = padstoreswitch;
            if (s == 1)
            {
                padstoreswitch = 0;
                gitaswitch = 0;

            }
            if (s == 0 && padswitch == 1)
            {
                padstoreswitch = 1;
                gitadelay = 1500;
                gitaswitch = 1;
                G = rnd.Next(1, 6);
                podskazkaswitch = 1;
            }

        }
        gitadelay = gitadelay - 1;
        padstoredraw();

        if (gitaswitch == 1 && gitadelay < 0)
        {


            if (G == 1)
            {

                if (podskazkaswitch == 1)

                {
                    DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    SetFillColor(Color.Red);
                    DrawText(330, 265, "Знай же: то, чем пронизано материальное тело, неразрушимо.", 16);
                    DrawText(330, 290, "Никто не может уничтожить бессмертную душу. ", 16);
                    DrawText(330, 330, "(\"Y\" чтобы скрыть)", 16);

                }

            }
            if (G == 2)
            {

                if (podskazkaswitch == 1)

                {
                    DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    SetFillColor(Color.Red);
                    DrawText(330, 260, "Материальное тело вечного, неуничтожимого и", 16);
                    DrawText(330, 290, "неизмеримого живого существа обречено на смерть. ", 16);
                    DrawText(330, 320, "Поэтому сражайся, о потомок Бхараты! ", 16);
                    DrawText(330, 360, "(\"Y\" чтобы скрыть)", 14);

                }

            }
            if (G == 3)
            {

                if (podskazkaswitch == 1)

                {
                    DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    SetFillColor(Color.Red);
                    DrawText(330, 240, "Душа не рождается и не умирает.", 16);
                    DrawText(330, 270, "Она никогда не возникала, не возникает и не возникнет. ", 16);
                    DrawText(330, 300, "Она нерожденная, вечная, всегда существующая и изначальная. ", 16);
                    DrawText(330, 330, "Она не гибнет, когда погибает тело. ", 16);
                    DrawText(330, 370, "(\"Y\" чтобы скрыть)", 14);

                }

            }
            if (G == 4)
            {

                if (podskazkaswitch == 1)

                {
                    DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    SetFillColor(Color.Red);
                    DrawText(330, 245, "Как человек, снимая старые одежды, надевает новые,", 14);
                    DrawText(330, 270, "так и душа входит в новые материальные тела, ", 14);
                    DrawText(330, 295, "оставляя старые и бесполезные. ", 14);

                    DrawText(330, 335, "(\"Y\" чтобы скрыть)", 12);

                }

            }
            if (G == 5)
            {

                if (podskazkaswitch == 1)

                {
                    DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    SetFillColor(Color.Red);
                    DrawText(330, 245, "Душу нельзя рассечь никаким оружием,", 16);
                    DrawText(330, 275, "сжечь огнем, намочить водой ", 16);
                    DrawText(330, 305, "или иссушить ветром.", 16);

                    DrawText(330, 335, "(\"Y\" чтобы скрыть)", 14);

                }

            }
            //string g1 = "Знай же: то, чем пронизано материальное тело, неразрушимо. Никто не может уничтожить бессмертную душу.";
            //string g2 = "Материальное тело вечного, неуничтожимого и неизмеримого живого существа обречено на смерть. Поэтому сражайся, о потомок Бхараты!";
            // string g3 = "Душа не рождается и не умирает. Она никогда не возникала, не возникает и не возникнет. Она нерожденная, вечная, всегда существующая и изначальная. Она не гибнет, когда погибает тело.";
            // string g4 = "Как человек, снимая старые одежды, надевает новые, так и душа входит в новые материальные тела, оставляя старые и бесполезные.";
            // string g4 = "Душу нельзя рассечь никаким оружием, сжечь огнем, намочить водой или иссушить ветром.";


        }


        rita(); //звуковые предупреждения

        if (GetKeyDown(Keyboard.Key.Y) == true)
        {
            int u = podskazkaswitch;
            if (u == 0) podskazkaswitch = 1;
            if (u == 1) podskazkaswitch = 0;

        }


        //Панель приборов
        PanelInstrument();

        if (GetKeyDown(Keyboard.Key.Escape) == true)
        {
            mainmenuSwitch = 2;
            break;
        }

        DisplayWindow();
        // 4. Ожидание
        Delay(1);
    }
} // Левел 3 Свободный полет


*/
    }
}
