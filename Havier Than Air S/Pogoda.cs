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
        public float davlenie = 200;
        public float veter = 0;
        private Clock clockDavlenie;
        private Clock clockVeter;
        Random rndDavlenie = new Random();
        Random rndVeter = new Random();

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


    }
}
