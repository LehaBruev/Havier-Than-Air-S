using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S.Missions
{
    public class Hous : IMoovable
    {
        PullStatus currentPullStatus = PullStatus.inPool;

        public RectangleShape rectShape;
        Marker Marker;
        public Hous() 
        {
            rectShape = new RectangleShape();
        rectShape.FillColor = Color.Green;
        rectShape.Size = new Vector2f(20, 50);
        rectShape.Origin = new Vector2f(0,rectShape.Size.Y);
            Marker = new Marker(rectShape,Color.Red,2);
        }

        public bool GetColliderStatus()
        {
            throw new NotImplementedException();
        }

        public PullStatus GetCurrentPullStatus()
        {
            return currentPullStatus;
        }

        public Vector2f GetPosition()
        {
            throw new NotImplementedException();
        }

        public Shape GetShape()
        {
            throw new NotImplementedException();
        }

        public TypeOfObject GetTypeOfObject()
        {
            return TypeOfObject.house;
        }

        public void SetDamage(IMoovable obj)
        {
            throw new NotImplementedException();
        }

        public void Start(Vector2f pos, float angle, Vector2f speed)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            Program.window.Draw(rectShape);

        }


    }
}
