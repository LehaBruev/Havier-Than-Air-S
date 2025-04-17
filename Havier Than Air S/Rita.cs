using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{



    internal class Rita
    {

        /*

        //Поломки
        static int otkazhydrosis = 0; // Гидросистема
        static int otkazmasterwarning = 0; // Матерсвитч
        static int otkazols = 0; // Оптико локационная станция
        static int otkazraketasprava = 0; //ракета справа
        static int otkazraketasleva = 0; //Ракета слева
        static int otkazpojardvig = 0; // Пожар двигателя
        static int otkazsbrosoboroti = 0; //Пожар двигателя
        static int delayrita = 350; //Пожар двигателя
        
        static float pojardelay = 1000; //Пожар двигателя начнется
        static int peregruzkamotora = 0; //Пожар двигателя начнется
        static float ritarandom = 1; //рандом для прицела



        1

        static void rita()

        {
            delayrita = delayrita - 1;
            if (delayrita < 0) delayrita = 400;

            if (otkazhydrosis == 1 && delayrita == 100) PlaySound(soundotkazHydro);
            if (otkazols == 1 && delayrita == 200) PlaySound(soundotkazols);
            if (otkazpojardvig == 1 && delayrita == 300) PlaySound(soundotkazpojar);
            if (otkazsbrosoboroti == 1 && delayrita == 400) PlaySound(sbrosoboroti);


            if (helilife < 80 || helifuel < 100) PlaySound(MasterWarningsound);

            //пожар мотора
            if (otkazpojardvig == 1) helienginelife = helienginelife - 0.03f;
            if (helienginelife < 28) helienginelife = 28;


            //Перегрузка мотора overlimit
            if (enginespeed > enginespeedlimit)
            {
                pojardelay = pojardelay - 1;
                if (pojardelay < 0) otkazpojardvig = 1;
                otkazsbrosoboroti = 1;
            }
            else { pojardelay = 650; otkazsbrosoboroti = 0; }

            //отказ гидростистемы
            if (otkazhydrosis == 1 && otkazcicle[3] != 1)
            {
                otkazcicle[1] = manageability;
                otkazcicle[2] = shagAngle;
                otkazcicle[3] = 1;

                manageability = 4; //управляемость
                shagAngle = 0.8f; // угол атаки
            }

            if (otkazols == 1)
            {
                if (delayrita == 50 || delayrita == 250) ritarandom = rnd1.Next(-30, 30);

            }
            else ritarandom = 1;
        }



        


        static void loterea()
        {

            int n = rnd1.Next(1, 8);

            if (n == 1) otkazhydrosis = 1;
            if (n == 2) otkazols = 1;
            if (n == 3) otkazpojardvig = 1;
            if (n == 4) helienginelife = helienginelife - rnd.Next(5, 10);
            if (n == 5) helienginelife = helienginelife - rnd.Next(10, 15);



        }



        //Поломки
        helienginelife = 100;
        otkazhydrosis = 0; // Гидросистема
        otkazmasterwarning = 0; // Матерсвитч
        otkazols = 0; // Оптико локационная станция
        otkazraketasprava = 0; //ракета справа
        otkazraketasleva = 0; //Ракета слева
        otkazpojardvig = 0; // Пожар двигателя
        otkazsbrosoboroti = 0; //Пожар двигателя

        peregruzkamotora = 0; //Пожар двигателя начнется
        ritarandom = 1; //рандом для прицела

        */
    }
}
