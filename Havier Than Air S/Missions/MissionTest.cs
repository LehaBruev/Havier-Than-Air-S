using SFML.Graphics;
using SFML.System;
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
        PullObjects pull;

        Clock clock;
        float zaderjka = 0.08f;

        //мышка тест
        private Vector2f mousPoint1;
        private Vector2f mousPoint2;
        private bool mouseIsPressed;

        //тест цель
        Image taergetImage;
        Texture targetTexture;
        Sprite targetSprite;
        RectangleShape targetRect;

        //Вертал
        Hely m_Hely;



        //Миссии
        int checkdelay = 50;
        int missionswitch = 0;
        int volnadelay = 0;
        int volnadelay2 = 0;
        int basedurability = 10;
        int winpobeda = 0;




        public MissionTest()
        {
            mouseController = Program.m_MouseController;
            clock = new Clock();
            m_Hely = new Hely();

             taergetImage = new Image("uh612.png");
             targetTexture = new Texture(taergetImage);
             //targetSprite = new Sprite(targetTexture);
             targetSprite = new Sprite(targetTexture);
            //targetSprite.TextureRect = new IntRect(1, 1,1,1);

            targetRect = new RectangleShape(new Vector2f(50,50));
            targetRect.FillColor = Color.Yellow;
            targetRect.Rotation = 37.0f;
            targetRect.Position = new Vector2f(100,400);

            //
            targetSprite.Position = new Vector2f(350, 400);
            targetSprite.Rotation = 45.0f;


            

        }
        

        public void Update()
        {
            m_Hely.Update();

            Program.window.Draw(targetRect);

            if (mouseController == null)
            {
                mouseController = Program.Game.MouseController;
            }



            if (mouseController.LeftButton == true)
            {
                SpawnRocket();
                if (mouseIsPressed == false)
                {
                    mouseIsPressed = true;
                    mousPoint1 = mouseController.currentMousePoint;
                }
            }
            else if (mouseIsPressed == true)
            {
                mouseIsPressed = false;// по одному
                mousPoint2 = mouseController.currentMousePoint;
                //SpawnRocket();
                mousPoint1 = mouseController.currentMousePoint;
            }
        }

        public void CheckTargetCollider(FloatRect incoming)
        {
            
            if (targetRect.GetGlobalBounds().Intersects(incoming) == true )
            {
                Console.WriteLine("Касание");
            }
            else
            {
                Console.WriteLine(".");
            }




        }

        private void SpawnRocket()
        {
            if (zaderjka < clock.ElapsedTime.AsSeconds())
            {
                m_Hely.Fire();

                Vector2f vectorMouse = new Vector2f((mousPoint2 - mousPoint1).X, (mousPoint2 - mousPoint1).Y);
                float vectorAngle = Matematika.AngleVector(vectorMouse);
                
                //Console.WriteLine("Вектор " + vectorMouse + "; угол " + vectorAngle);
                //positionNR = new Vector2f((float)mouseController.x, (float)mouseController.y);
                
                clock.Restart();
            }

        }


    }
}
