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
       public static bool TestModeP = false;
       public static DeltaTimer deltaTimer = new DeltaTimer();
       public static Game Game = new Game();
       public static PullObjects m_PullObjects = new PullObjects();

       public static VideoMode vMode = new VideoMode(1600, 900);
       public static RenderWindow window = new RenderWindow(vMode, "Havier Than Air SFML");
       
       public static View view = new View(new FloatRect(50, 50, 300, 100));
       public static View view2 = new View(new FloatRect(50, 50, 300, 100));
       public static CameraController cameraController= new CameraController();

       static void Main(string[] args)
       {
            //Game = new Game();
            //deltaTimer = new DeltaTimer();

           // VideoMode vMode = new VideoMode(1024, 768);
           // window = new RenderWindow(vMode, "Havier Than Air SFML");
            window.Closed += Win_Closed;
            window.Position = new Vector2i(50, 50);



            view.Reset(new FloatRect(0, 0, 1024, 768));// = new View(new FloatRect(50, 50, 300, 100));
            view2.Reset(new FloatRect(0, 0, 1024, 768));// = new View(new FloatRect(50, 50, 300, 100));
            view.Viewport = (new FloatRect(0f, 0f, 0.5f, 1.0f));
            view2.Viewport = (new FloatRect(0.5f, 0f, 0.5f, 1f));
            //view.Size = new Vector2f(50, 1000);
            

            while (window.IsOpen)
            {
                //window.SetView(view); // split
                //window.SetView(view2); // split
                

                window.Clear();

                window.DispatchEvents();
                deltaTimer.CheckDelta();
                Game.Update();
                m_PullObjects.Update();

                window.Display();

            }
       }

        private static void Win_Closed(object sender, EventArgs e)
        {
            (sender as RenderWindow).Close();
        }


    }
}
