using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Havier_Than_Air_S.Missions;
using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S
{


    public class RocketSNRLauncher: WeaponBase
    {
        // Параметры
         float NRrocketlenght = 20;
         float NRrocketpower = 47;
            
        
         int nrrocketsMaxquantity = 64; // максимальное количество NR неуправляемых ракет
        float skorostrel = 0.3f; //Скорострельность

       

       
        

        public RocketSNRLauncher(int ammo,Hely hely, TypeOfObject type) : base(type)
        {
            parentHely = hely; // base
            currentAmmCount = ammo;
            //+ тип передается в базу
            skorostrelnost = skorostrel;
        }

        public override void Fire()
        {
           base.Fire();
        }

    }

}
        





    

