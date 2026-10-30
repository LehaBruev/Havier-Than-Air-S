using Havier_Than_Air_S.Scripts.Enemies;
using Havier_Than_Air_S.Vehicle_parts;
using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Enemies
{
    public class Tnk2: Base_Vehicle
    {
         

       
        Image tankImage = new Image("Images\\tank2.png");


        public Tnk2()
        {
            typeofObject = TypeOfObject.tank2;

            detaly = new Detal[1];
            detalyPoints = new Vector2f[detaly.Length];

            Shape shape =new RectangleShape(new Vector2f(142, 38));
            shape.Origin = new Vector2f(71,38);
            Texture bodyTexture = new Texture(tankImage);
            Sprite bodySprite = new Sprite(bodyTexture);
            bodySprite.Scale = new Vector2f(0.6f, 0.6f);
            bodySprite.Origin = new Vector2f(120, 70);

            detaly[0] = new Detal(new Collider(shape), bodySprite);
            detalyPoints[0] = new Vector2f();
            AddShapeToCoolidersShapes(shape);

            SetDetalBashnya(); // Башня
            SetDetalPushka(); // Ствол



        }

        //Башня
        private void SetDetalBashnya()
        {
            //Создание башни
            Shape shape = new RectangleShape(new Vector2f(52, 18));
            shape.Origin = new Vector2f(16, 15);

            Texture _texture = new Texture(new Image("Images\\tank2_trunk.png"));
            Sprite _sprite = new Sprite(_texture);
            _sprite.Scale = new Vector2f(0.6f, 0.6f);
            _sprite.Origin = new Vector2f(25, 30);//Ориджин

            detaly[0].m_DetalyDaughters = new Detal[1];//Создание детали прикрепленной к корпусу
            detaly[0].m_DetalyDaughtersPoints = new Vector2f[1];
            detaly[0].m_DetalyDaughters[0] = new Detal(new Collider(shape), _sprite); //Башня
            detaly[0].m_DetalyDaughtersPoints[0] = new Vector2f(5, -38); //Точка установки башни на корпусе

            AddShapeToCoolidersShapes(shape);

        }

        private void SetDetalPushka()
        {
            Shape shape = new RectangleShape(new Vector2f(36, 6));
            shape.Origin = new Vector2f(36, 2);

            Texture _texture = new Texture(new Image("Images\\tank2_gun.png"));
            Sprite _sprite = new Sprite(_texture);
            _sprite.Scale = new Vector2f(0.6f, 0.6f);
            _sprite.Origin = new Vector2f(58, 3);


            //Создание ствола пушки
            detaly[0].m_DetalyDaughters[0].m_DetalyDaughters = new Detal[1]; // Создание детали прикрепленной к башне, прикрепленной к корпусу
            detaly[0].m_DetalyDaughters[0].m_DetalyDaughtersPoints = new Vector2f[1];
            detaly[0].m_DetalyDaughters[0].m_DetalyDaughters[0] = new Detal(new Collider(shape), _sprite, true, false, true); //Ствол
            detaly[0].m_DetalyDaughters[0].m_DetalyDaughtersPoints[0] = new Vector2f(-15,-13);//Точка установки ствола на башне

            detaly[0].m_DetalyDaughters[0].m_DetalyDaughters[0].DopAngle = 30;

            AddShapeToCoolidersShapes(shape);
        }


        public override void Start(Vector2f p, float a, Vector2f s)
        {
            base.Start(p, a, s);

            maxLifes = 250;
            currentLifes = 250;
            speed = 15;
            angleNaklonSpeed = 0.2f;

        }

    }
}
