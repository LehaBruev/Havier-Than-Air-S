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
           
        }

        protected override void SpawnHely()
        {
            textureName = "ми24_1.png";
            spriteScale = new Vector2f(0.18f, 0.18f);
            spriteOrigin = new Vector2f(550,0);
            rearRotorOrigin = -100;

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
            manageability = 1f;// управляемость //5 это ИНЕРЦИЯ
            maxangle = 37; // Максимальный угол атаки
            helifuelmax = 2000; // Максимальное топливо в баках
            maxboost = 9250; // максимальное ускорение от двигателя //11250
            holdOborotMotora = 12000; // Холостые обороты мотора

            maxenginespeed = 70000; //Максимальные обороты двигателя
            enginespeedlimit = 55000; //Предельные обороты двигателя

            weaponPositionLocal = new Vector2f(-5, 20); //Позиция подвесок оружия
            base.SpawnHely();

            topRotorRectShape.Size = new Vector2f(140, 2);
            topRotorRectShape.Origin = new Vector2f(70, 1);
            topRotorRectShape.FillColor = new Color(Color.Green);
            topVintSpeed = 1137;

        }


    }
}












   
