using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class StatisticaOfLevel
    {
        //
        public int CurrentScore = 0;
        public int CurrentMoney = 0;
        public float GameTime = 0;

        //
        public float FlighTime = 0;
        public float FuelRashodInLevel = 0;
        public int Landings = 0;
        public int repairings = 0;

        //
        public int ShotsGun = 0;
        public int ShotsNR = 0;
        public int TargetHits = 0;
        public int TargetDestroyed = 0;

        //
        public int MaxAltitude = 0;
        public int MaxSpeed = 0;

        //
        public int enemySpawned = 0;

        public void ClearIndicators()
        {
         CurrentScore = 0;
         CurrentMoney = 0;
         GameTime = 0;

        //
         FlighTime = 0;
         FuelRashodInLevel = 0;
        Landings = 0;
         repairings = 0;

        //
         ShotsGun = 0;
         ShotsNR = 0;
        TargetHits = 0;
        TargetDestroyed = 0;

        //
         MaxAltitude = 0;
         MaxSpeed = 0;

    }

    }
}
