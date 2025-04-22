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
        private NRocket[] Projectiles;
        public Vector2f position;

        public PullObjects()
        {
            position = new Vector2f(2000, 2000);
            //NRrockets = new Rocket[NRroketsCount];
            Projectiles = new NRocket[projectilesCount];
            for (int i = 0; i < Projectiles.Length; i++)
            {
                Projectiles[i] = new NRocket();
                Projectiles[i].ProduseNRocket();
            }
        }         

        public void Spawn_Projectile(Vector2f position, float angle, MissionTest mission)
        {
            for (int i = 0; i < Projectiles.Length; i++)
            {
                if (Projectiles[i].currentProjectileStatus == ProjectileStatus.inPool)
                {
                    Projectiles[i].Start(position, angle, mission);
                    return;
                }
                
            }
        }

        public void Update()
        {
            for (int i = 0;i < Projectiles.Length;i++)
            {
                if (Projectiles[i].currentProjectileStatus == ProjectileStatus.inAir)
                {
                    Projectiles[i].Update();
                }
            }
        }
    }
}
