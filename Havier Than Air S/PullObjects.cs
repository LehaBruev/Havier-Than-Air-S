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
    public enum PullStatus
    {
        inAir,
        inPool
    }

    public enum TypeOfObject
    {
        gun,
        nr,
        sr,
        bang
        
    }

    public class PullObjects
    {
        //Количество
        private int GunBulletCount = 30;
        private int NRcount = 5;
        private int BangCount = 5;

        //Pull
        private IMoovable[] IMoovables;

        //Сервис
        public Vector2f position = new Vector2f(2000, 2000);

        
        public void StartPull()
        {
            IMoovables = new IMoovable[NRcount+GunBulletCount+BangCount];

            for (int i = 0; i < NRcount; i++) IMoovables[i] = new NRocket();
            for (int i = NRcount; 
                     i < NRcount + GunBulletCount; i++) IMoovables[i] = new GunBullet();
            for (int i = NRcount + GunBulletCount;
                     i < NRcount + GunBulletCount + BangCount; i++) IMoovables[i] = new Bang(position);


        }

        public void StartObject(Vector2f position, float angle,TypeOfObject objectType)
        {
            for (int i = 0; i < IMoovables.Length; i++)
            {
                if (IMoovables[i].GetCurrentPullStatus() == PullStatus.inPool &&
                    IMoovables[i].GetTypeOfObject() == objectType)
                {
                    IMoovables[i].Start(position, angle);
                    return;
                }
            }
        }

        public void Update()
        {
            
            for (int i = 0; i < IMoovables.Length; i++)
            {
                if (IMoovables[i].GetCurrentPullStatus() == PullStatus.inAir)
                {
                    IMoovables[i].Update();
                }
            }
        }

       

        public void CheckRocketCollider()
        {
            //missTest.CheckTargetCollider(rectangleShape.GetGlobalBounds());

            //rectangleShape.GetGlobalBounds().Intersects

        }

    }
}
