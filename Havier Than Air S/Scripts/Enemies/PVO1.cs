using Havier_Than_Air_S.Scripts.Enemies;
using Havier_Than_Air_S.Vehicle_parts;
using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;
using System;

namespace Havier_Than_Air_S.Enemies
{
    public class PVO1: Base_Vehicle
    {

        public PVO1()
        {
            typeofObject = TypeOfObject.enemyPVO;

            Shape shape = new RectangleShape(new Vector2f(124, 40));
            shape.Origin = new Vector2f(62,40);

            Texture body = new Texture(Program.m_TextureManager.allImage, new IntRect(20, 307, 107, 69));
            Sprite bodySprite = new Sprite(body);
            bodySprite.Scale = new Vector2f(1.25f,1.25f);
            bodySprite.Origin = new Vector2f(48, 65); 

            detaly = new Detal[1];
            detaly[0] = new Detal(new Collider(shape), bodySprite,true,false,true);
            detalyPoints = new Vector2f[detaly.Length];

            AddShapeToCoolidersShapes(shape);
        }

        public override void Start(Vector2f p, float a, Vector2f s)
        {
            base.Start(p, a, s);

            maxLifes = 150;
            currentLifes = 150;
            speed = 65;
            angleNaklonSpeed = 0.5f;

        }



    }
}
