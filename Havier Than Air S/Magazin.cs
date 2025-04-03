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
    internal class Magazin
    {






        //цены
        static float fuelcost = 900; //цена топлива
        static float rocketcost = 800; //цена ракет
        static float partscost = 350; //цена запчастей

        //корзина
        static float fuelinbag = 100; //топливо на складе
        static float nrrocketsinbag = 100; //ракеты на складе
        static float partsinbag = 100; //Запчасти в корзине






        static void padstoredraw()
        {



            if (padstoreswitch == 1)
            {

                gunmode = 0;
                //музыка 
                magnitola();


                //ДОЗАПРАВКА и ремонт
                if (enginespeed < 1 && engineswitch == 0)
                {
                    if (helienginelife < 100 && partsinbag > 0) //мотор
                    {
                        helienginelife = helienginelife + 0.01f;
                        partsinbag = partsinbag - 0.1f;
                        PlaySound(enginerepairsound, volume - 30);
                        otkazpojardvig = 0;
                    }

                    if (helilife < helilifemax && partsinbag > 0) //жизни верталета
                    {
                        helilife = helilife + 0.1f;
                        partsinbag = partsinbag - 0.1f;
                        PlaySound(zapmachine, volume - 50);
                    }

                    if (helifuel < helifuelmax && fuelinbag > 0) //топливо
                    {
                        helifuel = helifuel + 0.5f;
                        fuelinbag = fuelinbag - 0.5f;
                        PlaySound(pumper, volume);

                    }
                    paddelay = paddelay - 1;

                    for (int i = 0; i < nrrocketsMaxquantity; i++) // ракеты
                    {
                        if (R[5, i] == 0 && paddelay < 1 && nrrocketsinbag >= 1)
                        {

                            R[5, i] = 1;
                            paddelay = 50;
                            nrrocketsinbag = nrrocketsinbag - 1;
                            PlaySound(nrrocketreloadsound, volume - 20);
                            break;
                        }

                    }

                }
                NRrocketchecklaunch = 0;
                for (int i = 0; i < R.GetLength(1); i++)
                {
                    if (R[5, i] == 1) NRrocketchecklaunch = NRrocketchecklaunch + 1;
                }
                SetFillColor(47, 55, 68);
                FillRectangle(350, 150, 1024 - 350, 500);


                //Параметры верталета
                SetFillColor(255, 187, 0);
                DrawText(400, 540, "HeliParts: " + (int)helilife, 18);
                DrawText(400, 300, "Fuel: " + (int)helifuel, 18);
                DrawText(400, 430, "Rockets: " + (int)NRrocketchecklaunch, 18);
                DrawText(620, 300, "" + (int)fuelinbag, 18);
                DrawText(620, 430, "" + (int)nrrocketsinbag, 18);
                DrawText(620, 540, "" + (int)partsinbag, 18);

                if (helifuel >= helifuelmax - 5) DrawSprite(uh61, 535, 300, 568, 15, 123, 87); //готово топлива
                if (NRrocketchecklaunch >= nrrocketsMaxquantity) DrawSprite(uh61, 535, 430, 568, 15, 123, 87); //готово топлива
                if (helilife >= helilifemax - 5)
                {
                    DrawSprite(uh61, 535, 540, 568, 15, 123, 87); //готово топлива

                    //Обнуление ошибок

                    //Ремонт гидросистемы
                    if (otkazcicle[3] == 1)
                    {
                        otkazhydrosis = 0;
                        otkazcicle[3] = 0;
                        manageability = otkazcicle[1];
                        shagAngle = otkazcicle[2];
                    }
                    //ремонт ОЛС
                    otkazols = 0;


                }

                DrawSprite(uh61, 790, 257, 967, 583, 142, 105); // топливо спрайт
                DrawSprite(uh61, 790, 257 + 105 + 15, 972, 824, 134, 103); // ракеты
                DrawSprite(uh61, 790, 257 + 105 + 15 + 15 + 103, 971, 697, 130, 117); // запчасти

                if (MouseX > 780 && MouseX < 940 && MouseY > 250 && MouseY < 360) // ПОКУПКА ТОПЛИВА
                {
                    if (storechoise != 1)
                    {
                        storechoise = 1;
                        PlaySound(click);
                    }


                }
                else
                {
                    if (MouseX > 780 && MouseX < 940 && MouseY > 366 && MouseY < 476) // ПОКУПКА РАКЕТ
                    {
                        if (storechoise != 2)
                        {
                            storechoise = 2;
                            PlaySound(click);
                        }
                    }
                    else
                    {
                        if (MouseX > 780 && MouseX < 940 && MouseY > 491 && MouseY < 615) // ПОКУПКА ЗАПЧАСТЕЙ
                        {
                            if (storechoise != 3)
                            {
                                storechoise = 3;
                                PlaySound(click);
                            }


                        }
                        else storechoise = 0;
                    }

                }

                if (storechoise == 1) //топливо
                {
                    DrawSprite(uh61, 720, 281, 1143, 573, 57, 75); // стрелочка
                    if (GetMouseButtonDown(Mouse.Button.Left) == true)
                    {
                        if (money >= fuelcost)
                        {
                            fuelinbag = fuelinbag + 100; //топливо на складе
                            money = money - fuelcost;
                            PlaySound(click);
                        }
                        else { donatswitch = 1; PlaySound(cansel); } //заправка
                    }
                }

                if (storechoise == 2) // ракеты нр
                {
                    DrawSprite(uh61, 720, 394, 1143, 573, 57, 75); // стрелочка
                    if (GetMouseButtonDown(Mouse.Button.Left) == true)
                    {
                        if (money >= rocketcost)
                        {
                            nrrocketsinbag = nrrocketsinbag + 1; //ракеты на складе
                            money = money - rocketcost;
                            PlaySound(click);
                        }
                        else { donatswitch = 1; PlaySound(cansel); }
                    }
                }


                if (storechoise == 3) // запчасти
                {
                    DrawSprite(uh61, 720, 517, 1143, 573, 57, 75); // стрелочка
                    if (GetMouseButtonDown(Mouse.Button.Left) == true)
                    {
                        if (money >= partscost)
                        {
                            partsinbag = partsinbag + 10; //Запчасти в корзине
                            money = money - partscost;
                            PlaySound(click);
                        }
                        else { donatswitch = 1; PlaySound(cansel); }


                    }
                }



                DrawSprite(uh61, 790, 257 + 105 + 15 + 15 + 103, 971, 697, 130, 117); // запчасти
                DrawSprite(uh61, 790, 257 + 105 + 15 + 15 + 103, 971, 697, 130, 117); // запчасти

                //меню надписи
                SetFillColor(Color.White);
                DrawText(820, 220, "Store          Price", 22);
                DrawText(400, 220, "In Heli", 22);
                DrawText(601, 220, "At the Base", 22);
                DrawText(450, 170, "Your Money: " + money, 30);
                //прайс
                DrawText(950, 300, "" + (int)fuelcost, 18);
                DrawText(950, 430, "" + (int)rocketcost, 18);
                DrawText(950, 540, "" + (int)partscost, 18);


                if (engineswitch == 1)
                {
                    SetFillColor(Color.Red);
                    DrawText(380, 600, "Press \"i\" to turn off Engine", 28);
                }

                //отступление для обучающей миссии
                if (checkpoints[4] == 2 && helifuel >= helifuelmax - 10 && levelchoise == 1)
                {
                    SetFillColor(Color.Blue);
                    DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    DrawText(330, 265, "Заведи мотор, клавиша \"i\"", 32);
                    DrawText(330, 300, "Выходи из магазина, \"R\"", 32);

                    // Условие победы
                    if (engineswitch == 1 && padstoreswitch == 0) { checkpoints[4] = 3; checkdelay = 200; }


                }


            }

        }




    }
}
