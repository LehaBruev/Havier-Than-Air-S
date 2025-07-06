using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S
{
    public class AH_1: Hely
    {

        Marker marker;

        public AH_1()
        {
           
        }

        protected override void SpawnHely()
        {

            textureName = "AH1_1.png";
            spriteScale = new Vector2f(0.13f, 0.13f);

            //Позиции деталей 
            spriteOrigin = new Vector2f(500,0);
            colliderOrigin = new Vector2f(0, 0);
            rearRotorOrigin = new Vector2f(-100,0);

            //Настройки верталета
            maxpowery = 400000; //Максимальная сила влияет на вертолет
            maxpowerx = 30000; // 
            shagengine = 70; // шаг увеличения мощности двигателя
            shagAngle = 1.3f; // шаг изменения угла атаки
            maxspeedhor = 200;
            maxspeedvert = 220;
            maxheigh = 500; // потолок полета
            speedxmax = 2.5f;

            //Характеристики мотора и проч
            helilifemax = 500;// максимальные жизни Вертолета
            helienginelife = 100; //исправность двигателя Вертолета
            fuelrashod = 50.7f; // расход топлива
            manageability = 3f;// управляемость //5 это ИНЕРЦИЯ
            maxangle = 70; // Максимальный угол атаки
            helifuelmax = 1300; // Максимальное топливо в баках
            maxboost = 9250; // максимальное ускорение от двигателя //11250
            holdOborotMotora = 12000; // Холостые обороты мотора

            maxenginespeed = 50000; //Максимальные обороты двигателя
            enginespeedlimit = 45000; //Предельные обороты двигателя

            weaponPositionOrigin = new Vector2f(0, 35); //Позиция подвесок оружия

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
            collider = new ConvexShape(8);
            collider.SetPoint(0, new Vector2f(-98, 5));
            collider.SetPoint(1, new Vector2f(-72, 14));
            collider.SetPoint(2, new Vector2f(-24, 14));
            collider.SetPoint(3, new Vector2f(23, 11));
            collider.SetPoint(4, new Vector2f(49, 25));
            collider.SetPoint(5, new Vector2f(50, 36));
            collider.SetPoint(6, new Vector2f(-13, 34));
            collider.SetPoint(7, new Vector2f(-79, 23));
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
            collider.FillColor = Color.Green;

            marker = new Marker(collider, Color.Red, 3);

        }

        public override void Update()
        {
            base.Update();

            //marker.Update();
            //Program.window.Draw(collider);

        }
    }
}












   
