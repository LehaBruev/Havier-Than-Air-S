using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;

namespace Havier_Than_Air_S
{
    internal class EnemiManager
    {





        //ПРОТИВНИКИ
        //Переменные БУК1
        static float bukx = 1000;
        static float buky = 700;
        static float buk1sizey = 50; // высота
        static float buk1sizex = 80; // длина
        static float bukspeed = 1.5f; // длина
        static float bukhold = 0; // длина
        static float buklife = 500; // длина
        static float buk1maxquantity = 5; // длина

        static float buk1destroy = 0;
        static float bukcoursex = 350;

        //Параметры Штурмовика A10
        static float a10lenght = 100;
        static float a10high = 100;
        static float a10x = -300;
        static float a10y = 300;
        static float a10startx = 1500;
        static float a10starty = 200;
        static float a10speed = 3;
        static float a10ammo = 3;
        static float a10delay = 5; //Задержка между полетами штурмовиков
                                   // A10Rockets
        static int a10rocketquantity = 20; //количество ракет в А10
        static float a10rocketdmg = 27; // урон от ракет A10
        static float a10rockethigh = 15; // колайдер У ракет А10
        static float a10rocketlenght = 57; // коллайдер Х ракет А10
        static float a10rocketspeed = 5; // скорость ракеты А10
        static float a10rocketpower = 10;

        //Параметры ПВО
        static float pvox = 0;
        static float pvoy = 0;
        static float pvospeed = 2f;
        static float pvoangle = 0;
        static float pvoturnability = 3;
        static float pvolenght = 25;
        static float pvofuel = 900;
        static int bukactivated = 0;
        static int pvodirectionx = 1;
        static int pvodirectiony = 1;
        static int pvorocketdirection = 0; //Направление полета ракеты
        static float pvopower = 30; //Направление полета ракеты

        //Параметры Танка1
        static float tank1x = 300;
        static float tank1y = ground;
        static float tank1sizex = 82;
        static float tank1sizey = 30;
        static float tank1live = 250;
        static float tank1speed = 2;
        static float tank1cource = 790;
        static float tank1destroy = 0;
        static int tank1maxquantity = 62;

        //Параметры воздушный шар

        static float airballonsizex = 90;
        static float airballonsizey = 90;






        static void airballondraw()

        {

            for (int i = 0; i < airballonscicle.GetLength(0); i++)
            {
                if (airballonscicle[3, i] == 1)
                {
                    if (airballonscicle[4, i] < airballonscicle[1, i]) airballonscicle[1, i] = airballonscicle[1, i] - 0.5f;
                    if (airballonscicle[4, i] > airballonscicle[1, i]) airballonscicle[1, i] = airballonscicle[1, i] + 0.5f;
                    if (airballonscicle[5, i] < airballonscicle[2, i]) airballonscicle[2, i] = airballonscicle[2, i] - 0.5f;
                    if (airballonscicle[5, i] > airballonscicle[2, i]) airballonscicle[2, i] = airballonscicle[2, i] + 0.5f;

                    DrawSprite(uh61, airballonscicle[1, i] - 50, airballonscicle[2, i] - 50, 301, 569, 173, 180);

                }
            }

            for (int i = 0; i < airballonscicle.GetLength(0); i++)
            {
                //FillCircle(airballonscicle[1, i], airballonscicle[2, i], 2);
                //FillCircle(airballonscicle[1, i]+airballonsizex, airballonscicle[2, i]+airballonsizey, 2);
                if (airballonscicle[1, i] < playerx + playerl && airballonscicle[1, i] + airballonsizex > playerx && airballonscicle[2, i] < playery + playerh && airballonscicle[2, i] + airballonsizey > playery && helidestroy != 1)
                {
                    helilife = helilife - 11;
                    getdamages = getdamages + 11;
                    if (playerx < airballonscicle[1, i]) playerx = playerx - 35;
                    if (playerx > airballonscicle[1, i]) playerx = playerx + 35;
                    if (playery < airballonscicle[2, i]) playery = playery - 80;
                    if (playery > airballonscicle[2, i]) playery = playery + 70;
                    PlaySound(bangsound);

                }

            }

        }


        // Танк1
        static void tank1move()
        {
            //танки едут  // Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения,6=скорость)
            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1)
                {
                    if (Tank1cicles[1, i] + 3 < Tank1cicles[4, i]) { Tank1cicles[1, i] = Tank1cicles[1, i] + Tank1cicles[6, i]; PlaySound(tank1motorsound, volume - 30); } // цель справа
                    if (Tank1cicles[1, i] - 3 > Tank1cicles[4, i]) { Tank1cicles[1, i] = Tank1cicles[1, i] - Tank1cicles[6, i]; PlaySound(tank1motorsound, volume - 30); } // цель справа
                    if (Tank1cicles[1, i] < -150) { Tank1cicles[3, i] = 0; basedurability = basedurability - 1; PlaySound(minus); }
                }


            }


        }
        static void tank1Draw() // Танк1 (1=x танка, 2=y танка, 3=проявлен, 4=х назначения, 5=у назначения, 6=жизни танка) [1=проявлен 2=побдит]
        {

            for (int i = 0; i < Tank1cicles.GetLength(1); i++)
            {
                if (Tank1cicles[3, i] == 1) // танк целый
                {
                    PlaySound(tank1motorsound2, volume);
                    DrawSprite(uh61, Tank1cicles[1, i] - 30, Tank1cicles[2, i], 8, 462, 120, 42); // спрайт танка
                                                                                                  //FillCircle(Tank1cicles[1, i], Tank1cicles[2, i], 3);
                                                                                                  //FillCircle(Tank1cicles[1, i] + tank1sizex, Tank1cicles[2, i] + tank1sizey, 3);
                    SetFillColor(Color.Yellow);
                    DrawText((int)Tank1cicles[1, i] - 20, (int)Tank1cicles[2, i] - 20, "" + Tank1cicles[7, i], 12);
                }

                if (Tank1cicles[3, i] == 2) //танк разрушен
                {

                    DrawSprite(uh61, Tank1cicles[1, i] - 30, Tank1cicles[2, i], 135, 519, 114, 35); // спрайт танка разрушенного
                                                                                                    //FillCircle(Tank1cicles[1, i], Tank1cicles[2, i], 3);
                                                                                                    // FillCircle(Tank1cicles[1, i] + tank1sizex, Tank1cicles[2, i] + tank1sizey, 3);

                }

            }

        }


        //Бук1

        static void buk1Move() // Бук перемещение гусеничной платформы + ЗАПУСК ПВО БУК1
        {// Бук1 (1=x бука , 2=y бука, 3=проявлен, 4=х назначения, 5=у назначения, 6=скорость бука, 7=жизни, 8= делэй запус

            for (int i = 0; i < Buk1cicles.GetLength(1); i++)
            {
                if (Buk1cicles[3, i] == 1) Buk1cicles[8, i] = Buk1cicles[8, i] - 1; //delay
                if (Buk1cicles[8, i] == 100 && helilife > 0)
                {
                    bukactivated = 1;
                    PlaySound(MissileMissile);
                    PlaySound(pvosound);
                    pvox = Buk1cicles[1, i];
                    pvoy = Buk1cicles[2, i];
                    pvoangle = 45;
                    pvofuel = 2000;

                }// запуск ракеты

                if (Buk1cicles[3, i] == 1 && Buk1cicles[8, i] <= 0) //
                {

                    if (Buk1cicles[1, i] + 3 < Buk1cicles[4, i]) Buk1cicles[1, i] = Buk1cicles[1, i] + Buk1cicles[6, i];
                    if (Buk1cicles[1, i] - 3 > Buk1cicles[4, i]) Buk1cicles[1, i] = Buk1cicles[1, i] - Buk1cicles[6, i];

                }
                //задержка перед пуском
                if (Buk1cicles[1, i] <= Buk1cicles[4, i] + 4 && Buk1cicles[1, i] >= Buk1cicles[4, i] - 4 && Buk1cicles[8, i] <= 0)
                {

                    Buk1cicles[8, i] = rnd1.Next(300, 500);
                    Buk1cicles[4, i] = rnd1.Next(150, 1000);
                }




            }



        }
        // Бук1 отрисовка
        static void buk1Draw()
        {

            for (int i = 0; i < Buk1cicles.GetLength(1); i++)
            {
                if (Buk1cicles[3, i] == 2)
                {
                    DrawSprite(uh61, Buk1cicles[1, i], Buk1cicles[2, i] - 3, 30, 391, 89, 65);
                }


            }


            for (int i = 0; i < Buk1cicles.GetLength(1); i++)
            {

                if (Buk1cicles[3, i] == 1)
                {
                    DrawSprite(uh61, Buk1cicles[1, i], Buk1cicles[2, i] - 3, 18, 304, 109, 72);
                    if (sounds == 1) PlaySound(radaractive, volume - 20);
                    SetFillColor(Color.Yellow);
                    DrawText((int)Buk1cicles[1, i] - 20, (int)Buk1cicles[2, i] - 20, "" + Buk1cicles[7, i], 12);
                }


            }


        }

        // ПВО
        static void pvomoveANDdraw() //  ракета ПВО БУК1
        {
            // ПВО ракета(1 = x пво , 2 = y пво, 3 = проявлен, 4 = х назначения, 5 = у назначения, 6 = скорость пво, 7 = топливо, 8 = угол полета)

            // bukactivated

            if (bukactivated == 1) // пуск ПВО и передача параметров от Бука
            {
                for (int i = 0; i < pvocicles.GetLength(1); i++)
                {
                    if (pvocicles[3, i] != 1)
                    {
                        bukactivated = 0;
                        //МОЖНО ВСТАВИТЬ ЗВУК ЗАПУСКА
                        pvocicles[3, i] = 1;
                        pvocicles[1, i] = pvox;
                        pvocicles[2, i] = pvoy;
                        pvocicles[7, i] = pvofuel;
                        pvocicles[8, i] = pvoangle;
                        break;

                    }
                }
            }

            for (int i = 0; i < pvocicles.GetLength(1); i++)
            {
                if (pvocicles[3, i] == 1)
                {
                    PlaySound(MasterWarningsound);

                    searchline = pvolenght;
                    searchangle = pvocicles[8, i];
                    searchAB();

                    //отрисовка ПВО
                    SetFillColor(Color.Red); // Цвет ракеты ПВО
                    if (pvocicles[8, i] >= 0 && pvocicles[8, i] < 90)
                    {
                        DrawLine(pvocicles[1, i], pvocicles[2, i], pvocicles[1, i] + searchB, pvocicles[2, i] - searchA, 5);
                    }
                    if (pvocicles[8, i] >= 90 && pvocicles[8, i] < 180)
                    {
                        DrawLine(pvocicles[1, i], pvocicles[2, i], pvocicles[1, i] + searchB, pvocicles[2, i] + searchA, 5);
                    }
                    if (pvocicles[8, i] >= 180 && pvocicles[8, i] < 270)
                    {
                        DrawLine(pvocicles[1, i], pvocicles[2, i], pvocicles[1, i] - searchB, pvocicles[2, i] + searchA, 5);
                    }
                    if (pvocicles[8, i] >= 270 && pvocicles[8, i] < 360)
                    {
                        DrawLine(pvocicles[1, i], pvocicles[2, i], pvocicles[1, i] - searchB, pvocicles[2, i] - searchA, 5);
                    }



                    //изменение положения ракеты
                    searchline = pvospeed;
                    searchAB();

                    if (pvocicles[8, i] >= 0 && pvocicles[8, i] < 90)
                    {
                        pvocicles[1, i] = pvocicles[1, i] + searchB;
                        pvocicles[2, i] = pvocicles[2, i] - searchA;
                    }
                    if (pvocicles[8, i] >= 90 && pvocicles[8, i] < 180)
                    {
                        pvocicles[1, i] = pvocicles[1, i] + searchB;
                        pvocicles[2, i] = pvocicles[2, i] + searchA;
                    }
                    if (pvocicles[8, i] >= 180 && pvocicles[8, i] < 270)
                    {
                        pvocicles[1, i] = pvocicles[1, i] - searchB;
                        pvocicles[2, i] = pvocicles[2, i] + searchA;
                    }
                    if (pvocicles[8, i] >= 270 && pvocicles[8, i] < 360)
                    {
                        pvocicles[1, i] = pvocicles[1, i] - searchB;
                        pvocicles[2, i] = pvocicles[2, i] - searchA;
                    }

                    pvocicles[7, i] = pvocicles[7, i] - 1;

                    // Изменение угла ПВО
                    //поиск диагонали
                    x1 = playerx;
                    x2 = pvocicles[1, i];
                    y1 = playery;
                    y2 = pvocicles[2, i];
                    searchdistance();
                    searchline = (float)d;
                    //Ищем угол до цели

                    if (playerx <= pvocicles[1, i])
                    {
                        aimangle = (float)((-playery + pvocicles[2, i]) / searchline) * 90 + 270; //sin
                    }
                    if (playerx > pvocicles[1, i])
                    {
                        aimangle = 90 + (float)((playery - pvocicles[2, i]) / searchline) * 90; //sin

                    }

                    //if (GetKey(Keyboard.Key.Up) == true) pvoangle = pvoangle + 5;
                    //if (GetKey(Keyboard.Key.Down) == true) pvoangle = pvoangle - 5;

                    if (pvocicles[8, i] < aimangle)
                    {


                        if (pvocicles[8, i] + (360 - aimangle) < 360 - (360 - aimangle) - pvocicles[8, i])
                        {


                            if (pvocicles[8, i] <= 0) pvocicles[8, i] = pvocicles[8, i] + 360;
                            pvocicles[8, i] = pvocicles[8, i] - pvoturnability;

                        }
                        if (pvocicles[8, i] + (360 - aimangle) > 360 - (360 - aimangle) - pvocicles[8, i])
                        {

                            if (pvocicles[8, i] >= 360) pvocicles[8, i] = pvocicles[8, i] - 360;
                            pvocicles[8, i] = pvocicles[8, i] + pvoturnability;

                        }
                    }
                    if (pvocicles[8, i] >= aimangle)
                    {

                        if (aimangle + (360 - pvocicles[8, i]) < 360 - (360 - pvocicles[8, i]) - aimangle)
                        {

                            if (pvocicles[8, i] >= 360) pvocicles[8, i] = pvocicles[8, i] - 360;
                            pvocicles[8, i] = pvocicles[8, i] + pvoturnability;

                        }

                        if (aimangle + (360 - pvocicles[8, i]) > 360 - (360 - pvocicles[8, i]) - aimangle)
                        {


                            if (pvocicles[8, i] <= 0) pvocicles[8, i] = pvocicles[8, i] + 360;
                            pvocicles[8, i] = pvocicles[8, i] - pvoturnability;

                        }
                    }


                }
                if (pvocicles[7, i] < 0) pvocicles[3, i] = 0;
            }



        }


        // ПРОТИВНИКИ ПРОТИВНИКИ ПРОТИВНИКИ


        static void a10move() // A10 движение отрисовка и запуск РАКЕТЫ
        {

            DrawSprite(uh61, a10x, a10y, 313, 438, 169, 39); // Самолет А10

            a10x = a10x - a10speed;

            for (int i = 0; i < R10.GetLength(1); i++)
            {
                if (R10[4, i] == 2)
                {

                    DrawSprite(uh61, R10[1, i], R10[2, i], 391, 362, 57, 15); // Ракета А10
                                                                              // Изменяем положение ракеты
                    R10[1, i] = R10[1, i] - a10rocketspeed;
                    if (R10[2, i] > R10[3, i]) R10[2, i] = R10[2, i] - rnd1.Next(1, 5);
                    if (R10[2, i] < R10[3, i]) R10[2, i] = R10[2, i] + rnd1.Next(1, 5);



                }

            }



        }

    }
}
