using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Havier_Than_Air_S.Missions;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

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
        public static TextureManager mTextureManager = new TextureManager();
        public MainMenuController MenuController = new MainMenuController();

        // Переменные
        public MissionSwitch missionSwitch = MissionSwitch.mis3;

        //private MissionBase[] allMissions = new MissionBase[] { new Mission1_Learning() , new MissionTest(), new Mission3_FreeFlight() };

        //Mission1_Learning mission1 =  new Mission1_Learning();
        MissionBase missionTest = new Mission3_FreeFlight();

       

        public void StartGame()
        {
            ChangeGameMode(GameMode.Play,MissionSwitch.test);
            missionTest.StartMiss();
        }

        public void ChangeGameMode(GameMode mode, MissionSwitch mission)
        {
            GameState.currentGameMode = mode;
            //missionSwitch = mission;
            //mission1.Start();
            //mMagnitola.PlayMusic();

        }



        public void Update()
        {
            
            MenuController.Update();

            
                    missionTest.Update();
                
                
            
        }
    }
}
