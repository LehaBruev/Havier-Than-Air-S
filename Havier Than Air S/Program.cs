using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{
    internal class Program
    {
        

       public static Game Game = new Game();
       public static VideoMode vMode = new VideoMode(1024, 768);
        public static RenderWindow window = new RenderWindow(vMode, "Havier Than Air SFML");;
       public static DeltaTimer deltaTimer = new DeltaTimer();
        public static View view = new View(new FloatRect(50, 50, 300, 100));
        public static CameraController cameraController= new CameraController();
        static void Main(string[] args)
        {
            //Game = new Game();
            //deltaTimer = new DeltaTimer();

           // VideoMode vMode = new VideoMode(1024, 768);
           // window = new RenderWindow(vMode, "Havier Than Air SFML");
            window.Closed += Win_Closed;

          
            while (window.IsOpen)
            {
                view.Viewport = (new FloatRect(0, 0, 0.5f, 1));
                
                view.Size = new Vector2f(2000, 50);
                window.SetView(view);

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
