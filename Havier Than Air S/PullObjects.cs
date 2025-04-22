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

        private RocketNRLauncher[] NRrockets;
        private Projectile[] Projectiles;
        public Vector2f position;

        public PullObjects()
        {
            position = new Vector2f(2000, 2000);
            //NRrockets = new Rocket[NRroketsCount];
            Projectiles = new Projectile[projectilesCount];
            for (int i = 0; i < NRrockets.Length; i++)
            {
                Projectiles[i] = new Projectile();
            }
        }         

        public void Spawn_Projectile(Vector2f position, float angle, MissionTest mission)
        {
            for (int i = 0; i < Projectiles.Length; i++)
            {
                if (Projectiles[i].currentProjectileStatus == ProjectileStatus.inPool)
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
                if (NRrockets[i].currentRocketStatus == ProjectileStatus.inAir)
                {
                    NRrockets[i].MoveNRrocket();
                }
            }
        }
    }
}
