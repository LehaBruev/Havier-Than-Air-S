using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Scripts.Missions.Scenaries
{
    internal class Scenariy_missFreeFlight
    {


        int currentWave = 0;
        int currentMegaWave = 0;
        EnemyWave[] Waves;
        Clock clock = new Clock();

        TypeOfObject type;

        Spawn spawn;

        public bool ScenarioReleased = false;

        public Scenariy_missFreeFlight(Spawn sp)
        {
            spawn = sp; //Спавн

            EnemyCrest[] crest1 = new EnemyCrest[]
            {
           new EnemyCrest(TypeOfObject.Jeep_1, 5, 3f),  // три танка через каждые 0.5 секунды
            new EnemyCrest(TypeOfObject.tank1, 2, 7f),
            new EnemyCrest(TypeOfObject.tank2, 1, 8f),
            new EnemyCrest(TypeOfObject.enemyPVO, 1, 7f),
             };

            EnemyCrest[] crest2 = new EnemyCrest[]
            {
            new EnemyCrest(TypeOfObject.tank1, 4, 5.5f),  // три танка через каждые 0.5 секунды
            new EnemyCrest(TypeOfObject.enemyPVO, 2, 4f),
            new EnemyCrest(TypeOfObject.Jeep_1, 10, 2.8f),
            new EnemyCrest(TypeOfObject.tank2, 3, 8f)
             };


            Waves = new EnemyWave[2];
            Waves[0] = new EnemyWave(crest1, 1.5f); // волна начнет работу через 1.5 секунды
            Waves[1] = new EnemyWave(crest2, 10f); // волна начнет работу через 1.5 секунды
        }


        public void Update()
        {
            if (ScenarioReleased == false)
            {
               if (Waves[currentMegaWave].Crests[Waves[currentMegaWave].currentCrest].CountInWave > 0) // Враги в гребне еще есть
                {
                    if (clock.ElapsedTime.AsSeconds()>= Waves[currentMegaWave].Crests[Waves[currentMegaWave].currentCrest].PrestartTimer) // Ждем таймер
                    {
                        spawn.SpawnEnemy(Waves[currentMegaWave].Crests[Waves[currentMegaWave].currentCrest].TypeOfEnemy);
                        Waves[currentMegaWave].Crests[Waves[currentMegaWave].currentCrest].CountInWave -= 1;
                        clock.Restart();

                    }

                }
               else
                {
                    Waves[currentMegaWave].currentCrest += 1; // Переход на следующий гребень
                    if (Waves[currentMegaWave].currentCrest> Waves[currentMegaWave].Crests.Length - 1) // Номер гребня больше чем количество гребней
                    {
                        currentMegaWave += 1; // Переход на след волну
                        if(currentMegaWave>Waves.Length - 1) // Номер волны больше чем количество волн
                        {
                            ScenarioReleased = true; // Окончить сценарий
                        }
                    }
                    clock.Restart();

                }

            }




        }

        private void ADDWave(TypeOfObject type, int count, float prestartTime) // Тит врага, количество, пауза перед стартом, 
        {
            


        }












    }
}
