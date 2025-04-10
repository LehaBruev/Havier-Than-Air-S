using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Missions
{
    public class MissionTest
    {
        //установка для нр
        Vector2f positionNR;
        float angleNR = 280.0f;

        MouseController mouseController;
        PullObjects pull;

        Clock clock;
        float zaderjka = 0.08f;

        public MissionTest()
        {
            clock = new Clock();
        }
        

        public void Update()
        {
            mouseController = Program.Game.MouseController;
            pull = Program.Game.Pull;
            if (mouseController.LeftButton == true)
            {
                SpawnRocket();
            }

        }

        private void SpawnRocket()
        {
            if (zaderjka < clock.ElapsedTime.AsSeconds())
            {
                positionNR = new Vector2f((float)mouseController.x, (float)mouseController.y);
                pull.SpawnNR_Rocket(positionNR, angleNR);
                clock.Restart();

            }

        }


    }
}
