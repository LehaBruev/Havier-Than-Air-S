using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    internal class Matematika
    {









        static void searchdistance() // Вычисление расстояния между двумя точками
        {
            d = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

        }

        static void searchAB() //вычисляем поправки координат синусом и косинусом стороны А и Б прямоугольника (прицелы)
        {
            // вычисление y
            const float pi = 3.14f;
            float rad = searchangle / 180 * pi; //Радиальный угол
            double sin = Math.Sin(rad); //синус а
            double sin2 = Math.Sqrt(sin * sin);
            double g = searchline; //длина прицела, ракеты (расстояние без углов до крайней точки)
            double yside = g * sin2;
            searchB = (float)yside;//перевод во float, горизонтальная поправка для Y

            // вычисление x
            double cos = Math.Cos(rad); //косинус а
            double cos2 = Math.Sqrt(cos * cos);
            double xside = g * cos2;
            searchA = (float)xside; // вертикальная поправка для X

        }



        static void loterea()
        {

            int n = rnd1.Next(1, 8);

            if (n == 1) otkazhydrosis = 1;
            if (n == 2) otkazols = 1;
            if (n == 3) otkazpojardvig = 1;
            if (n == 4) helienginelife = helienginelife - rnd.Next(5, 10);
            if (n == 5) helienginelife = helienginelife - rnd.Next(10, 15);



        }




    }
}
