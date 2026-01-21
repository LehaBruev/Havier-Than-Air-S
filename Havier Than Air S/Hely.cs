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
using Havier_Than_Air_S.HelyParts;
using Havier_Than_Air_S.Weapon;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;





namespace Havier_Than_Air_S
{
    public class Hely : GameObject, IMoovable
    {

        /*
        Пустой: 2363 кг.
        Максимальная взлётная масса: 4310 кг.
        Масса груза на внешней подвеске: 1759 кг.
        Внутренний запас топлива: 840 кг.
        */

        float angleCorrectorForse = 10;

        Marker marker;

        Detal[] detaly;

        public Vector2f centerOfMass = new Vector2f(0, 30);
        public Vector2f currentCenterOfMassLoc = new Vector2f();

        #region Параметры_Heli
        
        // Картинка верталета
        
        protected Texture heliTexture;
        public Sprite helySprite;
        protected string textureName = "Images\\uh61.png";
        protected Vector2f spriteScale =  new Vector2f(0.6f,0.6f);
        protected Vector2f spriteOrigin = new Vector2f(175, -10);

        //Настройки верталета
        protected float maxpowery = 300000; //Максимальная сила влияет на вертолет
        protected float maxpowerx = 30000; // 
        protected float shagRUD = 0.25f; // шаг увеличения мощности двигателя
        protected float maxShagAngle = 1.5f; // шаг изменения угла атаки
        protected float shagAngleSpeed = 10f; // отклик рукоятки угла
        protected float maxspeedhor = 100;
        protected float maxspeedvert = 500;
        protected float maxheigh = 575; // потолок полета
        protected Vector2f speedxmax = new Vector2f(6f,3);
        protected Vector2f speedMin = new Vector2f(0.001f,0.015f);
        protected float Weight = 2363; // вес машины
        protected float bladesEffectiveness = 3f; // эффективность лопастей

        //Характеристики мотора и проч
        protected float helilifemax = 300;// максимальные жизни Вертолета
        public float currentEnginelife = 100; //исправность двигателя Вертолета
        protected float fuelrashod = 1f; // расход топлива
        protected float maxangle = 60; // Максимальный угол атаки
        protected float helifuelmax = 840; // Максимальное топливо в баках
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
        public float currentWeight = 1; // текущий вес машины
        public Vector2f positionOfHely = new Vector2f(2200,50); // позиция в пространстве
        public Vector2f speed = new Vector2f(0,0); // скорость
        public Vector2f vectorKompensator = new Vector2f(0,0);//вектор для столкновений


        int helidestroy = 0; // верталет разрушен
        int helistop = 0; // вертолет обесточен

        // силы
        public Vector2f gravityPower = new Vector2f(0,0);
        float delta = 0;

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
        SoundBuffer engineStartSoundBuffer = new SoundBuffer("Sounds\\Engine\\zapusk2.wav"); //запуск
        //SoundBuffer engineStopSoundBuffer = new SoundBuffer("Sounds\\Engine\\zapusk2.wav"); //остановка
        SoundBuffer engineStopSoundBuffer = new SoundBuffer("Sounds\\Engine\\hw_spindown.wav"); //остановка
        Sound engineStartStopSound;
        Sound channelSoundRita;
        Sound channelSoundTex;
        Clock keyPressClock = new Clock();
        bool keyStartIsPressed = false;

        public int otkazpojardvig= 0;

        
        SoundBuffer ostalos500kg = new SoundBuffer("Sounds\\Rita\\Fuel500.wav"); // Осталось 500 кг звук
        SoundBuffer ostalos800kg = new SoundBuffer("Sounds\\Rita\\Fuel800.wav"); // Осталось 800 кг звук

        //звуки доп
        SoundBuffer metal1Sound = new SoundBuffer("Sounds\\metal1.wav"); // касание земли
        SoundBuffer metal2Sound = new SoundBuffer("Sounds\\metal2.wav"); // касание земли 2
        SoundBuffer bangsound = new SoundBuffer("Sounds\\Weapons\\explode4.wav"); //взрыв
        SoundBuffer grass1 = new SoundBuffer("Sounds\\glass3.wav"); // стекло


        #endregion

        #region Statistika
        // Статистика
        float fuelusedup = 0; //израсходовано топлива
        #endregion

        #region Testirovanie
        //Точка крепления ротора
        CircleShape CircleShapeRotorPoint;
        protected float scaleMasterSize = 1.0f;


        #endregion

        #region Rotors
        //Верхний винт
        protected Vector2f topVintPositionOrigin = new Vector2f();
        

        //Задний винт
        Sprite rearVintSprite;
        protected Vector2f rearVintPositionOrigin = new Vector2f(-104,8);
        



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

        public Dictionary<Shape, Vector2f[,]> DictionaryOfShapesReal;

        //Ротор коллайдеры
        Vector2f rearColliderOrigin = new Vector2f(0, 0);
        Vector2f topColliderOrigin = new Vector2f(0, 0);
        public ConvexShape rearColliderConvexShape;
        public ConvexShape topColliderConvexShape;

        #endregion

        float ratioenginespeed = 1; //Пожар двигателя
        //Данные для учета столкновения с землей
        
        float fuelWeight = 0.25f; //вес топл



        public Hely()
        {
            //Коллайдеры гор для столкновения

            DictionaryOfShapesReal = new Dictionary<Shape, Vector2f[,]>();
            
            SpawnHely();
            //SpawnEngineSound();
            Program.m_Avionika.SetHely(this);

            currentWeapon = 0;
            //Начальные настройки верталета
            
            engineswitch = 1;
            RPM = 30000;
            helistop = 0;
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


            WeaponsInit();
            SpawnColliders();
            SpawnRotors();
            SpawnSounds();
            

        }

        private void WeaponsInit()
        {
            //Оружие
            m_Weapons = new WeaponBase[] { new GunLauncher(1000, this, TypeOfObject.gun,1),
                                           new RocketNRLauncher(250, this, TypeOfObject.nr,0),
                                           new RocketSNRLauncher(250, this, TypeOfObject.sr,0)};


        }

        private void SpawnColliders()
        {

            //Коллайдер вертолета
            colliderConvexShape = new ConvexShape(11);
            colliderConvexShape.SetPoint(0, new Vector2f(-104, 4));
            colliderConvexShape.SetPoint(1, new Vector2f(-87, 23));
            colliderConvexShape.SetPoint(2, new Vector2f(-28, 24));
            colliderConvexShape.SetPoint(3, new Vector2f(-24, 15));
            colliderConvexShape.SetPoint(4, new Vector2f(26, 15));
            colliderConvexShape.SetPoint(5, new Vector2f(40, 29));
            colliderConvexShape.SetPoint(6, new Vector2f(27, 44));
            colliderConvexShape.SetPoint(7, new Vector2f(-14, 45));
            colliderConvexShape.SetPoint(8, new Vector2f(-21, 35));
            colliderConvexShape.SetPoint(9, new Vector2f(-92, 27));
            colliderConvexShape.SetPoint(10, new Vector2f(-108, 8));
            colliderConvexShape.FillColor = Color.Yellow;
            colliderConvexShape.Origin = colliderOrigin;

            //Коллайдер винта
            topColliderConvexShape = new ConvexShape(2);
            topColliderConvexShape.SetPoint(0, new Vector2f(-79, -2));
            topColliderConvexShape.SetPoint(1, new Vector2f(75, -1));
            topColliderConvexShape.FillColor = Color.Yellow;

            marker = new Marker(topColliderConvexShape, Color.Red, 3);

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
            
            detaly = new Detal[2];
            detaly[0] = new TopRotor_UH1();
            detaly[1] = new RearRotor_UH1();
            

            //GunTrunk
            GunTrunk = new RectangleShape();
            GunTrunk.Origin = gunTrunkOrigin;
            GunTrunk.Size = gunTrunkSize;
            GunTrunk.FillColor = gunTrunkColor;

        }

        Vector2f[] DetalyPos;

        public void RotorAnimatioUpdate()
        {
            
            (detaly[0] as TopRotor_UH1).Update(positionOfHely, angle, RPM / maxRPM);
            (detaly[1] as RearRotor_UH1).Update(Matematika.GlobalPointOfLocalPoint(positionOfHely,
               new Vector2f(rearVintPositionOrigin.X * flip, rearVintPositionOrigin.Y), angle), 
               angle, 
               RPM / maxRPM);

        }

        private void FlipUpdate()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.R) && rPressed == false)
            {
                if (DictionaryOfShapesReal.Count == 0)
                { 
                CheckFlip();
                }

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
            delta = Program.deltaTimer.Delta() * Program.gameSpeed;
            
            currentCenterOfMassLoc = Matematika.LocalPointOfRotationObject(centerOfMass, angle);
            center2PosGlobal = currentCenterOfMassLoc + positionOfHely;
            // Текущий вес
            currentWeight = Weight + helifuelCurrent * fuelWeight; 
            //расчет высоты
            altitude = 700 - positionOfHely.Y;

            CheckEngineSwitch();
            FlipUpdate();
            
            CheckRUD();
            AngleCheck();

            EngineUpdate();
            //ChechRotorSound();
            UpdateCollider();
            PlayerMove();
            SpriteDraw();
            WeaponUpdate();

            if (!Program.TestModeP)
            {
                RotorAnimatioUpdate();
            }

            CircleShapeRotorPoint.Position = positionOfHely;

            CheckGunMode();

            marker.Update();

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
            topColliderConvexShape.Position = positionOfHely;
            topColliderConvexShape.Rotation = angle;
            // Program.window.Draw(collider);
        }

       

        private void CheckRUD()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) == true) currentRUDposition = (currentRUDposition + shagRUD * delta);
            if (currentRUDposition > 100) currentRUDposition = 100;
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) == true) currentRUDposition = (currentRUDposition - shagRUD * delta);
            if (currentRUDposition < 0) currentRUDposition = 0;
        }


        private void CheckEngineSwitch()
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
                        // PlaySound(engineStartStopSound, engineStartSoundBuffer);
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
                    RPM = RPM - 150 * Program.deltaTimer.Delta() * 100;
                    if (helistop != 1)
                    {
                        helistop = 1;
                        //PlaySound(engineStartStopSound, engineStopSoundBuffer);
                    }
                }
                if (RPM < 0) RPM = 0;
            }

            // Продолжение работы мотора
            if (engineswitch == 1 && helifuelCurrent > 0 && helidestroy != 1)
            {
                if (RPM < holdRPM)
                {
                    RPM = RPM + shagRUD / 2 * delta * 100;
                    if (helistop == 1)
                    {
                        helistop = 0;
                    }
                }
            }
        }

        private void EngineUpdate()
        {

            //Расход топлива
            helifuelCurrent = helifuelCurrent - (RPM / 100) * (RPM / 100) / 1000000 * fuelrashod * delta;
            fuelusedup = fuelusedup + (RPM / 100) * (RPM / 100) / 1000000 * fuelrashod * delta;
            if (helifuelCurrent < 0) helifuelCurrent = 0;
            if (helifuelCurrent < 510 && helifuelCurrent > 507) PlaySound(channelSoundRita, ostalos500kg);
            if (helifuelCurrent < 810 && helifuelCurrent > 805) PlaySound(channelSoundRita, ostalos800kg);
            //if (helifuel < 150 && helifuel > 145) PlaySound(rubejvozvrata); //рубеж возврата предупреждение голосовое

            //Обороты
            RPM = currentRUDposition / 100 * maxRPM;
            if (RPM > maxRPM ) RPM = maxRPM;

            //Сила ротора
            currentRotorPower = RPM / maxRPM * (currentEnginelife / 100) * engineMaxPower * Program.m_Pogoda.GetCurrentAirP(altitude);

            powerRTR.X = currentRotorPower - (currentRotorPower - currentRotorPower / 2500 * (float)Math.Sqrt(angle * angle));
            powerRTR.X = powerRTR.X * Math.Sign(angle);
            powerRTR.Y = currentRotorPower - powerRTR.X * Math.Sign(angle);

        }

        private void PlaySound(Sound channel, SoundBuffer sound)
        {
            //channel.Stop();
            //channel.SoundBuffer = sound;
            //channel.Play();
        }

        float minRotorPowerToChangeAngle = 7000f;
        float workRotorPowerToChangeAngle = 23000f;
        float upravlyaemostAngle = 1;
       private void AngleCheck()
        {
            if (currentRotorPower > minRotorPowerToChangeAngle)
            {
                if(currentRotorPower< workRotorPowerToChangeAngle)
                {
                    upravlyaemostAngle = currentRotorPower / workRotorPowerToChangeAngle;

                }

                //Управление углом атаки
                if (Keyboard.IsKeyPressed(Keyboard.Key.D) == true)
                {
                    currentShagAngleSpeed = currentShagAngleSpeed + shagAngleSpeed * delta;
                    if (currentShagAngleSpeed > maxShagAngle)
                        currentShagAngleSpeed = maxShagAngle;

                    angle = angle + currentShagAngleSpeed * delta* upravlyaemostAngle;
                    if (angle > maxangle)
                        angle = maxangle;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.A) == true)
                {
                    currentShagAngleSpeed = currentShagAngleSpeed + shagAngleSpeed * delta;
                    if (currentShagAngleSpeed > maxShagAngle)
                        currentShagAngleSpeed = maxShagAngle;

                    angle = angle - currentShagAngleSpeed * delta* upravlyaemostAngle;
                    if (angle < -maxangle)
                        angle = -maxangle;
                }
                else
                {
                    currentShagAngleSpeed = 0;
                }
            }
        }



        public Vector2f F = new Vector2f(0,0);
        public Vector2f Ek = new Vector2f(0,0);
        public Vector2f AeroAntiPower = new Vector2f(0,0);
        Vector2f aeroTormozMinSpeed = new Vector2f(0.2f, 1f); // Это для аэродинамики
        Vector2f aeroResistance = new Vector2f(5, 1800); // Это для аэродинамики

        private void PlayerMove()
        {
            
            //Ek = new Vector2f(0.5f * speed.X * speed.X * currentWeight*Math.Sign(speed.X), 0.5f * speed.Y * speed.Y * currentWeight*Math.Sign(speed.Y));
            
            //Гравитация
            gravityPower = new Vector2f(0,Program.m_Pogoda.gravity * currentWeight);
            //Сопротивление воздуха
            float xx;
            if (speed.X > aeroTormozMinSpeed.X || speed.X < -aeroTormozMinSpeed.X)
            {
                xx = speed.X * speed.X * aeroResistance.X * 0.5f * Math.Sign(speed.X); 
            }
            else
            {
                xx = 0;
            }
            AeroAntiPower = new Vector2f(xx, speed.Y* speed.Y * aeroResistance.Y * 0.5f*(Math.Sign(speed.Y)));



            F = powerRTR - gravityPower - AeroAntiPower; // Ek убрал /  кинетика и мотор
            speed = speed +  F * delta / currentWeight; //(v-v0)/deltaTime = F/currentWeight;

            //Корректировка Speed
            ColliderPhisicsCompensation(); // Расчет вектора компенсатора при столкновениях
            

            if (speed.X > speedxmax.X) speed.X = speedxmax.X;
            if (speed.X < -speedxmax.X) speed.X = -speedxmax.X;
            if (speed.Y > speedxmax.Y) speed.Y = speedxmax.Y;
            if (speed.Y < -speedxmax.Y) speed.Y = -speedxmax.Y;

            

            if (positionOfHely.Y < 50)
            {
                positionOfHely.Y = 50;
                speed.Y = 0;
            }

            
            positionOfHely.X = positionOfHely.X + speed.X * delta; 
            positionOfHely.Y = positionOfHely.Y - speed.Y * delta;



            helySprite.Position = positionOfHely;

        }

      
        public Vector2f vectorToDamage_01 = new Vector2f(0,0);
        float compensatorForce = 0.3f;
        public Vector2f center2PosGlobal = new Vector2f();


        //Принимает объектСтолкновения, номера двух точек для построения линии, векторВертолета от центра до касаний
        private void VectorCompensatory()
        {
            if (DictionaryOfShapesReal.Count > 0)
            {
                int signalCentraMass = ZnakPregrady(GranPregradaPosGlob, currentCenterOfMassLoc + positionOfHely, Matematika.AngleOfVector(GranPregrada));
                int signalMirrorVector = ZnakPregrady(GranPregradaPosGlob, GranPregradaPosGlob + new Vector2f(MirrorVector.X, MirrorVector.Y), Matematika.AngleOfVector(GranPregrada));

                if (signalCentraMass == signalMirrorVector)
                {
                    vectorKompensator = MirrorVector;

                }
                else
                {
                    vectorKompensator = new Vector2f();
                }
            }
            else
            {
                vectorKompensator = new Vector2f();
            }

            if (vectorKompensator.X != 0 || vectorKompensator.Y != 0)
            {
                speed.X = vectorKompensator.X * compensatorForce;
                speed.Y = -vectorKompensator.Y * compensatorForce;

                if (Math.Abs(speed.X) < speedMin.X) speed.X = 0;
                if (Math.Abs(speed.Y) < speedMin.Y) speed.Y = 0;
            }

            AddAngle();

        }

        float rotationCoeffic = 0.05f;
        float minForceRotation = 0.1f;
        private void AddAngle()
        {
            /*
            if (vectorKompensator.X > 0)
                angle -= angleCorrectorForse * delta;
            if (vectorKompensator.X < 0)
                angle += angleCorrectorForse * delta;
            */

            float summAngle = Matematika.AngleOfVector(summaVectorov); // Угол вектора 
            Vector2f MV0 = Matematika.LocalPointOfRotationObject(summaVectorov,angle); // Наклон вектора касания к углу вертолета
            Vector2f MV = MV0 + MirrorVector; // Поиск точки силы
            Vector2f MV2 = Matematika.LocalPointOfRotationObject(MV, -angle - summAngle); // Доворот точки силы в 0 градусов суммВектора
            float F = MV2.Y;
            float L = Matematika.searchdistance(new Vector2f(), summaVectorov);

            float Moment = F * Math.Abs( L ) * rotationCoeffic* delta;

            if (minForceRotation < Math.Abs(Moment))
                {
                angle += Moment;
            }
           // MirrorVector
           // summaVectorov

        }

        private int ZnakPregrady(Vector2f posPregradaGlobal, Vector2f pointToCheckGlob,float alfaPregrada) // вычисляем центр масс за препятствием или перед
        {
            
            Vector2f LocalVectorToCenterMass = pointToCheckGlob - posPregradaGlobal;

            Vector2f angeledMassPosition = Matematika.LocalPointOfRotationObject(LocalVectorToCenterMass, -alfaPregrada);

            return Math.Sign(angeledMassPosition.Y);
        }

        Vector2f summaVectorov = new Vector2f(); //Вектор до грани коллайдера, столкновения корпуса
        private Vector2f  Touch_01_Vector(Vector2f[,] shapeMatrix)
        {
            //Вектор до граней коллайдера / сумма векторов до центров граней
            List<Vector2f> skladVectorov = new List<Vector2f>();
            
            int numOfVector = 0;

            for (int i = 0; i < shapeMatrix.GetLength(0); i++)
            {
                //Вектор до центра грани (отрицательный У)
                Vector2f centerGrany = Vectora.VectorToCenterGranyOfConvex(shapeMatrix[i, 1], colliderConvexShape);

                //Складировать вектор в массив или лист
                if (!skladVectorov.Contains(centerGrany))
                {
                    skladVectorov.Add(centerGrany);
                    summaVectorov = summaVectorov + centerGrany;
                    numOfVector += 1;
                }
            }

            //Построить новый вектор из листа
            summaVectorov = new Vector2f(summaVectorov.X, summaVectorov.Y)  / numOfVector;
            summaVectorov =  summaVectorov - centerOfMass;
            
            return summaVectorov; 
        }


        //Используются в авионике
        public Vector2f touchVector = new Vector2f(); // нужен
        public Vector2f GranPregrada = new Vector2f(); // нужен
        public Vector2f GranPregradaPosGlob = new Vector2f(); // нужен
        public Vector2f MirrorVector = new Vector2f(-150,50); // нужен

        private void ColliderPhisicsCompensation()
        {
            if (DictionaryOfShapesReal.Count==0)
            {
                vectorKompensator = new Vector2f(0,0);
                vectorToDamage_01 = new Vector2f(0,0);
            }

            // Ключ=форма, значение=два номера точек грани
            foreach (var shape in DictionaryOfShapesReal)
            {
                //Суммарный точ вектор до обшивки
                touchVector = Touch_01_Vector(shape.Value);

                //Грань препятствия из точек препятствия / суммарный вектор  = 2м массив с точками + сама фигура
                GranPregrada = granSkala(shape.Value, shape.Key);

                //Вектор отражение от препятствия / отражаем скорость от препятствия
                MirrorVector = Vectora.MirrorVector(GranPregrada, speed);

                VectorCompensatory();

            }

        }

       private Vector2f granSkala(Vector2f[,] shapeMatrix,Shape shape)
        {
            List<Vector2f> Points = new List<Vector2f>();
            List<int> skladTochek = new List<int>();
            List<int> obshieTochki = new List<int>();
            Vector2f summaVectorov = new Vector2f();

            for (int f=0;f< shapeMatrix.GetLength(0); f++)
            {
                if (!Points.Contains(shapeMatrix[f, 0])) Points.Add(shapeMatrix[f, 0]);
            }

           //Добавляем в лист все точки которые строят грани
           for (int i = 0; i < Points.Count; i++)
           {

                if (!skladTochek.Contains((int)Points[i].X)) 
                    skladTochek.Add((int)Points[i].X); 
                else obshieTochki.Add((int)Points[i].X);
               if (!skladTochek.Contains((int)Points[i].Y)) 
                    skladTochek.Add((int)Points[i].Y); 
                else obshieTochki.Add((int)Points[i].Y);
           }
                
            obshieTochki.Sort();

            //Перебираем общие
            for (int z = 0; z < obshieTochki.Count; z++)
            {
                skladTochek.Remove(obshieTochki[z]);
            }
            skladTochek.Sort();
            
            Vector2f tochka_01 = shape.GetPoint((uint)skladTochek[0]);
            Vector2f tochka_02 = shape.GetPoint((uint)skladTochek[skladTochek.Count() - 1]);

            summaVectorov = tochka_02 - tochka_01;
            GranPregradaPosGlob = tochka_01 + shape.Position;

            //Перенос точки отсчета вектора
            if (tochka_02.X < tochka_01.X)
            {
                summaVectorov = new Vector2f(-summaVectorov.X, -summaVectorov.Y);
                GranPregradaPosGlob = tochka_02 + shape.Position;
            }
            

            return summaVectorov;
        }


        bool inGround = false;

        Clock groundClock = new Clock();

        private void groundDamage()
        {
            groundClock.Restart();
            if ( inGround == false)
            {
                //tGround = positionOfHely.Y;
                inGround = true;
            }
            
            
            /*
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
          */

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

        string rotorSound1 = "Sounds\\Engine\\ap_rotorhigh.wav";
        string rotorSound2 = "Sounds\\Engine\\ap_rotor2earth.wav";
        string rotorSound3 = "Sounds\\Engine\\ap_rotor3down.wav";
        string rotorSound4 = "Sounds\\Engine\\ap_rotor4on.wav";

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

        #region objectives
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
        #endregion
    }
}
