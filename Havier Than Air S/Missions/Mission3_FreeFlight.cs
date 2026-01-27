using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Missions
{
    internal class Mission3_FreeFlight : MissionBase
    {

        Texture background = new Texture("Images\\BackGroundLevel3_2.png");
        Texture trace = new Texture("Images\\Trace_03.png");
        Sprite backgroundSprite;
        Sprite traceSprite;

        Clock clock;
        Random rand;

        //Вертал
        Hely m_Hely;

        // Коллайдеры столкновения
        public ConvexShape[] MountColliders;

        //Спавн
        Spawn EnemySpawn;

        public Mission3_FreeFlight()
        {
            backgroundSprite = new Sprite(background);
            backgroundSprite.Scale = new Vector2f(1.5f, 1.5f);
            backgroundSprite.Position = new Vector2f(-450, -50);

            traceSprite = new Sprite(trace);
            traceSprite.Scale = new Vector2f(1.5f, 1.5f);
            traceSprite.Position = new Vector2f(-450, 700);

            rand = new Random();
            clock = new Clock();

            m_Hely = new Hely();
            m_Hely.SetPosition(new Vector2f(50, 50));
            Program.cameraController.SetCameraObject(m_Hely);

            //Проверка столкновений

            //Spawn
            EnemySpawn = new Spawn();
            
        }


        private void Collisions()
        {
            m_Hely.DictionaryOfShapesReal.Clear();
            for (int i = 0; i < MountColliders.Length; i++)
            {
                //Проверка столкновений возвращает массив пересечений, двумерный массив номеров точек первой фигуры и второй
                //0=вектор с двумя номерами грани первой фигуры, 1=вектор с номерами грани второй фигуры
                Vector2f[,] m_2dmassiveNums = Program.collisions.CheckShapesForCollision(MountColliders[i], m_Hely.colliderConvexShape);
                if (m_2dmassiveNums.GetLength(0) > 0)
                {
                    //m_Hely.SetDamage(m_Hely);
                    // Если гора уже содержится в словаре
                    if (m_Hely.DictionaryOfShapesReal.ContainsKey(MountColliders[i])) // Если содержится уже данная форма
                    {
                        m_Hely.DictionaryOfShapesReal[MountColliders[i]] = m_2dmassiveNums;

                    }
                    else //Если горы нет сейчас в словаре
                    {
                        //Добавляет форму горы в словарь + массив номеров точек граней с пересечениями (vector(точка1,точка2) vs vector(точка1, точка2))
                        m_Hely.DictionaryOfShapesReal.Add(MountColliders[i], m_2dmassiveNums);

                    }


                }
            }

        }

        public override void StartMiss()
        {
            base.StartMiss();
            SetGround();
        }

        public override void Update()
        {

            base.Update();
            


            Program.window.Draw(backgroundSprite);
            Program.window.Draw(traceSprite);
            Program.window.Draw(MountColliders[0]);
            Collisions();
            if (m_Hely != null) m_Hely.Update();


            EnemySpawn.Update();

            CheckPlayerComands();

        }

        private void CheckPlayerComands()
        {
            if (clock.ElapsedTime.AsSeconds() > 0.1f)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.P))
                {
                    EnemySpawn.SpawnEnemy();
                }
                clock.Restart();
            }


        }

        private void SetGround()
        {
            MountColliders = new ConvexShape[1];
            ConvexShape MountShape1 = new ConvexShape(17);
            MountShape1.SetPoint(0, new Vector2f(988, 884));
            MountShape1.SetPoint(1, new Vector2f(950, 751));
            MountShape1.SetPoint(2, new Vector2f(1092, 660));
            MountShape1.SetPoint(3, new Vector2f(1170, -17));
            MountShape1.SetPoint(0, new Vector2f(1021, 890));
            MountShape1.SetPoint(1, new Vector2f(1041, 721));
            MountShape1.SetPoint(2, new Vector2f(501, 742));
            MountShape1.SetPoint(3, new Vector2f(395, 758));
            MountShape1.SetPoint(4, new Vector2f(141, 733));
            MountShape1.SetPoint(5, new Vector2f(-19, 741));
            MountShape1.SetPoint(6, new Vector2f(-158, 766));
            MountShape1.SetPoint(7, new Vector2f(-254, 758));
            MountShape1.SetPoint(8, new Vector2f(-334, 736));
            MountShape1.SetPoint(9, new Vector2f(-509, 728));
            MountShape1.SetPoint(10, new Vector2f(-594, 753));
            MountShape1.SetPoint(11, new Vector2f(-746, 770));
            MountShape1.SetPoint(12, new Vector2f(-903, 768));
            MountShape1.SetPoint(13, new Vector2f(-959, 749));
            MountShape1.SetPoint(14, new Vector2f(-1308, 761));
            MountShape1.SetPoint(15, new Vector2f(-1909, 771));
            MountShape1.SetPoint(16, new Vector2f(-1915, 892));

            MountColliders[0] = MountShape1;

            SetMountain(MountShape1);
        }

        private void SetMountain(ConvexShape shape)
        {

            shape.Texture = Program.m_TextureManager.MountainTexture_01;
            //shape.Texture.Smooth = true;
            shape.Position = new Vector2f(850, 0);
            

        }






        /*
        // Левел 3 Свободный полет
if (levelchoise == 3 && mainmenuSwitch == 0 && gameplaying == 1) // Левел 3 Свободный полет
{
    if (newgame == 1)
    {
        money = 0;
        volnadelay = 0;
        basedurability = 12;
        missionswitch = 0;
        podskazkaswitch = 0;
        NRrocketslaunched = 0;

        winpobeda = 0;
        ввввв
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

        }

        */


    }
}
