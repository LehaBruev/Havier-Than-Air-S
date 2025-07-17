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
using System.Xml.Serialization;
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
        
        protected Texture heliTexture;
        public Sprite helySprite;
        protected string textureName = "uh612.png";
        protected Vector2f spriteScale =  new Vector2f(2,2);
        protected Vector2f spriteOrigin = new Vector2f(34, 6);

        //Настройки верталета
        protected float maxpowery = 300000; //Максимальная сила влияет на вертолет
        protected float maxpowerx = 30000; // 
        protected float shagRUD = 75; // шаг увеличения мощности двигателя
        protected float shagAngle = 1.5f; // шаг изменения угла атаки
        protected float shagAngleSpeed = 7f; // отклик рукоятки угла
        protected float maxspeedhor = 50;
        protected float maxspeedvert = 300;
        protected float maxheigh = 575; // потолок полета
        protected float speedxmax = 2.5f;
        protected float Weight = 10000; // вес машины

        //Характеристики мотора и проч
        protected float helilifemax = 300;// максимальные жизни Вертолета
        public float currentEnginelife = 100; //исправность двигателя Вертолета
        protected float fuelrashod = 11.7f; // расход топлива
        protected float manageability = 4f;// управляемость //5 это ИНЕРЦИЯ
        protected float maxangle = 60; // Максимальный угол атаки
        protected float helifuelmax = 1300; // Максимальное топливо в баках
        protected float engineMaxPower = 8250; // максимальное ускорение от двигателя //11250
        protected float holdRPM = 12000; // Холостые обороты мотора

        protected float maxRPM = 60000; //Максимальные обороты двигателя
        public float RPMLimit = 45000; //Предельные обороты двигателя

        #endregion

        #region переменные

        //Переменные hely
        public float helylifeCurrent;// жизни
        public float altitude = 0; // высота
        public float helifuelCurrent; // тек топливо
        int bang1 = 0;
        protected float currentWeight = 10000; // вес машины
        public Vector2f position = new Vector2f(50,400); // позиция в пространстве
        public Vector2f speed = new Vector2f(0,0); // скорость
        
        int helidestroy = 0; // верталет разрушен
        int helistop = 0; // вертолет обесточен

        // rotor
        float currentRotorPower = 0;
        Vector2f powerRTR = new Vector2f(0, 0); // сила ротора по векторам

        // engine
        public int engineswitch = 1; // включение двигателя
        public float currentRUDposition = 0; // текущее положение ручки газа
        public float RPM; //Обороты двигателя

        // angle
        public float angle = 0; //угол атаки верталета
        public float currentShagAngleSpeed = 0; // текущая скорость прироста угла
        Vector2f boost = new Vector2f(0,0); //ускорение 

 
        // weapons
        public int currentWeapon;
        float allWeaponsWeight = 100.0f; // Вес weapons

        // animation
        Vector2f rearRotorPositionNewVector;
        public int flip = 1;

        // Knopki
        bool rPressed = false;


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
        Sprite rearVintSprite;
        protected RectangleShape rearRotorRectShape;
        float rearVintSpeed = 41;
        protected Vector2f rearRotorOrigin = new Vector2f( -58,0);


        //Верхний винт
        protected RectangleShape topRotorRectShape;
        protected float topVintSpeed = 1545;
        protected Vector2f topVontOrigin = new Vector2f(0, 0);

        #endregion


        #region Weapons
        protected Vector2f weaponPositionOrigin = new Vector2f(-5, 20); // позиция подвесок оружия
        public Vector2f weaponPositionCurrentPoint;
        public WeaponBase[] m_Weapons;
        
        
        

        #endregion

        #region Colliders
        protected Vector2f colliderOrigin = new Vector2f(0, 0);
        public ConvexShape collider;

        #endregion

       

        float ratioenginespeed = 1; //Пожар двигателя
        //Данные для учета столкновения с землей
        
        float ground = 700; // уровень земли

        float fuelWeight = 26; //вес топл

        public Hely()
        {
            
            SpawnHely();
            SpawnEngineSound();
            Program.m_Avionika.SetHely(this);

            currentWeapon = 0;
            //Начальные настройки верталета
            int rnd = new Random().Next(300, 800); // Положенме по Х рандом
            position.X = 350; //
            position.Y = 700;
            engineswitch = 0;
            RPM = 0;
            helistop = 1;
            helifuelCurrent = helifuelmax;
            helylifeCurrent = helilifemax;
        }



        virtual protected void SpawnHely()
        {

            //Спрайт
            heliTexture  = new Texture(textureName);
            helySprite = new Sprite(heliTexture);
            helySprite.Scale = spriteScale;
            helySprite.Origin = spriteOrigin; 

            //Позиция при старте
            int rnd = new Random().Next(300, 800);
            position = new Vector2f(rnd, 650);

     
            //Точка для ротора
            CircleShapeRotorPoint = new CircleShape(2);
            CircleShapeRotorPoint.FillColor = new Color(Color.Yellow);
            CircleShapeRotorPoint.Origin = new Vector2f(2, 2);

            //Оружие
            m_Weapons = new WeaponBase[] { new GunLauncher(1000, this, TypeOfObject.gun),
                                           new RocketNRLauncher(250, this, TypeOfObject.nr), 
                                           new RocketSNRLauncher(250, this, TypeOfObject.sr) };

            //Коллайдер
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
            collider.FillColor = Color.Yellow;
            collider.Origin = colliderOrigin;


            SpawnRotors();
            SpawnSounds();

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

            
        }

 
        public void RotorAnimatioUpdate()
        {
            //ротор rear
            rearRotorPositionNewVector = Matematika.searchAB(angle, rearRotorOrigin.X);
            rearRotorRectShape.Position = new Vector2f((position.X) + rearRotorPositionNewVector.X,
                                                 (position.Y) + rearRotorPositionNewVector.Y);
            rearRotorRectShape.Rotation += rearVintSpeed * Program.deltaTimer.Delta() * 100*
                                            RPM/maxRPM*1.7f;

            //ротор top
            topRotorRectShape.Position = position;
            topRotorRectShape.Rotation = angle;

            float RotorX = topRotorRectShape.Scale.X + topVintSpeed * Program.deltaTimer.Delta() / 100*
                                   RPM / maxRPM * 2.7f;
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

            for (int i = 0; i < collider.GetPointCount(); i++)
            {
                collider.SetPoint((uint)i, new Vector2f(-collider.GetPoint((uint)i).X, collider.GetPoint((uint)i).Y));

            }
            flip *= -1;
        }

        public virtual void Update()
        {
            if (groundClock.ElapsedTime.AsSeconds()>0.3)
            {
                tGround = ground;
                inGround = false;
            }

            CheckRUD();
            PlayerMove();
            EngineUpdate();
            SpriteDraw();
            

            if (!Program.TestModeP)
            {
                RotorAnimatioUpdate();
            }

            CircleShapeRotorPoint.Position = new Vector2f( position.X,
                                                 position.Y);


            Vector2f localpos = Matematika.LocalPointOfRotationObject(weaponPositionOrigin, angle);
            weaponPositionCurrentPoint = new Vector2f(position.X + localpos.X,
                                                 position.Y + localpos.Y);


            CheckGunMode();

            // Collider
            UpdateCollider();

        }

        private void UpdateCollider()
        {
            collider.Position = position;
            collider.Rotation = angle;
            // Program.window.Draw(collider);
        }



        private void CheckRUD()
        {
            
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) == true) currentRUDposition = (currentRUDposition + shagRUD * Program.deltaTimer.Delta());
            if (currentRUDposition > 100) currentRUDposition = 100;
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) == true) currentRUDposition = (currentRUDposition - shagRUD * Program.deltaTimer.Delta());
            if (currentRUDposition < 0) currentRUDposition = 0;

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
                if (RPM > 0)
                {

                    RPM = RPM - 150*Program.deltaTimer.Delta()*100;
                    if (helistop != 1)
                    {
                        helistop = 1;
                        PlaySound(engineStartStopSound, engineStopSoundBuffer);
                    }

                }
                if (RPM < 0) RPM = 0;
            }

            // Продолжение работы мотора
            if (engineswitch == 1 && helifuelCurrent > 0 && helidestroy != 1)
            {
                if (RPM < holdRPM)
                {
                    RPM = RPM + shagRUD / 2 * Program.deltaTimer.Delta()*100;
                    if (helistop == 1)
                    {
                        helistop = 0;
                    }
                }
            }

            //Расход топлива
            helifuelCurrent = helifuelCurrent - (RPM / 100) * (RPM / 100) / 1000000 * fuelrashod * Program.deltaTimer.Delta();
            fuelusedup = fuelusedup + (RPM / 100) * (RPM / 100) / 1000000 * fuelrashod * Program.deltaTimer.Delta();
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
            ratioenginespeed = currentEnginelife * 1.25f / 100;
            if (ratioenginespeed > 1) ratioenginespeed = 1;

            //расчет плотности воздуха, на выходе получаем = airP
            altitude = (768 - position.Y) - (768 - ground);

            Program.m_Pogoda.airP = (float)Math.Sqrt(position.Y) * 2 * 3;

            if (maxRPM < RPM) RPM = maxRPM;

            //расчет вертикальной скорости
            //расчет подъемной силы


            //угол атаки уменьшает подъемную силу
            //power.Y = (RPM * ratioenginespeed / 114 * airP) - gravityweight - helifuelCurrent * fuelWeight - allWeaponsWeight; // подъемная сила

            //boost.Y = power.Y / 200;       // вертиклаьное ускорение

            RPM = currentRUDposition / 100 * maxRPM;
            currentRotorPower = RPM * currentEnginelife / 100 * engineMaxPower * Program.m_Pogoda.GetCurrentAirP(altitude);
            

            if (boost.Y > (maxRPM / 100 * 75)) boost.Y = engineMaxPower;

            speed.Y = (boost.Y / 10); // вертикальная скорость
            if (inGround && speed.Y < 0) speed.Y = 0;

            position.Y = (position.Y - speed.Y * Program.deltaTimer.Delta() * 100);


            if (position.Y >= ground)
            {
                groundDamage();

            }

            // Расчет ГОРИЗОНТАЛЬНОГО ПОЛЕТА угол атаки
            // Вылет за зону полётов
            //Управление углом атаки
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) == true)
            {
                currentShagAngleSpeed = currentShagAngleSpeed + shagAngleSpeed * Program.deltaTimer.Delta();
                if (currentShagAngleSpeed > shagAngle) 
                    currentShagAngleSpeed = shagAngle;

                angle = (angle + currentShagAngleSpeed * Program.deltaTimer.Delta() * 100);
                if (angle > maxangle) 
                    angle = maxangle;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A) == true)
            {
                currentShagAngleSpeed = currentShagAngleSpeed + shagAngleSpeed * Program.deltaTimer.Delta();
                if (currentShagAngleSpeed > shagAngle) 
                    currentShagAngleSpeed = shagAngle;

                angle = (angle - currentShagAngleSpeed * Program.deltaTimer.Delta() * 100);
                if (angle < -maxangle) 
                    angle = -maxangle;
            }
            else
            {
                currentShagAngleSpeed = 0;
            }

            speed.X = speed.X + RPM / 114 * airP / 100 * angle * Program.deltaTimer.Delta() / gravityweight * manageability; // ФОРМУЛА РАСЧЕТА ГОРИЗОНТАЛЬНОЙ СКОРОСТИ (ПОМЕНЯТЬ)
            if (speed.X > speedxmax) speed.X = speedxmax;
            if (speed.X < -speedxmax) speed.X = -speedxmax;

            position.X = position.X + speed.X * Program.deltaTimer.Delta()*100; //wind

            position = new Vector2f(position.X, position.Y);

            helySprite.Position = position;
          

        }

        bool inGround = false;
        float tGround = 750;
        Clock groundClock = new Clock();

        private void groundDamage()
        {
            groundClock.Restart();
            if ( inGround == false)
            {
                tGround = position.Y;
                inGround = true;
            }
            //ЗЕМЛЯ столкновение
             if (position.Y >= tGround)
             {
               position.Y = tGround;

             }

            // g = 1;
            speed.X = 0;
                boost.Y = 0;
                powerRTR.Y = 0;
                
                speed.Y = 0;
                angle = 0;


          //  if (g == 1)
          // {
                if (s < -1)
                {
                    helylifeCurrent = helylifeCurrent - 19;
                    PlaySound(channelSoundTex, metal1Sound);
                    getdamages = getdamages - 19;
                }
                if (s < -2)
                {
                    helylifeCurrent = helylifeCurrent - 88;
                    PlaySound(channelSoundTex, metal2Sound);
                    PlaySound(channelSoundTex, grass1);
                    getdamages = getdamages - 89;
                    //  loterea(); //TODO Повреждения рика КЛАСС
                }

                if (helylifeCurrent <= 0)
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

        void SpriteDraw() // отрисовка Верталета
        {
            
            helySprite.Rotation = angle;
            Program.window.Draw(helySprite);

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
            if (RPM / maxRPM * 1.1f + 0.5f < 1.2) 
                enginesound.Pitch = RPM / maxRPM * 1.1f + 0.6f;
            else enginesound.Pitch = 1.2f;

            if (RPM / maxRPM * 100 + 0 < 25)
                enginesound.Volume = RPM / maxRPM * 100 + 0;
            else
                enginesound.Volume = 25;

            if (altitude <= 1 && prevAltitude > 1 ) ChangeSound(rotorSound3); // у земли
          //  if (altitude > 70 && prevAltitude <= 70 ||
           //     altitude <= 150 && prevAltitude > 150) ChangeSound(rotorSound2); // второй слой 
            if (altitude > 1 && prevAltitude <= 1 ||
                altitude <= 500 && prevAltitude > 500) ChangeSound(rotorSound4); // третий слой 
            if (altitude > 500 && prevAltitude <= 500) ChangeSound(rotorSound1); // третий слой 

            if (RPM / holdRPM > 0.6f) rotorSound.Volume = 100;
            else
            rotorSound.Volume = RPM/holdRPM;
            

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
