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

        

       public Game()
        {
            MenuController = new MainMenuController();
            MenuController.StartGameEvent += StartGame;
            
            Missions = new MissionBase[3];
            Missions[0] = new Mission1_Learning();
            Missions[1] = new MissionTest();
            Missions[2] = new Mission3_FreeFlight();
            
        }
        bool mainMenuOn = true;
        public void StartGame(int missionCode, int helyCode)
        {
            /*
            currentMissionNum = missionNum;
            Missions[currentMissionNum].StartMiss();
            
            //

            */

            switch (missionCode)
            {
                case 1: currentMissionNum = 0; break;
                case 2: currentMissionNum = 1; break;
                case 3: currentMissionNum = 2; break;
            }

            switch (helyCode)
            {
                case 11: break;
                case 12: break;
                case 13: break;
                case 14: break;
            }
            mainMenuOn = false;
            Missions[currentMissionNum].StartMiss();
        }

        

        public void Update()
        {
           // Program.m_Avionika.Update();


           // if (Keyboard.IsKeyPressed(Keyboard.Key.Escape) && MenuController.mainmenuSwitch==0)
           // {
          //    MenuController.mainmenuSwitch = 1;
          //  }



            if (mainMenuOn == true)
            {
                MenuController.Update();
            }
            else
            {
                Missions[currentMissionNum].Update();
               //Program.gameState.currentPlayerHely.SetPosition(new Vector2f(50, 50));
               
                }

         //   Program.m_PullObjects.Update();
          //  Program.collisions.Update();


        }
    }
}
