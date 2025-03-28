using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{


    internal class SoundManager
    {



        //ЗВУКИ
        static int warningdelay = 0;
        static int sounds = 1;
        static int volume = 85;
        static string rocketsound = LoadSound("rocket1.wav");
        static string click = LoadSound("buttonclick.wav"); //щелчек кнопки
        static string stopengine = LoadSound("hw_spindown.wav"); //щелчек кнопки
        static string bangsound = LoadSound("explode4.wav"); //взрыв


        //static string startengine = LoadSound("hw_spinup.wav"); //Запуск двигателя
        static string startenginesound = LoadSound("zapusk2.wav"); //Запуск двигателя
        static string helirotor1 = LoadSound("ap_rotor4on.wav"); //Вертолет включен
        static string helirotor2 = LoadSound("ap_rotor3down.wav"); //Вертолет падает
        static string helirotor3 = LoadSound("ap_rotor2earth.wav"); //
        static string helirotor4 = LoadSound("ap_rotorhigh.wav"); // Верталет ПЕРЕГРУЗКА
        static string helisound = LoadSound("hw_spindown.wav");
        static string proverupravlenie = LoadSound("FlightControls.wav");
        static string rubejvozvrata = LoadSound("Bingo.wav");
        static string sbrosoboroti = LoadSound("sbrosoboroti.wav");
        static string checkpointsound = LoadSound("mine_deploy.wav"); //чекпоинт, звук мины из хл
        static string tank1motorsound = LoadSound("rotormachine.wav"); //чекпоинт, звук мины из хл
        static string tank1motorsound2 = LoadSound("tankidle2.wav"); //чекпоинт, звук мины из хл
        static string helionpadsound = LoadSound("warn3.wav"); // верталет на базе
        static string metal1 = LoadSound("metal1.wav"); // касание земли
        static string metal2 = LoadSound("metal2.wav"); // касание земли 2
        static string pumper = LoadSound("pumper.wav"); // заправка
        static string zapmachine = LoadSound("zapmachine.wav"); // заправка
        static string cansel = LoadSound("button2.wav"); // заправка
        static string grass1 = LoadSound("glass3.wav"); // стекло
        static string grass2 = LoadSound("glass4.wav"); // стекло2
        static string pvosound = LoadSound("pvo1.wav"); //пво ракета
        static string minus = LoadSound("minus.wav"); //минус 1 на базе
        static string MissileMissile = LoadSound("MissileMissile.wav"); //определи направление угрозу
        static string MasterWarningsound = LoadSound("MasterWarning.wav"); //мастер предупреждение
        static string soundotkazHydro = LoadSound("Hydro.wav"); //гидростистема
        static string soundotkazols = LoadSound("OLS.wav"); //олс
        static string soundotkazpojar = LoadSound("EngineFire.wav"); //пожар
        static string enginerepairsound = LoadSound("signalgear1.wav"); //ремонт мотора


        //Звуки2
        static string kg500 = LoadSound("Fuel500.wav"); //500кг
        static string kg800 = LoadSound("Fuel800.wav"); //800кг
        static string puskrazreshen = LoadSound("ShootShoot.wav"); //Пуск разрешен
        static string nrrocketreloadsound = LoadSound("nrpusto.wav"); // ракеты заряжены
        static string proverpokazaniya = LoadSound("WarningWarning.wav"); // проверь показания приборов
        static string radaractive = LoadSound("tu_active.wav"); // Бук поиск цели
        static string collisionmet = LoadSound("ric_metal-2.wav"); // Столкновение с металлом



    }
}
