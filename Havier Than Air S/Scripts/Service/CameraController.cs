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
        IMoovable targetIMoovable;
        float camPosSpeed = 5;
        float currentCamAimPos;

        // perem
        CameraMode currentCameraMode = CameraMode.hold;

        public CameraController()
        {
            //Program.offset = new Vector2f(moovable.GetPosition().X, Program.vMode.Height / 2);
        }

        public void Update()
        {
            if (targetIMoovable != null)
            {
                if (currentCameraMode == CameraMode.hold)
                {

                }
                else if (currentCameraMode == CameraMode.hely)
                {
                    currentCamAimPos = targetIMoovable.GetPosition().X;
                    float dist = currentCamAimPos - Program.offset.X;

                    if (currentCamAimPos - Program.offset.X > camPosSpeed)
                    {
                        Program.offset = new Vector2f(Program.offset.X + camPosSpeed*Program.deltaTimer.Delta()* dist, Program.vMode.Height / 2);
                    }
                    else if ( Program.offset.X - currentCamAimPos > camPosSpeed)
                    {
                        Program.offset = new Vector2f(Program.offset.X + camPosSpeed * Program.deltaTimer.Delta()* dist, Program.vMode.Height / 2);
                    }
                    else
                    {
                        Program.offset = new Vector2f(targetIMoovable.GetPosition().X, Program.vMode.Height / 2);
                    }

                }
                else if (currentCameraMode == CameraMode.helyAtack)
                {
                    Program.offset = new Vector2f(targetIMoovable.GetPosition().X, Program.vMode.Height/2);
                    if (targetIMoovable is Hely)
                    {
                        Program.offset += new Vector2f((targetIMoovable as Hely).speed.X * 80, 0);
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
            targetIMoovable = obj;
        }
    }
}
