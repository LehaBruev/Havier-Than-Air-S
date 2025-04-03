using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    internal class Hely
    {




        //Настройки верталета

        static float helilife = 100;// жизни
        static float manageability = 5;// управляемость
        static float helilifemax = 300;// максимальные жизни Вертолета
        static float helienginelife = 100; //исправность двигателя Вертолета
        static int engineswitch = 1; // включение двигателя
        static int autopilotswitch = 0; // автопилот горизонтальный, удерживает угол в точке 0 градусов
        static float fuelrashod = 1; // расход топлива

        static float altitude = 200; // Высота

        static float maxangle = 65; // Максимальный угол атаки
        static float helifuel = 950; // Топливо в баках
        static float helifuelmax = 1300; // Максимальное топливо в баках
        static int bang1 = 1;

        static float maxboost = 11250; // максимальное ускорение от двигателя




        //ВООРУЖЕНИЕ ВЕРТАЛЕА
        static int gunmode = 0;

        // NR ракеты МОДЕ 2
        static float NRrocketlenght = 20;
        static float NRrocketpower = 47;
        static float NRrocketweight = 100; //вес ракеты
        static float NRrocketspeed = 4; // скорость NR неуправляемых ракет
        static int nrrocketsMaxquantity = 64; // максимальное количество NR неуправляемых ракет
        static int nrfuel = 400; // запас хода NR неуправляемых ракет


        static void MoveNRrocket() // неуправляемая ракета НР движение и отрисовка

        {

            for (int i = 0; i < R.GetLongLength(1); i++) //(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена(1 в кассете, 2 в полете, 0 потрачено)
            {
                //положение ракеты
                // вычисление х2 и у2 для отрисовки ракеты
                if (R[5, i] == 2)
                {
                    searchangle = R[3, i];
                    searchline = NRrocketlenght;
                    searchAB();
                    float a = searchA;
                    float b = searchB;

                    // вычисление х3 и у3 для перемещения ракеты
                    searchline = NRrocketspeed;
                    searchAB();

                    //цвет ракеты
                    SetFillColor(255, 161, 0);

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


                }
            }

        }



    }
}
