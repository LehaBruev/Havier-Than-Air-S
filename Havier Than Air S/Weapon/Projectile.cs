using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havier_Than_Air_S.Missions;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S.Weapon
{


    public enum ProjectileStatus
    {
        inCase,
        inAir,
        inPool
    }

    public class Projectile
    {
        public ProjectileStatus currentProjectileStatus;
        private Vector2f currentProjectilePosition;
        private float currentProjectileAngle;

        //Переменные

        private float currentProjectilefuel;
        private float currentProjectileSpeed;

        public float projectileRashod;

        public void Start(Vector2f position, float angle, MissionTest mission)
        {
            //missTest = mission;
            DeactivateProjectile();
            currentProjectileStatus = ProjectileStatus.inAir;

            currentProjectilePosition = position;
            currentProjectileAngle = angle;

        }


        virtual public void Update()
        {
                //currentRocketPosition = new Vector2f(currentRocketPosition.X +1.0f,
                //                                        currentRocketPosition.Y +1.0f);

                currentRocketSpeed = NRrocketspeed * (float)Program.deltaTimer.Delta();
                currentRocketPosition = currentRocketPosition + Matematika.searchAB(currentRocketAngle, currentRocketSpeed);



                //rocketSprite.Position = currentRocketPosition;
                rectangleShape.Position = currentRocketPosition;
                rectangleShape.Rotation = currentRocketAngle;
                // Отрисовка

                //расход
                if (currentRocketfuel > 0)
                {
                    currentRocketfuel -= NRrocketRashod * (float)Program.deltaTimer.Delta();
                    Program.window.Draw(NR);
                }
                else
                {
                DeactivateProjectile();
                }
            //ChechRocketCollider();
        }




        public void ChechRocketCollider()
        {
            //missTest.CheckTargetCollider(rectangleShape.GetGlobalBounds());

            //rectangleShape.GetGlobalBounds().Intersects

        }


        virtual public void DeactivateProjectile()
        {
            currentProjectileStatus = ProjectileStatus.inPool;
            currentProjectilefuel = 0;
            currentProjectileSpeed = 0.0f;
            currentProjectilePosition = Program.m_PullObjects.position;
        }



    }
}
