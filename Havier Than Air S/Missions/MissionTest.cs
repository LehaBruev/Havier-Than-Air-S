using Havier_Than_Air_S.Enemies;
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
        MouseController mouseController;

        Texture background = new Texture("BackGroundLevel3.png");
        Texture paralax = new Texture("Горы1.png");
        Sprite backgroundSprite;
        Sprite paralaxSprite;
        Sprite paralaxSprite2;
        Sprite paralaxSprite3;

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

        public MissionTest()
        {
            mounts = new Mountains();

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



            rand = new Random();
            
            mouseController = Program.m_MouseController;
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
            
            m_Hely = new Hely();
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

        int lognum = 0;
        public void Update()
        {
            backgroundSprite.Position = Program.offset - new Vector2f(Program.vMode.Width/2, Program.vMode.Height / 2);
            Program.window.Draw(backgroundSprite);

            float n = Program.offset.X / paralaxSprite.GetLocalBounds().Width;

            //paralaxSprite.Position = new Vector2f(0, 300);
            //Program.window.Draw(paralaxSprite);
            paralaxSprite.Position = new Vector2f(n* 0.8f * paralaxSprite.GetLocalBounds().Width + paralaxSprite.GetLocalBounds().Width, 300);
            Program.window.Draw(paralaxSprite);
            paralaxSprite.Position = new Vector2f(n*0.8f*paralaxSprite.GetLocalBounds().Width , 300);
            Program.window.Draw(paralaxSprite);
            //paralaxSprite.Position = new Vector2f(n * paralaxSprite.GetLocalBounds().Width - paralaxSprite.GetLocalBounds().Width, 300);
            Program.window.Draw(paralaxSprite2);

           
            


            if (m_Hely!=null) m_Hely.Update();

            if (mouseController == null)
            {
                mouseController = Program.m_MouseController;
            }

            

            if (mouseController.LeftButton == true)
            {

                if (m_Hely!=null) SpawnRocket();
                Program.m_PullObjects.StartObject(mouseController.currentMousePoint, 0, new Vector2f(0,0), TypeOfObject.bang);

                if (mouseIsPressed == false)
                {
                    mouseIsPressed = true;
                    mousPoint1 = mouseController.currentMousePoint;
                    Program.log.WriteXY("mount1.SetPoint(0" + lognum + ", new Vector2f(" + Mouse.GetPosition(Program.window).X + " , " + Mouse.GetPosition(Program.window).Y + " ));");
                    lognum += 1;
                }
            }
            else if (mouseIsPressed == true)
            {
                mouseIsPressed = false;// по одному
                mousPoint2 = mouseController.currentMousePoint;
                //SpawnRocket();
                mousPoint1 = mouseController.currentMousePoint;
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

            mounts.Update();


            //collisions
            bool d = Program.collisions.CheckShapesForCollision(mounts.mount1, m_Hely.collider);
            if (d==true)
            {
                m_Hely.SetDamage(m_Hely);
            }


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
