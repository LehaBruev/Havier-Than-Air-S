using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using Havier_Than_Air_S.Missions;

namespace Havier_Than_Air_S.Weapon
{
    public class NRocket : Projectile 
    {
        //Параметры
        private Vector2f rocketSize = new Vector2f(25.0f, 5);
        private Vector2f rocketOrigin = new Vector2f(2.5f, 2.5f);
        private Color rocketColor = Color.Red;
        private float rocketRashod = 1f;
        private float rocketFuel = 5;
        private float rocketSpeed = 85;
        private float NRocketWeight = 100;

        //Особые
        private float speedAxeleration = 8;
        private float currentSpeedAxeleration = 0;
        private float maxSpeed = 1200;

        public NRocket()
        {
            currentProjectileSpeed = rocketSpeed;
            currentProjectilefuel = rocketFuel;
            currentProjectileRashod = rocketRashod;
            

            //shape
            m_Rectangleshape = new RectangleShape();
            m_Rectangleshape.OutlineThickness = 3;
            m_Rectangleshape.OutlineColor = Color.Yellow;
            m_Rectangleshape.Size = rocketSize;
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
            currentProjectileSpeed = rocketSpeed;
            currentSpeedAxeleration = 0;
        }

        public override void Update()
        {
            currentSpeedAxeleration += speedAxeleration*Program.deltaTimer.Delta(); 
            currentProjectileSpeed += currentSpeedAxeleration;
            if (currentProjectileSpeed > maxSpeed) { currentProjectileSpeed = maxSpeed; }
            base.Update();
            
        }

    

    }
}
