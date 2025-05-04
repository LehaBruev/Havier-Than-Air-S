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

        static public float searchdistance(Vector2i point_1, Vector2i point_2) // Вычисление расстояния между двумя точками
        {
            float distance = (float)Math.Sqrt((point_1.X - point_2.X) * (point_1.X - point_2.X) + (point_1.Y - point_2.Y) * (point_1.Y - point_2.Y));

            return distance;
        }



        // Поулучает дистанцию до цели и угол наклона ПРАВОЕ = 0. 
        // Возвращает добавочные координаты на Х и У
        //searchline длина прицела, ракеты (расстояние без углов до крайней точки)
        //вычисляем поправки координат синусом и косинусом стороны А и Б прямоугольника ()
        static public Vector2f searchAB(float searchangle, float searchline) 
        {
            const float pi = 3.14f;
            float rad = searchangle / 180 * pi; //Радиальный угол
            
            // вычисление x
            double cos = Math.Cos(rad); //косинус а
            double cos2 = Math.Sqrt(cos * cos);
            double xside = searchline * cos2;
            float searchA = (float)xside; // вертикальная поправка для X
            if (270 > searchangle && searchangle > 90) searchA = -searchA;

            // вычисление y
            double sin = Math.Sin(rad); //синус а
            double sin2 = Math.Sqrt(sin * sin);
            double yside = searchline * sin2;
            float searchB = (float)yside;//перевод во float, горизонтальная поправка для Y
            if ((360 > searchangle && searchangle > 180) || (0>searchangle && searchangle>-180)) searchB = -searchB;

         
            return new Vector2f(searchA, searchB);
        }

        static public float AngleVector(Vector2f vector)
        {
            float angle;

            double podval = (Math.Sqrt(vectorGeneral.X * vectorGeneral.X + vectorGeneral.Y * vectorGeneral.Y) *
            Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y));

            double cos = (vectorGeneral.X * vector.X + vectorGeneral.Y * vector.Y) / podval;

            angle = 180*(float)Math.Acos(cos)/3.14f;

            if(Math.Sign(vector.Y)<0)
            {
                // angle = 180 + (180 - angle);
                angle = -angle;
            }

            return angle;
        }

        // Пересечение
        static public bool Intersection(double ax1, double ay1, double ax2, double ay2, double bx1, double by1, double bx2, double by2)
        {
            double v1, v2, v3, v4;
            v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
            v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
            v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
            v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);
            bool res = (v1 * v2 < 0) && (v3 * v4 < 0);
            return res;
        }

    }
}
