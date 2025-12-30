using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Enemies
{
    public class Tnk1: IMoovable
    {
        bool colliderStatus;
        int currentpoint = 0;
        float deltaPointa = 5;

        //Маршрут движения
        Marshrut myMarshrut;
        int currentMarshrutPoint = 0;
        float minDistToMarshPoint = 5f;
        Vector2f centerOfMass = new Vector2f(35,20);
        

        RectangleShape shape;
        PullStatus status = PullStatus.inPool;
        TypeOfObject typeofObject = TypeOfObject.enemy;

        // Параметры Танка1
        float maxLifes = 100;

        // Переменные 
        float currentLifes;
        float angle = 0;
        Vector2f position;

        float tank1sizex = 82;
         float tank1sizey = 30;
         float tank1live = 250;
         float tank1speed = 5;
         float tank1cource = 790;
         float tank1destroy = 0;
         int tank1maxquantity = 62;
        

        Image allImage = new Image("Images\\uh61all.png");
        Texture body;
        Texture head;
        Texture Gun;

        Sprite bodySprite;
        Sprite headSprite;
        Sprite gunSprite;

        Vector2f headPosition = new Vector2f(35,0); 
        Vector2f currentHeadPosition = new Vector2f(35,-10); 

        Vector2f gunPosition = new Vector2f(5,8);
        Vector2f currentGunPosition = new Vector2f(5,8);
        float gunAngle = 35;

        int napravlenie = 1;



        //marker
        Marker marker;
        Text lifeText;

        public void ChangeMarshrutPoint(int numberOfMarshrutPoint)
        {
            currentMarshrutPoint = numberOfMarshrutPoint;
            if (numberOfMarshrutPoint>myMarshrut.marshrutPoints.Length-1)
            {
                currentMarshrutPoint = myMarshrut.marshrutPoints.Length - 1;
                
            }
            angle = Matematika.AngleOfVector((position + centerOfMass) - myMarshrut.marshrutPoints[currentMarshrutPoint]);

            bodySprite.Rotation = angle;
            bodySprite.Origin = centerOfMass;
            headSprite.Rotation = angle;
            gunSprite.Rotation = gunAngle+ angle;

        }

        public Tnk1()
        {
            myMarshrut = new Marshrut();

            body = new Texture(allImage, new IntRect(39, 884, 85, 24));
            head = new Texture(allImage, new IntRect(159, 878, 45, 12));
            Gun = new Texture(allImage, new IntRect(154, 857, 59, 6));

            bodySprite = new Sprite(body);

            headSprite = new Sprite(head);
            headSprite.Origin = new Vector2f(12,7);
            gunSprite = new Sprite(Gun);
            gunSprite.Origin = new Vector2f(58, 3);

            shape = new RectangleShape(new Vector2f(85,24));
            
            marker = new Marker(shape,Color.Yellow,3);
            
            
        }

        Random rand;
        public void Start(Vector2f pos, float angle, Vector2f speed)
        {
            rand = new Random();
            currentLifes = rand.Next(50,200);
            position = pos;
            tank1speed = speed.X;//speed.X;
            status = PullStatus.inAir;
            colliderStatus = true;
        }

        public void Update()
        {
            //если дистанция до точки меньше чем
            if (minDistToMarshPoint>Matematika.searchdistance(position+centerOfMass, myMarshrut.marshrutPoints[currentMarshrutPoint]))
            {
                ChangeMarshrutPoint(currentMarshrutPoint+1);
            }

            //пройденное расстояние
            float distance = tank1speed * Program.deltaTimer.Delta();

            //угол до цели
            float angleToTarget = Matematika.AngleOfVector(myMarshrut.marshrutPoints[currentMarshrutPoint] - (position + centerOfMass));

            //вектор до цели
            Vector2f moveVector = Matematika.searchLocalVector(angleToTarget, distance);

            //перемещение
            position = position + moveVector;
            shape.Position = position;
            bodySprite.Position = position;

            currentHeadPosition = Matematika.LocalPointOfRotationObject(headPosition, angleToTarget);
            currentGunPosition = Matematika.LocalPointOfRotationObject(gunPosition, angleToTarget);
            headSprite.Position = position + currentHeadPosition;
            
            gunSprite.Position = position + currentGunPosition;
            
            Program.window.Draw(bodySprite);
            Program.window.Draw(headSprite);
            Program.window.Draw(gunSprite);
            marker.UpdatePoints(shape);
            marker.Update();
            
            lifeText = new Text(currentLifes.ToString(), Program.font, 10);
            lifeText.Position = position + new Vector2f(50, -10);
            lifeText.FillColor = Color.Yellow;
            Program.window.Draw(lifeText);

        }



        public TypeOfObject GetTypeOfObject()
        {
            return typeofObject;
        }

        public PullStatus GetCurrentPullStatus()
        {
            return status;
        }

        public Shape GetShape()
        {
            return shape;
        }

        public Vector2f GetPosition()
        {
            return position;
        }




        public void SetDamage(IMoovable obj)
        {
            if (obj is Projectile)
            {
                currentLifes -= (obj as Projectile).projectileDamage;

            }

            if (currentLifes<=0)
            {
                ReturnToPull();
            }

        }

        private void ReturnToPull()
        {
            status = PullStatus.inPool;
            position = Program.m_PullObjects.position;

        }

        public bool GetColliderStatus()
        {
            return colliderStatus;
        }


    }
}
