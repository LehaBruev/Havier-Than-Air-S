using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S.Weapon
{
  

    public class WeaponBase
    {
        public TypeOfObject weaponTyte;
        
        public Hely parentHely;

        public int currentAmmCount;
        public float ammWeight; //вес ракеты
        public int weaponWeight;
        public float skorostrelnost; // скорострельность


        // Сервисные
        Clock clock;

        // Звуки
        protected Sound sound;

        public WeaponBase(TypeOfObject type)
        {
            weaponTyte = type;
            clock = new Clock();
            sound = new Sound();
        }
            
        virtual public void Fire()
        {
            if(!(currentAmmCount<=0) && clock.ElapsedTime.AsSeconds()>skorostrelnost)
            {
                float a = parentHely.angle;
                if (parentHely.helySprite.Scale.X < 0) a += 179;

               Program.m_PullObjects.StartObject(parentHely.weaponPositionCurrentPoint,
                                                a,
                                                parentHely.speed,
                                                weaponTyte);
                currentAmmCount -= 1;
                clock.Restart();

                if (sound!=null) sound.Play();
            }

        }


    }
}
