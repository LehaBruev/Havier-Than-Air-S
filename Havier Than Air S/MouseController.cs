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
        public void CheckMousePress()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                Console.WriteLine(Mouse.GetPosition(Program.window).X.ToString());
            }
        }

        public int MousePositionX() 
        {
            int x = Mouse.GetPosition(Program.window).X;
            
           
            return x;
        }

        public int MousePositionY()
        {
            int y = Mouse.GetPosition(Program.window).X;


            return y;
        }


    }
}
