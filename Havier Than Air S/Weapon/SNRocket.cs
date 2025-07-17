using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Weapon
{
    public enum SNRmode
    {
        checkMousePosition,
        checkLaserPosition,
        rememberPosition,
        rememberTarget


    }

    public class SNRocket: Projectile
    {


        //Параметры
        private Vector2f rocketSize = new Vector2f(14 * 3f, 14);
        private Vector2f rocketOrigin = new Vector2f(7f, 7f);
        private Color rocketColor = Color.White;
        private float rocketRashod = 1f;
        private float rocketFuel = 3f;
        private float rocketSpeed = 75;
        private float NRocketWeight = 100;
        private float damagePower = 91;

        // Особые
        private float speedAxeleration = 1.5f;
        private float currentSpeedAxeleration = 0;
        private float maxSpeed = 500;

        Texture rocketTexture;

        

        // Звуки
        string rocketSound = "rocket1.wav";

        // Настройки для снр
        SNRmode snrmode = SNRmode.checkMousePosition;
        Vector2f currentTargetPosition;
        float manageability = 15;

        public SNRocket()
        {

            typeOfObject = TypeOfObject.sr;
            projectileDamage = damagePower;

            currentProjectileSpeed = rocketSpeed;
            currentProjectilefuel = rocketFuel;
            currentProjectileRashod = rocketRashod;
            rocketTexture = new Texture("Nrocket_01.png");


            //shape
            m_Rectangleshape = new RectangleShape();
            //m_Rectangleshape.OutlineThickness = 1;
            m_Rectangleshape.OutlineColor = Color.Yellow;
            m_Rectangleshape.Size = rocketSize;
            m_Rectangleshape.Origin = rocketOrigin;
            //m_Rectangleshape.FillColor = rocketColor;
            m_Rectangleshape.Texture = rocketTexture;
            m_Rectangleshape.Scale = new Vector2f(1, 1);


            DeactivateProjectile();

        }


        public override void Start(Vector2f position, float angle, Vector2f speed)
        {
            base.Start(position, angle, speed);
            currentProjectilefuel = rocketFuel;
            currentProjectileSpeed = rocketSpeed;
            currentSpeedAxeleration = 0;
            projectileDamage = damagePower;

            if (snrmode == SNRmode.checkMousePosition)
            {
                currentTargetPosition = (new Vector2f(Mouse.GetPosition(Program.window).X, Mouse.GetPosition(Program.window).Y))+
                                            Program.offset-new Vector2f(Program.vMode.Width/2, Program.vMode.Height / 2);
            }
        }

        public override void Update()
        {
            currentSpeedAxeleration += speedAxeleration * Program.deltaTimer.Delta();
            currentProjectileSpeed += currentSpeedAxeleration;
            if (currentProjectileSpeed > maxSpeed) { currentProjectileSpeed = maxSpeed; }
            s
            RocketAngleUpdate();

            base.Update();
            base.DrawProjectile();


        }

        private void RocketAngleUpdate()
        {

            float angleToTarget = Matematika.AngleOfVector(currentTargetPosition - position);
            if (currentProjectileAngle > angleToTarget)
            {
                currentProjectileAngle -= manageability * Program.deltaTimer.Delta();
                if (currentProjectileAngle < angleToTarget) currentProjectileAngle = angleToTarget;
            }
            else
            {
                currentProjectileAngle += manageability * Program.deltaTimer.Delta();
                if (currentProjectileAngle > angleToTarget) currentProjectileAngle = angleToTarget;
            }




        }


        public override void DeactivateProjectile()
        {
            Program.m_PullObjects.StartObject(position, 0, new Vector2f(0, 0), TypeOfObject.bang);
            base.DeactivateProjectile();
        }






    }

    
}
