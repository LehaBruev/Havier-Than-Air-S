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
        Marker marker;

        //Форма
        public RectangleShape m_Rectangleshape;

        //Переменные
        public float projectileWeight;
        public float projectileDamage = 0;
        
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
        protected bool colliderStatus;
        

        // Sound
        protected Sound projectileSound;

        public Projectile()
        {
            pullStatus = PullStatus.inPool;
            projectileSound = new Sound();
            
        }

        virtual public void Start(Vector2f pos, float angle, Vector2f speed)
        {
            pullStatus = PullStatus.inAir;
            colliderStatus = true;

            position = pos;
            currentProjectileAngle = angle;
            if (projectileSound != null) projectileSound.Play();
            currentProjectileSpeed = Matematika.searchdistance((Vector2i)speed, new Vector2i(0, 0));
           //marker = new Marker(m_Rectangleshape, Color.Green, 3);
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
               // marker.UpdatePoints(m_Rectangleshape);
               // marker.Update();
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

        public virtual void SetDamage(IMoovable obj)
        {
            DeactivateProjectile();
        }

        public bool GetColliderStatus()
        {
            return colliderStatus;
        }
    }
}
