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
         int warningdelay = 0;
         int sounds = 1;
         int volume = 85;
         string rocketsound = LoadSound("rocket1.wav");
         string click = LoadSound("buttonclick.wav"); //щелчек кнопки
         string stopengine = LoadSound("hw_spindown.wav"); //щелчек кнопки
         string bangsound = LoadSound("explode4.wav"); //взрыв


        //static string startengine = LoadSound("hw_spinup.wav"); //Запуск двигателя
         string startenginesound = LoadSound("zapusk2.wav"); //Запуск двигателя
         string helirotor1 = LoadSound("ap_rotor4on.wav"); //Вертолет включен
         string helirotor2 = LoadSound("ap_rotor3down.wav"); //Вертолет падает
         string helirotor3 = LoadSound("ap_rotor2earth.wav"); //
         string helirotor4 = LoadSound("ap_rotorhigh.wav"); // Верталет ПЕРЕГРУЗКА
        static string helisound = LoadSound("hw_spindown.wav");
         string proverupravlenie = LoadSound("FlightControls.wav");
         string rubejvozvrata = LoadSound("Bingo.wav");
         string sbrosoboroti = LoadSound("sbrosoboroti.wav");
         string checkpointsound = LoadSound("mine_deploy.wav"); //чекпоинт, звук мины из хл
         string tank1motorsound = LoadSound("rotormachine.wav"); //чекпоинт, звук мины из хл
         string tank1motorsound2 = LoadSound("tankidle2.wav"); //чекпоинт, звук мины из хл
         string helionpadsound = LoadSound("warn3.wav"); // верталет на базе
         string metal1 = LoadSound("metal1.wav"); // касание земли
         string metal2 = LoadSound("metal2.wav"); // касание земли 2
         string pumper = LoadSound("pumper.wav"); // заправка
         string zapmachine = LoadSound("zapmachine.wav"); // заправка
         string cansel = LoadSound("button2.wav"); // заправка
         string grass1 = LoadSound("glass3.wav"); // стекло
         string grass2 = LoadSound("glass4.wav"); // стекло2
         string pvosound = LoadSound("pvo1.wav"); //пво ракета
         string minus = LoadSound("minus.wav"); //минус 1 на базе
         string MissileMissile = LoadSound("MissileMissile.wav"); //определи направление угрозу
         string MasterWarningsound = LoadSound("MasterWarning.wav"); //мастер предупреждение
         string soundotkazHydro = LoadSound("Hydro.wav"); //гидростистема
         string soundotkazols = LoadSound("OLS.wav"); //олс
         string soundotkazpojar = LoadSound("EngineFire.wav"); //пожар
         string enginerepairsound = LoadSound("signalgear1.wav"); //ремонт мотора


        //Звуки2
         string kg500 = LoadSound("Fuel500.wav"); //500кг
         string kg800 = LoadSound("Fuel800.wav"); //800кг
         string puskrazreshen = LoadSound("ShootShoot.wav"); //Пуск разрешен
         string nrrocketreloadsound = LoadSound("nrpusto.wav"); // ракеты заряжены
         string proverpokazaniya = LoadSound("WarningWarning.wav"); // проверь показания приборов
         string radaractive = LoadSound("tu_active.wav"); // Бук поиск цели
         string collisionmet = LoadSound("ric_metal-2.wav"); // Столкновение с металлом



    }
}
