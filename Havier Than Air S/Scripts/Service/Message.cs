using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Scripts.Service
{
    internal class Message
    {
        
        public Shape BackGroundShape;
        public Text MessageText;

        public Message(Shape sh,Text tx)
        {
            BackGroundShape = sh;
            MessageText = tx;


        }


        public void Update()
        {
            Program.window.Draw(BackGroundShape);

        }

        /*
         * 
                //отступление для обучающей миссии
                if (checkpoints[4] == 2 && helifuel >= helifuelmax - 10 && levelchoise == 1)
                {
                    SetFillColor(Color.Blue);
                    DrawSprite(uh61, 850, 300, 484, 535, 205, 235);
                    DrawSprite(uh61, 892 - 610, 430 - 208, 308, 777, 610, 208);
                    DrawText(330, 265, "Заведи мотор, клавиша \"i\"", 32);
                    DrawText(330, 300, "Выходи из магазина, \"R\"", 32);

                    // Условие победы
                    if (engineswitch == 1 && padstoreswitch == 0) { checkpoints[4] = 3; checkdelay = 200; }


        */



    }
}
