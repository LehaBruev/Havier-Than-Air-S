using Havier_Than_Air_S.Scripts;
using Havier_Than_Air_S.Scripts.Enemies;
using Havier_Than_Air_S.Vehicle_parts;
using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;
using System;

namespace Havier_Than_Air_S.Enemies
{
    public class Tnk1: Base_Vehicle
    {
        

        public Tnk1()
        {
            typeofObject = TypeOfObject.tank1;//тип объекта

            detaly = new Detal[1];//массив деталей, прикрепленных к модели (0= корпус, 1=тестировочная)
            detalyPoints = new Vector2f[detaly.Length];//позиции деталей, прикрепленных к модели
            SetDetalKorpus(); // Корпус
            SetDetalBashnya(); // Башня
            SetDetalPushka(); // Ствол
            //SetTestDetal(); //ОПЦИЯ. В случае отключения, понизь массив "detaly" на 1 !!!

        }

        //Корпус
        private void SetDetalKorpus()
        {
            //Форма коллайдера
            Shape shape = new RectangleShape(new Vector2f(85, 24));
            shape.Origin = new Vector2f(45, 20);
            //Спрайт корпуса
            Texture body = new Texture(Program.m_TextureManager.allImage, new IntRect(39, 884, 85, 24));
            Sprite bodySprite = new Sprite(body);
            bodySprite.Origin = new Vector2f(45, 20);


            detaly[0] = new Detal(new Collider(shape), bodySprite, false, true,false);//Корпус
            detalyPoints[0] = new Vector2f(0, 0);

            AddShapeToCoolidersShapes(shape);
        }

        //Башня
        private void SetDetalBashnya()
        {
            //Создание башни
            Shape shape = new RectangleShape(new Vector2f(44, 10));
            shape.Origin = new Vector2f(12, 5);

            Texture _texture = new Texture(Program.m_TextureManager.allImage, new IntRect(159, 878, 45, 12));
            Sprite _sprite = new Sprite(_texture);
            _sprite.Origin = new Vector2f(11, 6);

            detaly[0].m_DetalyDaughters = new Detal[1];//Создание детали прикрепленной к корпусу
            detaly[0].m_DetalyDaughtersPoints = new Vector2f[1];
            detaly[0].m_DetalyDaughters[0] = new Detal(new Collider(shape), _sprite, false, false, false); //Башня
            detaly[0].m_DetalyDaughtersPoints[0] = new Vector2f(-10,-20); //Точка установки башни на корпусе

            AddShapeToCoolidersShapes(shape);

        }

        private void SetDetalPushka()
        {
            Shape shape = new RectangleShape(new Vector2f(58, 4));
            shape.Origin = new Vector2f(58, 0);

            Texture _texture = new Texture(Program.m_TextureManager.allImage, new IntRect(154, 857, 59, 6));
            Sprite _sprite = new Sprite(_texture);
            _sprite.Origin = new Vector2f(58, 2);
            
            


            //Создание ствола пушки
            detaly[0].m_DetalyDaughters[0].m_DetalyDaughters = new Detal[1]; // Создание детали прикрепленной к башне, прикрепленной к корпусу
            detaly[0].m_DetalyDaughters[0].m_DetalyDaughtersPoints = new Vector2f[1];
            detaly[0].m_DetalyDaughters[0].m_DetalyDaughters[0] = new Detal(new Collider(shape), _sprite,true,false,true); //Ствол
            detaly[0].m_DetalyDaughters[0].m_DetalyDaughtersPoints[0] = new Vector2f();//Точка установки ствола на башне

            detaly[0].m_DetalyDaughters[0].m_DetalyDaughters[0].DopAngle = 65;

            AddShapeToCoolidersShapes(shape);
        }

        public override void Start(Vector2f p, float a, Vector2f s)
        {
            base.Start(p, a, s);

            maxLifes = 125;
            currentLifes = 125;
            speed = 18;
            angleNaklonSpeed = 0.3f;

        }





    }
}
