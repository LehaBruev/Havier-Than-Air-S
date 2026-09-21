using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{

    public enum Layer
    {
        playerProjectiles,
        enemyProjectiles,
        playerColliders,
        enemyColliders,
        groundColliders
    }


    public class Collisions
    {
        // Два набора точек
        Vector2f[] points1;
        Vector2f[] points2;

        public Vector2f[,] CheckShapesForCollision(Shape Shape1, Shape Shape2) //гора вертолет
        {
            points1 = GetShapePoints(Shape1);
            points2 = GetShapePoints(Shape2);

            Vector2f[,] peresechenie = CheckColisions(points1, points2);
            return peresechenie;

        }

        public Vector2f[] GetShapePoints(Shape shape)
        {
            Vector2f[] points = new Vector2f[shape.GetPointCount()];
            for (int i = 0;i< shape.GetPointCount(); i++)
            {
                // Vector2f c = new Vector2f(Program.offset)
                points[i] = shape.Position  + Matematika.LocalPointOfRotationObject( shape.GetPoint((uint)i) - shape.Origin,
                                                                    shape.Rotation);//shape.Rotation
            }
            return points;
        }
      


        private Vector2f[,] CheckColisions(Vector2f[] pointsToCheck1, Vector2f[] pointsToCheck2) // гора вертолет
        {
            
            Vector2f[,] intersectionsOld = new Vector2f[0,2]; //Массив двумерный, запись значений
            Vector2f[,] intersectionsReal = intersectionsOld; //Массив двумерный, перезапись значений

            int numerator1 = 0; // Номератор для перебора точек в первой фигуре
            int numerator2 = 0; // Номератор для перебора точек во второй фигуре
            bool intersected = false;
            for (int i = 0; i < pointsToCheck1.Length; i++) // Подбор грани из первой фигуры
            {
                if (i == pointsToCheck1.Length - 1) numerator1 = 0; //Проверка на последнюю точку в массиве фигуры
                else numerator1 = i + 1;


                for (int k = 0; k < pointsToCheck2.Length; k++) //Подбор грани из второй фигуры
                {
                    if (k == pointsToCheck2.Length - 1) numerator2 = 0; //Проверка на последнюю точку в массиве фигуры
                    else numerator2 = k + 1;

                    //Стандартная проверка пересечения
                    intersected = Matematika.Intersection(pointsToCheck1[i].X, pointsToCheck1[i].Y,
                                     pointsToCheck1[numerator1].X, pointsToCheck1[numerator1].Y,
                                     pointsToCheck2[k].X, pointsToCheck2[k].Y,
                                     pointsToCheck2[numerator2].X, pointsToCheck2[numerator2].Y);

                    if (intersected) // Столкновение граней есть
                    {
                        intersectionsReal = new Vector2f[intersectionsOld.GetLength(0)+1, 2]; // Задается размер массива
                        
                        for (int n = 0; n < intersectionsOld.GetLength(0);n++)
                        {
                            intersectionsReal[n, 0] = intersectionsOld[n, 0];
                            intersectionsReal[n, 1] = intersectionsOld[n, 1];
                        }
                        
                        intersectionsReal[intersectionsOld.GetLength(0), 0] = new Vector2f(i, numerator1); //в 1 добавляются номера точек грани первой фигуры
                        intersectionsReal[intersectionsOld.GetLength(0), 1] = new Vector2f(k, numerator2); //в 2 добавляются номера точек грани второй фигуры

                        intersectionsOld = intersectionsReal; //Сохранение массива точек для последующего добавления
                        
                    }
                }

            }

            return intersectionsReal;
        }

        

        public void Update()
        {
            
        }


        public void CheckAllColliders()
        {

        }

    }
}
