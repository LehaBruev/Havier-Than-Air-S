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
        public MainMenuController MenuController = new MainMenuController();
        public int currentMissionNum = 0;

        public MissionBase[] Missions;

        public GameState gameState;

       public Game()
        {
            gameState = new GameState();

            Missions = new MissionBase[3];
            Missions[0] = new Mission1_Learning();
            Missions[1] = new MissionTest();
            Missions[2] = new Mission3_FreeFlight();

        }

        public void StartGame(int missionNum)
        {
            currentMissionNum = missionNum;
            Missions[currentMissionNum].StartMiss();
            gameState.currentPlayerHely = new Hely();
            gameState.currentPlayerHely.SetPosition(new Vector2f(50, 50));
            Program.cameraController.SetCameraObject(gameState.currentPlayerHely);
            MenuController.mainmenuSwitch = 0;
        }

        

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape) && MenuController.mainmenuSwitch==0)
            {
                MenuController.mainmenuSwitch = 1;
            }



            if (MenuController.mainmenuSwitch == 1)
            {
                MenuController.Update();
            }
            else
            {
                Missions[currentMissionNum].Update();
            }
        }
    }
}
