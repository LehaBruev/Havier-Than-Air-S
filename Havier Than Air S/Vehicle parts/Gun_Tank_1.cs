using SFML.Graphics;
using SFML.System;
using System;


namespace Havier_Than_Air_S.Vehicle_parts
{
    public  class Gun_Tank_1: Detal
    {

       public Gun_Tank_1()
       {
            _origin = new Vector2f(58,2);
            _shape = new RectangleShape(new Vector2f(10, 10));
            _texture  = new Texture(Program.m_TextureManager.allImage, new IntRect(154, 857, 59, 6));
            _sprite = new Sprite(_texture);
            _sprite.Origin = _origin;

        }



        public override void Update()
        {
            base.Update();
            
        }
    }
}
