using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.HelyParts
{
    public class TopRotor_UH1: Detal
    {

        //Верхний винт
        protected Vector2f topVintOrigin = new Vector2f(80, 1);
        protected Vector2f topVintSize = new Vector2f(160, 2);
        protected Color topRotorColor = Color.Yellow;
        protected float topVintSpeed = 1545;


        public TopRotor_UH1()
        {
            //topVint
            _shape = new RectangleShape(topVintSize);
            _shape.Origin = topVintOrigin;
            _shape.FillColor = topRotorColor;
            marker = new Marker(_shape, Color.Green, 3);
        }

        public override void Update()
        {
            _shape.Position = _position;
            _shape.Rotation = _angle;
            Program.window.Draw(_shape);
            marker.Update();
        }


        public void UpdateRotorSpeed(float RPM_procent)
        {

            float RotorX = _shape.Scale.X + topVintSpeed * Program.deltaTimer.Delta()*Program.gameSpeed / 1000 *
                                   RPM_procent;
            if (RotorX > 1)
            {
                RotorX = 1;
                topVintSpeed *= -1;
            }
            if (RotorX < 0.08f)
            {
                RotorX = 0.08f;
                topVintSpeed *= -1;
            }

            _shape.Scale = new Vector2f(RotorX, _shape.Scale.Y);
            


        }
    }
}
