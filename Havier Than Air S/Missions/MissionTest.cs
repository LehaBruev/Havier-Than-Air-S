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

        public MissionTest()
        {
            clock = new Clock();
        }
        

        public void Update()
        {
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
            else if (mouseIsPressed == true )
            {
                mouseIsPressed = false;
                mousPoint2 = mouseController.currentMousePoint;
                SpawnRocket();
            }


        }

        private void SpawnRocket()
        {
            if (zaderjka < clock.ElapsedTime.AsSeconds())
            {
                Vector2f vectorMouse = new Vector2f((mousPoint2 - mousPoint1).X, (mousPoint2 - mousPoint1).Y);
                float vectorAngle = Matematika.AngleVector(vectorMouse);
                angleNR = vectorAngle;
                Console.WriteLine("Вектор " + vectorMouse + "; угол " + vectorAngle);

                positionNR = new Vector2f((float)mouseController.x, (float)mouseController.y);
                pull.SpawnNR_Rocket(positionNR, angleNR);
                clock.Restart();

            }

        }


    }
}
