using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class MouseController
    {
        public int x;
        public int y;
        public bool LeftButtonIsPressed;
        public bool RightButtonIsPressed;
        private Timer timer;

        //ПОЗИЦИЯ WINDOW
        public Vector2i currentMousePosInWindow;
        public Vector2i memMousePosition;

        public MouseController() 
        {
            memMousePosition = new Vector2i(-2000,-2000);

            timer = new Timer(200.0f);
        }

        public void CheckMouse()
        {
            if (timer.timerOk == false)
            {
                timer.UpdateTimer();
            }
            else
            {
               //Console.WriteLine("x " + x + " y" + y + ". WX " + Program.window.Position.X + " WY" + Program.window.Position.Y);
                timer.Start(200.0f);

            }

            LeftButtonIsPressed = Mouse.IsButtonPressed(Mouse.Button.Left);
            RightButtonIsPressed = Mouse.IsButtonPressed(Mouse.Button.Left);

            x = Mouse.GetPosition(Program.window).X;
            y = Mouse.GetPosition(Program.window).Y;

            //ПОЛОЖЕНИЕ МЫШИ 
            currentMousePosInWindow = new Vector2i(x, y);

            


            //ОГРАНИЧЕНИЕ ПЕРЕМЕЩЕНИЯ МЫШИ
            if (x < 0)
            {
                Mouse.SetPosition(new Vector2i(Program.window.Position.X + 8,
                                    Program.window.Position.Y + 31 + Mouse.GetPosition(Program.window).Y));

            }



        }
        //ПРОВЕРКА КЛАВИАТУРЫ НА НАЖАТУЮ КЛАВИШУ
        public bool CheckKeyboardKey(Keyboard.Key key)
        {
            if(Keyboard.IsKeyPressed(key))
            return true;
            else return false;
        }

    }
}
