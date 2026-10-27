using SFML.Graphics;
using SFML.System;
using System;


namespace Havier_Than_Air_S.Vehicle_parts
{
    public  class Gun_Tank_1: Detal
    {
        float angle = 0;
        Random rnd = new Random();
       public Gun_Tank_1()
       {
            Texture _texture  = new Texture(Program.m_TextureManager.allImage, new IntRect(154, 857, 59, 6));
            _sprite = new Sprite(_texture);
            _sprite.Origin = new Vector2f(58, 2);
            rnd.Next();
            _Collider = new Collider(new RectangleShape(new Vector2f(10, 10)));
            angle = rnd.Next(0, 65);
        }


        public override void Update()
        {
            base.Update();
        }
    }
}
