using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;

namespace Havier_Than_Air_S
{
    internal class Player
    {

        /*

        // ИГРОК
        static float startx = 50; //Начальная позиция игрока
        static float starty = 400; //Начальная позиция игрока
        static float playerh = 35; // высота вертолета
        static float playerl = 50; // длина вертолета
        static float maxpowery = 300000; //Максимальная сила влияет на вертолет
        static float maxpowerx = 30000; // 
        static float shagengine = 75; // шаг увеличения мощности двигателя
        static float shagAngle = 2; // шаг изменения угла атаки
        static float maxspeedhor = 50;
        static float maxspeedvert = 300;
        static float maxheigh = 575; // потолок полета



        static void PlayerDraw() // отрисовка Верталета
        {

            DrawSprite(uh61, padx, pady, 147, 603, 137, 66); // Верталетная площадка
                                                             //цветы

            if (helilife <= 0) DrawSprite(uh61, playerx - 41, playery - 17, 408, 101, 91, 43);
            else
            {
                if (angle >= 0 && angle <= 10) DrawSprite(uh61, playerx - 95, playery - 26, 0, 0, 130, 57);
                if (angle > 10 && angle <= 30) DrawSprite(uh61, playerx - 96, playery - 30, 0, 56, 127, 59);
                if (angle > 30 && angle <= 45) DrawSprite(uh61, playerx - 75, playery - 68, 23, 184, 105, 106);
                if (angle > 45 && angle <= 70) DrawSprite(uh61, playerx - 61, playery - 83, 150, 1, 93, 125);

                if (angle >= -15 && angle < 0) DrawSprite(uh61, playerx - 98, playery - 23, 403, 28, 134, 53);
                if (angle >= -30 && angle < -15) DrawSprite(uh61, playerx - 35, playery - 27, 272, 68, 127, 59);
                if (angle >= -45 && angle < -30) DrawSprite(uh61, playerx - 29, playery - 66, 277, 163, 103, 105);
                if (angle >= -70 && angle < -45) DrawSprite(uh61, playerx - 25, playery - 86, 160, 147, 79, 122);
            } //отрисовка спрайтов Вертолета

            FillCircle(playerx, playery, 3);


            // Отрисовка прицела МОДЕ 2
            if (gunmode == 2) // Оружие МОДЕ 2. Прицел.
            {

                //Вычисление поправок
                searchline = aimlehght + ritarandom - 1;
                searchangle = angle + ritarandom - 1;
                searchAB();

                if (angle > 0 && angle < 70)
                {
                    DrawSprite(uh61, playerx + searchA, playery + searchB * ritarandom, 305, 302, 35, 37);

                }
                if (angle > -70 && angle < -15)
                {
                    DrawSprite(uh61, playerx - searchA * ritarandom - 50, playery + searchB, 305, 302, 35, 37);

                }
                if (angle >= -15 && angle <= 0)
                {
                    DrawSprite(uh61, playerx + searchA, playery * ritarandom - searchB, 305, 302, 35, 37);
                }

            }// Отрисовка прицела МОДЕ 2

            // Мышка
            FillCircle(MouseX, MouseY, 3);
            if (gunmode == 3) DrawSprite(aiming, MouseX - 50, MouseY - 50);
            FillCircle(MouseX, MouseY, 3);
            //Вращение винта

            //звуки верталета
            //ПРЕДЕЛЬНАЯ ВЫСОТА
            if (enginespeed > enginespeedlimit)
            {
                PlaySound(helirotor4);
                enginespeed = enginespeed - 50;
                otkazsbrosoboroti = 1;


            } // в небе
            else otkazsbrosoboroti = 0;


            if (altitude > 50) PlaySound(helirotor1);
            if (altitude <= 50 && helistop != 1 && helidestroy != 1) PlaySound(helirotor2); // у земли

            if (helilife <= 0 && playery + 10 >= ground) DrawSprite(uh61, playerx - 570, playery - 540, 1685, 4, 705, 568);

            //цветы
            DrawSprite(uh61, 170, 700, 455, 165, 43, 37);
            DrawSprite(uh61, 200, 710, 455, 165, 43, 37);
            DrawSprite(uh61, 250, 690, 455, 165, 43, 37);
            // Верталетная площадка 


        }

        static void PlayerMove() // расчет движений Верталета
        {

            ratioenginespeed = helienginelife * 1.25f / 100;
            if (ratioenginespeed > 1) ratioenginespeed = 1;

            //Данные для учета столкновения с землей
            float s = speedy;

            //расчет плотности воздуха, на выходе получаем =airP
            altitude = (768 - playery) - (768 - ground);

            airP = (float)Math.Sqrt(playery) * 2 * 3;

            if (altitude > 0) flighttime = flighttime + 1;

            // Автопилот висение 
            if (GetKeyDown(Keyboard.Key.H) == true)
            {
                autopilotv = (768 - playery) - (768 - ground);
                int A = autopilotswitch;
                if (A == 1) autopilotswitch = 0;
                if (A == 0) autopilotswitch = 1;
            }
            if (autopilotswitch == 1)
            {

                if (altitude < autopilotv)
                {
                    if (enginespeed - gravityweight > 1000 || enginespeed - gravityweight < 1000)
                        enginespeed = enginespeed + shagengine;
                    else enginespeed = enginespeed + shagengine / 4;
                }
                if (altitude > autopilotv)
                {
                    if (enginespeed - gravityweight > 1000 || enginespeed - gravityweight < 1000)
                        enginespeed = enginespeed - shagengine;
                    else enginespeed = enginespeed + shagengine / 4;
                }
            }


            if (maxenginespeed < enginespeed) enginespeed = maxenginespeed;

            // вкл/выкл двигателя
            if (GetKeyDown(Keyboard.Key.I) == true)

            {

                int j = engineswitch;
                if (j == 1) engineswitch = 0;
                if (j == 0) engineswitch = 1;

                if (engineswitch == 1 && helifuel > 0 && helidestroy != 1)
                {
                    PlaySound(startenginesound);
                }

            }
            if (engineswitch == 0 || helifuel <= 0 || helidestroy == 1) //отключение двигателя
            {
                if (enginespeed > 0)
                {

                    enginespeed = enginespeed - 200;
                    if (helistop != 1)
                    {
                        helistop = 1;
                        PlaySound(stopengine);
                    }

                }
                if (enginespeed < 0) enginespeed = 0;
            }

            if (engineswitch == 1 && helifuel > 0 && helidestroy != 1)
            {
                if (enginespeed < 12000)
                {
                    enginespeed = enginespeed + shagengine / 2;
                    if (helistop == 1)
                    {
                        helistop = 0;

                    }
                }

            }

            //Расход топлива
            helifuel = helifuel - (enginespeed / 100) * (enginespeed / 100) / 1000000 * fuelrashod;
            fuelusedup = fuelusedup + (enginespeed / 100) * (enginespeed / 100) / 1000000 * fuelrashod;
            if (helifuel < 0) helifuel = 0;
            if (helifuel < 510 && helifuel > 507) PlaySound(kg500);
            if (helifuel < 810 && helifuel > 805) PlaySound(kg800);


            //ОСНОВНЫЕ ПАРАМЕТРЫ   ДВИЖЕНИЕ WSDA
            if (GetKey(Keyboard.Key.W) == true) enginespeed = (enginespeed + shagengine);
            if (enginespeed > maxenginespeed) enginespeed = maxenginespeed;
            if (GetKey(Keyboard.Key.S) == true) enginespeed = (enginespeed - shagengine * 1.5f);
            if (enginespeed < 0) enginespeed = 0;


            //расчет вертикальной скорости

            //расчет подъемной силы
            //Масса ракет
            int n = 0;
            for (int i = 0; i < R.GetLength(1); i++)
            {
                if (R[5, i] == 1)
                    n = n + 1;

            }
            //угол атаки уменьшает подъемную силу
            powery = (enginespeed * ratioenginespeed / 114 * airP) - gravityweight - helifuel * 6 - n * NRrocketweight; // подъемная сила

            boostv = powery / 200;       // вертиклаьное ускорение
            if (boostv > (maxenginespeed / 100 * 75)) boostv = maxboost;

            speedy = (boostv / 10); // вертикальная скорость

            playery = (playery - speedy);

            //ЗЕМЛЯ столкновение
            if (playery >= ground)
            {
                g = 1;

                playery = ground;
                speedx = 0;
                boostv = 0;
                powery = 0;
                speedy = 0;
                angle = 0;

            }
            if (g == 1)
            {
                if (s < -1) { helilife = helilife - 19; PlaySound(metal1, volume); getdamages = getdamages - 19; }
                if (s < -2) { helilife = helilife - 88; PlaySound(metal2); PlaySound(grass1); getdamages = getdamages - 89; loterea(); }
                if (helilife <= 0)
                {
                    helidestroy = 1;
                    if (bang1 == 1)
                    {
                        PlaySound(bangsound);
                        bang1 = 0;
                    }
                }
                g = 0;
            }

            // Расчет ГОРИЗОНТАЛЬНОГО ПОЛЕТА угол атаки
            // Вылет за зону полётов
            //Управление углом атаки
            if (GetKey(Keyboard.Key.D) == true) angle = (angle + shagAngle);
            if (angle > maxangle) angle = maxangle;
            if (GetKey(Keyboard.Key.A) == true) angle = (angle - shagAngle);
            if (angle < -maxangle) angle = -maxangle;

            speedx = speedx + enginespeed / 114 * airP / 100 * angle * DeltaTime / gravityweight * manageability; // ФОРМУЛА РАСЧЕТА ГОРИЗОНТАЛЬНОЙ СКОРОСТИ (ПОМЕНЯТЬ)
            if (speedx > speedxmax) speedx = speedxmax;
            if (speedx < -speedxmax) speedx = -speedxmax;


            playerx = playerx + speedx + wind;
            if (GetKeyDown(Keyboard.Key.V) == true)
            {
                float v = autopilotswitchX;
                if (v == 1) autopilotswitchX = 0;
                if (v == 0) autopilotswitchX = 1;

            }

            if (autopilotswitchX == 1)
            {
                if (angle > 0) angle -= 1;
                if (angle < 0) angle += 1;

            }
            //Включение автопилота возврата в зону полета АВТОПИЛОТЫ ЗОНЫ
            if (playerx >= 1025 && autopilotzonaswitch == 0) //верталет уходит вправо
            {
                autopilotzonaangle = -45;
                autopilotzonaswitch = 1;
                autopilotzonax = 1000;
                PlaySound(proverupravlenie);

            }
            if (playerx <= -5 && autopilotzonaswitch == 0) //верталет уходит влево
            {
                autopilotzonaangle = 45;
                autopilotzonaswitch = 2;
                autopilotzonax = 50;
                PlaySound(proverupravlenie);

            }
            // Автопилот возврата в зону полета
            if (autopilotzonaswitch == 1)
            {
                if (autopilotzonax < playerx) angle = angle - 1f;
                if (autopilotzonax > playerx)
                {
                    if (angle > autopilotzonaangle) angle = angle + 0.5f;
                    if (angle < autopilotzonaangle) angle = angle - 0.5f;
                    if (angle < autopilotzonaangle + 1 || angle < autopilotzonaangle - 1)
                    {
                        angle = autopilotzonaangle;
                        autopilotzonaswitch = 0;
                    }
                }


            }
            if (autopilotzonaswitch == 2)
            {
                if (autopilotzonax > playerx) angle = angle + 1f;
                if (autopilotzonax < playerx)
                {
                    if (angle < autopilotzonaangle) angle = angle + 0.5f;
                    if (angle > autopilotzonaangle) angle = angle - 0.5f;
                    if (angle > autopilotzonaangle + 1 || angle < autopilotzonaangle - 1)
                    {
                        angle = autopilotzonaangle;
                        autopilotzonaswitch = 0;
                    }
                }


            }


            //Вывод параметров в консоль. Информация



        }




        */



    }
}
