using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class DeltaTimer
    {
        private float delta;
        
        Clock clock;

        public DeltaTimer()
        {
            clock = new Clock(); 
        }

        public void CheckDelta()
        {
            delta = clock.ElapsedTime.AsSeconds();
            clock.Restart();
        }

    
        public float Delta()
        {
            return delta; 
        }

    }
}
