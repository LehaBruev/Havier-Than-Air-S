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
        
        public static SoundManager soundManager = new SoundManager();
        public static Magnitola mMagnitola = new Magnitola();
        public static TextureManager mTextureManager = new TextureManager();
        public MainMenuController MenuController = new MainMenuController();
        public PullObjects Pull = new PullObjects();

        public MissionSwitch missionSwitch = MissionSwitch.mis1;
        public MouseController MouseController = new MouseController();

        private Sprite mBackgroundSprite;

        Mission1_Learning mission1 =  new Mission1_Learning();
        MissionTest missionTest = new MissionTest();

        public Game()
        {
            StartGame();
        }

        private void StartGame()
        {
            //MouseController = new MouseController();
            //missionSwitch = MissionSwitch.mis1;
            //missionTest = new MissionTest();  

            
            //GameState = new GameState();
            //MenuController = new MainMenuController();
            //mMagnitola = new Magnitola();
            //mTextureManager = new TextureManager();

            //mission1 = new Mission1_Learning();
            //Pull = new PullObjects();

            //отладка
           // ChangeGameMode(GameMode.MainMenu,MissionSwitch.mis1);
            ChangeGameMode(GameMode.Play,MissionSwitch.test);
        }

        public void ChangeGameMode(GameMode mode, MissionSwitch mission)
        {
            GameState.currentGameMode = mode;
            missionSwitch = mission;
            //mission1.Start();
            //mMagnitola.PlayMusic();

        }

        // SetFont("comic.ttf"); // Шрифт
        // PlayMusic(mainmenumusic, volume);
        //playingmusic = mainmenumusic;
        //Меню
        int mainmenuSwitch = 1;
         int levelchoise = 0;
         int menuchoise2 = 0;
         int newgame = 0;
         int gameplaying = 0;
         int menudelay = 50;
         int podskazkaswitch = 1;

        //Миссии
         int checkdelay = 50;
         int missionswitch = 0;
         int volnadelay = 0;
         int volnadelay2 = 0;
         int basedurability = 10;
         int winpobeda = 0;



        //результаты
         float resultsmenuswitch = 0; //меню результатов
         float resultmenuchoise = 0; //меню результатов ывбор кнопки
         float money = 0; //очки
         float hiscore = 0; //рекорд очков
         float flighttime = 0; //время нахождения в воздухе
         float flighttimerecord = 0; //рекорд нахождения в воздухе
         float landingquantity = 0; //количество посадок
         float NRrocketslaunched = 0; //выпущено NR ракет количество
         float targetbingos = 0; //попаданий по цели
         float buk1destroyes = 0; //уничтожено буков1
         float tank1destroyes = 0; //уничтожено танков1
         float fuelusedup = 0; //израсходовано топлива
         float repairings = 0; //Отремонтирован вертолет
         float getdamages = 0; //Получено повреждений


        public void Update()
        {
            
            MouseController.CheckMouse();
            mTextureManager.DrawBackground();
            
          
               MenuController.Update();

            
            if (GameState.CurrentMode == GameMode.Play)
            {
                if (missionSwitch == MissionSwitch.mis1)
                {
                    mission1.UpdateMission_1();  
                }
                else if (missionSwitch == MissionSwitch.test)
                {
                    missionTest.Update();
                }
                MooveObjects();
                DrawObjects();
            }

            Pull.Update();
             
        }


        public void MooveObjects()
        {
            

        }

        public void DrawObjects()
        {
           

        }


        //награды
        float tank1reward = 10000; //Получено повреждений
         float buk1reward = 30000; //Получено повреждений
         //static float repairings = 0; //Отремонтирован вертолет

 
    }
}
