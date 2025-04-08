using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class Hely: GameObject
    {

        //Настройки верталета

        //Переменные
        static float helilifeCurrent = 200;// жизни
        static int engineswitch = 1; // включение двигателя
        static int autopilotswitch = 0; // автопилот горизонтальный, удерживает угол в точке 0 градусов
        static float altitude = 200; // Высота
        static float helifuel = 950; // Топливо в баках
        static int bang1 = 1;
        static int gunmode = 0;


        //Характеристики
        static float helilifemax = 300;// максимальные жизни Вертолета
        static float helienginelife = 100; //исправность двигателя Вертолета
        static float fuelrashod = 1; // расход топлива
        static float manageability = 5;// управляемость
        static float maxangle = 65; // Максимальный угол атаки
        static float helifuelmax = 1300; // Максимальное топливо в баках
        static float maxboost = 11250; // максимальное ускорение от двигателя

        
        



    }
}
