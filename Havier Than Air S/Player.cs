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

        

            //Вывод параметров в консоль. Информация



        }




        */



    }
}
