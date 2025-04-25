using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S.Weapon
{
    public enum TypeOfWeapon
    {
        gun,
        nr,
        sr,
        b,
        pushk
    }

    public class WeaponBase
    {
        public TypeOfWeapon weaponTyte;
        
        public Hely parentHely;

        public int currentAmmCount;
        public float ammWeight; //вес ракеты
        public int weaponWeight;

        public WeaponBase(TypeOfWeapon type)
        {
            weaponTyte = type;

        }
            
        virtual public void Fire()
        {
            if(!(currentAmmCount<=0))
            {
               Program.m_PullObjects.StartObject(parentHely.weaponPositionCurrentPoint, parentHely.angle, weaponTyte);
                currentAmmCount -= 1;

            }

        }


    }
}
