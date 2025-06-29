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
        private int GunBulletCount = 75;
        private int NRcount = 8;
        private int SNRcount = 8;
        private int BangCount = 8;
        private int TankCount = 10;
        private int HousCount = 200;
        private int[] counts;


        //Pull
        private IMoovable[] IMoovables;

        //Сервис
        public Vector2f position = new Vector2f(2000, -2000);

        // Collisions
        public Collisions collisions;
        
        public void StartPull()
        {
            

            counts = new int[]
            {
                GunBulletCount,
                NRcount,
                SNRcount,
                BangCount,
                TankCount,
                HousCount
            };

            IMoovables = new IMoovable[ GunBulletCount + NRcount + SNRcount + BangCount + TankCount + HousCount];

            int n = 0;
            for (int m = 0; m < counts.Length; m++)
            {
                for (int i = 0; i < counts[m]; i++)
                {
                    if (m==0) IMoovables[n] = new GunBullet();
                    if (m==1) IMoovables[n] = new NRocket();
                    if (m==2) IMoovables[n] = new SNRocket();
                    if (m==3) IMoovables[n] = new Bang(position);
                    if (m==4) IMoovables[n] = new Tnk1();
                    if (m==5) IMoovables[n] = new Hous();
                    n += 1;
                }
            }


            collisions = Program.collisions;
        }

        public void StartObject(Vector2f position, float angle, Vector2f speed, TypeOfObject objectType)
        {
            for (int i = 0; i < IMoovables.Length; i++)
            {
                if (IMoovables[i]!=null && IMoovables[i].GetCurrentPullStatus() == PullStatus.inPool &&
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

                if ( (IMoovables[i].GetTypeOfObject() == TypeOfObject.gun || 
                    IMoovables[i].GetTypeOfObject() == TypeOfObject.nr ||
                    IMoovables[i].GetTypeOfObject() == TypeOfObject.sr) && 
                    IMoovables[i].GetCurrentPullStatus() == PullStatus.inAir && 
                    IMoovables[i].GetColliderStatus() == true)
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

                            }

                        }
                        if (IMoovables[k].GetTypeOfObject() == TypeOfObject.house && IMoovables[k].GetCurrentPullStatus() == PullStatus.inAir && IMoovables[i].GetColliderStatus() == true)
                        {
                            bool d = collisions.CheckShapesForCollision(IMoovables[i].GetShape(), IMoovables[k].GetShape());

                            if (d == true)
                            {

                                IMoovables[i].SetDamage(IMoovables[k]);
                                IMoovables[k].SetDamage(IMoovables[i]);
                            }

                        }
                    }
                }
            }






        }

    }
}
