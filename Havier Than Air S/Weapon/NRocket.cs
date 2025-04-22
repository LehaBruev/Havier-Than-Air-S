using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Havier_Than_Air_S.Weapon
{
    public class NRocket: Projectile
    {
        Texture rocketTexture;
        Sprite rocketSprite;
        public float rocketRashod = 1.0f;

        public void ProduseNRocket()
        {
            projectileRashod = rocketRashod;

            //sprite
            rocketTexture = new Texture("Nrocket_01.png");
            rocketSprite = new Sprite();
            rocketSprite.Texture = rocketTexture;
            rocketSprite.TextureRect = new IntRect(1, 1, 100, 100);
            rocketSprite.Color = Color.Green;
            rocketSprite.GetGlobalBounds().Intersects(rocketSprite.GetGlobalBounds());

            //shape
            rectangleShape = new RectangleShape();
            //rectangleShape.Position = new Vector2f(0, 0);
            //rectangleShape.Rotation = 70;
            rectangleShape.Size = new Vector2f(80.0f, 10);
            rectangleShape.Origin = new Vector2f(5, 5);
            rectangleShape.FillColor = Color.Red;

            
        }
    }
}
