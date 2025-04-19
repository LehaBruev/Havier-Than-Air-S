using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{


    public class Hely : GameObject
    {
        #region переменные

        //Настройки верталета

        static float maxpowery = 300000; //Максимальная сила влияет на вертолет
        static float maxpowerx = 30000; // 
        static float shagengine = 75; // шаг увеличения мощности двигателя
        static float shagAngle = 2; // шаг изменения угла атаки
        static float maxspeedhor = 50;
        static float maxspeedvert = 300;
        static float maxheigh = 575; // потолок полета

        float currentHelilife;


        //Переменные
        float helilifeCurrent = 200;// жизни
        int engineswitch = 1; // включение двигателя
        int autopilotswitch = 0; // автопилот горизонтальный, удерживает угол в точке 0 градусов
        float altitude = 200; // Высота
        float helifuel = 1500; // Топливо в баках
        int bang1 = 1;
        int gunmode = 0;

        //Характеристики
        float helilifemax = 300;// максимальные жизни Вертолета
        float helienginelife = 100; //исправность двигателя Вертолета
        float fuelrashod = 0.1f; // расход топлива
        float manageability = 5;// управляемость
        float maxangle = 65; // Максимальный угол атаки
        float helifuelmax = 1300; // Максимальное топливо в баках
        float maxboost = 11250; // максимальное ускорение от двигателя
        float holdOborotMotora = 12000; // Холостые обороты мотора


        float playerx = 50;
        float playery = 400;
        float speedx = 0;
        float speedxmax = 2.5f;
        float speedy = 0;
        float powery = 200;
        float enginespeed = 19500; //Обороты двигателя
        float maxenginespeed = 60000; //Максимальные обороты двигателя
        float enginespeedlimit = 45000; //Предельные обороты двигателя

        float angle = 0; //угол атаки верталета

        float boostv = 0; //ускорение вертикальное


        int helidestroy = 0; // верталет разрушен
        int helistop = 0; // вертолет обесточен

        //Настройки прицеливания
        float aimlehght = 180;

        #endregion

        // Картинка верталета
        //Texture heliTexture = new Texture("uh61.png");
        Texture heliTexture = new Texture("uh612.png");
        Sprite helySprite;


        //Мотор
        //SOUND
        SoundBuffer engineStartSoundBuffer = new SoundBuffer("zapusk2.wav"); //запуск
        //SoundBuffer engineStopSoundBuffer = new SoundBuffer("zapusk2.wav"); //остановка
        SoundBuffer engineStopSoundBuffer = new SoundBuffer("hw_spindown.wav"); //остановка
        Sound engineStartStopSound;
        Sound channelSoundRita;
        Sound channelSoundTex;
        Clock keyPressClock = new Clock();
        bool keyStartIsPressed = false;

        SoundBuffer ostalos500kg = new SoundBuffer("Fuel500.wav"); // Осталось 500 кг звук
        SoundBuffer ostalos800kg = new SoundBuffer("Fuel800.wav"); // Осталось 800 кг звук

        // Статистика
        float fuelusedup = 0; //израсходовано топлива


        //Точка крепления ротора
        CircleShape CircleShape;


        //Задний винт
        Sprite rearVintSprite;
        RectangleShape rearRotorRectShape;
        float rearVintSpeed = 41;

        //Верхний винт
        RectangleShape topRotorRectShape;
        float topVintSpeed = 1545;
        

        public Hely()
        {
            SpawnHely();



            //Начальные настройки верталета
            int rnd = new Random().Next(300, 800);
            playerx = rnd; //
            playery = 700;
            engineswitch = 0;
            enginespeed = 0;
            helistop = 1;
            helifuel = 1000;
            helifuelmax = 1300;
            currentHelilife = 300;
            helilifemax = 300;
            speedxmax = 3f;
            manageability = 9; //управляемость
            shagAngle = 1.7f; // угол атаки
            //nrrocketsMaxquantity = 8; //максимально ракет
            //padstoreswitch = 0;
            helidestroy = 0;


            shagengine = 75; //шаг увелич мощности двигателя
            enginespeedlimit = 35000; //лимит оборотов двигателя
            fuelrashod = 1.7f; // расход топлива
                               //otkazcicle[1] = manageability;
                               //otkazcicle[2] = shagAngle;
                               //otkazcicle[3] = 0;
        }


        public void SpawnHely()
        {
            helySprite = new Sprite(heliTexture);
            
            
            //helySprite.Scale = new Vector2f(0.5f, 0.5f);
            helySprite.Scale = new Vector2f(2, 2);
            helySprite.Color = Color.White;
            helySprite.Origin = new Vector2f(34, 6);
            int rnd = new Random().Next(300, 800);
            helySprite.Position = new Vector2f(rnd, 650);
            Console.WriteLine(rnd);

            //Sounds
            engineStartStopSound = new Sound();
            channelSoundRita = new Sound();
            channelSoundTex = new Sound();


            //Точка для ротора
            CircleShape = new CircleShape(2);
            CircleShape.FillColor = new Color(Color.Yellow);
            CircleShape.Origin = new Vector2f(2, 2);

            SpawnRotors();

        }

        private void SpawnRotors()
        {
            //rearVintSprite.
            rearRotorRectShape = new RectangleShape();
            rearRotorRectShape.Size = new Vector2f(2, 18);
            rearRotorRectShape.FillColor = new Color(Color.Yellow);
            rearRotorRectShape.Origin = new Vector2f(1,9f);

            topRotorRectShape = new RectangleShape();
            topRotorRectShape.Size = new Vector2f(90, 2);
            topRotorRectShape.Origin = new Vector2f(45, 1);
            topRotorRectShape.FillColor = new Color(Color.Yellow);
        }


        public void Update()
        {
            CheckPosition();
            PlayerMove();
            EngineUpdate();
            PlayerDraw();
            Program.window.Draw(helySprite);

            CircleShape.Position = new Vector2f( helySprite.Position.X,
                                                 helySprite.Position.Y);

            //роторы
            Vector2f rotorNewVector = new Vector2f();
            rotorNewVector = Matematika.searchAB(helySprite.Rotation,-58);
            rearRotorRectShape.Position = new Vector2f((helySprite.Position.X)+rotorNewVector.X,
                                                 (helySprite.Position.Y)+ rotorNewVector.Y);

            topRotorRectShape.Position = helySprite.Position;

            Program.window.Draw(CircleShape);

            rearRotorRectShape.Rotation += rearVintSpeed*Program.deltaTimer.Delta()*100;
            topRotorRectShape.Rotation = helySprite.Rotation;

            float RotorX = topRotorRectShape.Scale.X + topVintSpeed * Program.deltaTimer.Delta()/100;
            if (RotorX > 1)
            {
                RotorX = 1;
                topVintSpeed *= -1;
            }
            if (RotorX < 0.08f)
            {
                RotorX = 0.08f;
                topVintSpeed *= -1;
            }

            topRotorRectShape.Scale = new Vector2f(RotorX, topRotorRectShape.Scale.Y);


            Program.window.Draw(rearRotorRectShape);
            Program.window.Draw(topRotorRectShape);
        }

        private void CheckPosition()
        {
            //ОСНОВНЫЕ ПАРАМЕТРЫ   ДВИЖЕНИЕ WSDA

            if (Keyboard.IsKeyPressed(Keyboard.Key.W) == true) enginespeed = (enginespeed + shagengine * Program.deltaTimer.Delta()*100);
            if (enginespeed > maxenginespeed) enginespeed = maxenginespeed;
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) == true) enginespeed = (enginespeed - shagengine * 1.5f*Program.deltaTimer.Delta()*100);
            if (enginespeed < 0) enginespeed = 0;

            /*
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                helySprite.Position = new Vector2f(helySprite.Position.X, helySprite.Position.Y-powery*Program.deltaTimer.Delta());

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                helySprite.Position = new Vector2f(helySprite.Position.X, helySprite.Position.Y + powery * Program.deltaTimer.Delta());

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                helySprite.Position = new Vector2f(helySprite.Position.X + powery * Program.deltaTimer.Delta(), helySprite.Position.Y );

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                helySprite.Position = new Vector2f(helySprite.Position.X - powery * Program.deltaTimer.Delta(), helySprite.Position.Y);

            }
            */
        }


        private void EngineUpdate()
        {
            // вкл/выкл двигателя
            if (Keyboard.IsKeyPressed(Keyboard.Key.I) == true && keyStartIsPressed == false)
            {
                keyStartIsPressed = true;
                if (keyPressClock.ElapsedTime.AsSeconds() > 0.5f)
                {
                    int j = engineswitch;
                    if (j == 1) engineswitch = 0;
                    if (j == 0) engineswitch = 1;

                    if (engineswitch == 1 && helifuel > 0 && helidestroy != 1)
                    {
                        PlaySound(engineStartStopSound, engineStartSoundBuffer);
                    }
                    keyPressClock.Restart();
                }
            }
            else if (keyStartIsPressed == true)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.I) == false)
                {
                    keyStartIsPressed = false;
                }
            }

            // Отключение двигателя
            if (engineswitch == 0 || helifuel <= 0 || helidestroy == 1)
            {
                if (enginespeed > 0)
                {

                    enginespeed = enginespeed - 200*Program.deltaTimer.Delta()*100;
                    if (helistop != 1)
                    {
                        helistop = 1;
                        PlaySound(engineStartStopSound, engineStopSoundBuffer);
                    }

                }
                if (enginespeed < 0) enginespeed = 0;
            }

            // Продолжение работы мотора
            if (engineswitch == 1 && helifuel > 0 && helidestroy != 1)
            {
                if (enginespeed < holdOborotMotora)
                {
                    enginespeed = enginespeed + shagengine / 2 * Program.deltaTimer.Delta()*100;
                    if (helistop == 1)
                    {
                        helistop = 0;
                    }
                }
            }

            //Расход топлива
            helifuel = helifuel - (enginespeed / 100) * (enginespeed / 100) / 1000000 * fuelrashod * Program.deltaTimer.Delta();
            fuelusedup = fuelusedup + (enginespeed / 100) * (enginespeed / 100) / 1000000 * fuelrashod * Program.deltaTimer.Delta();
            if (helifuel < 0) helifuel = 0;
            if (helifuel < 510 && helifuel > 507) PlaySound(channelSoundRita, ostalos500kg);
            if (helifuel < 810 && helifuel > 805) PlaySound(channelSoundRita, ostalos800kg);

        }

        private void PlaySound(Sound channel, SoundBuffer sound)
        {
            channel.Stop();
            channel.SoundBuffer = sound;
            channel.Play();
        }

        float ratioenginespeed = 1; //Пожар двигателя
        //Данные для учета столкновения с землей
        float s;
        float ground = 700; // уровень земли
        float airP = 0; //плотность воздуха

        float flighttime = 0; //время нахождения в воздухе

        static float gravityweight = 20000; //Сила притяжения
        int NRrocketsInHely;
        float NRrocketweight = 100.0f;

        //земля
        static int g = 0;
        //звуки доп
        SoundBuffer metal1Sound = new SoundBuffer("metal1.wav"); // касание земли
        SoundBuffer metal2Sound = new SoundBuffer("metal2.wav"); // касание земли 2
        SoundBuffer bangsound = new SoundBuffer("explode4.wav"); //взрыв
        SoundBuffer grass1 = new SoundBuffer("glass3.wav"); // стекло

        float getdamages = 0; //Получено повреждений

        void PlayerMove() // коэффициент живучести двигателя
        {

            ratioenginespeed = helienginelife * 1.25f / 100;
            if (ratioenginespeed > 1) ratioenginespeed = 1;

            s = speedy;

            //расчет плотности воздуха, на выходе получаем = airP
            altitude = (768 - playery) - (768 - ground);

            airP = (float)Math.Sqrt(playery) * 2 * 3;

            if (altitude > 0) flighttime = flighttime + 1;
            if (maxenginespeed < enginespeed) enginespeed = maxenginespeed;



            //расчет вертикальной скорости

            //расчет подъемной силы


            //угол атаки уменьшает подъемную силу
            powery = (enginespeed * ratioenginespeed / 114 * airP) - gravityweight - helifuel * 6 - NRrocketsInHely * NRrocketweight; // подъемная сила

            boostv = powery / 200;       // вертиклаьное ускорение
            if (boostv > (maxenginespeed / 100 * 75)) boostv = maxboost;

            speedy = (boostv / 10); // вертикальная скорость

            playery = (playery - speedy * Program.deltaTimer.Delta() * 100);



            //ЗЕМЛЯ столкновение
            if (playery >= ground)
            {
                g = 1;
                playery = ground;
                speedx = 0;
                boostv = 0;
                powery = 0;
                speedy = 0;
                angle = 0;
            }


            if (g == 1)
            {
                if (s < -1)
                {
                    currentHelilife = currentHelilife - 19;
                    PlaySound(channelSoundTex, metal1Sound);
                    getdamages = getdamages - 19;
                }
                if (s < -2)
                {
                    currentHelilife = currentHelilife - 88;
                    PlaySound(channelSoundTex, metal2Sound);
                    PlaySound(channelSoundTex, grass1);
                    getdamages = getdamages - 89;
                    //  loterea(); //TODO Повреждения рика КЛАСС
                }

                if (currentHelilife <= 0)
                {
                    helidestroy = 1;
                    if (bang1 == 1)
                    {
                        PlaySound(channelSoundTex, bangsound);
                        bang1 = 0;
                    }
                }
                g = 0;
            }


            // Расчет ГОРИЗОНТАЛЬНОГО ПОЛЕТА угол атаки
            // Вылет за зону полётов
            //Управление углом атаки
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) == true) angle = (angle + shagAngle*Program.deltaTimer.Delta()*100);
            if (angle > maxangle) angle = maxangle;
            if (Keyboard.IsKeyPressed(Keyboard.Key.A) == true) angle = (angle - shagAngle * Program.deltaTimer.Delta()*100);
            if (angle < -maxangle) angle = -maxangle;

            speedx = speedx + enginespeed / 114 * airP / 100 * angle * Program.deltaTimer.Delta() / gravityweight * manageability; // ФОРМУЛА РАСЧЕТА ГОРИЗОНТАЛЬНОЙ СКОРОСТИ (ПОМЕНЯТЬ)
            if (speedx > speedxmax) speedx = speedxmax;
            if (speedx < -speedxmax) speedx = -speedxmax;

            playerx = playerx + speedx*Program.deltaTimer.Delta()*100; //wind

            helySprite.Position = new Vector2f(playerx, playery);
            /*
            if (Keyboard.IsKeyPressed(Keyboard.Key.V) == true)
            {
                float v = autopilotswitchX;
                if (v == 1) autopilotswitchX = 0;
                if (v == 0) autopilotswitchX = 1;

            }

            if (autopilotswitchX == 1)
            {
                if (angle > 0) angle -= 1;
                if (angle < 0) angle += 1;

            }

            */

        }


        void PlayerDraw() // отрисовка Верталета
        {
            // DrawSprite(uh61, padx, pady, 147, 603, 137, 66); // Верталетная площадка
            //цветы

            /*
            if (currentHelilife <= 0) DrawSprite(uh61, playerx - 41, playery - 17, 408, 101, 91, 43);
            else
            {
                if (angle >= 0 && angle <= 10) DrawSprite(uh61, playerx - 95, playery - 26, 0, 0, 130, 57);
                if (angle > 10 && angle <= 30) DrawSprite(uh61, playerx - 96, playery - 30, 0, 56, 127, 59);
                if (angle > 30 && angle <= 45) DrawSprite(uh61, playerx - 75, playery - 68, 23, 184, 105, 106);
                if (angle > 45 && angle <= 70) DrawSprite(uh61, playerx - 61, playery - 83, 150, 1, 93, 125);

                if (angle >= -15 && angle < 0) DrawSprite(uh61, playerx - 98, playery - 23, 403, 28, 134, 53);
                if (angle >= -30 && angle < -15) DrawSprite(uh61, playerx - 35, playery - 27, 272, 68, 127, 59);
                if (angle >= -45 && angle < -30) DrawSprite(uh61, playerx - 29, playery - 66, 277, 163, 103, 105);
                if (angle >= -70 && angle < -45) DrawSprite(uh61, playerx - 25, playery - 86, 160, 147, 79, 122);
            } //отрисовка спрайтов Вертолета
            */

            helySprite.Rotation = angle;

            /*
            FillCircle(playerx, playery, 3);
            

            // Отрисовка прицела МОДЕ 2
            if (gunmode == 2) // Оружие МОДЕ 2. Прицел.
            {

                //Вычисление поправок
                searchline = aimlehght + ritarandom - 1;
                searchangle = angle + ritarandom - 1;
                searchAB();

                if (angle > 0 && angle < 70)
                {
                    DrawSprite(uh61, playerx + searchA, playery + searchB * ritarandom, 305, 302, 35, 37);

                }
                if (angle > -70 && angle < -15)
                {
                    DrawSprite(uh61, playerx - searchA * ritarandom - 50, playery + searchB, 305, 302, 35, 37);

                }
                if (angle >= -15 && angle <= 0)
                {
                    DrawSprite(uh61, playerx + searchA, playery * ritarandom - searchB, 305, 302, 35, 37);
                }

            }// Отрисовка прицела МОДЕ 2

            // Мышка
            FillCircle(MouseX, MouseY, 3);
            if (gunmode == 3) DrawSprite(aiming, MouseX - 50, MouseY - 50);
            FillCircle(MouseX, MouseY, 3);
            //Вращение винта

            //звуки верталета
            //ПРЕДЕЛЬНАЯ ВЫСОТА
            if (enginespeed > enginespeedlimit)
            {
                PlaySound(helirotor4);
                enginespeed = enginespeed - 50;
                otkazsbrosoboroti = 1;


            } // в небе
            else otkazsbrosoboroti = 0;


            if (altitude > 50) PlaySound(helirotor1);
            if (altitude <= 50 && helistop != 1 && helidestroy != 1) PlaySound(helirotor2); // у земли

            if (helilife <= 0 && playery + 10 >= ground) DrawSprite(uh61, playerx - 570, playery - 540, 1685, 4, 705, 568);


            */
        }
    }
}
