using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{
    public class Hely: GameObject
    {
        //Настройки верталета






        //Переменные
        static float helilifeCurrent = 200;// жизни
        static int engineswitch = 1; // включение двигателя
        static int autopilotswitch = 0; // автопилот горизонтальный, удерживает угол в точке 0 градусов
        static float altitude = 200; // Высота
        static float helifuel = 950; // Топливо в баках
        static int bang1 = 1;
        static int gunmode = 0;

        //Характеристики
        static float helilifemax = 300;// максимальные жизни Вертолета
        static float helienginelife = 100; //исправность двигателя Вертолета
        static float fuelrashod = 1; // расход топлива
        static float manageability = 5;// управляемость
        static float maxangle = 65; // Максимальный угол атаки
        static float helifuelmax = 1300; // Максимальное топливо в баках
        static float maxboost = 11250; // максимальное ускорение от двигателя


        static float playerx = 50;
        static float playery = 400;
        static float speedx = 0;
        static float speedxmax = 2.5f;
        static float speedy = 0;
        static float powery = 0;
        static float enginespeed = 19500; //Обороты двигателя
        static float maxenginespeed = 60000; //Максимальные обороты двигателя
        static float enginespeedlimit = 45000; //Предельные обороты двигателя

        static float angle = 0; //угол атаки верталета

        static float boostv = 0; //ускорение вертикальное
        static float autopilotv = 0; // автопилот переменная, задает высоту полета
        static float autopilotswitchX = 0; //автопилот вертикальный, удерживает высоту
        static float autopilotzonax = 0; //Автопилот возврат в зону полета
        static float autopilotzonaangle = 0; //Автопилот возврат в зону полета
        static float autopilotzonaswitch = 0; //Автопилот возврат в зону полета

        static int helidestroy = 0; // верталет разрушен
        static int helistop = 0; // вертолет обесточен

        //Настройки прицеливания
        static float aimlehght = 180;

        public Hely()
        {
            //Начальные настройки верталета
            playerx = 120;
            playery = 700;
            engineswitch = 0;
            enginespeed = 0;
            helistop = 1;
            helifuel = 1000;
            helifuelmax = 1300;
            helilife = 300;
            helilifemax = 300;
            speedxmax = 3f;
            manageability = 9; //управляемость
            shagAngle = 1.7f; // угол атаки
            nrrocketsMaxquantity = 8; //максимально ракет
            padstoreswitch = 0;
            helidestroy = 0;

            
            shagengine = 75; //шаг увелич мощности двигателя
            enginespeedlimit = 35000; //лимит оборотов двигателя
            fuelrashod = 1.7f; // расход топлива
            otkazcicle[1] = manageability;
            otkazcicle[2] = shagAngle;
            otkazcicle[3] = 0;
        }

        //Оружие и прицеливание
/*
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
/*
}
}
