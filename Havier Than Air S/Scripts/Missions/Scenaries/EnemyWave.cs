using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Scripts.Missions.Scenaries
{
    public class EnemyWave
    {

        public EnemyCrest[] Crests;
        public float prestartTimer = 0;
        public int currentCrest = 0;

        public EnemyWave(EnemyCrest[] crests, float timer)
        {
            prestartTimer = timer;
            Crests = crests;
        }









    }
}
