using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{
    internal class MaiMenuController
    {








        /*
        static void mainmenuDraw()
        {

            DrawSprite(maimenutexture, 0, 0);

            if (mainmenuSwitch == 1) //switch 1

            {

                SetFillColor(Color.Green);
                DrawText(220, 330, "1. Get pilot license", 18);
                DrawText(222, 370, "2. Missions", 18);
                DrawText(224, 410, "3. Free flight ", 18);

                //Мышь на меню 1
                if (MouseX > 217 && MouseX < 423 && MouseY > 332 && MouseY < 353)
                {
                    SetFillColor(Color.Red);
                    DrawText(220, 330, "1. Get pilot license", 18);
                    if (levelchoise != 1) PlaySound(click);
                    levelchoise = 1;
                    Delay(2);
                }
                else //Меню на 2
                {
                    if (MouseX > 221 && MouseX < 341 && MouseY > 369 && MouseY < 388)
                    {
                        SetFillColor(Color.Red);
                        DrawText(222, 370, "2. Missions", 18);
                        if (levelchoise != 2) PlaySound(click);
                        levelchoise = 2;
                        Delay(2);
                    }
                    else //Меню на 3
                    {
                        if (MouseX > 221 && MouseX < 370 && MouseY > 410 && MouseY < 430)
                        {
                            SetFillColor(Color.Red);
                            DrawText(224, 410, "3. Free flight ", 18);
                            if (levelchoise != 3) PlaySound(click);
                            levelchoise = 3;
                            Delay(2);
                        }
                        else
                        {
                            levelchoise = 0;
                            Delay(2);
                        }
                    }
                }
            } // switch 1
            if (mainmenuSwitch == 2)
            {

                SetFillColor(Color.Green);
                DrawText(220, 330, "1. Continium", 18);
                DrawText(232, 410, "2. Exit", 18);

                if (MouseX > 217 && MouseX < 328 && MouseY > 327 && MouseY < 353) // contin
                {
                    SetFillColor(Color.Red);
                    DrawText(220, 330, "1. Continium", 18);
                    if (menuchoise2 != 1) PlaySound(click);
                    menuchoise2 = 1;
                    Delay(2);
                }
                else //Меню на exit
                {
                    if (MouseX > 223 && MouseX < 296 && MouseY > 407 && MouseY < 431) // exit
                    {
                        SetFillColor(Color.Red);
                        DrawText(232, 410, "2. Exit", 18);
                        if (menuchoise2 != 2) PlaySound(click);
                        menuchoise2 = 2;
                        Delay(2);
                    }

                }

            }

        }



        //РЕЗУЛЬТАТЫ РЕЗУЛЬТАТЫ РЕЗУЛЬТАТЫ
        static void resultsDraw()
        {

            DrawSprite(scoresprite, 0, 0);
            SetFillColor(Color.White);

            DrawText(500, 310, "Results", 30);
            DrawText(400, 345, "Score: " + money, 20); //score
            DrawText(400, 365, "Flight Time: " + flighttime, 20); //полетное время
            DrawText(400, 385, "NR ракет запущено: " + NRrocketslaunched, 20);
            DrawText(400, 405, "Попаданий ракетами: " + targetbingos, 20);
            DrawText(400, 425, "Поражено ПВО: " + buk1destroyes, 20);
            DrawText(400, 445, "Поражено Танков: " + tank1destroyes, 20);
            DrawText(400, 465, "Израсходовано топлива: " + fuelusedup, 20);
            DrawText(400, 485, "Получено повреждений: " + getdamages, 20);

            DrawText(380, 644, "В МЕНЮ ", 24);
            DrawText(725, 644, "ПОВТОРИТЬ", 24);

            if (MouseX > 377 && MouseX < 495 && MouseY > 641 && MouseY < 673)  // в меню
            {
                if (resultmenuchoise != 1) PlaySound(click);

                resultmenuchoise = 1;

                SetFillColor(Color.Green);
                DrawText(380, 644, "В МЕНЮ ", 24);
            }

            else
            {
                if (MouseX > 714 && MouseX < 878 && MouseY > 642 && MouseY < 673)  // переиграть
                {
                    if (resultmenuchoise != 2) PlaySound(click);

                    resultmenuchoise = 2;
                    SetFillColor(Color.Green);
                    DrawText(725, 644, "ПОВТОРИТЬ", 24);



                }
                else resultmenuchoise = 0;

            }
        }



        */


    }
}
