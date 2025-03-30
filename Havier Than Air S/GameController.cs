using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public enum GameMode
    {
        MainMenu,
        Play,
        Pause

    }

    public class GameController
    {
        public GameMode CurrentMode;
        

        public GameController() 
        {
            CurrentMode = GameMode.MainMenu;
             

        }


    }
}
