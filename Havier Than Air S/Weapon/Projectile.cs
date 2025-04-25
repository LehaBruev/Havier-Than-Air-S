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
        protected Vector2f currentProjectilePosition;
        protected Vector2f previousProjectilePosition;
        protected float currentProjectileAngle;
        protected float currentProjectileSpeed;
        protected float currentProjectilefuel;
        protected float currentProjectileRashod;
 
        //Сервисные
        float deltaProjectileSpeed;
        
        public Projectile()
        {
            currentProjectileStatus = ProjectileStatus.inPool;
        }

        virtual public void Start(Vector2f position, float angle)
        {
            currentProjectileStatus = ProjectileStatus.inAir;

            currentProjectilePosition = position;
            currentProjectileAngle = angle;

        }


        virtual public void Update()
        {

            //Вычисление позиции
            deltaProjectileSpeed = currentProjectileSpeed * (float)Program.deltaTimer.Delta();
            currentProjectilePosition = currentProjectilePosition + 
                                        Matematika.searchAB(currentProjectileAngle, deltaProjectileSpeed);
            



            //Расход
            currentProjectilefuel -= currentProjectileRashod * (float)Program.deltaTimer.Delta();
           
        }

        virtual public void DrawProjectile()
        {
            //Check
            if (currentProjectilefuel > 0)
            {
                // Отрисовка
                m_Rectangleshape.Position = currentProjectilePosition;
                m_Rectangleshape.Rotation = currentProjectileAngle;


                Program.window.Draw(m_Rectangleshape);
            }
            else
            {
                DeactivateProjectile();
                return;
            }
        }

        virtual public void DeactivateProjectile()
        {
            currentProjectileStatus = ProjectileStatus.inPool;
            //currentProjectilefuel = 0;
            //currentProjectileSpeed = 0.0f;
            currentProjectilePosition = Program.m_PullObjects.position;
        }



    }
}
