using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Havier_Than_Air_S
{
    static public class Matematika
    {

        static public float searchdistance(Vector2i point_1, Vector2i point_2) // Вычисление расстояния между двумя точками
        {
            float distance = (float)Math.Sqrt((point_1.X - point_2.X) * (point_1.X - point_2.X) + (point_1.Y - point_2.Y) * (point_1.Y - point_2.Y));

            return distance;
        }



        // Поулучает дистанцию до цели и угол наклона ПРАВОЕ = 0. 
        // Возвращает добавочные координаты на Х и У
        //вычисляем поправки координат синусом и косинусом стороны А и Б прямоугольника ()
        static public Vector2f searchAB(float searchangle, float searchline) 
        {
            const float pi = 3.14f;
            float rad = searchangle / 180 * pi; //Радиальный угол
            
            // вычисление x
            double cos = Math.Cos(rad); //косинус а
            double cos2 = Math.Sqrt(cos * cos);
            double xside = g * cos2;
            float searchA = (float)xside; // вертикальная поправка для X
            if (270 > searchangle && searchangle > 90) searchA = -searchA;

            // вычисление y
            double sin = Math.Sin(rad); //синус а
            double sin2 = Math.Sqrt(sin * sin);
            double g = searchline; //длина прицела, ракеты (расстояние без углов до крайней точки)
            double yside = g * sin2;
            float searchB = (float)yside;//перевод во float, горизонтальная поправка для Y
            if (360 > searchangle && searchangle > 180) searchB = -searchB;

           
            
            return new Vector2f(searchA, searchB);
        }


    }
}
