using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S
{
    public class mi24: Hely
    {

        public mi24()
        {
            textureName = "ми24_1.png";
            spriteScale = new Vector2f(0.1f, 0.1f);

            //Настройки верталета
            maxpowery = 300000; //Максимальная сила влияет на вертолет
            maxpowerx = 30000; // 
            shagengine = 50; // шаг увеличения мощности двигателя
            shagAngle = 1.1f; // шаг изменения угла атаки
            maxspeedhor = 240;
            maxspeedvert = 200;
            maxheigh = 400; // потолок полета
            speedxmax = 4.5f;

            //Характеристики мотора и проч
            helilifemax = 1000;// максимальные жизни Вертолета
            helienginelife = 100; //исправность двигателя Вертолета
            fuelrashod = 50.7f; // расход топлива
            manageability = 6f;// управляемость //5 это ИНЕРЦИЯ
            maxangle = 50; // Максимальный угол атаки
            helifuelmax = 3000; // Максимальное топливо в баках
            maxboost = 6250; // максимальное ускорение от двигателя //11250
            holdOborotMotora = 12000; // Холостые обороты мотора

            maxenginespeed = 70000; //Максимальные обороты двигателя
            enginespeedlimit = 55000; //Предельные обороты двигателя

            weaponPositionLocal = new Vector2f(-5, 20); //Позиция подвесок оружия


        }


    }
}












   
