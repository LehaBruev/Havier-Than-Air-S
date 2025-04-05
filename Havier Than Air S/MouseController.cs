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
        public bool LeftButton;
        public bool RightButton;

        public void CheckMouse()
        {
            Console.Write("x " + x + " y");
            Console.WriteLine(y);

            LeftButton = Mouse.IsButtonPressed(Mouse.Button.Left);
            RightButton = Mouse.IsButtonPressed(Mouse.Button.Left);

            x = Mouse.GetPosition(Program.window).X;
            y = Mouse.GetPosition(Program.window).Y;

            if(x<0)
            {
                Mouse.SetPosition(new Vector2i(Program.window.Position.X+8,
                                            Program.window.Position.Y +31+ Mouse.GetPosition(Program.window).Y));

            }
        }

       

    }
}
