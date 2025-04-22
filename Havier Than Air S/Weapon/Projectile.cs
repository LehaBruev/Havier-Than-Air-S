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
        public RectangleShape rectangleShape;
        public float projectileRashod;

        //Переменные

        public float currentProjectilefuel;
        public float currentProjectileSpeed;
        public Vector2f currentProjectilePosition;
        public float currentProjectileAngle;
        public float currentRocketfuel;

        public void Start(Vector2f position, float angle, MissionTest mission)
        {
            currentProjectileStatus = ProjectileStatus.inAir;
            currentProjectilePosition = position;
            currentProjectileAngle = angle;

        }

        public void Update()
        {
            if (currentProjectileStatus == ProjectileStatus.inAir)
            {
                ChechRocketCollider();
                //currentRocketPosition = new Vector2f(currentRocketPosition.X +1.0f,
                //                                        currentRocketPosition.Y +1.0f);

                currentProjectileSpeed = currentProjectileSpeed * (float)Program.deltaTimer.Delta();
                currentProjectilePosition = currentProjectilePosition + Matematika.searchAB(currentProjectileAngle,
                                                                                    currentProjectileSpeed);


                //rocketSprite.Position = currentRocketPosition;
                rectangleShape.Position = currentProjectilePosition;
                rectangleShape.Rotation = currentProjectileAngle;
                // Отрисовка

                //расход
                if (currentRocketfuel > 0)
                {
                    currentRocketfuel -= projectileRashod * (float)Program.deltaTimer.Delta();
                    Program.window.Draw(rectangleShape);
                }
                else
                {
                    DeactivateProjectile();
                }
            }
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
            currentProjectilePosition = Program.PullObjects.position;
        }
    }
}
