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
        //Количество
        private int NRcount = 40;

        //Pulls
        private NRocket[] NRockets ;

        //Сервис
        public Vector2f position = new Vector2f(2000, 2000);

        public PullObjects()
        {
            
        }  
        
        public void StartPull()
        {
            //NR pull
            NRockets = new NRocket[NRcount];
            for (int i = 0; i < NRockets.Length; i++) NRockets[i] = new NRocket();

        }

        public void StartObject(Vector2f position, float angle,TypeOfWeapon weaponTyte)
        {
            
            if (weaponTyte == TypeOfWeapon.nr)
            {
                for (int i = 0; i < NRockets.Length; i++)
                {
                    if (NRockets[i].currentProjectileStatus == ProjectileStatus.inPool)
                    {
                        NRockets[i].Start(position, angle);
                        return;
                    }

                }
            }
            else if (weaponTyte == TypeOfWeapon.gun)
            {

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

       

        public void ChechRocketCollider()
        {
            //missTest.CheckTargetCollider(rectangleShape.GetGlobalBounds());

            //rectangleShape.GetGlobalBounds().Intersects

        }

    }
}
