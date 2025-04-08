using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S
{
    public enum RocketStatus
    {
        inCase,
        inAir,
        inPool
    }

    internal class Rocket
    {


        // NR ракеты МОДЕ 2
        static float NRrocketlenght = 20;
        static float NRrocketpower = 47;
        static float NRrocketweight = 100; //вес ракеты
        static float NRrocketspeed = 4; // скорость NR неуправляемых ракет
        static int nrrocketsMaxquantity = 64; // максимальное количество NR неуправляемых ракет
        static float nrfuel = 400.0f; // запас хода NR неуправляемых ракет
        private Color nrColor = new Color(255, 161, 0);

        //Переменные
        private RocketStatus currentRocketStatus;
        private float currentRocketfuel;
        private float currentRocketSpeed;

        private Vector2i currentRocketPosition;
        private float currentRocketAngle;


        public Rocket()
        {
            DeactivateRocket();
        }

        public void DeactivateRocket()
        {
            currentRocketStatus = RocketStatus.inPool;
            currentRocketfuel = nrfuel;
            currentRocketSpeed = 0.0f;

            
        }

        public void StartRocket(Vector2i position, float angle)
        {
            currentRocketStatus = RocketStatus.inAir;
            currentRocketPosition = position;
            currentRocketAngle = angle;


        }

        public void UpdateRocket()
        {
            if(currentRocketStatus == RocketStatus.inAir)
            {


            }


        }


        private void MoveNRrocket() // неуправляемая ракета НР движение и отрисовка

        {
               
                //положение ракеты

                //Угол наклона

                //Отрисовка

                //Проверка столкновений

                //Расход топл


            /*
                // вычисление х2 и у2 для отрисовки ракеты
                if (R[5, i] == 2)
                {
                    //searchangle = R[3, i];

                    float searchline = NRrocketlenght;
                    //searchAB();
                    float a = searchA;
                    float b = searchB;

                    // вычисление х3 и у3 для перемещения ракеты
                    searchline = NRrocketspeed;
                    searchAB();

                    //отрисовка ракеты
                    if (R[3, i] > 0 && R[3, i] < 70)
                    {
                        DrawLine(R[1, i], R[2, i], R[1, i] + a, R[2, i] + b, 4);
                        R[1, i] = R[1, i] + searchA;
                        R[2, i] = R[2, i] + searchB;

                    }
                    if (R[3, i] > -70 && R[3, i] < -15)
                    {
                        DrawLine(R[1, i], R[2, i], R[1, i] - a, R[2, i] + b, 4);
                        R[1, i] = R[1, i] - searchA;
                        R[2, i] = R[2, i] + searchB;
                    }
                    if (R[3, i] >= -15 && R[3, i] <= 0)
                    {
                        DrawLine(R[1, i], R[2, i], R[1, i] + a, R[2, i] - b, 4);
                        R[1, i] = R[1, i] + searchA;
                        R[2, i] = R[2, i] - searchB;
                    }
                    R[4, i] = R[4, i] - 1; // расход топлива ракеты
                    if (R[4, i] < 0)
                    {
                        R[5, i] = 0;

                    }
            */

               // }
            }

        }
        





    }
}
