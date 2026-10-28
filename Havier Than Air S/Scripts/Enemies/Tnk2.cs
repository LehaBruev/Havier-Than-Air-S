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
         

        //Позиции
        Vector2f headPosition = new Vector2f(0,-25); 
        Vector2f gunPosition = new Vector2f(-4,-23);

        Vector2f currentGunPosition = new Vector2f(5,8);
        float gunAngle = 35;

       
        Image tankImage = new Image("Images\\tank2.png");


        public Tnk2()
        {
            typeofObject = TypeOfObject.tank2;

            centerOfMass = new Vector2f(60, 40);


            detaly = new Detal[3];
            detalyPoints = new Vector2f[detaly.Length];

            Shape shape =new RectangleShape(new Vector2f(85, 24));
            shape.Origin = centerOfMass;
            Texture bodyTexture = new Texture(tankImage);
            Sprite bodySprite = new Sprite(bodyTexture);
            bodySprite.Scale = new Vector2f(0.75f, 0.75f);
            bodySprite.Origin = centerOfMass;

            detaly[0] = new Detal(new Collider(shape,Color.Yellow), bodySprite);
            detalyPoints[0] = headPosition;
            AddShapeToCoolidersShapes(shape);

            detaly[1] = new Head_Tank_1();
            detalyPoints[1] = headPosition;

            detaly[2] = new Gun_Tank_1();
            detalyPoints[2] = gunPosition;


            marshrut = new Marshrut();

            angleNaklonSpeed = new Random().Next(1,3);
        }



    }
}
