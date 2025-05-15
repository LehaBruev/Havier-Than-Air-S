using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class CameraController
    {

        public Vector2f offset;
        IMoovable moovable;
        Hely player;
        public CameraController()
        {
            
           //Program.view.Reset(new FloatRect(50,50,300, 100));
        }

        public void Update()
        {
            if (moovable != null)
            {
                Program.offset = new Vector2f(moovable.GetPosition().X, 450);
                //Program.offset = new Vector2f(1, 0);
                if (moovable is Hely)
                {
                    //Program.offset += new Vector2f((moovable as Hely).speedx*40, (moovable as Hely).speedy *40);
                    Program.offset += new Vector2f((moovable as Hely).speedx*80, 0);
                }
            }

        }

        public void SetCameraObject(IMoovable obj)
        {

            moovable = obj;
        }
    }
}
