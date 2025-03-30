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
        static SoundManager soundManager;
        static void Main(string[] args)
        {

            soundManager = new SoundManager();
            soundManager.playSound();


            VideoMode vMode = new VideoMode(800, 600);
            RenderWindow win = new SFML.Graphics.RenderWindow(vMode, "Havier Than Air SFML");
            win.Closed += Win_Closed;

            GameController mGameController = new GameController();

            Game mGame = new Game(mGameController);
            Magnitola mMagnitola = new Magnitola();

            while (win.IsOpen)
            {
                win.Clear();
                win.DispatchEvents();

                mGame.Update();


                win.Display();
            }

            


        }

        private static void Win_Closed(object sender, EventArgs e)
        {

            (sender as RenderWindow).Close();

        }

    }
}
