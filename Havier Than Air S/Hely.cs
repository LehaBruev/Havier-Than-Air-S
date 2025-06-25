using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Havier_Than_Air_S.Weapon;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{
    public class Hely : GameObject, IMoovable
    {

        #region Параметры_Heli

        // Картинка верталета
        //Texture heliTexture = new Texture("uh61.png");
        //protected Texture heliTexture = new Texture("uh612.png");
        protected Texture heliTexture;
        public Sprite helySprite;
        protected string textureName;//= "uh612.png";
        protected Vector2f spriteScale =  new Vector2f(2,2);

        //Настройки верталета
        protected float maxpowery = 300000; //Максимальная сила влияет на вертолет
        protected float maxpowerx = 30000; // 
        protected float shagengine = 75; // шаг увеличения мощности двигателя
        protected float shagAngle = 1.5f; // шаг изменения угла атаки
        protected float maxspeedhor = 50;
        protected float maxspeedvert = 300;
        protected float maxheigh = 575; // потолок полета
        protected float speedxmax = 2.5f;
        //nrrocketsMaxquantity = 8; //максимально ракет

        //Характеристики мотора и проч
        protected float helilifemax = 300;// максимальные жизни Вертолета
        public float helienginelife = 100; //исправность двигателя Вертолета
        protected float fuelrashod = 11.7f; // расход топлива
        protected float manageability = 4f;// управляемость //5 это ИНЕРЦИЯ
        protected float maxangle = 60; // Максимальный угол атаки
        protected float helifuelmax = 1300; // Максимальное топливо в баках
        protected float maxboost = 8250; // максимальное ускорение от двигателя //11250
        protected float holdOborotMotora = 12000; // Холостые обороты мотора

        protected float maxenginespeed = 60000; //Максимальные обороты двигателя
        public float enginespeedlimit = 45000; //Предельные обороты двигателя

        #endregion

        #region переменные

        //Переменные
        public float helilifeCurrent;// жизни
        public int engineswitch = 1; // включение двигателя
        public float altitude = 0; // Высота
        public float helifuelCurrent; // Топливо в баках
        int bang1 = 1;
        

        public float playerx = 50;
        public float playery = 400;

        public Vector2f position;
        public float speedx;
        public float speedy;
        float powery;
        public  float enginespeed; //Обороты двигателя

        public float angle = 0; //угол атаки верталета
        float boostv = 0; //ускорение вертикальное

        int helidestroy = 0; // верталет разрушен
        int helistop = 0; // вертолет обесточен

        #endregion

        #region Sounds
        //SOUND
        SoundBuffer engineStartSoundBuffer = new SoundBuffer("zapusk2.wav"); //запуск
        //SoundBuffer engineStopSoundBuffer = new SoundBuffer("zapusk2.wav"); //остановка
        SoundBuffer engineStopSoundBuffer = new SoundBuffer("hw_spindown.wav"); //остановка
        Sound engineStartStopSound;
        Sound channelSoundRita;
        Sound channelSoundTex;
        Clock keyPressClock = new Clock();
        bool keyStartIsPressed = false;

        public int otkazpojardvig= 0;

        SoundBuffer ostalos500kg = new SoundBuffer("Fuel500.wav"); // Осталось 500 кг звук
        SoundBuffer ostalos800kg = new SoundBuffer("Fuel800.wav"); // Осталось 800 кг звук

        //звуки доп
        SoundBuffer metal1Sound = new SoundBuffer("metal1.wav"); // касание земли
        SoundBuffer metal2Sound = new SoundBuffer("metal2.wav"); // касание земли 2
        SoundBuffer bangsound = new SoundBuffer("explode4.wav"); //взрыв
        SoundBuffer grass1 = new SoundBuffer("glass3.wav"); // стекло


        #endregion

        #region Statistika
        // Статистика
        float fuelusedup = 0; //израсходовано топлива
        #endregion

        #region Testirovanie
        //Точка крепления ротора
        CircleShape CircleShapeRotorPoint;


        #endregion

        #region Rotors
        //Задний винт
        Vector2f rearRotorPositionNewVector;
        Sprite rearVintSprite;
        RectangleShape rearRotorRectShape;
        float rearVintSpeed = 41;

        //Верхний винт
        RectangleShape topRotorRectShape;
        float topVintSpeed = 1545;

        #endregion

        #region Weapons
        public Vector2f weaponPositionCurrentPoint;
        public Vector2f positionWeaponLocalPoint;
        public WeaponBase[] m_Weapons;
        public int currentWeapon;
        float allWeaponsWeight = 100.0f; // Вес weapons
        
        protected Vector2f weaponPositionLocal = new Vector2f(-5, 20); // позиция подвесок оружия

        #endregion

        #region Colliders
        public ConvexShape collider;
        public Collider heliCollider;

        #endregion

        Vector2f inertiaVector;

        float ratioenginespeed = 1; //Пожар двигателя
        //Данные для учета столкновения с землей
        float s;
        float ground = 700; // уровень земли
        float airP = 0; //плотность воздуха

        float flighttime = 0; //время нахождения в воздухе

        static float gravityweight = 20000; //Сила притяжения

        
        float fuelWeight = 26; //вес топл

        //земля
        static int g = 0;


        float getdamages = 0; //Получено повреждений

        Avionika avionika;

        

        public Hely()
        {
            avionika = new Avionika(this);

            SpawnHely();

            SpawnEngineSound();

            currentWeapon = 0;

            if (!Program.TestModeP)
            {
                SpawnRotors();
                SpawnSounds();
            }

            //Начальные настройки верталета
            int rnd = new Random().Next(300, 800); // Положенме по Х рандом
            playerx = rnd; //
            playery = 700;
            engineswitch = 0;
            enginespeed = 0;
            helistop = 1;
            helifuelCurrent = helifuelmax;
            helilifeCurrent = helilifemax;
        }


        float scaleX = 2; // Для зеркального отображения спрайта вертолета
        float rearRotorOrigin = -58;

        protected void SpawnHely()
        {
            heliTexture  = new Texture(textureName);
            helySprite = new Sprite(heliTexture);

            //helySprite.Scale = new Vector2f(0.5f, 0.5f);
            helySprite.Scale = spriteScale; // new Vector2f(scaleX, 2);
            
            //helySprite.Color = Color.White;
            //helySprite.Origin = new Vector2f(34, 6);
            helySprite.Origin = new Vector2f(400, 100);
            int rnd = new Random().Next(300, 800);
            helySprite.Position = new Vector2f(rnd, 650);
            Console.WriteLine(rnd);

     
            //Точка для ротора
            CircleShapeRotorPoint = new CircleShape(2);
            CircleShapeRotorPoint.FillColor = new Color(Color.Yellow);
            CircleShapeRotorPoint.Origin = new Vector2f(2, 2);

            m_Weapons = new WeaponBase[] { new GunLauncher(1000, this, TypeOfObject.gun),
                                           new RocketNRLauncher(250, this, TypeOfObject.nr), 
                                           new RocketNRLauncher(250, this, TypeOfObject.sr) };

            
            collider = new ConvexShape(10);
            collider.SetPoint(0, new Vector2f(-27, 5));
            collider.SetPoint(1, new Vector2f(-23, 15));
            collider.SetPoint(2, new Vector2f(10, 15));
            collider.SetPoint(3, new Vector2f(15,10));
            collider.SetPoint(4, new Vector2f(55,10));
            collider.SetPoint(5, new Vector2f(66,15));
            collider.SetPoint(6, new Vector2f(60,30));
            collider.SetPoint(7, new Vector2f(5,30));
            collider.SetPoint(8, new Vector2f(0,25));
            collider.SetPoint(9, new Vector2f(-23,20));
            collider.FillColor = Color.White;
            collider.Origin = helySprite.Origin;



            heliCollider = new Collider(collider);


        }

        private void SpawnSounds()
        {
            //Sounds
            engineStartStopSound = new Sound();
            channelSoundRita = new Sound();
            channelSoundTex = new Sound();
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

            //positionWeaponLocalPoint = weaponPositionLocal;
        }

        bool rPressed = false;


        public void RotorUpdate()
        {
            //ротор rear
            rearRotorPositionNewVector = Matematika.searchAB(helySprite.Rotation, rearRotorOrigin);
            rearRotorRectShape.Position = new Vector2f((helySprite.Position.X) + rearRotorPositionNewVector.X,
                                                 (helySprite.Position.Y) + rearRotorPositionNewVector.Y);
            rearRotorRectShape.Rotation += rearVintSpeed * Program.deltaTimer.Delta() * 100*
                                            enginespeed/maxenginespeed*1.7f;

            //ротор top
            topRotorRectShape.Position = helySprite.Position;
            topRotorRectShape.Rotation = helySprite.Rotation;

            float RotorX = topRotorRectShape.Scale.X + topVintSpeed * Program.deltaTimer.Delta() / 100*
                                   enginespeed / maxenginespeed * 2.7f;
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


            //weaponPoint
            //Vector2f currentLocalPositionPW = Matematika.searchAB(positionWeaponLocalPoint.X+angle + new Random().Next(1, 3), 
              //                                              positionWeaponLocalPoint.Y + new Random().Next(1,3) );
            
            //weaponPositionCurrentPoint = new Vector2f( helySprite.Position.X + currentLocalPositionPW.X,
              //                          helySprite.Position.Y + currentLocalPositionPW.Y);
            
            Vector2f localpos = Matematika.LocalPointOfRotationObject(weaponPositionLocal,angle);
            weaponPositionCurrentPoint = new Vector2f(position.X + localpos.X,
                                                 position.Y + localpos.Y);

            if (Keyboard.IsKeyPressed(Keyboard.Key.R) && rPressed==false)
            {
                CheckFlip();
                rPressed = true;
            }
            else
            {
                if (!Keyboard.IsKeyPressed(Keyboard.Key.R))
                 {
                    rPressed = false;
                }
            }

        }

        private void CheckFlip()
        {
            weaponPositionCurrentPoint = new Vector2f(weaponPositionCurrentPoint.X * (-1),
                                                        weaponPositionCurrentPoint.Y);
            rearRotorOrigin = rearRotorOrigin * (-1);
            helySprite.Scale = new Vector2f(helySprite.Scale.X * (-1), helySprite.Scale.Y);

        }

        public void Update()
        {
            if (groundClock.ElapsedTime.AsSeconds()>0.3)
            {
                tGround = ground;
                inGround = false;
            }

            CheckPosition();
            PlayerMove();
            EngineUpdate();
            PlayerDraw();
            Program.window.Draw(helySprite);

            if (!Program.TestModeP)
            {
                RotorUpdate();
            }

            CircleShapeRotorPoint.Position = new Vector2f( helySprite.Position.X,
                                                 helySprite.Position.Y);

            
            //Program.window.Draw(CircleShape);
            avionika.Update();
            CheckGunMode();

            // Collider
            collider.Position = position;
            collider.Rotation = angle;
            //Program.window.Draw(collider);

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

                    if (engineswitch == 1 && helifuelCurrent > 0 && helidestroy != 1)
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
            if (engineswitch == 0 || helifuelCurrent <= 0 || helidestroy == 1)
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
            if (engineswitch == 1 && helifuelCurrent > 0 && helidestroy != 1)
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
            helifuelCurrent = helifuelCurrent - (enginespeed / 100) * (enginespeed / 100) / 1000000 * fuelrashod * Program.deltaTimer.Delta();
            fuelusedup = fuelusedup + (enginespeed / 100) * (enginespeed / 100) / 1000000 * fuelrashod * Program.deltaTimer.Delta();
            if (helifuelCurrent < 0) helifuelCurrent = 0;
            if (helifuelCurrent < 510 && helifuelCurrent > 507) PlaySound(channelSoundRita, ostalos500kg);
            if (helifuelCurrent < 810 && helifuelCurrent > 805) PlaySound(channelSoundRita, ostalos800kg);
            //if (helifuel < 150 && helifuel > 145) PlaySound(rubejvozvrata); //рубеж возврата предупреждение голосовое

        }

        private void PlaySound(Sound channel, SoundBuffer sound)
        {
            channel.Stop();
            channel.SoundBuffer = sound;
            channel.Play();
        }

       

        void PlayerMove() // коэффициент живучести двигателя
        {
            ChechRotorSound();
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
            powery = (enginespeed * ratioenginespeed / 114 * airP) - gravityweight - helifuelCurrent * fuelWeight - allWeaponsWeight; // подъемная сила

            boostv = powery / 200;       // вертиклаьное ускорение
            if (boostv > (maxenginespeed / 100 * 75)) boostv = maxboost;

            speedy = (boostv / 10); // вертикальная скорость
            if (inGround && speedy<0) speedy = 0;

            playery = (playery - speedy * Program.deltaTimer.Delta() * 100);


            if (playery >= ground)
            {
                groundDamage();

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

            position = new Vector2f(playerx, playery);

            helySprite.Position = position;
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

        bool inGround = false;
        float tGround = 750;
        Clock groundClock = new Clock();

        private void groundDamage()
        {
            groundClock.Restart();
            if ( inGround == false)
            {
                tGround = playery;
                inGround = true;
            }
            //ЗЕМЛЯ столкновение
             if (playery >= tGround)
             {
               playery = tGround;

             }
            
            // g = 1;
             speedx = 0;
                boostv = 0;
                powery = 0;
                
                speedy = 0;
                angle = 0;


          //  if (g == 1)
          // {
                if (s < -1)
                {
                    helilifeCurrent = helilifeCurrent - 19;
                    PlaySound(channelSoundTex, metal1Sound);
                    getdamages = getdamages - 19;
                }
                if (s < -2)
                {
                    helilifeCurrent = helilifeCurrent - 88;
                    PlaySound(channelSoundTex, metal2Sound);
                    PlaySound(channelSoundTex, grass1);
                    getdamages = getdamages - 89;
                    //  loterea(); //TODO Повреждения рика КЛАСС
                }

                if (helilifeCurrent <= 0)
                {
                    helidestroy = 1;
                    if (bang1 == 1)
                    {
                        PlaySound(channelSoundTex, bangsound);
                        bang1 = 0;
                    }
                }
               // g = 0;
           // }

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

            
            

             
        }
    
        public void Fire()
        {
            m_Weapons[currentWeapon].Fire();
        }

        private void CheckWeaponsWeight()
        {
            allWeaponsWeight = 0;
            for (int i = 0; i < m_Weapons.Length; i++)
            {

                allWeaponsWeight += m_Weapons[i].ammWeight;
            }

        }


        private void CheckGunMode()
        {
            
            if (Program.m_MouseController.CheckKeyboardKey(Keyboard.Key.Num1)) currentWeapon = 0;
            if (Program.m_MouseController.CheckKeyboardKey(Keyboard.Key.Num2))
            {
                currentWeapon = 1;
                Program.window.SetMouseCursorVisible(true);
            }
            if (Program.m_MouseController.CheckKeyboardKey(Keyboard.Key.Num3))
            {
                currentWeapon = 2;
                Program.window.SetMouseCursorVisible(false);
            }
            

        }

        string rotorSound1 = "ap_rotorhigh.wav";
        string rotorSound2 = "ap_rotor2earth.wav";
        string rotorSound3 = "ap_rotor3down.wav";
        string rotorSound4 = "ap_rotor4on.wav";

        Sound rotorSound = new Sound();
        float prevAltitude = 100;

        SoundBuffer rotorBufer;
        Sound enginesound;

        private void SpawnEngineSound()
        {
            enginesound = new Sound();
            enginesound.Volume = 0;
            enginesound.SoundBuffer = new SoundBuffer(rotorSound2);
            enginesound.Loop = true;
            enginesound.Play();

            
        }

        private void ChechRotorSound()
        {
            if (enginespeed / maxenginespeed * 1.1f + 0.5f < 1.2) 
                enginesound.Pitch = enginespeed / maxenginespeed * 1.1f + 0.6f;
            else enginesound.Pitch = 1.2f;

            if (enginespeed / maxenginespeed * 100 + 0 < 25)
                enginesound.Volume = enginespeed / maxenginespeed * 100 + 0;
            else
                enginesound.Volume = 25;

            if (altitude <= 1 && prevAltitude > 1 ) ChangeSound(rotorSound3); // у земли
          //  if (altitude > 70 && prevAltitude <= 70 ||
           //     altitude <= 150 && prevAltitude > 150) ChangeSound(rotorSound2); // второй слой 
            if (altitude > 1 && prevAltitude <= 1 ||
                altitude <= 500 && prevAltitude > 500) ChangeSound(rotorSound4); // третий слой 
            if (altitude > 500 && prevAltitude <= 500) ChangeSound(rotorSound1); // третий слой 

            if (enginespeed / holdOborotMotora > 0.6f) rotorSound.Volume = 100;
            else
            rotorSound.Volume = enginespeed/holdOborotMotora;
            

            prevAltitude = altitude;
        }

        


        private void ChangeSound(string soundString)
        {
            rotorSound.Stop();
            rotorBufer = new SoundBuffer(soundString);
            rotorSound.SoundBuffer = rotorBufer;
            rotorSound.Loop = true;
            rotorSound.Play();


        }

        public void Start(Vector2f pos, float angle, Vector2f speed)
        {
            throw new NotImplementedException();
        }

        public TypeOfObject GetTypeOfObject()
        {
            throw new NotImplementedException();
        }

        public PullStatus GetCurrentPullStatus()
        {
            throw new NotImplementedException();
        }

        public Shape GetShape()
        {
            throw new NotImplementedException();
        }

        public Vector2f GetPosition()
        {
            return position;
        }

        public void SetDamage(IMoovable obj)
        {
            if (obj is Hely)
            {

                groundDamage();
            }
        }

        public bool GetColliderStatus()
        {
            throw new NotImplementedException();
        }
    }
}
