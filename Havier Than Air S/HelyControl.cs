using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    internal class HelyControl
    {

        /*
        DrawText(25, 170, "След волна через: " + volnadelay, 16);
        DrawText(25, 215, "Теперь можете загрузить " + nrrocketsMaxquantity + " ракет!", 16);
        DrawText(25, 240, "Оборона базы выдержит: " + basedurability + " танков!", 16);
            if (checkpoints2[1] == 0)
            {
                SetFillColor(Color.Green);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 265, "Вы победили всех врагов!", 32);
                DrawText(330, 300, "Нажми Escape, для выхода. ", 32);


            }
         if (basedurability < 0 || helidestroy == 1)
            {

                gitadelay = 200;
                gitaswitch = 1;
                G = rnd.Next(1, 6);
                SetFillColor(Color.Green);
                DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                DrawText(330, 265, "Танки захватили Вашу базу.", 32);
                DrawText(330, 300, "Нажми Escape, для выхода. ", 32);

            }

        */

        /*
        //Оружие и прицеливание

if (GetKeyDown(Keyboard.Key.Num1) == true) // Моде 1 ВЫБОР
{
    gunmode = 1; // пулемет
    PlaySound(click);
}

if (GetKeyDown(Keyboard.Key.Num2) == true) // Моде 2 ВЫБОР
{
    gunmode = 2; // ракета
    PlaySound(click);
int PRNR = 0; // Пуск Разрешен
    for (int i = 0; i<R.GetLongLength(1); i++)
    {
        if (R[5, i] == 1)
        {
            PlaySound(puskrazreshen);
PRNR = 1;
            break;

        }

    }
    if (PRNR == 0) PlaySound(proverpokazaniya);

}// Моде 2 ВЫБОР

if (GetKeyDown(Keyboard.Key.Num3) == true)
{
gunmode = 3; // самонаводящаяся ракета 
PlaySound(click);

// Выстрел
if (GetMouseButtonDown(Mouse.Button.Left) == true) // ОГОНЬ!
{
    if (gunmode == 1)
    {
    }
    if (gunmode == 2) //(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена)
    {
        NRrocketchecklaunch = 0;
        for (int i = 0; i < R.GetLongLength(1); i++)
        {

            if (R[5, i] == 0 || R[5, i] == 2) continue;
            if (R[5, i] == 1)
            {
                R[1, i] = playerx;
                R[2, i] = playery;
                R[3, i] = angle;
                R[4, i] = nrfuel;
                R[5, i] = 2; // ракета отрисовывается
                NRrocketchecklaunch = 1;
                PlaySound(rocketsound);
                NRrocketslaunched = NRrocketslaunched + 1;
                break;
            }

        }
        if (NRrocketchecklaunch == 0)
        {
            PlaySound(click);
            PlaySound(proverpokazaniya);
        }
    }//(1 = x ракеты, 2 = y ракеты, 3 = angle ракеты, 4 = fuel ракеты, 5 = ракета проявлена)
    if (gunmode == 3)
    {

        PlaySound(rocketsound);

    }

}

}
}
*/



    }
}
