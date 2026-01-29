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
    public class Tnk2: IMoovable
    {
        //Тип объекта
        TypeOfObject typeofObject = TypeOfObject.enemy;

        bool colliderStatus;

        //Маршрут движения
        public Marshrut myMarshrut;
        int currentMarshrutPoint = 0;
        float minDistToMarshPoint = 5f;

        //Центровка
        Vector2f centerOfMass = new Vector2f(60,40);
        
        //Параметры формы коллайдера
        RectangleShape shape;
        PullStatus status = PullStatus.inPool;

        //Запчасти
        Detal[] detaly;
        Vector2f[] detalyPoints;


        // Параметры Танка1
        float maxLifes = 100;
        float tank1speed = 5;

        // Переменные 
        float currentLifes = 0;
        float angle = 0;
        Vector2f position = new Vector2f(0,0);

        Texture bodyTexture;

        Sprite bodySprite;

        //Позиции
        Vector2f headPosition = new Vector2f(0,-25); 
        Vector2f gunPosition = new Vector2f(-4,-23);

        Vector2f currentGunPosition = new Vector2f(5,8);
        float gunAngle = 35;

       
        //marker
        Marker marker;
        Text lifeText;

        //Наклон на кочках
        float targetAngleNaklon = 0;
        float angleNaklonSpeed = 1;

        Image tankImage = new Image("Images\\tank2.png");


        public Tnk2()
        {

            detaly = new Detal[2];
            detalyPoints = new Vector2f[detaly.Length];
            detaly[0] = new Head_Tank_1();
            detalyPoints[0] = headPosition;
            detaly[1] = new Gun_Tank_1();
            detalyPoints[1] = gunPosition;


            myMarshrut = new Marshrut();

            bodyTexture = new Texture(tankImage);
            bodySprite = new Sprite(bodyTexture);
            bodySprite.Scale = new Vector2f(0.75f, 0.75f);
            bodySprite.Origin = centerOfMass;

            shape = new RectangleShape(new Vector2f(85, 24));
            shape.Origin = centerOfMass;

            marker = new Marker(shape, Color.Yellow, 3);

            angleNaklonSpeed = new Random().Next(1,3);
        }



        public void ChangeMarshrutPoint(int numberOfMarshrutPoint)
        {
            currentMarshrutPoint = numberOfMarshrutPoint;
            if (numberOfMarshrutPoint>myMarshrut.marshrutPoints.Length-1)
            {
                currentMarshrutPoint = myMarshrut.marshrutPoints.Length - 1;
                


            }
            int t = currentMarshrutPoint;
            if (currentMarshrutPoint == myMarshrut.marshrutPoints.Length) t -= 1;
            targetAngleNaklon = Matematika.AngleOfVector(myMarshrut.marshrutPoints[t-1 ] - myMarshrut.marshrutPoints[currentMarshrutPoint]);

            

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

            //Приписка спавну
            Program.Game.CurrentMission.CallSpawner(this);
        }

        public void Update()
        {
            //если дистанция до точки меньше чем
            if (minDistToMarshPoint>Matematika.searchdistance(position, myMarshrut.marshrutPoints[currentMarshrutPoint]))
            {
                ChangeMarshrutPoint(currentMarshrutPoint+1);
                if (currentMarshrutPoint == myMarshrut.marshrutPoints.Length-1)
                {
                    currentMarshrutPoint = 0;
                    ReturnToPull();

                    return;
                }
            }

            //пройденное расстояние
            float distance = tank1speed * Program.deltaTimer.Delta();

            //угол до цели
            float angleToTarget = Matematika.AngleOfVector(myMarshrut.marshrutPoints[currentMarshrutPoint] - position );

            //вектор до цели
            Vector2f moveVector = Matematika.searchLocalVector(angleToTarget, distance);


            if (angle != targetAngleNaklon)
            {
                if (angle > targetAngleNaklon)
                {
                    angle -= angleNaklonSpeed*Program.deltaTimer.Delta()*Program.gameSpeed;
                }
                if (angle < targetAngleNaklon)
                {
                    angle += angleNaklonSpeed * Program.deltaTimer.Delta() * Program.gameSpeed;
                }

                if (Math.Abs(angle - targetAngleNaklon) < 0.03f) angle = targetAngleNaklon;
            }


            //перемещение
            position = position + moveVector;
            shape.Position = position;
            shape.Rotation = angle;
            bodySprite.Rotation = angle;
            bodySprite.Position = position;

                        
           
            Program.window.Draw(bodySprite);
            for (int i = 0; i < detaly.Length; i++)
            {
                Vector2f tecPointPos = Matematika.LocalPointOfRotationObject(detalyPoints[i], angle);
                detaly[i].setPosAndAngle(tecPointPos + position, angle);
                detaly[i].Update();
            }
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
