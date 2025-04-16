using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    internal class Avtopilot
    {


        float autopilotv = 0; // автопилот переменная, задает высоту полета
        float autopilotswitchX = 0; //автопилот вертикальный, удерживает высоту
        float autopilotzonax = 0; //Автопилот возврат в зону полета
        float autopilotzonaangle = 0; //Автопилот возврат в зону полета
        float autopilotzonaswitch = 0; //Автопилот возврат в зону полета


        /* 
          
            // Автопилот висение 
            if (GetKeyDown(Keyboard.Key.H) == true)
            {
                autopilotv = (768 - playery) - (768 - ground);
                int A = autopilotswitch;
                if (A == 1) autopilotswitch = 0;
                if (A == 0) autopilotswitch = 1;
            }
            if (autopilotswitch == 1)
            {

                if (altitude < autopilotv)
                {
                    if (enginespeed - gravityweight > 1000 || enginespeed - gravityweight < 1000)
                        enginespeed = enginespeed + shagengine;
                    else enginespeed = enginespeed + shagengine / 4;
                }
                if (altitude > autopilotv)
                {
                    if (enginespeed - gravityweight > 1000 || enginespeed - gravityweight < 1000)
                        enginespeed = enginespeed - shagengine;
                    else enginespeed = enginespeed + shagengine / 4;
                }
            }
          
          //Включение автопилота возврата в зону полета АВТОПИЛОТЫ ЗОНЫ
            if (playerx >= 1025 && autopilotzonaswitch == 0) //верталет уходит вправо
            {
                autopilotzonaangle = -45;
                autopilotzonaswitch = 1;
                autopilotzonax = 1000;
                PlaySound(proverupravlenie);

            }
            if (playerx <= -5 && autopilotzonaswitch == 0) //верталет уходит влево
            {
                autopilotzonaangle = 45;
                autopilotzonaswitch = 2;
                autopilotzonax = 50;
                PlaySound(proverupravlenie);

            }
            // Автопилот возврата в зону полета
            if (autopilotzonaswitch == 1)
            {
                if (autopilotzonax < playerx) angle = angle - 1f;
                if (autopilotzonax > playerx)
                {
                    if (angle > autopilotzonaangle) angle = angle + 0.5f;
                    if (angle < autopilotzonaangle) angle = angle - 0.5f;
                    if (angle < autopilotzonaangle + 1 || angle < autopilotzonaangle - 1)
                    {
                        angle = autopilotzonaangle;
                        autopilotzonaswitch = 0;
                    }
                }


            }
            if (autopilotzonaswitch == 2)
            {
                if (autopilotzonax > playerx) angle = angle + 1f;
                if (autopilotzonax < playerx)
                {
                    if (angle < autopilotzonaangle) angle = angle + 0.5f;
                    if (angle > autopilotzonaangle) angle = angle - 0.5f;
                    if (angle > autopilotzonaangle + 1 || angle < autopilotzonaangle - 1)
                    {
                        angle = autopilotzonaangle;
                        autopilotzonaswitch = 0;
                    }
                }


            }*/



    }
}
