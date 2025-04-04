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
        Result,
        Pause

    }

    public class GameState
    {
        private GameMode currentMode;
        public GameMode CurrentMode => currentMode;

        public GameState() 
        {
            currentMode = GameMode.MainMenu;

        }

        public void SetGameMode(GameMode gameMode)
        {
            currentMode = gameMode;

        }

    }
}
