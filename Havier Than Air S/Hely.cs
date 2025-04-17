using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
         float helifuel = 850; // Топливо в баках
         int bang1 = 1;
         int gunmode = 0;

        //Характеристики
         float helilifemax = 300;// максимальные жизни Вертолета
         float helienginelife = 100; //исправность двигателя Вертолета
         float fuelrashod = 1; // расход топлива
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

        public Hely()
        {
            SpawnHely();
            


            //Начальные настройки верталета
            playerx = 120;
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
            helySprite.Position = new Vector2f(300, 300);
            //helySprite.Scale = new Vector2f(0.5f, 0.5f);
            helySprite.Scale = new Vector2f(2, 2);
            helySprite.Color = Color.White;

            //Sounds
            engineStartStopSound = new Sound();
            channelSoundRita = new Sound();
            channelSoundTex = new Sound();

        }


        public void Update()
        {
            CheckPosition();
            EngineUpdate();
            Program.window.Draw(helySprite);
        }

        private void CheckPosition()
        {
            //ОСНОВНЫЕ ПАРАМЕТРЫ   ДВИЖЕНИЕ WSDA
            /*
            if (GetKey(Keyboard.Key.W) == true) enginespeed = (enginespeed + shagengine);
            if (enginespeed > maxenginespeed) enginespeed = maxenginespeed;
            if (GetKey(Keyboard.Key.S) == true) enginespeed = (enginespeed - shagengine * 1.5f);
            if (enginespeed < 0) enginespeed = 0;
            */

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
        }


        private void EngineUpdate()
        {
            // вкл/выкл двигателя
            if (Keyboard.IsKeyPressed(Keyboard.Key.I) == true  && keyStartIsPressed == false)
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
            else if(keyStartIsPressed == true)
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

                    enginespeed = enginespeed - 200;
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
                    enginespeed = enginespeed + shagengine / 2;
                    if (helistop == 1)
                    {
                        helistop = 0;
                    }
                }

            }
            
            //Расход топлива
            helifuel = helifuel - (enginespeed / 100) * (enginespeed / 100) / 1000000 * fuelrashod;
            fuelusedup = fuelusedup + (enginespeed / 100) * (enginespeed / 100) / 1000000 * fuelrashod;
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
        float ground; // уровень земли
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

            playery = (playery - speedy);



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
        }
            /*
            // Расчет ГОРИЗОНТАЛЬНОГО ПОЛЕТА угол атаки
            // Вылет за зону полётов
            //Управление углом атаки
            if (GetKey(Keyboard.Key.D) == true) angle = (angle + shagAngle);
            if (angle > maxangle) angle = maxangle;
            if (GetKey(Keyboard.Key.A) == true) angle = (angle - shagAngle);
            if (angle < -maxangle) angle = -maxangle;

            speedx = speedx + enginespeed / 114 * airP / 100 * angle * DeltaTime / gravityweight * manageability; // ФОРМУЛА РАСЧЕТА ГОРИЗОНТАЛЬНОЙ СКОРОСТИ (ПОМЕНЯТЬ)
            if (speedx > speedxmax) speedx = speedxmax;
            if (speedx < -speedxmax) speedx = -speedxmax;


            playerx = playerx + speedx + wind;
            if (GetKeyDown(Keyboard.Key.V) == true)
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
}
