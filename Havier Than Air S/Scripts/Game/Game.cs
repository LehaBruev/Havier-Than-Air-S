using Havier_Than_Air_S.Missions;
using SFML.System;
using SFML.Window;
using System;

namespace Havier_Than_Air_S
{
   
    public class Game 
    {
        public static GameState GameState = new GameState();

        public Random rnd = new Random();
        public MainMenuController MenuController;
        public int currentMissionNum = 2;

        public MissionBase[] Missions;
        public MissionBase currentMission;
        

       public Game()
        {
            MenuController = new MainMenuController();
            MenuController.StartGameEvent += StartGame;
           
            
        }
        bool mainMenuOn = true;
        public void StartGame(int missionCode, int helyCode)
        {
            
            switch (missionCode)
            {
                case 1: currentMission = new Mission1_Learning();  break;
                case 2: currentMission = new MissionTest(); break;
                case 3: currentMission = new Mission3_FreeFlight(); break;
            }

            switch (helyCode)
            {
                case 11: Program.gameState.currentPlayerHely = new Hely(); break;
                case 12: Program.gameState.currentPlayerHely = new AH_1(); break;
                case 13: Program.gameState.currentPlayerHely = new mi24(); break;
                case 14: Program.gameState.currentPlayerHely = new OH_6(); break;
            }
            mainMenuOn = false;
            currentMission.StartMiss();
        }

        

        public void Update()
        {
          if (Program.m_MouseController.CheckKeyboardKey(Keyboard.Key.Escape) && mainMenuOn == false)
            {
                mainMenuOn = true;
            }


            if (mainMenuOn == true)
            {
                MenuController.Update();
            }
            else
            {
                currentMission.Update();

                Program.m_PullObjects.Update();
                Program.collisions.Update();
                Program.m_Avionika.Update();
            }



        }
    }
}
