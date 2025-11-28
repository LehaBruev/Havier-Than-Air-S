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
        //Длинна 21.35
        Marker marker;

      

        protected override void SpawnHely()
        {

            textureName = "Images\\ми24_1.png";
            spriteScale = new Vector2f(0.3f, 0.3f);

            //Позиции деталей 
            spriteOrigin = new Vector2f(540,0);
            colliderOrigin = new Vector2f(0, 0);
            rearRotorOrigin = new Vector2f(-100,0);

            //Настройки верталета
            maxpowery = 300000; //Максимальная сила влияет на вертолет
            maxpowerx = 30000; // 
            shagRUD = 20; // шаг увеличения мощности двигателя
            shagAngle = 1.1f; // шаг изменения угла атаки
            shagAngleSpeed = 1f; // отклик рукоятки угла
            maxspeedhor = 240;
            maxspeedvert = 200;
            maxheigh = 400; // потолок полета
            speedxmax = 6.5f;
            Weight = 2500;


            //Характеристики мотора и проч
            helilifemax = 1000;// максимальные жизни Вертолета
            currentEnginelife = 100; //исправность двигателя Вертолета
            fuelrashod = 50.7f; // расход топлива
            inertia = 2f;// управляемость //5 это ИНЕРЦИЯ
            maxangle = 37; // Максимальный угол атаки
            helifuelmax = 2000; // Максимальное топливо в баках
            engineMaxPower = 46250; // максимальное ускорение от двигателя //11250
            holdRPM = 12000; // Холостые обороты мотора

            maxRPM = 70000; //Максимальные обороты двигателя
            RPMLimit = 55000; //Предельные обороты двигателя

            weaponPositionsOrigins[0] = new Vector2f(-5, 50); //Позиция подвесок оружия
            base.SpawnHely();

            //Верхний винт
            topRotorRectShape.Size = new Vector2f(140, 2);
            topRotorRectShape.FillColor = new Color(Color.Green);
            topVintSpeed = 1137;

            topRotorRectShape.Origin = new Vector2f(70, 1);

            //Задний винт

            rearRotorRectShape.Size = new Vector2f(2, 18);
            rearRotorRectShape.FillColor = new Color(Color.Yellow);
            rearRotorRectShape.Origin = new Vector2f(1, 9f);



            //Коллайдер
            colliderConvexShape = new ConvexShape(8);
            colliderConvexShape.SetPoint(0, new Vector2f(-98, 5));
            colliderConvexShape.SetPoint(1, new Vector2f(-72, 14));
            colliderConvexShape.SetPoint(2, new Vector2f(-24, 14));
            colliderConvexShape.SetPoint(3, new Vector2f(23, 11));
            colliderConvexShape.SetPoint(4, new Vector2f(49, 25));
            colliderConvexShape.SetPoint(5, new Vector2f(50, 36));
            colliderConvexShape.SetPoint(6, new Vector2f(-13, 34));
            colliderConvexShape.SetPoint(7, new Vector2f(-79, 23));
            //collider.SetPoint(4, new Vector2f(63, 30));
            //collider.SetPoint(5, new Vector2f(-80, 28));
            
            /*
            collider.SetPoint(3, new Vector2f(0, 5));
            collider.SetPoint(4, new Vector2f(55, 10));
            collider.SetPoint(5, new Vector2f(66, 15));
            collider.SetPoint(6, new Vector2f(60, 30));
            collider.SetPoint(7, new Vector2f(5, 30));
            collider.SetPoint(8, new Vector2f(0, 25));
            collider.SetPoint(9, new Vector2f(-63, 30));
            */
            colliderConvexShape.FillColor = Color.Green;

            //marker = new Marker(collider, Color.Red, 3);

        }

        public override void Update()
        {
            base.Update();

            //marker.Update();
            //Program.window.Draw(collider);

        }
    }
}












   
