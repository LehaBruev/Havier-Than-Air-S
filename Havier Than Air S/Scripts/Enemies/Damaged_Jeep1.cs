using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Scripts.Enemies
{
    public class Damaged_Jeep1 : IMoovable
    {
        PullStatus currentPullStatus = PullStatus.inPool;
        Sprite spriteBody;

        public Shape colliderShape;

        public Damaged_Jeep1()
        {
            Shape colliderShape = new RectangleShape(new Vector2f(70, 24));
            colliderShape.Origin = new Vector2f(35, 22);
            //Collider coll = new Collider(colliderShape, Color.Green);
            Collider coll = new Collider(colliderShape);

            Texture textureBody = new Texture(new Image("Images\\DamagedObjectsImages\\Jeep1_windowv.png"));
            spriteBody = new Sprite(textureBody);
            spriteBody.Scale = new Vector2f(0.2f, 0.2f);
            spriteBody.Origin = new Vector2f(180, 200);


        }


        public bool GetColliderStatus()
        {
            return true;
        }

        public PullStatus GetCurrentPullStatus()
        {
            return currentPullStatus;
        }

        public Vector2f GetPosition()
        {
            throw new NotImplementedException();
        }

        public Shape GetColliderShape()
        {
            return colliderShape;
        }

        public TypeOfObject GetTypeOfObject()
        {
            return TypeOfObject.house;
        }

        public void SetDamage(IMoovable obj)
        {
            //currentPullStatus = PullStatus.inPool;
            //rectShape.Position = Program.m_PullObjects.position;
        }

        public void Start(Vector2f pos, float angle, Vector2f speed)
        {
            currentPullStatus = PullStatus.inAir;
            spriteBody.Position = pos;
            spriteBody.Rotation = angle;
        }

        public void Update()
        {
            Program.window.Draw(spriteBody);

        }

        public Shape GetColliderShape(int numOfDetal)
        {
            return null;
        }

        public void ReturnToPull()
        {
            throw new NotImplementedException();
        }
    }
}
