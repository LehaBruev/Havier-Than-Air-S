using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    internal class Prochee
    {






        static Random rnd = new Random();




        // Переменные доступные всем методам и функциям

        //Меню
        static int mainmenuSwitch = 1;
        static int levelchoise = 0;
        static int menuchoise2 = 0;
        static int newgame = 0;
        static int gameplaying = 0;
        static int menudelay = 50;
        static int podskazkaswitch = 1;



        //Настройки прицеливания
        static float aimlehght = 180;

        //Вычисление угла ГЕОМЕТРИЯ
        static float searchA = 0; //y
        static float searchB = 0; //x
        static float searchline = 0; // диагональ
        static float searchangle = 0; // угол
        static float x1 = 0; // координаты
        static float x2 = 0; // координаты
        static float y1 = 0; // координаты
        static float y2 = 0; // координаты
        static double d = 0; // расстояние между двумя точками
        static float aimangle = 0; // угол до цели

        //Параметры МИРА и ВЕРТАЛЕТА
        static float wind = 0; //Сила ветра
        static float ground = 700; //Уровень земли
        static float gravityweight = 20000; //Сила притяжения
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

        static float airP = 0; //плотность воздуха
        static float boostv = 0; //ускорение вертикальное
        static float autopilotv = 0; // автопилот переменная, задает высоту полета
        static float autopilotswitchX = 0; //автопилот вертикальный, удерживает высоту
        static float autopilotzonax = 0; //Автопилот возврат в зону полета
        static float autopilotzonaangle = 0; //Автопилот возврат в зону полета
        static float autopilotzonaswitch = 0; //Автопилот возврат в зону полета
        static int g = 0;
        static int helidestroy = 0; // верталет разрушен
        static int helistop = 0; // вертолет обесточен





    }
}
