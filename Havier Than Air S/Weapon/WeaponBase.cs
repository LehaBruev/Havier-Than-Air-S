using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S.Weapon
{
    public enum typeOfWeapon
    {
        gun,
        nr,
        sr,
        b,
        pushk
    }

    public class WeaponBase
    {
        public typeOfWeapon weaponTyte;
        public int currentAmmCount;
        public Hely parentHely;

        public float ammWeight; //вес ракеты

        public WeaponBase()
        {
            
            
        }
            
        virtual public void Fire()
        {
            if(!(currentAmmCount<=0))
            {
               Program.PullObjects.Update();
                currentAmmCount -= 1;

            }

        }


    }
}
