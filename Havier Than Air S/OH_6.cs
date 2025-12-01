using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S
{
    public class OH_6: Hely
    {

        Marker marker;

        public OH_6()
        {
           
        }

        protected override void SpawnHely()
        {

            textureName = "Images\\OH-6_1.png";
            spriteScale = new Vector2f(0.33f, 0.33f);

            //Позиции деталей 
            spriteOrigin = new Vector2f(250,0);
            colliderOrigin = new Vector2f(0, 0);
            rearRotorOrigin = new Vector2f(-50,0);

            //Настройки верталета
            maxpowery = 200000; //Максимальная сила влияет на вертолет
            maxpowerx = 20000; // 
            shagRUD = 120; // шаг увеличения мощности двигателя
            shagAngle = 1.7f; // шаг изменения угла атаки
            shagAngleSpeed = 7f; // отклик рукоятки угла
            maxspeedhor = 120;
            maxspeedvert = 240;
            maxheigh = 500; // потолок полета
            speedxmax = new Vector2f(3.5f, 2);
            Weight = 0.7f;

            //Характеристики мотора и проч
            helilifemax = 200;// максимальные жизни Вертолета
            currentEnginelife = 100; //исправность двигателя Вертолета
            fuelrashod = 30.7f; // расход топлива
            inertia = 6f;// управляемость //5 это ИНЕРЦИЯ
            maxangle = 85; // Максимальный угол атаки
            helifuelmax = 800; // Максимальное топливо в баках
            engineMaxPower = 18000; // максимальное ускорение от двигателя //11250
            holdRPM = 12000; // Холостые обороты мотора

            maxRPM = 50000; //Максимальные обороты двигателя
            RPMLimit = 39000; //Предельные обороты двигателя

            weaponPositionsOrigins[0] = new Vector2f(-5, 20); //Позиция подвесок оружия

           
            base.SpawnHely();

            //Верхний винт
            topRotorRectShape.Size = new Vector2f(80, 2);
            topRotorRectShape.FillColor = new Color(Color.Green);
            topVintSpeed = 600;

            topRotorRectShape.Origin = new Vector2f(40, 1);

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












   
