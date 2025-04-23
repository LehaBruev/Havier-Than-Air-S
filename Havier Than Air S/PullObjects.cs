using Havier_Than_Air_S.Missions;
using Havier_Than_Air_S.Weapon;
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
        private int projectilesCount = 40;

        //private RocketNRLauncher[] NRrockets;
        private NRocket[] NRockets;
        public Vector2f position;

        public PullObjects()
        {
            position = new Vector2f(2000, 2000);
            //NRrockets = new Rocket[NRroketsCount];
            NRockets = new NRocket[projectilesCount];
            for (int i = 0; i < NRockets.Length; i++)
            {
                NRockets[i] = new NRocket();
                NRockets[i].ProduseNRocket();
            }
        }         

        public void Start_Projectile(Vector2f position, float angle, MissionTest mission)
        {
            for (int i = 0; i < NRockets.Length; i++)
            {
                if (NRockets[i].currentProjectileStatus == ProjectileStatus.inPool)
                {
                    NRockets[i].Start(position, angle, mission);
                    return;
                }
                
            }
        }

        public void Update()
        {
            for (int i = 0;i < NRockets.Length;i++)
            {
                if (NRockets[i].currentProjectileStatus == ProjectileStatus.inAir)
                {
                    NRockets[i].Update();
                }
            }
        }
    }
}
