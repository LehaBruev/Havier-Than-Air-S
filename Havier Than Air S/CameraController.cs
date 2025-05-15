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

        Vector2f offset;
        IMoovable moovable;

        public CameraController()
        {
            
           //Program.view.Reset(new FloatRect(50,50,300, 100));
        }

        public void Update()
        {
            offset = new Vector2f(0, moovable.GetPosition().Y);



        }
    }
}
