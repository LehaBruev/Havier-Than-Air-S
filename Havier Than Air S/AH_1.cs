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
        //длинна 13.59
        Marker marker;

        public AH_1()
        {

        }



        protected override void SpawnHely()
        {


            textureName = "Images\\AH1_1.png";
            scaleMasterSize =  0.67f;
            scaleMasterSize = scaleMasterSize * Program.helyScale;
            spriteScale = new Vector2f(0.27f, 0.27f)* scaleMasterSize;



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
            speedxmax = new Vector2f(4.5f,2);
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
            topVintOrigin = new Vector2f(105, 1.25f ) * scaleMasterSize;
            topVintSize = new Vector2f(210, 2.5f) * scaleMasterSize;
            topRotorColor = new Color(Color.Red);
            topVintSpeed = 1137;

            //Задний винт
            rearVintPositionOrigin = new Vector2f(-130f, 12f) * scaleMasterSize;
            rearRotorOrigin = new Vector2f(1.5f, 15f) * scaleMasterSize;
            rearRotorSize = new Vector2f(3f, 30) * scaleMasterSize;
            rearRotorColor = new Color(Color.Red);
            rearVintSpeed = 55;

            // weapons
            weaponPositionsOrigins[0] = new Vector2f(0 , 22 ) * scaleMasterSize; //Позиция подвесок оружия
            weaponPositionsOrigins[1] = new Vector2f(46, 44) * scaleMasterSize; //Позиция пушки

            base.SpawnHely();

            //Коллайдер
            
            colliderConvexShape = new ConvexShape(15);
            /*
            colliderConvexShape.SetPoint(0, new Vector2f(-98, 5));
            colliderConvexShape.SetPoint(1, new Vector2f(-72, 14));
            colliderConvexShape.SetPoint(2, new Vector2f(-24, 14));
            colliderConvexShape.SetPoint(3, new Vector2f(23, 11));
            colliderConvexShape.SetPoint(4, new Vector2f(49, 25));
            colliderConvexShape.SetPoint(5, new Vector2f(50, 36));
            colliderConvexShape.SetPoint(6, new Vector2f(-13, 34));
            colliderConvexShape.SetPoint(7, new Vector2f(-79, 23));
            */
            colliderConvexShape.SetPoint(0, new Vector2f(-130, 10));
            colliderConvexShape.SetPoint(1, new Vector2f(-111, 24));
            colliderConvexShape.SetPoint(2, new Vector2f(-54, 26));
            colliderConvexShape.SetPoint(3, new Vector2f(-30, 7));
            colliderConvexShape.SetPoint(4, new Vector2f(9, 8));
            colliderConvexShape.SetPoint(5, new Vector2f(63, 28));
            colliderConvexShape.SetPoint(6, new Vector2f(62, 38));
            colliderConvexShape.SetPoint(7, new Vector2f(41, 47));
            colliderConvexShape.SetPoint(8, new Vector2f(26, 51));
            colliderConvexShape.SetPoint(9, new Vector2f(-17, 51));
            colliderConvexShape.SetPoint(10, new Vector2f(-17, 45));
            colliderConvexShape.SetPoint(11, new Vector2f(-119, 36));
            colliderConvexShape.SetPoint(12, new Vector2f(-131, 38));
            colliderConvexShape.SetPoint(13, new Vector2f(-126, 30));
            colliderConvexShape.SetPoint(14, new Vector2f(-134, 17));

            for (int i=0; i< colliderConvexShape.GetPointCount(); i++)
            {
                colliderConvexShape.SetPoint((uint)i,colliderConvexShape.GetPoint((uint)i)* scaleMasterSize);
            }
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

            marker.Update();
            //Program.window.Draw(collider);

        }
    }
}













