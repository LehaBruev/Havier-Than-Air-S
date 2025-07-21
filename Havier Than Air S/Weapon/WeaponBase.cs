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
        public TypeOfObject weaponType;
        
        public Hely parentHely;

        public int currentAmmCount = 50;
        public float ammWeight = 1; //вес ракеты
        public int weaponWeight = 50;
        public float AllWeight = 0;
        public float skorostrelnost; // скорострельность


        // Сервисные
        protected Clock clock;
        public int slotInHely = 0;

        // Звуки
        protected Sound sound;

        public WeaponBase(TypeOfObject type)
        {
            weaponType = type;
            clock = new Clock();
            sound = new Sound();
        }
            
        virtual public void Fire()
        {
            if(!(currentAmmCount<=0) && clock.ElapsedTime.AsSeconds()>skorostrelnost)
            {
                float a = parentHely.angle ;
                if (parentHely.flip < 0) a += 179;

                Vector2f posOrujiya = Matematika.GlobalPointOfLocalPoint(parentHely.positionOfHely,
                                                                         parentHely.weaponPositionsOrigins[slotInHely],
                                                                         parentHely.angle);

                Program.m_PullObjects.StartObject(posOrujiya,
                                                a,  
                                                parentHely.speed,
                                                weaponType);
                currentAmmCount -= 1;
                clock.Restart();

                if (sound!=null) sound.Play();
                CheckWeight();
            }

        }

        public void CheckWeight()
        {
            AllWeight = weaponWeight + ammWeight * currentAmmCount;

        }
    }
}
