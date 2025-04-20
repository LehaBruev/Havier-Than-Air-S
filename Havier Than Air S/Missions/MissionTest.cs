using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Missions
{
    public class MissionTest
    {
        //установка для нр
        Vector2f positionNR;
        float angleNR = 280.0f;

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
        Hely Hely;
        Hely Hely_2;
        //Hely Hely_3;

        // Земля
        RectangleShape groundRectShape;

        //Авионика
        Avionika avionika;

        public MissionTest()
        {
            //Земля
            groundRectShape = new RectangleShape(new Vector2f(1200, 50));
            groundRectShape.Position = new Vector2f(0,700);
            groundRectShape.FillColor = new Color(100,255,105);

            clock = new Clock();
            Hely = new Hely();
            Hely_2 = new Hely();
            //Hely_3 = new Hely();

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

            //avionika
            avionika = new Avionika();
        }
        

        public void Update()
        {
            Program.window.Draw(targetRect);
            Program.window.Draw(groundRectShape);
            avionika.Update();

            Hely.Update();
            Hely_2.Update();
           //Hely_3.Update();

            if (mouseController == null)
            {
                mouseController = Program.Game.MouseController;
                pull = Program.Game.Pull;
            }

            if (mouseController.LeftButton == true)
            {
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
                SpawnRocket();
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
             //   Console.WriteLine(".");
            }
        }

        private void SpawnRocket()
        {
            if (zaderjka < clock.ElapsedTime.AsSeconds())
            {
                Vector2f vectorMouse = new Vector2f((mousPoint2 - mousPoint1).X, (mousPoint2 - mousPoint1).Y);
                float vectorAngle = Matematika.AngleVector(vectorMouse);
                angleNR = vectorAngle;
                //Console.WriteLine("Вектор " + vectorMouse + "; угол " + vectorAngle);

                positionNR = new Vector2f((float)mouseController.x, (float)mouseController.y);
                pull.SpawnNR_Rocket(mousPoint1, angleNR, this);
                clock.Restart();
            }
        }
    }
}
