using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.GroundObjects
{
    public class Ground_01: BaseGroundObject
    {

       public  Ground_01()
       {
            position = new Vector2f(0, 0);

            m_Colliders = new ConvexShape[1];

            m_Colliders[0] = new ConvexShape();
            

            ConvexShape colliderConvexShape = m_Colliders[0];
            colliderConvexShape.SetPointCount(15);

            colliderConvexShape.SetPoint(0, new Vector2f(559, 793));
            colliderConvexShape.SetPoint(1, new Vector2f(655, 815));
            colliderConvexShape.SetPoint(2, new Vector2f(720, 829));
            colliderConvexShape.SetPoint(3, new Vector2f(841, 823));
            colliderConvexShape.SetPoint(4, new Vector2f(894, 815));
            colliderConvexShape.SetPoint(5, new Vector2f(955, 813));
            colliderConvexShape.SetPoint(6, new Vector2f(1015, 826));
            colliderConvexShape.SetPoint(7, new Vector2f(1082, 828));
            colliderConvexShape.SetPoint(8, new Vector2f(1158, 807));
            colliderConvexShape.SetPoint(9, new Vector2f(1152, 892));
            colliderConvexShape.SetPoint(10, new Vector2f(423, 888));
            colliderConvexShape.SetPoint(11, new Vector2f(425, 834));
            colliderConvexShape.SetPoint(12, new Vector2f(470, 822));
            colliderConvexShape.SetPoint(13, new Vector2f(498, 801));
            colliderConvexShape.SetPoint(14, new Vector2f(541, 790));


            colliderConvexShape.Position = new Vector2f(-750,-30);

            m_Markers = new Marker[1];
            m_Markers[0] = new Marker(colliderConvexShape, Color.Blue, 5);


        }

        public override void Update()
        {
            for (int i = 0; i < m_Markers.Length; i++)
            {
                m_Markers[i].Update();
            }

            for (int i = 0; i < m_Colliders.Length; i++)
            {
                Program.window.Draw(m_Colliders[i]);
            }

        }

    }
}
