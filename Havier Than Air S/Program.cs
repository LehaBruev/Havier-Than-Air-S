using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{
    internal class Program
    {
        

       public static Game Game;
       public static RenderWindow window;
        public static DeltaTimer deltaTimer;

        static void Main(string[] args)
        {
            Game = new Game();
            deltaTimer = new DeltaTimer();

            VideoMode vMode = new VideoMode(1024, 768);
            window = new RenderWindow(vMode, "Havier Than Air SFML");
            window.Closed += Win_Closed;

          
            while (window.IsOpen)
            {
                window.Clear();
                window.DispatchEvents();
                deltaTimer.CheckDelta();
                Game.Update();
                window.Display();
            }
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            (sender as RenderWindow).Close();
        }


    }
}
