using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havier_Than_Air_S.Missions;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S.Weapon
{


    public class Projectile : IMoovable
    {
        

        //Форма
        public RectangleShape m_Rectangleshape;

        //Переменные
        public float projectileWeight;
        
        protected Vector2f position;
        protected Vector2f previousProjectilePosition;
        protected float currentProjectileAngle;
        protected float currentProjectileSpeed;
        protected float currentProjectilefuel;
        protected float currentProjectileRashod;
 
        //Сервисные
        float deltaProjectileSpeed;
        protected TypeOfObject typeOfObject;
        PullStatus pullStatus;

        // Sound
        protected Sound projectileSound;

        public Projectile()
        {
            pullStatus = PullStatus.inPool;
            projectileSound = new Sound();
        }

        virtual public void Start(Vector2f pos, float angle)
        {
            pullStatus = PullStatus.inAir;

            position = pos;
            currentProjectileAngle = angle;
            if (projectileSound != null) projectileSound.Play();
        }


        virtual public void Update()
        {

            //Вычисление позиции
            deltaProjectileSpeed = currentProjectileSpeed * (float)Program.deltaTimer.Delta();
            position = position + Matematika.searchAB(currentProjectileAngle, deltaProjectileSpeed);
            

            //Расход
            currentProjectilefuel -= currentProjectileRashod * (float)Program.deltaTimer.Delta();


            //rocketSound.Position = new Vector3f( currentProjectilePosition.X,
            //                             currentProjectilePosition.Y,0);

        }

        virtual public void DrawProjectile()
        {
            //Check
            if (currentProjectilefuel > 0)
            {
                // Отрисовка
                m_Rectangleshape.Position = position;
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
            if (projectileSound != null ) projectileSound.Stop();
            pullStatus = PullStatus.inPool;
            //currentProjectilefuel = 0;
            //currentProjectileSpeed = 0.0f;
            position = Program.m_PullObjects.position;
        }

        public TypeOfObject GetTypeOfObject()
        {

            return typeOfObject;
        }
        public PullStatus GetCurrentPullStatus()
        {

            return pullStatus;
        }

        public Shape GetShape()
        {

            return m_Rectangleshape;
        }

        public Vector2f GetPosition()
        {
            return position;
        }
    }
}
