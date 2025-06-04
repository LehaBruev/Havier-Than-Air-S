using Havier_Than_Air_S.Enemies;
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
        bang,
        enemy,
        house
        
    }

    public class PullObjects
    {
        //Количество
        private int GunBulletCount = 30;
        private int NRcount = 5;
        private int BangCount = 5;
        private int TankCount = 10;
        private int HousCount = 200;

        //Pull
        private IMoovable[] IMoovables;

        //Сервис
        public Vector2f position = new Vector2f(2000, -2000);

        // Collisions
        public Collisions collisions;
        
        public void StartPull()
        {
            IMoovables = new IMoovable[NRcount+GunBulletCount+BangCount+ TankCount];

            for (int i = 0; i < NRcount; i++) IMoovables[i] = new NRocket();
            for (int i = NRcount; 
                     i < NRcount + GunBulletCount; i++) IMoovables[i] = new GunBullet();
            for (int i = NRcount + GunBulletCount;
                     i < NRcount + GunBulletCount + BangCount; i++) IMoovables[i] = new Bang(position);
            for (int i = NRcount + GunBulletCount + BangCount;
                     i < NRcount + GunBulletCount + BangCount + TankCount; i++) IMoovables[i] = new Tnk1();
            for (int i = NRcount + GunBulletCount + BangCount + TankCount;
                     i < NRcount + GunBulletCount + BangCount + TankCount + HousCount; i++) IMoovables[i] = new Hous();

            collisions = Program.collisions;
        }

        public void StartObject(Vector2f position, float angle, Vector2f speed, TypeOfObject objectType)
        {
            for (int i = 0; i < IMoovables.Length; i++)
            {
                if (IMoovables[i].GetCurrentPullStatus() == PullStatus.inPool &&
                    IMoovables[i].GetTypeOfObject() == objectType)
                {
                    IMoovables[i].Start(position, angle, speed);
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
            CheckCollisions();
        }

       

        public void CheckCollisions()
        {

            for (int i = 0; i < IMoovables.Length; i++)
            {

                if (IMoovables[i].GetTypeOfObject() == TypeOfObject.gun && IMoovables[i].GetCurrentPullStatus() == PullStatus.inAir && IMoovables[i].GetColliderStatus() == true)
                {
                    for (int k = 0; k < IMoovables.Length; k++)
                    {
                        if (IMoovables[k].GetTypeOfObject() == TypeOfObject.enemy && IMoovables[k].GetCurrentPullStatus() == PullStatus.inAir && IMoovables[i].GetColliderStatus() == true)
                        {
                           bool d = collisions.CheckShapesForCollision(IMoovables[i].GetShape(), IMoovables[k].GetShape());

                            if (d == true)
                            {

                                IMoovables[i].SetDamage(IMoovables[k]);
                                IMoovables[k].SetDamage(IMoovables[i]);


                                Console.Write("" + IMoovables[i] + " VS " + IMoovables[k]);
                            }

                        }
                    }
                }
            }






        }

    }
}
