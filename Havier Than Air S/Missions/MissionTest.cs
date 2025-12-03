using Havier_Than_Air_S.Enemies;
using Havier_Than_Air_S.GroundObjects;
using Havier_Than_Air_S.Weapon;
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
    public class MissionTest : MissionBase
    {

        Texture background = new Texture("Images\\BackGroundLevel3.png");
        Texture background_01 = new Texture("Images\\BackGroundLevel1 - Копировать.png");
        Texture paralax = new Texture("Images\\Горы1.png");
        Sprite backgroundSprite;
        Sprite paralaxSprite;
        Sprite paralaxSprite2;
        Sprite paralaxSprite3;
        Sprite background_01_Sprite;

        Clock clock;

        //мышка тест
        private Vector2f mousPoint1;
        private Vector2f mousPoint2;
        private bool mouseIsPressed;

        //Вертал
        Hely m_Hely;


        //Миссии
        int checkdelay = 50;
        int missionswitch = 0;
        int volnadelay = 0;
        int volnadelay2 = 0;
        int basedurability = 10;
        int winpobeda = 0;

        Tnk1 tank;

        // Houses

        Vector2f[] housesPositions;
        Hous[] houses;
        Random rand;
        int hCount = 100;
        int hBeginX = 1000;
        int hEndX = 3000;
        int hBeginY = 300;
        int hEndY = 790;

        //Mountains
        Mountains mounts;


        //GroundObjects
        BaseGroundObject[] gorundObjects;


        public MissionTest()
        {
            mounts = new Mountains();
            gorundObjects = new BaseGroundObject[1];
            gorundObjects[0] = new Ground_01();


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

            rand = new Random();

            
            clock = new Clock();



            /*
            housesPositions = new Vector2f[]
            {
                new Vector2f(1100, 750),
                new Vector2f(1300, 750),
                new Vector2f(1400, rand.Next(730,770)),
                new Vector2f(1470, rand.Next(730,770)),
                new Vector2f(1700, rand.Next(730,770)),
                new Vector2f(2200, rand.Next(500,700)),
                new Vector2f(2500, rand.Next(500,700)),
                new Vector2f(3000, rand.Next(500,700)),
            };
            */
            //tank = new Tnk1();

            
            

        }

        int tankCount = 10;

        Random rnd;
        Random rnd2;
        public void StartMiss()
        {
            rnd = new Random();
            rnd2 = new Random();
            
           // m_Hely = new Hely();
            //m_Hely = new mi24();
            //m_Hely = new OH_6();
            m_Hely = new AH_1();
            Program.cameraController.SetCameraObject(m_Hely);

            // tanks
            for (int i = 0; i < tankCount; i++)
            {
                Program.m_PullObjects.StartObject(new Vector2f(rnd.Next(1500,3500) , 750), 0, new Vector2f(rnd2.Next(5, 50),0), TypeOfObject.enemy);
            }

           

            // houses
            housesPositions = new Vector2f[hCount];

            for (int i = 0; i < housesPositions.Length; i++)
            {
                housesPositions[i] = new Vector2f(rand.Next(hBeginX, hEndX), rand.Next(hBeginY, hEndY));
            }
            for (int i = 0; i < hCount; i++)
            {
                Program.m_PullObjects.StartObject(housesPositions[i], 0, new Vector2f(0, 0), TypeOfObject.house);
            }
            /*
            houses = new Hous[housesPositions.Length];
            for (int i = 0; i < housesPositions.Length; i++)
            {
                houses[i] = new Hous();
                houses[i].rectShape.Position = housesPositions[i];
            }
            */
        }


        
        
        public void Update()
        {
            backgroundSprite.Position = Program.offset - new Vector2f(Program.vMode.Width/2, Program.vMode.Height / 2);
            Program.window.Draw(backgroundSprite);
            Program.window.Draw(background_01_Sprite);


            float n = Program.offset.X / paralaxSprite.GetLocalBounds().Width;

            //paralaxSprite.Position = new Vector2f(0, 300);
            //Program.window.Draw(paralaxSprite);
            paralaxSprite.Position = new Vector2f(n* 0.8f * paralaxSprite.GetLocalBounds().Width + paralaxSprite.GetLocalBounds().Width, 300);
            Program.window.Draw(paralaxSprite);
            paralaxSprite.Position = new Vector2f(n*0.8f*paralaxSprite.GetLocalBounds().Width , 300);
            Program.window.Draw(paralaxSprite);
            //paralaxSprite.Position = new Vector2f(n * paralaxSprite.GetLocalBounds().Width - paralaxSprite.GetLocalBounds().Width, 300);
            Program.window.Draw(paralaxSprite2);

           
            
            

            if (Program.m_MouseController.LeftButton == true)
            {

                if (m_Hely!=null) SpawnRocket();
                //Program.m_PullObjects.StartObject(mouseController.currentMousePoint, 0, new Vector2f(0,0), TypeOfObject.bang);

               
            }
            else if (mouseIsPressed == true)
            {
                mouseIsPressed = false;// по одному
                mousPoint2 = Program.m_MouseController.currentMousePoint;
                //SpawnRocket();
                mousPoint1 = Program.m_MouseController.currentMousePoint;
            }
            // if (tank!=null) tank.Update();

            /*
            // Houses
            for (int i = 0; i < housesPositions.Length; i++)
            {
                houses[i].Update();
            }
            */
            Program.window.Draw(paralaxSprite3);
            Program.window.Draw(background_01_Sprite);

            mounts.Update();
            gorundObjects[0].Update();



            //collisions
            
            for (int i = 0; i < mounts.MountColliders.Length; i++)
            {
                //Проверка столкновений возвращает массив пересечений, двумерный массив номеров точек первой фигуры и второй
                //0=вектор с двумя номерами грани первой фигуры, 1=вектор с номерами грани второй фигуры
                Vector2f[,] m_2dmassiveNums = Program.collisions.CheckShapesForCollision(mounts.MountColliders[i], m_Hely.colliderConvexShape);
                if (m_2dmassiveNums.GetLength(0) > 0)
                {
                    //m_Hely.SetDamage(m_Hely);
                    // Если гора уже содержится в словаре
                    if (m_Hely.DictionaryOfShapesReal.ContainsKey(mounts.MountColliders[i])) // Если содержится уже данная форма
                    {
                        m_Hely.DictionaryOfShapesReal[mounts.MountColliders[i]] = m_2dmassiveNums;

                    }
                    else //Если горы нет сейчас в словаре
                    {
                        //Добавляет форму горы в словарь + массив номеров точек граней с пересечениями (vector(точка1,точка2) vs vector(точка1, точка2))
                        m_Hely.DictionaryOfShapesReal.Add(mounts.MountColliders[i], m_2dmassiveNums);



                    }
                    
                    
                }
            }
            if (m_Hely != null) m_Hely.Update();
        }

        public void CheckTargetCollider(FloatRect incoming)
        {
            
            //if (targetRect.GetGlobalBounds().Intersects(incoming) == true )
           
        }

        private void SpawnRocket()
        {
                m_Hely.Fire();
                Vector2f vectorMouse = new Vector2f((mousPoint2 - mousPoint1).X, (mousPoint2 - mousPoint1).Y);
                float vectorAngle = Matematika.AngleOfVector(vectorMouse);
           
                clock.Restart();
           

        }


    }
}
