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
        public GameMode currentGameMode;
        public GameMode CurrentMode => currentGameMode;

        public GameState() 
        {
            currentGameMode = GameMode.Result;

        }

        public void SetGameMode(GameMode gameMode)
        {
            currentGameMode = gameMode;

        }

    }
}
