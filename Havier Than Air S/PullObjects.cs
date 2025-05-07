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
        inCase,
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
        private int NRcount = 1;
        private int GunBulletCount = 1;
        private int BangCount = 1;

        //Pulls
        private NRocket[] NRockets ;
        private GunBullet[] GunBullets;
        private Bang[] Bangs;

        //Сервис
        public Vector2f position = new Vector2f(2000, 2000);

        
        public void StartPull()
        {
            //NR pull
            NRockets = new NRocket[NRcount];
            for (int i = 0; i < NRockets.Length; i++) NRockets[i] = new NRocket();

            //Gun pull
            GunBullets = new GunBullet[GunBulletCount];
            for (int i = 0; i < GunBullets.Length; i++) GunBullets[i] = new GunBullet();

            //Bang pull
            Bangs = new Bang[BangCount];
            for (int i = 0; i < Bangs.Length; i++) Bangs[i] = new Bang(position);


        }

        public void StartObject(Vector2f position, float angle,TypeOfObject objectType)
        {
            
            if (objectType == TypeOfObject.nr)
            {
                for (int i = 0; i < NRockets.Length; i++)
                {
                    if (NRockets[i].currentProjectileStatus == PullStatus.inPool)
                    {
                        NRockets[i].Start(position, angle);
                        return;
                    }
                }
            }
            else if (objectType == TypeOfObject.gun)
            {
                for (int i = 0; i < GunBullets.Length; i++)
                {
                    if (GunBullets[i].currentProjectileStatus == PullStatus.inPool)
                    {
                        GunBullets[i].Start(position, angle);
                        return;
                    }

                }
            }else if (objectType == TypeOfObject.bang)
            {
                for (int i = 0; i < Bangs.Length; i++)
                {
                    if (Bangs[i].pullStatus == PullStatus.inPool)
                    {
                        Bangs[i].StartBang(position);
                        return;
                    }

                }
            }
        }

        

        public void Update()
        {
            for (int i = 0;i < NRockets.Length;i++)
            {
                if (NRockets[i].currentProjectileStatus == PullStatus.inAir)
                {
                    NRockets[i].Update();
                }
            }
            for (int i = 0; i < GunBullets.Length; i++)
            {
                if (GunBullets[i].currentProjectileStatus == PullStatus.inAir)
                {
                    GunBullets[i].Update();
                }
            }
            for (int i = 0; i < Bangs.Length; i++)
            {
                if (Bangs[i].pullStatus == PullStatus.inAir)
                {
                    Bangs[i].UpdateBang();
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
