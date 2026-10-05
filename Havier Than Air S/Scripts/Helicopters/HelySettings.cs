using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class HelySettings
    {
        /*
        Пустой: 2363 кг.
        Максимальная взлётная масса: 4310 кг.
        Масса груза на внешней подвеске: 1759 кг.
        Внутренний запас топлива: 840 кг.
        Объем баков 1250л по 850гр
        Полезная нагрузка: 1360 - 1815 - 3000кг
        обороты двигателя 19500
        */

        // Картинка вертолета

        public string textureName = "Images\\uh61.png";
        public Vector2f spriteScale = new Vector2f(0.6f, 0.6f);
        public Vector2f spriteOrigin = new Vector2f(175, -10);

        //Настройки верталета
        public float maxpowery = 300000; //Максимальная сила влияет на вертолет
        public float maxpowerx = 30000; // 
        public float shagRUD = 0.25f; // шаг увеличения мощности двигателя
        public float maxShagAngle = 1.5f; // шаг изменения угла атаки
        public float shagAngleSpeed = 10f; // отклик рукоятки угла
        public float maxspeedhor = 100;
        public float maxspeedvert = 500;
        public float maxheigh = 575; // потолок полета
        public Vector2f speedxmax = new Vector2f(6f, 3);
        public Vector2f speedMin = new Vector2f(0.001f, 0.015f);
        public float Weight = 2363; // вес машины
        public float bladesEffectiveness = 3f; // эффективность лопастей

        //Характеристики мотора и проч
        public float helilifemax = 300;// максимальные жизни Вертолета
        public float fuelrashod = 0.1f; // расход топлива
        public float maxangle = 60; // Максимальный угол атаки
        public float helifuelmax = 850; // Максимальное топливо в баках
        public float engineMaxPower = 55250; // максимальное ускорение от двигателя //11250
        public float holdRPM = 12000; // Холостые обороты мотора

        public float maxRPM = 20000; //Максимальные обороты двигателя
        public float RPMLimit = 19500; //Предельные обороты двигателя

        //Weapons
        public Vector2f[] weaponPositionsOrigins = new Vector2f[2]
                        { new Vector2f(-9, 35), // подвески
                         new Vector2f(-6, 35) }; // носовая пушка
        public int bulletsCount = 250;
        float bulletWeight = 0.2f;
        public int NRrocketsCount = 16;
        float NRrocketWeight = 100;
        public int SNRrocketsCount = 4;
        float SNRrocketWeight = 200;


        //Верхний винт
        public Vector2f topVintPositionOrigin = new Vector2f();

        //Задний винт
        Sprite rearVintSprite;
        public Vector2f rearVintPositionOrigin = new Vector2f(-104, 8);

        public float fuelWeight = 0.85f; //вес топл

        //Детали
        public Vector2f[] DetalyPos;

        //GUN
        public Vector2f gunTrunkSize = new Vector2f(2, 20);
        public Vector2f gunTrunkOrigin = new Vector2f(1, 10);
        public Color gunTrunkColor = Color.Yellow;

        public float angleCorrectorForse = 10;
        public Vector2f centerOfMass = new Vector2f(0, 30); // Центр масс

        ConvexShape colliderConvexShape;
        protected Vector2f colliderOrigin = new Vector2f(0, 0);
        public ConvexShape SpawnColliders()
        {

            //Коллайдер вертолета
            colliderConvexShape = new ConvexShape(11);
            colliderConvexShape.SetPoint(0, new Vector2f(-104, 4));
            colliderConvexShape.SetPoint(1, new Vector2f(-87, 23));
            colliderConvexShape.SetPoint(2, new Vector2f(-28, 24));
            colliderConvexShape.SetPoint(3, new Vector2f(-24, 15));
            colliderConvexShape.SetPoint(4, new Vector2f(26, 15));
            colliderConvexShape.SetPoint(5, new Vector2f(40, 29));
            colliderConvexShape.SetPoint(6, new Vector2f(27, 44));
            colliderConvexShape.SetPoint(7, new Vector2f(-14, 45));
            colliderConvexShape.SetPoint(8, new Vector2f(-21, 35));
            colliderConvexShape.SetPoint(9, new Vector2f(-92, 27));
            colliderConvexShape.SetPoint(10, new Vector2f(-108, 8));
            colliderConvexShape.FillColor = Color.Yellow;
            colliderConvexShape.Origin = colliderOrigin;

            return colliderConvexShape;
            /*
            //Коллайдер винта
            topColliderConvexShape = new ConvexShape(2);
            topColliderConvexShape.SetPoint(0, new Vector2f(-79, -2));
            topColliderConvexShape.SetPoint(1, new Vector2f(75, -1));
            topColliderConvexShape.FillColor = Color.Yellow;

            marker = new Marker(topColliderConvexShape, Color.Red, 3);
            */
        }


    }
}
