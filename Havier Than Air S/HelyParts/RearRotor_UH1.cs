using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.HelyParts
{
    public class RearRotor_UH1: Detal
    {

        Vector2f rearRotorSize = new Vector2f(3, 26);
        Vector2f rearRotorOrigin = new Vector2f(1.5f, 13);
        Color rearRotorColor = Color.Yellow;
        float rearVintSpeed = 141;

        public RearRotor_UH1()
        {
            //topVint
            _shape = new RectangleShape(rearRotorSize);
            _shape.Origin = rearRotorOrigin;
            _shape.FillColor = rearRotorColor;
            //marker = new Marker(_shape, Color.Green, 3);
        }

        public void Update(Vector2f pos, float ang, float RPM_procent)
        {
            setPosAndAngle(pos, ang);
            _shape.Position = _position;
            UpdateRotorSpeed(RPM_procent);
            Program.window.Draw(_shape);
            //marker.Update();

        }

        private void UpdateRotorSpeed(float RPM_procent)
        {

            _shape.Rotation += rearVintSpeed * Program.deltaTimer.Delta()*Program.gameSpeed  * RPM_procent;



        }

    }
}
