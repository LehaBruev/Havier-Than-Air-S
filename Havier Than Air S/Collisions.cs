using System;
using System.Collections.Generic;
using System.Linq;
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
        groundCplliders
    }


    public class Collisions
    {
        
        RectangleShape collider1;
        RectangleShape collider2;
        Vertex naborTochek;
        ConvexShape naborTochekConvex;


        // Два набора точек
        Vector2f[] points1;
        Vector2f[] points2;

        // Маркер
        CircleShape marker;

        public Collisions()
        {

            //collider1
            collider1 = new RectangleShape(new Vector2f(70,50));
            collider1.FillColor = Color.White;
            collider1.Rotation = 35;
            collider1.Origin = new Vector2f(35,25);

            //collider2
            collider2 = new RectangleShape(new Vector2f(100, 100));
            collider2.FillColor = Color.Yellow;
            collider2.Rotation = 0;
            collider2.Position = new Vector2f(400,300);
            collider2.Origin = new Vector2f(50, 50);

            naborTochekConvex = new ConvexShape();
            naborTochekConvex.SetPointCount(6);
            naborTochekConvex.Position = new Vector2f(500, 300);
            naborTochekConvex.SetPoint(0, new Vector2f(10, 10));
            naborTochekConvex.SetPoint(1, new Vector2f(15, 70));
            naborTochekConvex.SetPoint(2, new Vector2f(50, 76));
            naborTochekConvex.SetPoint(3, new Vector2f(150, 100));
            naborTochekConvex.SetPoint(4, new Vector2f(200, 30));
            naborTochekConvex.SetPoint(5, new Vector2f(100, 5));

            naborTochekConvex.FillColor = Color.Green;
            naborTochekConvex.Rotation = 78;
            naborTochekConvex.Origin = new Vector2f(50,100);


            // Marker
            marker = new CircleShape();
            marker.FillColor = Color.Blue;
            marker.Radius = 5;
            marker.Origin = new Vector2f(5, 5);

        }


        public bool CheckShapesForCollision(Shape recShape1, Shape recShape2)
        {
            points1 = GetShapePoints(recShape1);
            //points2 = GetGrani(recShape2);
            points2 = GetShapePoints(naborTochekConvex);

            bool peresechenie = CheckColisions(points1, points2);


            Console.WriteLine(peresechenie);

            return peresechenie;

        }

        private Vector2f[] GetShapePoints(Shape collider)
        {
            Vector2f[] points = new Vector2f[collider.GetPointCount()];
            for (int i = 0;i< collider.GetPointCount(); i++)
            {
                points[i] = collider.GetPoint((uint)i) + collider.Position;
                points[i] = Matematika.LocalPointOfRotationObject(-collider.Origin + collider.GetPoint((uint)i), collider.Rotation) + collider.Position;
            }


            return points;
        }

        /*
        private Vector2f[] GetRectanglePoints(RectangleShape col)
        {
            Vector2f a = Matematika.LocalPointOfRotationObject(-col.Origin, col.Rotation) + col.Position;
            Vector2f b = Matematika.LocalPointOfRotationObject(-col.Origin + new Vector2f(col.Size.X,0), col.Rotation) + col.Position; 
            Vector2f c = Matematika.LocalPointOfRotationObject(-col.Origin.X + col.Size.X, -col.Origin.Y + col.Size.Y, col.Rotation) + col.Position;
            Vector2f d = Matematika.LocalPointOfRotationObject(-col.Origin.X, -col.Origin.Y + col.Size.Y, col.Rotation) + col.Position;

            
            return new Vector2f[]{ a, b, c, d };

            

        }
        */

        private bool CheckColisions(Vector2f[] pointsToCheck1, Vector2f[] pointsToCheck2)
        {
            int numerator1 = 0;
            int numerator2 = 0;
            bool intersected = false;
            for (int i = 0; i < pointsToCheck1.Length; i++)
            {
                if (i == pointsToCheck1.Length - 1) numerator1 = 0;
                else numerator1 = i + 1;


                for (int k = 0; k < pointsToCheck2.Length; k++)
                {
                    if (k == pointsToCheck2.Length - 1) numerator2 = 0;
                    else numerator2 = k + 1;

                    intersected = Matematika.Intersection(pointsToCheck1[i].X, pointsToCheck1[i].Y,
                                     pointsToCheck1[numerator1].X, pointsToCheck1[numerator1].Y,
                                     pointsToCheck2[k].X, pointsToCheck2[k].Y,
                                     pointsToCheck2[numerator2].X, pointsToCheck2[numerator2].Y);

                    if (intersected)
                    {
                        return true;
                    }

                }

            }

            return false;
        }



        public void Update()
        {
            collider1.Position = (Vector2f)Mouse.GetPosition(Program.window);
            CheckShapesForCollision(collider1, collider2);

            //Program.window.Draw(s1);
            Program.window.Draw(collider1);
            Program.window.Draw(collider2);
            Program.window.Draw(naborTochekConvex);
            
            // Маркеры
            for (int i = 0;i< points1.Length;i++)
            {
                marker.Position = points1[i];
                Program.window.Draw(marker);
            }

            for (int i = 0; i < points2.Length; i++)
            {
                marker.Position = points2[i];
                Program.window.Draw(marker);
            }


        }



















        /*
        // СТОЛКНОВЕНИЯ СТОЛКНОВЕНИЯ СТОЛКНОВЕНИЯ
        static void SearchConflict() // Поиск столкновений и коллизий ( Bx1 < Ax2 && Bx 2> Ax1 ) формула
        {


            //Взрывная волна
            for (int i = 0; i < Bang1.GetLength(1); i++)
            {
                if (Bang1[4, i] == 1 && Bang1[6, i] == 1)
                {
                    for (int j = 0; j < Tank1cicles.GetLength(1); j++) // рикошет по танкам
                    {
                        if (Tank1cicles[3, j] == 1)
                        {
                            if (Tank1cicles[1, j] < Bang1[1, i] + bangradius && Tank1cicles[1, j] + tank1sizex > Bang1[1, i] - bangradius && Tank1cicles[2, j] < Bang1[2, i] + bangradius && Tank1cicles[2, j] + tank1sizey > Bang1[2, i] - bangradius)
                            {


                                Tank1cicles[7, j] = Tank1cicles[7, j] - explosivepower;
                                if (Tank1cicles[7, j] <= 0) Tank1cicles[3, j] = 2; //танк уничтожен
                            }

                        }

                    } //танк

                    for (int j = 0; j < Buk1cicles.GetLength(1); j++) //рикошет по пво
                    {
                        if (Buk1cicles[3, j] == 1)
                        {
                            if (Buk1cicles[1, j] < Bang1[1, i] + bangradius && Buk1cicles[1, j] + buk1sizex > Bang1[1, i] - bangradius && Buk1cicles[2, j] < Bang1[2, i] + bangradius && Buk1cicles[2, j] + buk1sizey > Bang1[2, i] - bangradius)
                            {


                                Buk1cicles[7, j] = Buk1cicles[7, j] - (explosivepower + 5);
                                if (Buk1cicles[7, j] < 0) Buk1cicles[3, j] = 2;
                            }

                        }

                    } //бук1


                    if (playerx < Bang1[1, i] + bangradius && playerx + playerl > Bang1[1, i] - bangradius && playery < Bang1[2, i] + bangradius && playery + playerh > Bang1[2, i] - bangradius)
                    {


                        helilife = helilife - explosivepower * 2;
                        getdamages = getdamages + explosivepower * 2;
                        loterea();


                    }




                    Bang1[6, i] = 0;//волна прошла

                }


            }


            //Столкновение с ракетами А10
            for (int i = 0; i < R10.GetLongLength(1); i++)
            {
                if (R10[1, i] < playerx + playerl && R10[1, i] + a10rocketlenght > playerx && R10[2, i] < playery + playerh && R10[2, i] + a10rockethigh > playery && R10[4, i] == 2)
                {
                    // взрыв
                    for (int k = 0; k < Bang1.GetLength(1); k++)
                    {
                        if (Bang1[4, k] != 1)
                        {
                            Bang1[4, k] = 1;
                            Bang1[1, k] = playerx;
                            Bang1[2, k] = playery;
                            Bang1[5, k] = 1;
                            Bang1[6, i] = 1;
                            PlaySound(bangsound);
                            break;
                        }
                    }

                    playerx -= rnd1.Next(8, 20);
                    playery += rnd1.Next(-25, 5);
                    helilife -= a10rocketpower;
                    loterea();
                    getdamages = getdamages + a10rocketpower;
                    R10[4, i] = 0;

                }
            }

            //Столкновение Бук1 с ракетой NR
            for (int i = 0; i < R.GetLongLength(1); i++)
            {

                if (R[5, i] == 2)
                {
                    searchline = NRrocketlenght;
                    searchangle = R[3, i];
                    searchAB();

                    for (int j = 0; j < Buk1cicles.GetLength(1); j++)
                    {

                        if (R[1, i] < Buk1cicles[1, j] + buk1sizex && R[1, i] + searchA > Buk1cicles[1, j] && R[2, i] < Buk1cicles[2, j] + buk1sizey && R[2, i] + searchB > Buk1cicles[2, j])
                        {
                            PlaySound(collisionmet);
                            targetbingos = targetbingos + 1;
                            buk1destroyes = buk1destroyes + 1;
                            // взрыв
                            for (int k = 0; k < Bang1.GetLength(1); k++)
                            {
                                if (Bang1[4, k] != 1)
                                {
                                    Bang1[4, k] = 1;
                                    Bang1[1, k] = Buk1cicles[1, j];
                                    Bang1[2, k] = Buk1cicles[2, j];
                                    Bang1[5, k] = 1;
                                    Bang1[6, k] = 1;
                                    PlaySound(bangsound);
                                    break;
                                }
                            }


                            Buk1cicles[1, j] -= rnd1.Next(-15, 15);
                            R[5, i] = 0;
                            Buk1cicles[7, j] = Buk1cicles[7, j] - NRrocketpower;

                            if (Buk1cicles[7, j] <= 0 && Buk1cicles[3, j] == 1) { Buk1cicles[3, j] = 2; money = money + buk1reward; } //Бук уничтожен



                        }
                    }
                }


                //  Buk1cicles[1, i]
            }

            //Столкновение Ракет NR верталета МОДЕ 2 с Танком 1
            for (int i = 0; i < R.GetLongLength(1); i++)
            {
                if (R[5, i] == 2)
                {
                    searchline = NRrocketlenght;
                    searchangle = R[3, i];
                    searchAB();

                    for (int j = 0; j < Tank1cicles.GetLength(1); j++)
                    {

                        if (R[1, i] < Tank1cicles[1, j] + tank1sizex && R[1, i] + searchA > Tank1cicles[1, j] && R[2, i] < Tank1cicles[2, j] + tank1sizey && R[2, i] + searchB > Tank1cicles[2, j])
                        {
                            PlaySound(collisionmet);
                            targetbingos = targetbingos + 1;
                            tank1destroyes = tank1destroyes + 1;
                            // взрыв
                            for (int k = 0; k < Bang1.GetLength(1); k++)
                            {
                                if (Bang1[4, k] != 1)
                                {
                                    Bang1[4, k] = 1;
                                    Bang1[1, k] = R[1, i];
                                    Bang1[2, k] = R[2, i];
                                    Bang1[5, k] = 1;
                                    Bang1[6, k] = 1;
                                    PlaySound(bangsound);
                                    break;
                                }
                            }
                            Tank1cicles[1, j] -= rnd1.Next(-15, 15);
                            R[5, i] = 0;
                            Tank1cicles[7, j] = Tank1cicles[7, j] - NRrocketpower;

                            if (Tank1cicles[7, j] <= 0 && Tank1cicles[3, j] == 1) { Tank1cicles[3, j] = 2; money = money + tank1reward; } //танк уничтожен



                        }
                    }
                }
            }

            /* //Столкновение Ракет NR верталета МОДЕ 2 с БУК1
             for (int i = 0; i < R.GetLongLength(1); i++)
             {
                 if (R[5, i] == 2)
                 {
                     searchline = NRrocketlenght;
                     searchangle = R[3, i];
                     searchAB();

                     if (R[1, i] < bukx + buk1sizex && R[1, i] + searchA > bukx && R[2, i] < buky + buk1sizex && R[2, i] + searchB > buky)
                     {
                         PlaySound(collisionmet);
                         bukx -= rnd1.Next(-15, 15);
                         R[5, i] = 0;
                         buklife = buklife - NRrocketpower;
                         if (buklife < 0) buk1destroy = 1;

                     }
                 }
             }
            // FillCircle(playerx, playery,2); //верталет
            // FillCircle(playerx + playerl, playery + playerh,2); //верталет
            // FillCircle(bukx, buky, 10); //Бук
            // FillCircle(bukx+buk1sizex, buky+buk1sizey, 2); //Бук
              */
        /*

            //Столкновение Ракет NR верталета МОДЕ 2 с Землей
            for (int i = 0; i < R.GetLongLength(1); i++)
            {
                if (R[5, i] == 2)
                {
                    searchline = NRrocketlenght;
                    searchangle = R[3, i];
                    searchAB();

                    if (R[2, i] - 35 > ground && R[2, i] + searchB - 45 > ground)
                    {
                        // взрыв
                        for (int k = 0; k < Bang1.GetLength(1); k++)
                        {
                            if (Bang1[4, k] != 1)
                            {
                                Bang1[4, k] = 1;
                                Bang1[1, k] = R[1, i];
                                Bang1[2, k] = R[2, i];
                                Bang1[5, k] = 1;
                                Bang1[6, k] = 1;
                                PlaySound(bangsound);
                                break;
                            }
                        }
                        ////////// ВЗРЫВ ДОЛЖЕН ПОЯВИТЬСЯ ЗДЕСЬ!!! И ВОРОНКА ОТ ВЗРЫВА
                        R[5, i] = 0;



                    }
                }
            }



            // Столкновение Вертолета и БУК1 ПВО ракеты
            for (int i = 0; i < pvocicles.GetLength(1); i++)
            {
                if (pvocicles[3, i] == 1)
                {
                    if (pvocicles[1, i] < playerx + playerl && pvocicles[1, i] + pvolenght > playerx && pvocicles[2, i] < playery + playerh && pvocicles[2, i] + pvolenght > playery)
                    {

                        playery += 35;
                        helilife -= pvopower;
                        loterea();
                        getdamages = getdamages + pvopower;
                        PlaySound(collisionmet);
                        // взрыв
                        // взрыв
                        for (int k = 0; k < Bang1.GetLength(1); k++)
                        {
                            if (Bang1[4, k] != 1)
                            {
                                Bang1[4, k] = 1;
                                Bang1[1, k] = playerx;
                                Bang1[2, k] = playery;
                                Bang1[5, k] = 1;
                                Bang1[6, k] = 1;
                                PlaySound(bangsound);
                                break;
                            }
                        }

                        pvocicles[3, i] = 0;


                    }
                }
            }

            if (helilife <= 0) helidestroy = 1;

            // Приземление на площадку
            if (padx < playerx + playerl && padx + padsizex > playerx && pady < playery + playerh && pady + padsizey > playery && helidestroy != 1)
            {

                padswitch = 1;
                if (padstoreswitch != 1) PlaySound(helionpadsound, volume - 30);
            }
            else padswitch = 0;

            // FillCircle(padx, pady, 3);
            // FillCircle(padx+ padsizex, pady+ padsizey, 3);

        } 
*/
    }
}
