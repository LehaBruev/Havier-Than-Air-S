using Havier_Than_Air_S.Enemies;
using Havier_Than_Air_S.Weapon;
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
        Collisions collisions;

        MouseController mouseController;

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


        public MissionTest()
        {
            collisions = new Collisions();
            mouseController = Program.m_MouseController;
            clock = new Clock();
            m_Hely = new Hely();
            Program.cameraController.SetCameraObject(m_Hely);


            //tank = new Tnk1();

        }
        

        public void Update()
        {
            collisions.Update(); 

            if (m_Hely!=null) m_Hely.Update();

            if (mouseController == null)
            {
                mouseController = Program.m_MouseController;
            }



            if (mouseController.LeftButton == true)
            {

                if (m_Hely!=null) SpawnRocket();
                Program.m_PullObjects.StartObject(mouseController.currentMousePoint, 0, TypeOfObject.bang);

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
             if (tank!=null) tank.Update();
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
                
                //Console.WriteLine("Вектор " + vectorMouse + "; угол " + vectorAngle);
                //positionNR = new Vector2f((float)mouseController.x, (float)mouseController.y);
                
                clock.Restart();
           

        }


    }
}
