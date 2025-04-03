using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Havier_Than_Air_S
{
    internal class Gita
    {











        //gita
        static float gitadelay = 2000; //счетчик ракет
        static float G = 0; //счетчик ракет
        static int gitaswitch = 0; //счетчик ракет



        //Пожертвования
        static void donat()
        {
            SetFillColor(Color.Blue);
            DrawSprite(uh61, 840, 300, 1215, 575, 221, 235);
            DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
            DrawText(330, 240, "Не хватает денег,", 30);
            DrawText(330, 268, "я дарю Тебе 20000 money. ", 30);
            DrawText(330, 296, "Cкоро разбогатеешь!;) Жми \"K\"!", 30);
            DrawText(330, 335, "Донат и обраная связь  ", 18);
            DrawText(330, 350, "по телефону 89500808627  ", 18);
            DrawText(330, 365, "(сбер: Алексей тимофеевич Б.)", 18);

            if (GetKeyDown(Keyboard.Key.K) == true)
            {
                money = money + 20000;
                donatswitch = 0;
            }

        }



    }
}
