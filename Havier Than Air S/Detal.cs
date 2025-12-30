using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class Detal
    {

        protected Shape _shape;

        protected Texture _texture;
        protected Sprite _sprite;


        protected Vector2f _position;
        protected float _angle;
        protected Vector2f _origin;

        //Маркер
        Marker marker;
        Color color = new Color(Color.Green);
        int markerON = 0;

        public Detal()
        {
            _shape = new RectangleShape(new Vector2f(5, 5));
            marker = new Marker(_shape, color, 3);

        }

        public virtual void setPosAndAngle(Vector2f pos, float ang)
        {
            _position = pos;
            _angle = ang;
        }

        public virtual void Update()
        {
            _sprite.Position = _position;
            _sprite.Rotation = _angle;
            _shape.Position = _position;
            _shape.Rotation = _angle;
            Program.window.Draw(_sprite);
            Program.window.Draw(_shape);
            marker.Update();
        }




    }
}
