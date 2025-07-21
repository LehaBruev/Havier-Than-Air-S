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
        private Color nrColor = new Color(255, 161, 0);
        private Texture rocketTexture;

        private Sprite rocketSprite;
        private RectangleShape rectangleShape;
        private Drawable NR;

        // Trunk
        Vector2f trunkOrigin = new Vector2f(25, 0);
        public float currentTrankAngle;


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

                // Суммарный угол

                

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



    }

}
        





    

