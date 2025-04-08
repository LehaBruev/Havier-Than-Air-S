using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    internal class PullObjects
    {
        private int NRroketsCount = 5;

        private Rocket[] NRrockets;

        public PullObjects()
        {

            NRrockets = new Rocket[NRroketsCount];
            for (int i = 0; i < NRrockets.Length; i++)
            {
                NRrockets[i] = new Rocket();
            }





        }         








    }
}
