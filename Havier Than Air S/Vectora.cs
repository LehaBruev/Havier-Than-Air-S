using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace Havier_Than_Air_S
{
    static public class Vectora
    {
        //ПринимаетНомера точек на фигуре
        static public Vector2f VectorToCenterGranyOfConvex(Vector2f numOfPoints,ConvexShape colliderConvexShape)
        {
            //Номера точки
            int point_01 = (int)numOfPoints.X;
            int point_02 = (int)numOfPoints.Y;

            //Координаты точек
            Vector2f point_Vector_01 = colliderConvexShape.GetPoint((uint)point_01);
            Vector2f point_Vector_02 = colliderConvexShape.GetPoint((uint)point_02);

            //Центр вектора
            Vector2f g_01 = new Vector2f((point_Vector_01.X + point_Vector_02.X) / 2,
                                         (point_Vector_01.Y + point_Vector_02.Y) / 2);

            return g_01;
        }
    

        static public Vector2f MirrorVector(Vector2f pregrada,Vector2f workVector)
        {
            //Получить вектор прикрученный к нолю из двух точек
            // Вектор препятствие
            Vector2f pregrada_t1 = new Vector2f(0, 0);
            //Vector2f pregrada_t2 = new Vector2f(-50,0);
            Vector2f pregrada_t2 = pregrada;
            Vector2f trueVectorPregrada = pregrada_t2;

            //Перенос точки отсчета вектора
            if (pregrada_t2.X < pregrada_t1.X)
            {
                trueVectorPregrada = new Vector2f(-pregrada_t2.X, pregrada_t2.Y);
            }
            if (pregrada_t2.Y < pregrada_t1.Y)
            {
                // trueVectorPregrada = new Vector2f(trueVectorPregrada.X, pregrada_t2.Y);
            }

            //Вектор противодействия инерции
            //1Длина вектора инерции
            float vectorInertiaDist = Matematika.searchdistance(new Vector2f(0, 0), workVector);
            //2Угол вектора инерции
            float angle1_inertia = Matematika.AngleOfVector(new Vector2f(workVector.X, -workVector.Y));
            //3угол наклона препятствия
            float angle2_grany = Matematika.AngleOfVector(trueVectorPregrada);
            //Разница углов
            float angle3 = angle1_inertia - angle2_grany;
            //Нормальный вектор
            Vector2f normalVector = Matematika.searchLocalVector(-angle3 + angle2_grany, vectorInertiaDist);
            //Новый вектор

            return normalVector;
        }
    }
}
