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
        string shotSound = "gun2shot.wav";

        //Отрисовка
        
        private Texture rocketTexture;

  
        // Trunk
        public float currentTrankAngle = 30;
        RectangleShape trunkShape;
        Vector2f trunkSize = new Vector2f(20, 4);
        Vector2f trunkOrigin = new Vector2f(2, 2);
        private Color trunkColor = new Color(255, 161, 0);

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
                float a = parentHely.angle + currentTrankAngle;
                if (parentHely.flip < 0) a += 179;

                // Позиция вертолета
                //parentHely.positionOfHely
                // Позиция оружия
                Vector2f posOrujiya = Matematika.GlobalPointOfLocalPoint(parentHely.positionOfHely,
                                                                         parentHely.weaponPositionsOrigins[slotInHely],
                                                                         parentHely.angle);

                // Позиция кончика ствола

                Vector2f posDulo = Matematika.GlobalPointOfLocalPoint(posOrujiya,
                                                                      trunkOrigin,
                                                                      parentHely.angle+ currentTrankAngle);

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
            Vector2f posOrujiya = Matematika.GlobalPointOfLocalPoint(parentHely.positionOfHely,
                                                                         parentHely.weaponPositionsOrigins[slotInHely],
                                                                         parentHely.angle);
            trunkShape.Position = posOrujiya;
            trunkShape.Rotation = parentHely.angle + currentTrankAngle;

            Program.window.Draw(trunkShape);
        }

    }

}
        





    

