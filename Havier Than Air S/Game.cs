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
        TextureManager mTextureManager;

        //Меню
         int mainmenuSwitch = 1;
         int levelchoise = 0;
         int menuchoise2 = 0;
         int newgame = 0;
         int gameplaying = 0;
         int menudelay = 50;
         int podskazkaswitch = 1;


        public Game(GameController gameController, TextureManager textureManager)
        {

            mGameController = gameController;
            mTextureManager = textureManager;

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
