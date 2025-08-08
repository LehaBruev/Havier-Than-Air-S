using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Havier_Than_Air_S.Missions;
using Havier_Than_Air_S.Weapon;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Havier_Than_Air_S
{


    public class GunLauncher: WeaponBase
    {
        // Параметры
   
        TypeOfObject type = TypeOfObject.gun;
        float skorostrel = 0.1f; //Скорострельность


        int nrrocketsMaxquantity = 64; // максимальное количество NR неуправляемых ракет
        float projectileWeight = 100;

        //Sounds
        string shotSound = "Sounds\\Weapons\\gun2shot.wav";

        // Trunk
        public float currentTrankAngle = 30;
        RectangleShape trunkShape;
        Vector2f trunkSize = new Vector2f(20, 3);
        Vector2f trunkOrigin = new Vector2f(2, 1.5f);
        private Color trunkColor = new Color(255, 161, 0);
        float targeTrunkAngle = 0;
        float trunkAngleSpeed = 1f;
        float trunkMinAngle = 65;
        float trunkMaxAngle = -15;

        int hiroscopeMode = 0;
        float helyAngleMemory = 0;
        Clock keyClock = new Clock();

        private void TrunkAngleUpdate()
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.M) && keyClock.ElapsedTime.AsSeconds()>0.5f)
            {
                if (hiroscopeMode == 1)
                {
                    hiroscopeMode = 0;
                }
                else
                {
                    hiroscopeMode = 1;
                    helyAngleMemory = parentHely.angle;
                }
                keyClock.Restart();
            }    


                if (Keyboard.IsKeyPressed(Keyboard.Key.LShift))
            {
                targeTrunkAngle -= trunkAngleSpeed * Program.deltaTimer.Delta()*Program.gameSpeed;
                if (targeTrunkAngle < trunkMaxAngle) targeTrunkAngle = trunkMaxAngle;
                
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.LControl))
            {
                targeTrunkAngle += trunkAngleSpeed * Program.deltaTimer.Delta() * Program.gameSpeed;
                if (targeTrunkAngle > trunkMinAngle) targeTrunkAngle = trunkMinAngle;
                
            }
            

            if (hiroscopeMode ==1)
            {
                if (parentHely.angle> helyAngleMemory)
                {
                    float delta = helyAngleMemory - parentHely.angle;
                    currentTrankAngle = targeTrunkAngle + delta;
                    if (currentTrankAngle < trunkMaxAngle) currentTrankAngle = trunkMaxAngle;

               }
                else
                {
                    float delta = parentHely.angle - helyAngleMemory ;
                    currentTrankAngle = targeTrunkAngle - delta;
                    if (currentTrankAngle > trunkMinAngle) currentTrankAngle = trunkMinAngle;
                }
               
            }
            else
            {
                currentTrankAngle = targeTrunkAngle;
            }

        }

        public GunLauncher(int ammo, Hely hely, TypeOfObject type, int weaponSlot) : base(type)
        {
            parentHely = hely; // base
            currentAmmCount = ammo;
            ammWeight = projectileWeight;
            //+ тип передается в базу
            skorostrelnost = skorostrel;

            sound.SoundBuffer = new SoundBuffer(shotSound);
            sound.Volume = 20;

            slotInHely = weaponSlot;
            TrunkSpawn();

        }

        private void TrunkSpawn()
        {
            trunkShape = new RectangleShape();
            trunkShape.Size = trunkSize;
            trunkShape.Origin = trunkOrigin;
            trunkShape.FillColor = trunkColor;
        }



        public override void Fire()
        {
            if (!(currentAmmCount <= 0) && clock.ElapsedTime.AsSeconds() > skorostrelnost)
            {
                float a = parentHely.angle + currentTrankAngle*parentHely.flip;
                if (parentHely.flip < 0) a += 179;

                // Позиция вертолета
                //parentHely.positionOfHely
                // Позиция оружия
                Vector2f posOrujiya = Matematika.GlobalPointOfLocalPoint(parentHely.positionOfHely,
                                                                     new Vector2f(parentHely.weaponPositionsOrigins[slotInHely].X * parentHely.flip,
                                                                                    parentHely.weaponPositionsOrigins[slotInHely].Y),
                                                                    parentHely.angle);

                // Позиция кончика ствола

                Vector2f posDulo = Matematika.GlobalPointOfLocalPoint(posOrujiya,
                                                                      new Vector2f(trunkOrigin.X*parentHely.flip, trunkOrigin.Y),
                                                                      parentHely.angle + currentTrankAngle);

                Program.m_PullObjects.StartObject(posDulo,
                                                a,
                                                parentHely.speed,
                                                weaponType);
                currentAmmCount -= 1;
                clock.Restart();

                if (sound != null) sound.Play();
                CheckWeight();
            }
        }


        public override void Update()
        {
            TrunkAngleUpdate();
            Vector2f posOrujiya = Matematika.GlobalPointOfLocalPoint(parentHely.positionOfHely,
                                                                     new Vector2f(parentHely.weaponPositionsOrigins[slotInHely].X * parentHely.flip, 
                                                                                    parentHely.weaponPositionsOrigins[slotInHely].Y),
                                                                    parentHely.angle);
            trunkShape.Position = posOrujiya;
            trunkShape.Rotation = parentHely.angle + currentTrankAngle*parentHely.flip;
            trunkShape.Scale = new Vector2f( parentHely.flip, trunkShape.Scale.Y );


            Program.window.Draw(trunkShape);
        }

    }

}
        





    

