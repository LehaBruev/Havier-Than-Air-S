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
        //Форма
        public RectangleShape m_Rectangleshape;

        //Переменные
        public ProjectileStatus currentProjectileStatus;
        private Vector2f currentProjectilePosition;
        private float currentProjectileAngle;
        private float currentProjectileSpeed;
        private float currentProjectilefuel;
        protected float currentProjectileRashod;
 
        //Сервисные
        float deltaProjectileSpeed;
        

        virtual public void Start(Vector2f position, float angle)
        {
            currentProjectileStatus = ProjectileStatus.inAir;

            currentProjectilePosition = position;
            currentProjectileAngle = angle;

        }


        virtual public void Update()
        {
            //Check
            if (currentProjectilefuel > 0)
            {
                Program.window.Draw(m_Rectangleshape);
            }
            else
            {
                DeactivateProjectile();
                return;
            }

            //Вычисление позиции
            deltaProjectileSpeed = currentProjectileSpeed * (float)Program.deltaTimer.Delta();
            currentProjectilePosition = currentProjectilePosition + 
                                        Matematika.searchAB(currentProjectileAngle, deltaProjectileSpeed);
            // Отрисовка
            m_Rectangleshape.Position = currentProjectilePosition;
            m_Rectangleshape.Rotation = currentProjectileAngle;

            //Расход
            currentProjectilefuel -= currentProjectileRashod * (float)Program.deltaTimer.Delta();
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
