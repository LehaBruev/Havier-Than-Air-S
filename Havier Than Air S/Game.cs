using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class Game 
    {
        GameController mGameController;

        //Меню
        static int mainmenuSwitch = 1;
        static int levelchoise = 0;
        static int menuchoise2 = 0;
        static int newgame = 0;
        static int gameplaying = 0;
        static int menudelay = 50;
        static int podskazkaswitch = 1;

        public Game(GameController gameController)
        {

            mGameController = gameController;


        }



        public void Update()
        {
        

            if (mGameController.CurrentMode  == GameMode.Play)
            {
                MooveObjects();
                DrawObjects();
            }
            else if (mGameController.CurrentMode == GameMode.MainMenu) 
            {
                DrawMenu();
            
            }


        }



        private void MooveObjects()
        { 
        
        }

        private void DrawObjects()
        {

        }

        private void DrawMenu()
        {

        }










    }
}
