using Havier_Than_Air_S.Weapon;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
            Shape _shape = new RectangleShape(rearRotorSize);
            _shape.Origin = rearRotorOrigin;
            _shape.FillColor = rearRotorColor;
            _Collider = new Collider(_shape);
            
        }

        public void Update(Vector2f pos, float ang, float RPM_procent)
        {
            UpdateRotorSpeed(RPM_procent);
            setPosAndAngle(pos, _angle);
            base.Update();
            
        }

        private void UpdateRotorSpeed(float RPM_procent)
        {
            _angle += rearVintSpeed * Program.deltaTimer.Delta()*Program.gameSpeed  * RPM_procent;
        }

    }
}
