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


            detaly = new Detal[2];
            detalyPoints = new Vector2f[detaly.Length];

            //Кузов
            detaly[0] = new Detal(coll, spriteBody); //Кузов
            detalyPoints[0] = new Vector2f(0,0);


            //Стекла
            Texture textureBody2 = new Texture(new Image("Images\\DamagedObjectsImages\\Jeep1_windowv.png"));
            Sprite spriteBody2 = new Sprite(textureBody2);
            spriteBody2.Scale = new Vector2f(0.2f, 0.2f);
            spriteBody2.Origin = new Vector2f(180, 200);
            
            detaly[1] = new Detal(spriteBody2); //Кузов
            detalyPoints[1] = new Vector2f(0, 0);

            AddShapeToCoolidersShapes(colliderShape);

            
        }

        public override void Start(Vector2f p, float a, Vector2f s)
        {
            base.Start(p, a, s);

            maxLifes = 75;
            currentLifes = 75;
            speed = 35;
            angleNaklonSpeed = 1;

        }

        float glasssLifes = 4;

        public override void SetDamage(IMoovable obj)
        {
            if (obj is Projectile)
            {
                currentLifes -= (obj as Projectile).projectileDamage;


                if (detaly[1].DetalOFF == false)
                {
                    if (rand.Next(1, 101) > 80)
                    {
                        Program.soundManager.playSound(4);
                        glasssLifes -= (obj as Projectile).projectileDamage;

                        //Уничтожено
                        if (glasssLifes < 0) detaly[1].DetalOFF = true;

                    }
                }
                
            }

            if (currentLifes <= 0)
            {
                currentMarshrutPoint = 0;
                detaly[1].DetalOFF = false;
                glasssLifes = 4;
                Program.m_PullObjects.StartObject(position, angle, new Vector2f(), TypeOfObject.house);
                ReturnToPull();
                
            }





        }




    }
}
