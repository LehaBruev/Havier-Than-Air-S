using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Scripts.Missions.Scenaries
{
    public class EnemyCrest
    {
        public float PrestartTimer = 0;
        public TypeOfObject TypeOfEnemy;
        public int CountInWave = 0;

        public EnemyCrest(TypeOfObject type, int count, float prestartTime)
        {
            TypeOfEnemy = type;
            CountInWave = count;
            PrestartTimer = prestartTime;
        }






    }
}
