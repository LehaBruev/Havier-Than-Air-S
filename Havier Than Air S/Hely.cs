using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{


    public class Hely : GameObject
    {
        #region переменные

        //Настройки верталета

        float currentHelilife;
        float shagAngle;
        float shagengine;

        //Переменные
        float helilifeCurrent = 200;// жизни
         int engineswitch = 1; // включение двигателя
         int autopilotswitch = 0; // автопилот горизонтальный, удерживает угол в точке 0 градусов
         float altitude = 200; // Высота
         float helifuel = 950; // Топливо в баках
         int bang1 = 1;
         int gunmode = 0;

        //Характеристики
         float helilifemax = 300;// максимальные жизни Вертолета
         float helienginelife = 100; //исправность двигателя Вертолета
         float fuelrashod = 1; // расход топлива
         float manageability = 5;// управляемость
         float maxangle = 65; // Максимальный угол атаки
         float helifuelmax = 1300; // Максимальное топливо в баках
         float maxboost = 11250; // максимальное ускорение от двигателя


         float playerx = 50;
         float playery = 400;
         float speedx = 0;
         float speedxmax = 2.5f;
         float speedy = 0;
         float powery = 0;
         float enginespeed = 19500; //Обороты двигателя
         float maxenginespeed = 60000; //Максимальные обороты двигателя
         float enginespeedlimit = 45000; //Предельные обороты двигателя

         float angle = 0; //угол атаки верталета

         float boostv = 0; //ускорение вертикальное
        

         int helidestroy = 0; // верталет разрушен
         int helistop = 0; // вертолет обесточен

        //Настройки прицеливания
         float aimlehght = 180;

        #endregion



        public Hely()
        {
            
            //Начальные настройки верталета
            playerx = 120;
            playery = 700;
            engineswitch = 0;
            enginespeed = 0;
            helistop = 1;
            helifuel = 1000;
            helifuelmax = 1300;
            currentHelilife = 300;
            helilifemax = 300;
            speedxmax = 3f;
            manageability = 9; //управляемость
            shagAngle = 1.7f; // угол атаки
            //nrrocketsMaxquantity = 8; //максимально ракет
            //padstoreswitch = 0;
            helidestroy = 0;

            
            shagengine = 75; //шаг увелич мощности двигателя
            enginespeedlimit = 35000; //лимит оборотов двигателя
            fuelrashod = 1.7f; // расход топлива
            //otkazcicle[1] = manageability;
            //otkazcicle[2] = shagAngle;
            //otkazcicle[3] = 0;
            
        }
    


    
    }
}
