using Havier_Than_Air_S.Missions;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class PullObjects
    {
        private int NRroketsCount = 30;

        private Rocket[] NRrockets;

        public PullObjects()
        {

            NRrockets = new Rocket[NRroketsCount];
            for (int i = 0; i < NRrockets.Length; i++)
            {
                NRrockets[i] = new Rocket();
            }
        }         

        public void SpawnNR_Rocket(Vector2f position, float angle, MissionTest mission)
        {
            for (int i = 0; i < NRrockets.Length; i++)
            {
                if (NRrockets[i].currentRocketStatus == RocketStatus.inPool)
                {
                    NRrockets[i].StartRocket(position, angle, mission);
                    return;
                }
                
            }
        }

        public void Update()
        {
            for (int i = 0;i < NRrockets.Length;i++)
            {
                if (NRrockets[i].currentRocketStatus == RocketStatus.inAir)
                {
                    NRrockets[i].MoveNRrocket();
                }
            }
        }
    }
}
