using Havier_Than_Air_S.Scripts.Enemies;
using Havier_Than_Air_S.Vehicle_parts;
using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;
using System;

namespace Havier_Than_Air_S.Enemies
{
    public class Jeep_1: Base_Vehicle, IMoovable
    {

        bool colliderStatus;
        
        PullStatus status = PullStatus.inPool;



        public Jeep_1()
        {
            //Тип объекта
            typeofObject = TypeOfObject.Jeep_1;
            marshrut = new Marshrut();

            textureBody = new Texture(new Image("Images\\Jeep1.png"));
            

            spriteBody = new Sprite(textureBody);
            spriteBody.Scale = new Vector2f(0.2f, 0.2f);
            spriteBody.Origin = centerOfMass-new Vector2f(50,-50);

            colliderShape = new RectangleShape(new Vector2f(104, 35));
            colliderShape.Origin = centerOfMass + new Vector2f(0,-30);

            marker = new Marker(colliderShape, Color.Yellow, 3);

            angleNaklonSpeed = new Random().Next(1,3);
        }



        public void ChangeMarshrutPoint(int numberOfMarshrutPoint)
        {
            currentMarshrutPoint = numberOfMarshrutPoint;
            if (numberOfMarshrutPoint>marshrut.marshrutPoints.Length-1)
            {
                currentMarshrutPoint = marshrut.marshrutPoints.Length - 1;
            }
            int t = currentMarshrutPoint;
            if (currentMarshrutPoint == marshrut.marshrutPoints.Length) t -= 1;
            targetAngleNaklon = Matematika.AngleOfVector(marshrut.marshrutPoints[t-1 ] - marshrut.marshrutPoints[currentMarshrutPoint]);

            

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
            //Program.Game.Missions[Program.Game.currentMissionNum].CallSpawner(this);
        }

        public void Update()
        {
            //если дистанция до точки меньше чем
            if (minDistToMarshPoint>Matematika.searchdistance(position, marshrut.marshrutPoints[currentMarshrutPoint]))
            {
                ChangeMarshrutPoint(currentMarshrutPoint+1);
                if (currentMarshrutPoint == marshrut.marshrutPoints.Length-1)
                {
                    currentMarshrutPoint = 0;
                    ReturnToPull();

                    return;
                }
            }

            //пройденное расстояние
            float distance = tank1speed * Program.deltaTimer.Delta();

            //угол до цели
            float angleToTarget = Matematika.AngleOfVector(marshrut.marshrutPoints[currentMarshrutPoint] - position );

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
            colliderShape.Position = position;
            colliderShape.Rotation = angle;
            spriteBody.Rotation = angle;
            spriteBody.Position = position+new Vector2f(-50,-20);

                        
           
            Program.window.Draw(spriteBody);
            /*
            for (int i = 0; i < detaly.Length; i++)
            {
                Vector2f tecPointPos = Matematika.LocalPointOfRotationObject(detalyPoints[i], angle);
                detaly[i].setPosAndAngle(tecPointPos + position, angle);
                detaly[i].Update();
            }
            */
            marker.UpdatePoints(colliderShape);
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
            return colliderShape;
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
                currentMarshrutPoint = 0;
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
