using Havier_Than_Air_S.Scripts;
using Havier_Than_Air_S.Scripts.Enemies;
using Havier_Than_Air_S.Vehicle_parts;
using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;
using System;

namespace Havier_Than_Air_S.Enemies
{
    public class Jeep_1 : Base_Vehicle
    {

        public Jeep_1()
        {
            //Тип объекта
            typeofObject = TypeOfObject.Jeep_1;
            marshrut = new Marshrut();

            Shape colliderShape = new RectangleShape(new Vector2f(70, 24));
            colliderShape.Origin = new Vector2f(35,22);
            //Collider coll = new Collider(colliderShape, Color.Green);
            Collider coll = new Collider(colliderShape);

            Texture textureBody = new Texture(new Image("Images\\Jeep1.png"));
            Sprite spriteBody = new Sprite(textureBody);
            spriteBody.Scale = new Vector2f(0.2f, 0.2f);
            spriteBody.Origin = new Vector2f(180, 200);


            detaly = new Detal[1];
            detalyPoints = new Vector2f[detaly.Length];

            detaly[0] = new Detal(coll, spriteBody); //Кузов
            detalyPoints[0] = new Vector2f(0,0);

           // detaly[1] = new TestDetal(); //test
           // detalyPoints[1] = new Vector2f(0, 0);


            angleNaklonSpeed = new Random().Next(1,3);
        }



        public override void Update()
        {
           base.Update();

        }





    }
}
