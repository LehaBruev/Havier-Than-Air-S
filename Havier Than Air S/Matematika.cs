using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Havier_Than_Air_S
{
    static public class Matematika
    {
        public static Vector2f vectorGeneral = new Vector2f(1,0);
        

        // Принимает Точку_01
        // Принимает Точку_02
        // Возвращает дистанцию между точками
        static public float searchdistance(Vector2f point_1, Vector2f point_2) // Вычисление расстояния между двумя точками
        {
            float distance = (float)Math.Sqrt((point_1.X - point_2.X) * (point_1.X - point_2.X) + (point_1.Y - point_2.Y) * (point_1.Y - point_2.Y));

            return distance;
        }


        // Принимает угол до цели ПРАВОЕ = 0. 
        // Принимает дистанцию до цели 
        // Возвращает уточненные координаты Х и У (cos, sin)
        // (searchline длина прицела, ракеты (расстояние без углов до крайней точки))
        static public Vector2f searchLocalVector(float searchAngle, float searchLine) 
        {
            const float pi = 3.14f;
            float rad = searchAngle / 180 * pi; //Радиальный угол
            
            // вычисление x
            double cos = Math.Cos(rad); //косинус а
            double cos2 = Math.Sqrt(cos * cos);
            double xside = searchLine * cos2;
            float searchA = (float)xside; // вертикальная поправка для X
            if (270 > searchAngle && searchAngle > 90 || -270 < searchAngle && searchAngle < -90) searchA = -searchA;

            // вычисление y
            double sin = Math.Sin(rad); //синус а
            double sin2 = Math.Sqrt(sin * sin);
            double yside = searchLine * sin2;
            float searchB = (float)yside;//перевод во float, горизонтальная поправка для Y
            if ((360 > searchAngle && searchAngle > 180) || (0>searchAngle && searchAngle>-180)) searchB = -searchB;

         
            return new Vector2f(searchA, searchB);
        }


        // Принимает вектор
        // Возвращает угол наклона вектора
        // (Ноль отсчитывается от горизонтальной линии врпаво)
        static public float AngleOfVector(Vector2f vector)
        {
            float angle;

            double podval = (Math.Sqrt(vectorGeneral.X * vectorGeneral.X + vectorGeneral.Y * vectorGeneral.Y) *
            Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y));

            if (podval == 0)
            {
                return 0;
            }

            double cos = (vectorGeneral.X * vector.X + vectorGeneral.Y * vector.Y) / podval;

            angle = 180*(float)Math.Acos(cos)/3.14f;

            if(Math.Sign((float)vector.Y)<0)
            {
                // angle = 180 + (180 - angle);
                angle = -angle;
            }

            return angle;
        }

        // Пересечение двух линий
        // а = вектор1
        // b = вектор2
        static public bool Intersection(double ax1, double ay1,
                                        double ax2, double ay2,
                                        double bx1, double by1,
                                        double bx2, double by2)
        {
            double v1, v2, v3, v4;
            v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
            v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
            v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
            v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);
            bool res = (v1 * v2 < 0) && (v3 * v4 < 0);
            return res;
        }


        // Принимает origin дочернего объекта
        // Принимает угол материнского объекта
        // Возвращает локальную координату дочерней точки
        static public Vector2f LocalPointOfRotationObject(Vector2f DaughterOrigin, float MotherAngle)
        {
            float dist = searchdistance(new Vector2f(0,0), DaughterOrigin); // дистанция до точки
            float ang = AngleOfVector(DaughterOrigin);  // угол к точке

            Vector2f localCoordinate = searchLocalVector(ang + MotherAngle, dist);

            return localCoordinate;
        }


        // Принимает позицию материнского объекта
        // Принимает origin точки на материнском объекте
        // Принимает угол наклона материнского объекта
        // Возвращает глобальную координату точки на материнском объекте

        static public Vector2f GlobalPointOfLocalPoint(Vector2f MotherPos, Vector2f DoterOrigin, float MotherAngle)
        {
            // Дистанция от MotherOrigin До DoterOrigin
           float distance =  searchdistance(new Vector2f(0, 0), DoterOrigin);
           float angle = AngleOfVector(DoterOrigin);

            Vector2f localCoordinate = searchLocalVector(angle + MotherAngle, distance);

            return (MotherPos + localCoordinate);
        }



    }
}
