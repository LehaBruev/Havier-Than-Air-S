using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using Havier_Than_Air_S.Missions;
using System.Runtime.InteropServices;

namespace Havier_Than_Air_S.Weapon
{
    public class GunBullet : Projectile 
    {
        //Параметры
        private Vector2f rocketSize = new Vector2f(5.0f, 1);
        private Vector2f rocketOrigin = new Vector2f(0.5f, 0.5f);
        private Color rocketColor = Color.Yellow;
        private float rocketRashod = 1f;
        private float rocketFuel = 3;
        private float rocketSpeed = 1000;
        private float NRocketWeight = 100;
        

        //Особые
        private float bulletGravity = 1;
        private float bulletGravityShag = 5;
        private float currentBulletGravity = 0;
        private float maxSpeedResist = 700;

        public GunBullet()
        {
            currentProjectileSpeed = rocketSpeed;
            currentProjectilefuel = rocketFuel;
            currentProjectileRashod = rocketRashod;
            

            //shape
            m_Rectangleshape = new RectangleShape();
            m_Rectangleshape.Size = rocketSize;
            m_Rectangleshape.OutlineThickness = 0.5f;
            m_Rectangleshape.Origin = rocketOrigin;
            m_Rectangleshape.FillColor = rocketColor;

            DeactivateProjectile();
            /*
          //sprite
          rocketTexture = new Texture("Nrocket_01.png");
          rocketSprite = new Sprite();
          rocketSprite.Texture = rocketTexture;
          rocketSprite.TextureRect = new IntRect(1, 1, 100, 100);
          rocketSprite.Color = Color.Green;
          rocketSprite.GetGlobalBounds().Intersects(rocketSprite.GetGlobalBounds());
          */
        }

        public override void Start(Vector2f position, float angle)
        {
            
            base.Start(position, angle);
            currentProjectilefuel = rocketFuel;
            currentBulletGravity = 0;
            currentProjectileSpeed = rocketSpeed;
        }

        public override void Update()
        {

            
            currentBulletGravity += bulletGravityShag * Program.deltaTimer.Delta();
            currentProjectilePosition = new Vector2f(currentProjectilePosition.X,
                                        currentProjectilePosition.Y + currentBulletGravity);
            
            /*
            currentBulletGravity += bulletGravityShag * Program.deltaTimer.Delta(); //червячки
            currentProjectileAngle += currentBulletGravity;
            */


            float coef = currentProjectileSpeed / rocketSpeed * maxSpeedResist;
            currentProjectileSpeed -= coef * Program.deltaTimer.Delta();
            base.Update();
        }
    }
}
