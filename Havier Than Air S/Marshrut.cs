using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class Marshrut
    {
        VertexArray marsh_01;
        Vector2f[] marshrutPoints;
        public Marshrut()
        {

            marshrutPoints = new Vector2f[49];

            marshrutPoints[0] = new Vector2f(2585, 798);
            marshrutPoints[1] = new Vector2f(2504, 764);
            marshrutPoints[2] = new Vector2f(2388, 756);
            marshrutPoints[3] = new Vector2f(2052, 806);
            marshrutPoints[4] = new Vector2f(1916, 729);
            marshrutPoints[5] = new Vector2f(1862, 737);
            marshrutPoints[6] = new Vector2f(1682, 819);
            marshrutPoints[7] = new Vector2f(1331, 831);
            marshrutPoints[8] = new Vector2f(1172, 801);
            marshrutPoints[9] = new Vector2f(1104, 779);
            marshrutPoints[10] = new Vector2f(1069, 757);
            marshrutPoints[11] = new Vector2f(836, 727);
            marshrutPoints[12] = new Vector2f(649, 668);
            marshrutPoints[13] = new Vector2f(541, 664);
            marshrutPoints[14] = new Vector2f(368, 756);
            marshrutPoints[15] = new Vector2f(339, 766);
            marshrutPoints[16] = new Vector2f(286, 747);
            marshrutPoints[17] = new Vector2f(263, 734);
            marshrutPoints[18] = new Vector2f(207, 651);
            marshrutPoints[19] = new Vector2f(175, 611);
            marshrutPoints[20] = new Vector2f(144, 565);
            marshrutPoints[21] = new Vector2f(113, 552);
            marshrutPoints[22] = new Vector2f(85, 553);
            marshrutPoints[23] = new Vector2f(40, 580);
            marshrutPoints[24] = new Vector2f(13, 616);
            marshrutPoints[25] = new Vector2f(-36, 670);
            marshrutPoints[26] = new Vector2f(-86, 715);
            marshrutPoints[27] = new Vector2f(-162, 761);
            marshrutPoints[28] = new Vector2f(-257, 779);
            marshrutPoints[29] = new Vector2f(-329, 768);
            marshrutPoints[30] = new Vector2f(-403, 768);
            marshrutPoints[31] = new Vector2f(-483, 787);
            marshrutPoints[32] = new Vector2f(-607, 779);
            marshrutPoints[33] = new Vector2f(-712, 756);
            marshrutPoints[34] = new Vector2f(-772, 738);
            marshrutPoints[35] = new Vector2f(-830, 768);
            marshrutPoints[36] = new Vector2f(-880, 777);
            marshrutPoints[37] = new Vector2f(-936, 769);
            marshrutPoints[38] = new Vector2f(-953, 723);
            marshrutPoints[39] = new Vector2f(-983, 712);
            marshrutPoints[40] = new Vector2f(-1006, 665);
            marshrutPoints[41] = new Vector2f(-1036, 644);
            marshrutPoints[42] = new Vector2f(-1062, 667);
            marshrutPoints[43] = new Vector2f(-1090, 712);
            marshrutPoints[44] = new Vector2f(-1109, 756);
            marshrutPoints[45] = new Vector2f(-1140, 783);
            marshrutPoints[46] = new Vector2f(-1202, 774);
            marshrutPoints[47] = new Vector2f(-1266, 743);
            marshrutPoints[48] = new Vector2f(-1393, 691);
            marshrutPoints[49] = new Vector2f(-1494, 660);
            marshrutPoints[50] = new Vector2f(-1594, 620);



        }



        public void AddPointToMarshrut(Vector2f newPoint)
        {
            Vector2f[] oldMarshrut = marshrutPoints;
            marshrutPoints = new Vector2f[oldMarshrut.Length+1];

            for (int i = 0; i< oldMarshrut.Length;i++)
            {
                marshrutPoints[i] = oldMarshrut[i];
            }
            marshrutPoints[oldMarshrut.Length] = newPoint;

        }


    }
}
