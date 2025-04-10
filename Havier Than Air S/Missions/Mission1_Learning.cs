using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    internal class Mission1_Learning
    {

        // Бэкграунд 
        Texture backgroundLevel1 = new Texture("BackGroundLevel1.png");
        Sprite backGroundSprite = new Sprite();


        public void Start()
        {
            backGroundSprite.Texture = backgroundLevel1;
        }

        public void UpdateMission_1()
        {

            Program.window.Draw(backGroundSprite);


            // Место старта верта


            // Описать верт

            // Этапы сценария


            // Положение объектов

            // Проверка столкновений объектов + отработка событий + результаты

            // Отрисовка объектов

        }

        /// <summary>
        /// /*
        /// </summary>
        /// 
        /*
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


        */
    }
}
