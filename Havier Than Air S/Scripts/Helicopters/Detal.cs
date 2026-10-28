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
        //Параметры
        public Collider _Collider;
        protected Sprite _sprite;
        
        //Маркер позиции детали
        CircleShape _circleShape;
        bool positionMarkerOn = false;

        //Положение
        protected Vector2f _position;
        protected float _angle;
        public float DopAngle;

        //Крепление
        public Detal[] m_DetalyDaughters;
        public Vector2f[] m_DetalyDaughtersPoints;

        //Переменные
        public Vector2f[] CurrentDaughterPointsLocalPos;

        
        public Detal(Collider collider, Sprite sprite)
        {
            _Collider = collider;
            _sprite = sprite;
        }
        public Detal()
        { 
        }

        public Detal(Collider collider, Sprite sprite,bool markerBodyOn, bool markerPointsOn,bool centerOn)
        {
            _Collider = collider;
            _sprite = sprite;

            if (markerBodyOn || markerPointsOn || centerOn)
            {
                //МАРКЕРЫ
                _Collider.marker = new Marker(_Collider.shape, Color.Green, 4);
                positionMarkerOn = centerOn;

                if (markerBodyOn) _Collider.marker.ShapeOn = true;
                if (markerPointsOn) _Collider.marker.PointsOn = true;


                _circleShape = new CircleShape(6);
                _circleShape.Origin = new Vector2f(3, 3);
                _circleShape.FillColor = Color.Red;
            }
            
        }

        public virtual void setPosAndAngle(Vector2f pos, float ang)
        {
            _position = pos;
            _angle = ang + DopAngle;
        }

        public virtual void Update()
        {
            if (_sprite != null)
            {
                _sprite.Position = _position; //Обновление картинки
                _sprite.Rotation = _angle;    //
                Program.window.Draw(_sprite); //Отрисовка
            }

            if (_Collider != null)
            {
                _Collider.shape.Position = _position; //Обновление коллайдера
                _Collider.shape.Rotation = _angle;    //
                _Collider.Update();    //Отрисовка
            }

            //Работа с дочерними деталями
            if (m_DetalyDaughters != null)
            {
                for (int i = 0;i<m_DetalyDaughters.Length;i++)
                {
                    Vector2f texPointPos = Matematika.LocalPointOfRotationObject(m_DetalyDaughtersPoints[i], _angle);
                    m_DetalyDaughters[i].setPosAndAngle(texPointPos + _position,_angle);
                    m_DetalyDaughters[i].Update();
                }

            }

            //отображение маркера центра детали
            if (positionMarkerOn)
            {
                _circleShape.Position = _position;
                Program.window.Draw(_circleShape);
            }

        }
    }
}
