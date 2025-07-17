using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Havier_Than_Air_S
{
    public class Pogoda
    {
        public float maxAlt = 1400;
        public float airP = 1;
        public float veter = 0;
        private Clock clockDavlenie;
        private Clock clockVeter;
        Random rndDavlenie = new Random();
        Random rndVeter = new Random();
        public float gravityweight = 20000; //Сила притяжения
        public float gravity = 9.8F;

        public Pogoda()
        {
            clockDavlenie  = new Clock();
            clockVeter = new Clock();
            rndDavlenie.Next(1, 200);
            rndVeter.Next(1, 200);
        }

        public void Update()
        {

        }

        //Принимает высоту, выдаёт текущую плотность воздуха на этой высоте
        public float GetCurrentAirP(float alt)
        {
            float p = airP;

            if (alt != 0)
             p =  airP * ((maxAlt - alt) / maxAlt);


            return p;
        }

    }
}
