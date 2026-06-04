using System;
using Havier_Than_Air_S.Missions;

namespace Havier_Than_Air_S
{
    public enum MissionSwitch
    {
        mis1,
        mis2,
        mis3,
        test
    }

    public class Game 
    {
        public static GameState GameState = new GameState();

        public Random rnd = new Random();
        public MainMenuController MenuController = new MainMenuController();
        public int currentMissionNum = 0;

        public MissionBase[] Missions;

       public Game()
        {
            Missions = new MissionBase[3];
            Missions[0] = new Mission1_Learning();
            Missions[1] = new MissionTest();
            Missions[2] = new Mission3_FreeFlight();

        }

        public void StartGame(int missionNum)
        {
            currentMissionNum = missionNum;
            Missions[currentMissionNum].StartMiss();
            MenuController.mainmenuSwitch = 0;
        }

        

        public void Update()
        {
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
