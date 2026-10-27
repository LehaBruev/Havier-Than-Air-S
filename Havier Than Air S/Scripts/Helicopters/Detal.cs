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


        //Положение
        protected Vector2f _position;
        protected float _angle;

        //Крепление
        public Vector2f[] AttachmentPoints;

        //Переменные
        public Vector2f[] CurrentAttachmentPointLocalPos;

        void CheckAttachPointPositions()
        {
            for (int i = 0; i < AttachmentPoints.Length; i++)
            {
                CurrentAttachmentPointLocalPos[i] = Matematika.LocalPointOfRotationObject(AttachmentPoints[i], _angle);
            }

        }


        public Detal(Collider collider, Sprite sprite, Vector2f[] attachPoints)
        {
            _Collider = collider;
            _sprite = sprite;
            AttachmentPoints = attachPoints;
            CurrentAttachmentPointLocalPos = new Vector2f[AttachmentPoints.Length];
        }
        public Detal(Collider collider, Sprite sprite)
        {
            _Collider = collider;
            _sprite = sprite;
        }
        public Detal()
        { 
        }

        public virtual void setPosAndAngle(Vector2f pos, float ang)
        {
            _position = pos;
            _angle = ang;
        }

        public virtual void Update()
        {
            if (AttachmentPoints != null)
            {
                CheckAttachPointPositions(); //Корректировка положений точек креплений
            }

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

            
            
            
        }




    }
}
