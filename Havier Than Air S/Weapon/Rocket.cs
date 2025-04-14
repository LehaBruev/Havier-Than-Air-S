using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S
{
    public enum RocketStatus
    {
        inCase,
        inAir,
        inPool
    }

    public class Rocket
    {


        // NR ракеты МОДЕ 2
         float NRrocketlenght = 20;
         float NRrocketpower = 47;
         float NRrocketweight = 100; //вес ракеты
         float NRrocketspeed = 200; // скорость NR неуправляемых ракет
         int nrrocketsMaxquantity = 64; // максимальное количество NR неуправляемых ракет
         float nrfuel = 3; // запас хода NR неуправляемых ракет
        float NRrocketRashod = 1;
        private Color nrColor = new Color(255, 161, 0);

        //Переменные
        public RocketStatus currentRocketStatus;
        private float currentRocketfuel;
        private float currentRocketSpeed;
        private Texture rocketTexture;
        private Sprite rocketSprite;

        private Vector2f currentRocketPosition;
        private float currentRocketAngle;

        //Отрисовка
        RectangleShape rectangleShape;
        private Drawable NR;

        public Rocket()
        {
            ProduceRocket();
            DeactivateRocket();

        }

        private void ProduceRocket()
        {
            //sprite
            rocketTexture = new Texture("Nrocket_01.png");
            rocketSprite = new Sprite();
            rocketSprite.Texture = rocketTexture;
            rocketSprite.TextureRect = new IntRect(1, 1, 100, 100);
            rocketSprite.Color = Color.Green;
            rocketSprite.GetGlobalBounds().Intersects(rocketSprite.GetGlobalBounds());


            //shape
            rectangleShape = new RectangleShape();
            rectangleShape.GetGlobalBounds();
            //rectangleShape.Position = new Vector2f(0, 0);
            //rectangleShape.Rotation = 70;
            rectangleShape.Size = new Vector2f(100.0f,20);
            rectangleShape.Origin = new Vector2f(10, 10);
            rectangleShape.FillColor = Color.Red;
            //rectangleShape.Position = 

        

            NR = rectangleShape;
            //CircleShape

            /*
                 sf::Vertex line[] =
             {
                 sf::Vertex(sf::Vector2f(10, 10)),
                 sf::Vertex(sf::Vector2f(150, 150))
            };
            */
        }


        public void DeactivateRocket()
        {
            currentRocketStatus = RocketStatus.inPool;
            currentRocketfuel = nrfuel;
            currentRocketSpeed = 0.0f;
        }

        public void StartRocket(Vector2f position, float angle)
        {
            DeactivateRocket();
            currentRocketStatus = RocketStatus.inAir;
            
            currentRocketPosition = position;
            currentRocketAngle = angle;
            
        }

        public void MoveNRrocket()
        {
            if(currentRocketStatus == RocketStatus.inAir)
            {
                //currentRocketPosition = new Vector2f(currentRocketPosition.X +1.0f,
                //                                        currentRocketPosition.Y +1.0f);

                currentRocketSpeed = NRrocketspeed * (float)Program.deltaTimer.Delta();
                currentRocketPosition  = currentRocketPosition + Matematika.searchAB(currentRocketAngle, currentRocketSpeed);

               

                //rocketSprite.Position = currentRocketPosition;
                rectangleShape.Position = currentRocketPosition;
                rectangleShape.Rotation = currentRocketAngle;
                // Отрисовка

                //расход
                if (currentRocketfuel > 0)
                {
                    currentRocketfuel -= NRrocketRashod*(float)Program.deltaTimer.Delta();
                    Program.window.Draw(NR);
                }
                else
                {
                    DeactivateRocket();
                }

                
            }

            //положение ракеты

            //Угол наклона

            //Отрисовка

            //Проверка столкновений

            //Расход топл

            ////  searchangle вычисляемый угол, угол наклона
            //// searchline длина отрезка, пути
            //// найти А и Б searchAB()
            //// searchA
            //// searchB

            /*
                // вычисление х2 и у2 для отрисовки ракеты
                if (R[5, i] == 2)
                {
                    //searchangle = R[3, i];

                    float searchline = NRrocketlenght;
                    //searchAB();
                    float a = searchA;
                    float b = searchB;

                    // вычисление х3 и у3 для перемещения ракеты
                    searchline = NRrocketspeed;
                    searchAB();

                    //отрисовка ракеты
                    if (R[3, i] > 0 && R[3, i] < 70)
                    {
                        DrawLine(R[1, i], R[2, i], R[1, i] + a, R[2, i] + b, 4);
                        R[1, i] = R[1, i] + searchA;
                        R[2, i] = R[2, i] + searchB;

                    }
                    if (R[3, i] > -70 && R[3, i] < -15)
                    {
                        DrawLine(R[1, i], R[2, i], R[1, i] - a, R[2, i] + b, 4);
                        R[1, i] = R[1, i] - searchA;
                        R[2, i] = R[2, i] + searchB;
                    }
                    if (R[3, i] >= -15 && R[3, i] <= 0)
                    {
                        DrawLine(R[1, i], R[2, i], R[1, i] + a, R[2, i] - b, 4);
                        R[1, i] = R[1, i] + searchA;
                        R[2, i] = R[2, i] - searchB;
                    }
                    R[4, i] = R[4, i] - 1; // расход топлива ракеты
                    if (R[4, i] < 0)
                    {
                        R[5, i] = 0;

                    }
            */

            // }
        }

    }
        





    
}
