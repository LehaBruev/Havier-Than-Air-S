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


    public class GunLauncher: WeaponBase
    {
        // Параметры
   
        TypeOfWeapon type = TypeOfWeapon.gun;
         
         
         int nrrocketsMaxquantity = 64; // максимальное количество NR неуправляемых ракет
        float projectileWeight = 100;

        //Отрисовка
        private Color nrColor = new Color(255, 161, 0);
        private Texture rocketTexture;

        private Sprite rocketSprite;
        private RectangleShape rectangleShape;
        private Drawable NR;


        public GunLauncher(int ammo, Hely hely, TypeOfWeapon type) : base(type)
        {
            parentHely = hely; // base
            currentAmmCount = ammo;
            ammWeight = projectileWeight;
            //+ тип передается в базу
        }

        public override void Fire()
        {
           base.Fire();
        }

    }

}
        





    

