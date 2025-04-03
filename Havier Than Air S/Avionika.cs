using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Havier_Than_Air_S
{
    internal class Avionika
    {


        /*
        static void PanelInstrument() // параметры приборной панели и отрисовка
        {
            SetFillColor(Color.Red);

            DrawSprite(uh61, 0, 0, 139, 679, 159, 131);
            DrawSprite(uh61, 175, 0, 139, 679, 159, 131);

            //Параметры верталета
            SetFillColor(Color.White);



            DrawText(25, 15, "Heli Life: " + (int)helilife, 14);
            if (helilife < 90) { SetFillColor(Color.Red); DrawText(25, 15, "Heli Life: " + (int)helilife, 14); SetFillColor(Color.White); }
            DrawText(200, 30, "Engine Switch: " + engineswitch, 14);
            DrawText(25, 30, "Altitude: " + (int)altitude * 10, 14);
            DrawText(25, 45, "Angle: " + (int)angle, 14);
            DrawText(25, 60, "Автопилот V: " + autopilotswitchX, 14);
            DrawText(25, 75, "Автопилот H: " + autopilotswitch, 14);


            //Двигаетль
            DrawText(200, 15, "Engine S.: " + (int)enginespeed, 14);
            if (enginespeed > enginespeedlimit) { SetFillColor(Color.Red); DrawText(200, 15, "Engine S.: " + (int)enginespeed, 14); SetFillColor(Color.White); }
            DrawText(200, 30, "Engine Switch: " + engineswitch, 14);
            if (engineswitch == 1) { SetFillColor(Color.Green); DrawText(200, 30, "Engine Switch: " + engineswitch, 14); SetFillColor(Color.White); }
            DrawText(200, 45, "Engine Life: " + (int)helienginelife, 14);
            if (helienginelife < 75 || otkazpojardvig == 1) { SetFillColor(Color.Yellow); DrawText(200, 45, "Engine Life: " + (int)helienginelife, 14); SetFillColor(Color.White); }
            if (helienginelife < 53 || otkazpojardvig == 1) { SetFillColor(Color.Red); DrawText(200, 45, "Engine Life: " + (int)helienginelife, 14); SetFillColor(Color.White); }
            DrawText(200, 60, "Fuel: " + (int)helifuel, 14);
            if (helifuel < 150) { SetFillColor(Color.Yellow); DrawText(200, 60, "Fuel: " + (int)helifuel, 14); SetFillColor(Color.White); }

            //Вооружение
            DrawText(400, 5, "Режим: " + gunmode, 18);

            int n = 0;
            for (int i = 0; i < R.GetLength(1); i++)
            {
                if (R[5, i] == 1) n = n + 1;

            }
            DrawText(400, 20, "НР ракеты " + n + " из " + nrrocketsMaxquantity, 18);
            if (n <= 3) { SetFillColor(Color.Yellow); DrawText(400, 20, "НР ракеты " + n + " из " + nrrocketsMaxquantity, 18); SetFillColor(Color.White); }



            //Окруж среда
            DrawText(600, 5, "Плотность воздуха: " + gunmode, 14);
            DrawText(600, 20, "Ветер " + wind, 14);


            //Очки
            DrawText(800, 35, "Money: " + money, 18);
            DrawText(800, 55, "Record: " + hiscore, 18);
            DrawText(800, 15, "Flight: time " + flighttime, 18);

            if (helifuel < 150 && helifuel > 145) PlaySound(rubejvozvrata); //рубеж возврата предупреждение голосовое

        }

*/

    }
}
