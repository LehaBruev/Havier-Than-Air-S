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
        protected string textureName = "uh61.png";
        protected Vector2f spriteScale =  new Vector2f(0.6f,0.6f);
        protected Vector2f spriteOrigin = new Vector2f(175, -10);

        //Настройки верталета
        protected float maxpowery = 300000; //Максимальная сила влияет на вертолет
        protected float maxpowerx = 30000; // 
        protected float shagRUD = 18; // шаг увеличения мощности двигателя
        protected float shagAngle = 1.5f; // шаг изменения угла атаки
        protected float shagAngleSpeed = 7f; // отклик рукоятки угла
        protected float maxspeedhor = 50;
        protected float maxspeedvert = 300;
        protected float maxheigh = 575; // потолок полета
        protected float speedxmax = 4.5f;
        protected float Weight = 1000; // вес машины
        protected float bladesEffectiveness = 3f; // эффективность лопастей

        //Характеристики мотора и проч
        protected float helilifemax = 300;// максимальные жизни Вертолета
        public float currentEnginelife = 100; //исправность двигателя Вертолета
        protected float fuelrashod = 11.7f; // расход топлива
        protected float inertia = 5f;// управляемость //5 это ИНЕРЦИЯ
        protected float maxangle = 60; // Максимальный угол атаки
        protected float helifuelmax = 1300; // Максимальное топливо в баках
        protected float engineMaxPower = 39250; // максимальное ускорение от двигателя //11250
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
        protected float currentWeight = 1; // текущий вес машины
        public Vector2f positionOfHely = new Vector2f(50,700); // позиция в пространстве
        public Vector2f speed = new Vector2f(0,0); // скорость
        
        int helidestroy = 0; // верталет разрушен
        int helistop = 0; // вертолет обесточен

        // силы
        public float gravityPower = 0;

        // rotor
        public float currentRotorPower = 0;
        public Vector2f powerRTR = new Vector2f(0, 0); // сила ротора по векторам

        // engine
        public int engineswitch = 1; // включение двигателя
        public float currentRUDposition = 0; // текущее положение ручки газа
        public float RPM; //Обороты двигателя

        // angle
        public float angle = 0; //угол атаки верталета
        public float currentShagAngleSpeed = 0; // текущая скорость прироста угла
        public Vector2f boost = new Vector2f(0,0); //ускорение 

 
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
        //Верхний винт
        protected Vector2f topVintPositionOrigin = new Vector2f();
        protected RectangleShape topRotorRectShape;
        protected Vector2f topVintOrigin = new Vector2f(80, 1);
        protected Vector2f topVintSize = new Vector2f(160, 2);
        protected Color topRotorColor = Color.Yellow;
        protected float topVintSpeed = 1545;

        //Задний винт
        Sprite rearVintSprite;
        protected Vector2f rearVintPositionOrigin = new Vector2f(-104,8);
        protected RectangleShape rearRotorRectShape;
        protected Vector2f rearRotorSize = new Vector2f(3, 26);
        protected Vector2f rearRotorOrigin = new Vector2f(1.5f, 13);
        protected Color rearRotorColor = Color.Yellow;
        protected float rearVintSpeed = 41;



        #endregion


        #region Weapons
        public Vector2f[] weaponPositionsOrigins = new Vector2f[2] 
                                                                    { new Vector2f(-9, 35), // подвески
                                                                      new Vector2f(-6, 35) }; // носовая пушка
        public WeaponBase[] m_Weapons;
        public Vector2f[] weaponPositionsCurrentPoints;
        
        //GUN
        protected RectangleShape GunTrunk;
        protected Vector2f gunTrunkSize = new Vector2f(2,20);
        protected Vector2f gunTrunkOrigin = new Vector2f(1, 10);
        Color gunTrunkColor = Color.Yellow;
        


        #endregion

        #region Colliders
        protected Vector2f colliderOrigin = new Vector2f(0, 0);
        public ConvexShape colliderConvexShape;

        #endregion

       

        float ratioenginespeed = 1; //Пожар двигателя
        //Данные для учета столкновения с землей
        
        float ground = 700; // уровень земли

        float fuelWeight = 1; //вес топл


        

        public Hely()
        {
            
            SpawnHely();
            SpawnEngineSound();
            Program.m_Avionika.SetHely(this);

            currentWeapon = 0;
            //Начальные настройки верталета
            
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

                
            //Точка для ротора
            CircleShapeRotorPoint = new CircleShape(2);
            CircleShapeRotorPoint.FillColor = new Color(Color.Yellow);
            CircleShapeRotorPoint.Origin = new Vector2f(2, 2);

            //Оружие
            m_Weapons = new WeaponBase[] { new GunLauncher(1000, this, TypeOfObject.gun,1),
                                           new RocketNRLauncher(250, this, TypeOfObject.nr,0), 
                                           new RocketSNRLauncher(250, this, TypeOfObject.sr,0)};

            //Коллайдер
            colliderConvexShape = new ConvexShape(10);
            colliderConvexShape.SetPoint(0, new Vector2f(-27, 5));
            colliderConvexShape.SetPoint(1, new Vector2f(-23, 15));
            colliderConvexShape.SetPoint(2, new Vector2f(10, 15));
            colliderConvexShape.SetPoint(3, new Vector2f(15,10));
            colliderConvexShape.SetPoint(4, new Vector2f(55,10));
            colliderConvexShape.SetPoint(5, new Vector2f(66,15));
            colliderConvexShape.SetPoint(6, new Vector2f(60,30));
            colliderConvexShape.SetPoint(7, new Vector2f(5,30));
            colliderConvexShape.SetPoint(8, new Vector2f(0,25));
            colliderConvexShape.SetPoint(9, new Vector2f(-23,20));
            colliderConvexShape.FillColor = Color.Yellow;
            colliderConvexShape.Origin = colliderOrigin;


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
            //topVint
            topRotorRectShape = new RectangleShape();
            topRotorRectShape.Origin = topVintOrigin;
            topRotorRectShape.Size = topVintSize;
            topRotorRectShape.FillColor = topRotorColor;

            //rearVintSprite.
            rearRotorRectShape = new RectangleShape();
            rearRotorRectShape.Origin = rearRotorOrigin;
            rearRotorRectShape.Size = rearRotorSize;
            rearRotorRectShape.FillColor = rearRotorColor;

            //GunTrunk
            GunTrunk = new RectangleShape();
            GunTrunk.Origin = gunTrunkOrigin;
            GunTrunk.Size = gunTrunkSize;
            GunTrunk.FillColor = gunTrunkColor;

        }

 
        public void RotorAnimatioUpdate()
        {
            //ротор top
            topRotorRectShape.Position = positionOfHely;
            topRotorRectShape.Rotation = angle;

            float RotorX = topRotorRectShape.Scale.X + topVintSpeed * Program.deltaTimer.Delta() / 100 *
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

            //ротор rear
            rearRotorRectShape.Position = Matematika.GlobalPointOfLocalPoint(positionOfHely,
               (new Vector2f(rearVintPositionOrigin.X*flip, rearVintPositionOrigin.Y)), angle);
            rearRotorRectShape.Rotation += rearVintSpeed * Program.deltaTimer.Delta() * 100 *
                                            RPM / maxRPM * 1.7f;

            Program.window.Draw(topRotorRectShape);
            Program.window.Draw(rearRotorRectShape);



        }

        private void FliapUpdate()
        {


            if (Keyboard.IsKeyPressed(Keyboard.Key.R) && rPressed == false)
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
            
            helySprite.Scale = new Vector2f(helySprite.Scale.X * (-1), helySprite.Scale.Y);

            for (int i = 0; i < colliderConvexShape.GetPointCount(); i++)
            {
                colliderConvexShape.SetPoint((uint)i, new Vector2f(-colliderConvexShape.GetPoint((uint)i).X, colliderConvexShape.GetPoint((uint)i).Y));

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

            FliapUpdate();

            AngleCheck();
            CheckRUD();
            EngineUpdate();
            PlayerMove();
            SpriteDraw();
            WeaponUpdate();

            if (!Program.TestModeP)
            {
                RotorAnimatioUpdate();
            }

            CircleShapeRotorPoint.Position = new Vector2f( positionOfHely.X,
                                                 positionOfHely.Y);



            CheckGunMode();

            // Collider
            UpdateCollider();

        }

        private void WeaponUpdate()
        {
            for (int i = 0; i < m_Weapons.Length; i++)
            {
                m_Weapons[i].Update();

            }
        }

        private void UpdateCollider()
        {
            colliderConvexShape.Position = positionOfHely;
            colliderConvexShape.Rotation = angle;
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

       private void AngleCheck()
        {
            //Управление углом атаки
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) == true)
            {
                currentShagAngleSpeed = currentShagAngleSpeed + shagAngleSpeed * Program.deltaTimer.Delta();
                if (currentShagAngleSpeed > shagAngle)
                    currentShagAngleSpeed = shagAngle;

                angle = (angle + currentShagAngleSpeed * Program.deltaTimer.Delta() * Program.gameSpeed);
                if (angle > maxangle)
                    angle = maxangle;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A) == true)
            {
                currentShagAngleSpeed = currentShagAngleSpeed + shagAngleSpeed * Program.deltaTimer.Delta();
                if (currentShagAngleSpeed > shagAngle)
                    currentShagAngleSpeed = shagAngle;

                angle = (angle - currentShagAngleSpeed * Program.deltaTimer.Delta() * Program.gameSpeed);
                if (angle < -maxangle)
                    angle = -maxangle;
            }
            else
            {
                currentShagAngleSpeed = 0;
            }
        }


        void PlayerMove() // коэффициент живучести двигателя
        {
            // Текущий вес
            currentWeight = Weight + helifuelCurrent*fuelWeight;

            ChechRotorSound();
            
            //расчет высоты
            altitude = ground - positionOfHely.Y;
            if (altitude < 0) altitude = 0;


            //расчет вертикальной скорости
            //расчет подъемной силы
            RPM = currentRUDposition / 100 * maxRPM ;
            if (maxRPM < RPM) RPM = maxRPM;

            currentRotorPower = RPM/maxRPM * (currentEnginelife / 100) * engineMaxPower * Program.m_Pogoda.GetCurrentAirP(altitude);
            powerRTR.Y = currentRotorPower;
            powerRTR.X = currentRotorPower - (currentRotorPower - currentRotorPower / 90 * (float)Math.Sqrt(angle * angle) / 10);

            gravityPower = Program.m_Pogoda.gravity * currentWeight;
            boost.Y = (powerRTR.Y - gravityPower)/currentWeight* bladesEffectiveness*Program.m_Pogoda.GetCurrentAirP(altitude);

            speed.Y = boost.Y; // вертикальная скорость
           
            positionOfHely.Y = (positionOfHely.Y - speed.Y * Program.deltaTimer.Delta() * Program.gameSpeed);
            
            if (positionOfHely.Y > 770) positionOfHely.Y = 770;
            if (positionOfHely.Y < 50) 
                positionOfHely.Y = 50;

            if (positionOfHely.Y >= ground)
            {
                groundDamage();

            }

            // Расчет ГОРИЗОНТАЛЬНОГО ПОЛЕТА угол атаки
            speed.X = speed.X + powerRTR.X *Math.Sign(angle) * Program.deltaTimer.Delta()/(Weight/inertia)*
                bladesEffectiveness * Program.m_Pogoda.GetCurrentAirP(altitude); // ФОРМУЛА РАСЧЕТА ГОРИЗОНТАЛЬНОЙ СКОРОСТИ (ПОМЕНЯТЬ)
            if (speed.X > speedxmax) speed.X = speedxmax;
            if (speed.X < -speedxmax) speed.X = -speedxmax;

            positionOfHely.X = positionOfHely.X + speed.X * Program.deltaTimer.Delta()*Program.gameSpeed; //wind

            helySprite.Position = positionOfHely;
        }

        bool inGround = false;
        float tGround = 750;
        Clock groundClock = new Clock();

        private void groundDamage()
        {
            groundClock.Restart();
            if ( inGround == false)
            {
                tGround = positionOfHely.Y;
                inGround = true;
            }
            //ЗЕМЛЯ столкновение
             if (positionOfHely.Y >= tGround)
             {
               positionOfHely.Y = tGround;

             }

            
            speed.X = 0;
          //      boost.Y = 0;
         //       powerRTR.Y = 0;
                
          //      speed.Y = 0;
           //     angle = 0;


       
                if (speed.Y < -1)
                {
                    helylifeCurrent = helylifeCurrent - 19;
                    PlaySound(channelSoundTex, metal1Sound);
                    
                }
                if (speed.Y < -2)
                {
                    helylifeCurrent = helylifeCurrent - 88;
                    PlaySound(channelSoundTex, metal2Sound);
                    PlaySound(channelSoundTex, grass1);
                    
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
            return positionOfHely;
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
