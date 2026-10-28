using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Scripts.Enemies
{
    public class Base_Vehicle : IMoovable
    {
        //Тип объекта
        public TypeOfObject typeofObject;
        public PullStatus status = PullStatus.inPool;
        public bool colliderStatus;

        //Запчасти
        public Detal[] detaly;
        public Vector2f[] detalyPoints;

        //Маршрут движения
        public Marshrut marshrut;
        public int currentMarshrutPoint = 0;
        public float minDistToMarshPoint = 5f;

        // Параметры 
        public float maxLifes = 100;
        public float tank1speed = 15;

        // Переменные 
        public float currentLifes = 0;
        public float angle = 0;
        public Vector2f position = new Vector2f(0, 0);

        
        public Text lifeText;

        //Наклон на кочках
        public float targetAngleNaklon = 0;
        public float angleNaklonSpeed = 1;

        public Vector2f centerOfMass = new Vector2f(54, 63);

        public Random rand;


        public Base_Vehicle()
        {
            marshrut = new Marshrut();
            angleNaklonSpeed = new Random().Next(1, 3);
            AllCollidersShapes = new Shape[0];

        }

        public virtual void Update()
        {
            //если дистанция до точки меньше чем
            if (minDistToMarshPoint > Matematika.searchdistance(position, marshrut.marshrutPoints[currentMarshrutPoint]))
            {
                ChangeMarshrutPoint(currentMarshrutPoint + 1);
                if (currentMarshrutPoint == marshrut.marshrutPoints.Length - 1)
                {
                    currentMarshrutPoint = 0;
                    ReturnToPull();

                    return;
                }
            }



            //пройденное расстояние
            float distance = tank1speed * Program.deltaTimer.Delta();

            //угол до цели
            float angleToTarget = Matematika.AngleOfVector(marshrut.marshrutPoints[currentMarshrutPoint] - position);

            //вектор до цели
            Vector2f moveVector = Matematika.searchLocalVector(angleToTarget, distance);


            if (angle != targetAngleNaklon)
            {
                if (angle > targetAngleNaklon)
                {
                    angle -= angleNaklonSpeed * Program.deltaTimer.Delta() * Program.gameSpeed;
                }
                if (angle < targetAngleNaklon)
                {
                    angle += angleNaklonSpeed * Program.deltaTimer.Delta() * Program.gameSpeed;
                }

                if (Math.Abs(angle - targetAngleNaklon) < 0.03f) angle = targetAngleNaklon;
            }


            //перемещение

            position = position + moveVector;
            for (int i = 0; i < detaly.Length; i++)
            {
                Vector2f tecPointPos = Matematika.LocalPointOfRotationObject(detalyPoints[i], angle);
                detaly[i].setPosAndAngle(tecPointPos + position, angle);
                detaly[i].Update();


            }


            lifeText = new Text(currentLifes.ToString(), Program.font, 15);
            lifeText.Position = position + new Vector2f(0, -50);
            lifeText.FillColor = Color.Yellow;
            Program.window.Draw(lifeText);




        }


        public void ChangeMarshrutPoint(int numberOfMarshrutPoint)
        {
            currentMarshrutPoint = numberOfMarshrutPoint;
            if (numberOfMarshrutPoint > marshrut.marshrutPoints.Length - 1)
            {
                currentMarshrutPoint = marshrut.marshrutPoints.Length - 1;
            }
            int t = currentMarshrutPoint;
            if (currentMarshrutPoint == marshrut.marshrutPoints.Length) t -= 1;
            targetAngleNaklon = Matematika.AngleOfVector(marshrut.marshrutPoints[t - 1] - marshrut.marshrutPoints[currentMarshrutPoint]);



        }

        public void Start(Vector2f pos, float angle, Vector2f speed)
        {
            rand = new Random();
            currentLifes = rand.Next(50, 200);
            position = pos;
            tank1speed = speed.X;//speed.X;
            status = PullStatus.inAir;
            colliderStatus = true;
        }


        public Shape[] AllCollidersShapes;

        public void AddShapeToCoolidersShapes(Shape addShape)
        {
            Shape[] shOld = AllCollidersShapes;
            AllCollidersShapes = new Shape[shOld.Length + 1];
            for (int i = 0; i < shOld.Length; i++)
            {
                AllCollidersShapes[i] = shOld[i];

            }
            AllCollidersShapes[AllCollidersShapes.Length - 1] = addShape;

        }





        
        // Обязательные
        

        public TypeOfObject GetTypeOfObject()
        {
            return typeofObject;
        }

        public PullStatus GetCurrentPullStatus()
        {
            return status;
        }

        

        public Shape GetColliderShape(int numOfdetal)
        {
            

            return AllCollidersShapes[0];
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

            if (currentLifes <= 0)
            {
                currentMarshrutPoint = 0;
                ReturnToPull();
            }
        }

        public bool GetColliderStatus()
        {
            return colliderStatus;
        }

        public void ReturnToPull()
        {
            status = PullStatus.inPool;
            position = Program.m_PullObjects.position;

        }

    }
}
