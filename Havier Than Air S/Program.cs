using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{
    internal class Program
    {
        //константы
        public static Random random = new Random();
        public static Font font = new Font("comic.ttf");

        public static float gameSpeed = 50;
        public static float helyScale = 1f;

        // Режим разработчки
       public static bool TestModeP = false;

       static ContextSettings _Settings = new ContextSettings();
       public static Collisions collisions = new Collisions();
        
       public static LogWriter log = new LogWriter();

       public static CameraController cameraController = new CameraController();
       public static TextureManager m_TextureManager = new TextureManager();
       public static DeltaTimer deltaTimer = new DeltaTimer();
       public static Pogoda m_Pogoda = new Pogoda();
       public static Avionika m_Avionika = new Avionika();
       
       public static PullObjects m_PullObjects = new PullObjects();
       public static MouseController m_MouseController = new MouseController();
       public static SoundManager soundManager = new SoundManager();
       public static Magnitola mMagnitola = new Magnitola();
        

        // Вывод изображения

        public static VideoMode vMode = new VideoMode(1600, 900);
        public static RenderWindow window;
        public static View view = new View(new FloatRect(50, 50, 300, 100));
        public static Vector2f offset = new Vector2f(800,450);

        //
        public static Game Game = new Game();
        public static StatisticaOfLevel statistica = new StatisticaOfLevel();

        static void Main(string[] args)
       {
            //window
            _Settings.AntialiasingLevel = 8; // сглажывание
            //window = new RenderWindow(vMode, "Havier Than Air SFML", new Styles(), _Settings);
            window = new RenderWindow(vMode, "Havier Than Air SFML");
            window.Closed += Win_Closed;
            window.Position = new Vector2i(1, 1);
            m_PullObjects.StartPull(); // Заполнение пула объектов

            
            view.Reset(new FloatRect(0, 0, 1600, 900));// = new View(new FloatRect(50, 50, 300, 100));
            //view2.Reset(new FloatRect(0, 0, 1024, 768));// = new View(new FloatRect(50, 50, 300, 100));
            //view.Viewport = (new FloatRect(0f, 0f, 0f, 1.0f));
            //view2.Viewport = (new FloatRect(0.5f, 0f, 0.5f, 1f));
            //view.Size = new Vector2f(1600, 900);
            
            Game.StartGame();

            while (window.IsOpen)
            {
                //clear and settings
                window.Clear();
                cameraController.Update();
                view.Center = offset; //Move(offset);
                window.SetView(view);
                window.DispatchEvents();

                //updates
                deltaTimer.CheckDelta();
                m_MouseController.CheckMouse();
                m_Avionika.Update();
                Game.Update();
                m_PullObjects.Update();
                collisions.Update();

                

                //display
                window.Display();
                
                
            }
       }

        private static void Win_Closed(object sender, EventArgs e)
        {
            (sender as RenderWindow).Close();
        }


    }
}
