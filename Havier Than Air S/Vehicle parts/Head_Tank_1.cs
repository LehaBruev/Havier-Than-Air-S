using SFML.Graphics;
using SFML.System;
using System;


namespace Havier_Than_Air_S.Vehicle_parts
{
    public  class Head_Tank_1: Detal
    {

       public Head_Tank_1()
       {
            _origin = new Vector2f(11,6);
            _shape = new RectangleShape(new Vector2f(10, 10));
            _texture  = new Texture(Program.m_TextureManager.allImage, new IntRect(159, 878, 45, 12));
            _sprite = new Sprite(_texture);
            _sprite.Origin = _origin;

        }



        public override void Update()
        {
            base.Update();
            
        }
    }
}
