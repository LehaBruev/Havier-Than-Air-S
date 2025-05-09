using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public interface IMoovable
    {

        void Start(Vector2f pos, float angle);
        void Update();
        TypeOfObject GetTypeOfObject();
        PullStatus GetCurrentPullStatus();


    }
}
