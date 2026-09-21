using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.GroundObjects
{
    public class BaseGroundObject
    {

        public Vector2f position;

        // Коллайдеры столкновения
        public ConvexShape[] m_Colliders;
        public Marker[] m_Markers;

        public BaseGroundObject() 
        {
        
        }

        public virtual void Update()
        {

        }
    }
}
