
using Havier_Than_Air_S.GroundObjects;
using SFML.Graphics;
using SFML.System;
using System;

namespace Havier_Than_Air_S.Missions
{
    public class MissionTest : MissionBase
    {
        //ФОН
        Texture background = new Texture("Images\\BackGroundLevel3.png");
        Texture background_01 = new Texture("Images\\BackGroundLevel1 - Копировать.png");
        Texture paralax = new Texture("Images\\Горы1.png");
        Sprite backgroundSprite;
        Sprite paralaxSprite;
        Sprite paralaxSprite2;
        Sprite paralaxSprite3;
        Sprite background_01_Sprite;

        //ТАЙМЕРЫ
        Clock clock;
        Clock clock_preMission;
        float clock_preMission_timer = 2;

        
        //Вертал
        Hely Player_Hely;


        //Миссии
        int checkdelay = 50;
        int missionswitch = 0;
        int volnadelay = 0;
        int volnadelay2 = 0;
        int basedurability = 10;
        int winpobeda = 0;

        

        // ПОСТРОЙКИ СТРОЕНИЯ

        Vector2f[] housesPositions;
        Hous[] houses;
        Random rand;
        int hCount = 100; //КОЛИЧЕСТВО ДОМОВ
        int hBeginX = 1000; //НАЧАЛО РАССТАНОВКИ ДОМОВ
        int hEndX = 3000;
        int hBeginY = 300;
        int hEndY = 790; // КОНЕЦ РАССТАНОВКИ ДОМОВ

        //Mountains
        Mountains mounts;


        //GroundObjects
        BaseGroundObject[] gorundObjects;


        // ГЕЙМПЛЕЙ
        int tankCount = 19;

        Random rnd;
        Random rnd2;



        public MissionTest()
        {

            clock_preMission = new Clock();
            clock_preMission.Restart();

            mounts = new Mountains(); // ГОРЫ
            gorundObjects = new BaseGroundObject[1]; // НАЗЕМНЫЕ ОБЪЕКТЫ

            // ОТРИСОВКА КАРТЫ
            backgroundSprite = new Sprite(background);
            backgroundSprite.Scale = new Vector2f(1.6f, 1.6f);

            paralaxSprite = new Sprite(paralax);
            paralaxSprite.Scale = new Vector2f(0.8f, 0.8f);
            paralaxSprite.Color = Color.Blue;

            paralaxSprite2 = new Sprite(paralax);
            paralaxSprite2.Scale = new Vector2f(1.4f, 1.4f);
            paralaxSprite2.Position = new Vector2f(-500, 400);
            

            paralaxSprite3 = new Sprite(paralax);
            paralaxSprite3.Scale = new Vector2f(3.5f, 3.5f);
            paralaxSprite3.Position = new Vector2f(300, 150);

            background_01_Sprite = new Sprite(background_01);
            background_01_Sprite.Scale = new Vector2f(2f, 2f);
            background_01_Sprite.Position = new Vector2f(-500,260);


            //СЕРВИСЫ
            rnd = new Random();
            rnd2 = new Random();
            rand = new Random();
            clock = new Clock();

            // houses
            AddHouses();


        }

        
        public override void StartMiss()
        {
            

            //ВЕРТОЛЕТ И ПОЗИЦИЯ
            Player_Hely = Program.gameState.currentPlayerHely;
            Player_Hely.SetPosition(new Vector2f(50, 500));

            Program.cameraController.SetCameraObject(Program.gameState.currentPlayerHely);


            //ПРОТИВНИКИ ТАНКИ
            for (int i = 0; i < tankCount; i++)
            {
                Program.m_PullObjects.StartObject(new Vector2f(rnd.Next(3500,3900), 750),
                                                0, 
                                                new Vector2f(rnd2.Next(5, 75),0), 
                                                TypeOfObject.enemy);
            }


            
        }

        private void AddHouses()
        {
            housesPositions = new Vector2f[hCount];

            for (int i = 0; i < housesPositions.Length; i++)
            {
                housesPositions[i] = new Vector2f(rand.Next(hBeginX, hEndX), rand.Next(hBeginY, hEndY));
            }
            for (int i = 0; i < hCount; i++)
            {
                Program.m_PullObjects.StartObject(housesPositions[i], 0, new Vector2f(0, 0), TypeOfObject.house);
            }

        }

        
        public override void Update()
        {
            base.Update();

            //ФОН
            backgroundSprite.Position = Program.offset - new Vector2f(Program.vMode.Width/2, Program.vMode.Height / 2);
            Program.window.Draw(backgroundSprite);
            Program.window.Draw(background_01_Sprite);

            //ПАРАЛАКС
            float n = Program.offset.X / paralaxSprite.GetLocalBounds().Width;

            //paralaxSprite.Position = new Vector2f(0, 300);
            //Program.window.Draw(paralaxSprite);
            paralaxSprite.Position = new Vector2f(n* 0.8f * paralaxSprite.GetLocalBounds().Width + paralaxSprite.GetLocalBounds().Width, 300);
            Program.window.Draw(paralaxSprite);
            paralaxSprite.Position = new Vector2f(n*0.8f*paralaxSprite.GetLocalBounds().Width , 300);
            Program.window.Draw(paralaxSprite);
            //paralaxSprite.Position = new Vector2f(n * paralaxSprite.GetLocalBounds().Width - paralaxSprite.GetLocalBounds().Width, 300);
            Program.window.Draw(paralaxSprite2);
            Program.window.Draw(paralaxSprite3);
            Program.window.Draw(background_01_Sprite);

            //ЗЕМЛЯ
            mounts.Update();
            /*
            // Houses
            for (int i = 0; i < housesPositions.Length; i++)
            {
                houses[i].Update();
            }
            */

            //МЫШЬ
            if (Program.m_MouseController.LeftButtonIsPressed == true)
            {
                if (Player_Hely!=null) PlayerHelyFire();
            }
            //else 

              //  if (mouseIsPressed == true)
           // {
                //mouseIsPressed = false;// по одному
                //mousPoint2 = Program.m_MouseController.currentMousePosInWindow;
                //SpawnRocket();
                //mousPoint1 = Program.m_MouseController.currentMousePosInWindow;
           // }
            // if (tank!=null) tank.Update();

            

            //СТОЛКНОВЕНИЯ collisions
            Player_Hely.DictionaryOfShapesReal.Clear();
            for (int i = 0; i < mounts.MountColliders.Length; i++)
            {
                //Проверка столкновений возвращает массив пересечений, двумерный массив номеров точек первой фигуры и второй
                //0=вектор с двумя номерами грани первой фигуры, 1=вектор с номерами грани второй фигуры
                Vector2f[,] m_2dmassiveNums = Program.collisions.CheckShapesForCollision(mounts.MountColliders[i], Player_Hely.colliderConvexShape);
                if (m_2dmassiveNums.GetLength(0) > 0)
                {
                    //m_Hely.SetDamage(m_Hely);
                    // Если гора уже содержится в словаре
                    if (Player_Hely.DictionaryOfShapesReal.ContainsKey(mounts.MountColliders[i])) // Если содержится уже данная форма
                    {
                        Player_Hely.DictionaryOfShapesReal[mounts.MountColliders[i]] = m_2dmassiveNums;

                    }
                    else //Если горы нет сейчас в словаре
                    {
                        //Добавляет форму горы в словарь +
                        //массив номеров точек граней с пересечениями (vector(точка1,точка2) vs vector(точка1, точка2))
                        Player_Hely.DictionaryOfShapesReal.Add(mounts.MountColliders[i], m_2dmassiveNums);

                    }
                    
                    
                } 
            }

            if (clock_preMission_timer < clock_preMission.ElapsedTime.AsSeconds())
            {
                if (Player_Hely != null) Player_Hely.Update();
            }
        }


        private void PlayerHelyFire()
        {
                Player_Hely.Fire();
                //Vector2f vectorMouse = new Vector2f((mousPoint2 - mousPoint1).X, (mousPoint2 - mousPoint1).Y);
                //float vectorAngle = Matematika.AngleOfVector(vectorMouse);
           
                clock.Restart();
           

        }


    }
}
