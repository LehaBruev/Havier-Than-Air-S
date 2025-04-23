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


    public class RocketNRLauncher: WeaponBase
    {
        // Параметры
         float NRrocketlenght = 20;
         float NRrocketpower = 47;
        float NRocketWeight = 100;
        TypeOfWeapon type = TypeOfWeapon.nr;
         
         float NRrocketspeed = 200; // скорость NR неуправляемых ракет
         int nrrocketsMaxquantity = 64; // максимальное количество NR неуправляемых ракет
         float nrfuel = 3; // запас хода NR неуправляемых ракет
        float NRrocketRashod = 1;

       

        //Отрисовка
        private Color nrColor = new Color(255, 161, 0);
        private Texture rocketTexture;

        private Sprite rocketSprite;
        private RectangleShape rectangleShape;
        private Drawable NR;

        MissionTest missTest;
        

        public RocketNRLauncher(int ammo,Hely hely)
        {
            //ProduceRocket();
            ammWeight = NRocketWeight; // base
            weaponTyte = type; // base
            parentHely = hely; // base
            currentAmmCount = ammo;
        }

        public override void Fire()
        {
           base.Fire();
        }

    }

}
        





    

