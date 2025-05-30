using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{

    public enum CameraMode
    {
        hold,
        hely,
        helyAtack
    }

    public class CameraController
    {
        public Vector2f offset;
        IMoovable moovable;
        Hely player;

        // perem
        CameraMode currentCameraMode = CameraMode.hold;

        public CameraController()
        {  
           //Program.view.Reset(new FloatRect(50,50,300, 100));
        }

        public void Update()
        {
            if (moovable != null)
            {
                if (currentCameraMode == CameraMode.hold)
                {

                }
                else if (currentCameraMode == CameraMode.hely)
                {
                    Program.offset = new Vector2f(moovable.GetPosition().X, 450);
                }
                else if (currentCameraMode == CameraMode.helyAtack)
                {
                    Program.offset = new Vector2f(moovable.GetPosition().X, 450);
                    if (moovable is Hely)
                    {
                       
                        Program.offset += new Vector2f((moovable as Hely).speedx * 80, 0);
                    }
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.F1))
                {
                    currentCameraMode = CameraMode.hold;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.F2))
                {
                    currentCameraMode = CameraMode.hely;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.F3))
                {
                    currentCameraMode = CameraMode.helyAtack;
                }
            }
        }
        

        public void SetCameraObject(IMoovable obj)
        {
            moovable = obj;
        }
    }
}
