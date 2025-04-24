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

        //результаты
        float resultsmenuswitch = 0; //меню результатов
        float resultmenuchoise = 0; //меню результатов ывбор кнопки
        float money = 0; //очки
        float hiscore = 0; //рекорд очков

        float flighttimerecord = 0; //рекорд нахождения в воздухе
        float landingquantity = 0; //количество посадок
        float NRrocketslaunched = 0; //выпущено NR ракет количество
        float targetbingos = 0; //попаданий по цели
        float buk1destroyes = 0; //уничтожено буков1
        float tank1destroyes = 0; //уничтожено танков1

        float repairings = 0; //Отремонтирован вертолет








        public GameMode currentGameMode;
        public GameMode CurrentMode => currentGameMode;

        public GameState() 
        {
            currentGameMode = GameMode.MainMenu;

        }

        public void SetGameMode(GameMode gameMode)
        {
            currentGameMode = gameMode;

        }

        //награды
        float tank1reward = 10000; //Получено повреждений
        float buk1reward = 30000; //Получено повреждений
                                  //static float repairings = 0; //Отремонтирован вертолет

/*
 * //результаты
flighttime = 0; //время нахождения в воздухе

landingquantity = 0; //количество посадок
NRrocketslaunched = 0; //выпущено NR ракет количество
targetbingos = 0; //попаданий по цели
buk1destroyes = 0; //уничтожено буков1
tank1destroyes = 0; //уничтожено танков1
fuelusedup = 0; //израсходовано топлива
repairings = 0; //Отремонтирован вертолет
getdamages = 0; //Получено повреждений

        */



}
}
