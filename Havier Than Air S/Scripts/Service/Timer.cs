using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class Timer
    {
        float currentTime;
        public bool timerOk = false;
        float targetTime;

        public Timer(float targetForTimer) 
        {
            targetTime = targetForTimer;
        }

        public void UpdateTimer()
        {
            if (currentTime < targetTime)
            {
                currentTime += 1;
            }
            else 
            {
                timerOk = true;
            }
        }

        public void Start(float targetForTimer)
        {
            targetTime = targetForTimer;
            currentTime = 0;
            timerOk = false;
        }

    }
}
