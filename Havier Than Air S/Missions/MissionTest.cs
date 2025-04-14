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

        public MissionTest()
        {
            clock = new Clock();

             taergetImage = new Image("Nrocket_01.png");
             targetTexture = new Texture(taergetImage);
             targetSprite = new Sprite(targetTexture);

            //
            targetSprite.Position = new Vector2f(350, 400);
            targetSprite.Rotation = 45.0f;

        }
        

        public void Update()
        {

            Program.window.Draw(targetSprite);

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
           
            if (targetSprite.GetGlobalBounds().Intersects(incoming) == true )
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
