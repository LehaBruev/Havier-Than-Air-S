using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S
{
    public class AH_1 : Hely
    {

        Marker marker;

        public AH_1()
        {

        }

        protected override void SpawnHely()
        {

            textureName = "AH1_1.png";
            spriteScale = new Vector2f(0.27f, 0.27f);

            //Позиции деталей 
            spriteOrigin = new Vector2f(500, 0);
            colliderOrigin = new Vector2f(0, 0);

            //Настройки верталета
            maxpowery = 400000; //Максимальная сила влияет на вертолет
            maxpowerx = 30000; // 
            shagRUD = 25; // шаг увеличения мощности двигателя
            shagAngle = 1.3f; // шаг изменения угла атаки
            maxspeedhor = 200;
            maxspeedvert = 220;
            maxheigh = 500; // потолок полета
            speedxmax = 4.5f;
            Weight = 1500;

            //Характеристики мотора и проч
            helilifemax = 500;// максимальные жизни Вертолета
            currentEnginelife = 100; //исправность двигателя Вертолета
            fuelrashod = 50.7f; // расход топлива
            inertia = 3f;// управляемость //5 это ИНЕРЦИЯ
            maxangle = 70; // Максимальный угол атаки
            helifuelmax = 1300; // Максимальное топливо в баках
            engineMaxPower = 29250; // максимальное ускорение от двигателя //11250
            holdRPM = 12000; // Холостые обороты мотора

            maxRPM = 50000; //Максимальные обороты двигателя
            RPMLimit = 45000; //Предельные обороты двигателя



            //Верхний винт
            topVintOrigin = new Vector2f(48, 1);
            topVintSize = new Vector2f(96, 2);
            topRotorColor = new Color(Color.Red);
            topVintSpeed = 1137;

            //Задний винт
            rearVintPositionOrigin = new Vector2f();
            rearRotorOrigin = new Vector2f(1, 9f);
            rearRotorSize = new Vector2f(2, 18);
            rearRotorColor = new Color(Color.Yellow);
            rearVintSpeed = 55;

            // weapons
            weaponPositionsOrigins[0] = new Vector2f(0, 22); //Позиция подвесок оружия
            weaponPositionsOrigins[1] = new Vector2f(75, 30); //Позиция пушки

            base.SpawnHely();

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

            marker = new Marker(colliderConvexShape, Color.Red, 3);

        }

        public override void Update()
        {
            base.Update();

            //marker.Update();
            //Program.window.Draw(collider);

        }
    }
}













