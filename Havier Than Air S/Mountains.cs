using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class Mountains
    {
      
        // Коллайдер для активации второй текстуры
        public ConvexShape ColliderActivation;

        // Коллайдеры столкновения
        public ConvexShape[] MountColliders;
        Marker mark_1;

        //Предустановка
        
        int numOfMount = 0;


        public Mountains()
        {
            MountColliders = new ConvexShape[14];

            ConvexShape MountShape1 = new ConvexShape();
            #region m1
            MountShape1.SetPointCount(14);
            MountShape1.SetPoint(0, new Vector2f(-1144, 793));
            MountShape1.SetPoint(1, new Vector2f(-1111, 777));
            MountShape1.SetPoint(2, new Vector2f(-1094, 730));
            MountShape1.SetPoint(3, new Vector2f(-1066, 670));
            MountShape1.SetPoint(4, new Vector2f(-1042, 644));
            MountShape1.SetPoint(5, new Vector2f(-1023, 650));
            MountShape1.SetPoint(6, new Vector2f(-998, 669));
            MountShape1.SetPoint(7, new Vector2f(-982, 713));
            MountShape1.SetPoint(8, new Vector2f(-956, 726));
            MountShape1.SetPoint(9, new Vector2f(-943, 757));
            MountShape1.SetPoint(10, new Vector2f(-919, 782));
            MountShape1.SetPoint(11, new Vector2f(-867, 785));
            MountShape1.SetPoint(12, new Vector2f(-870, 857));
            MountShape1.SetPoint(13, new Vector2f(-1154, 848));
            #endregion
            SetMountain(MountShape1);

            mark_1 = new Marker(MountShape1, Color.Blue,5);


            #region m2
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(18);
            MountShape1.SetPoint(0, new Vector2f(-155, 763));
            MountShape1.SetPoint(1, new Vector2f(-87, 718));
            MountShape1.SetPoint(2, new Vector2f(-25, 662));
            MountShape1.SetPoint(3, new Vector2f(12, 618));
            MountShape1.SetPoint(4, new Vector2f(42, 575));
            MountShape1.SetPoint(5, new Vector2f(83, 550));
            MountShape1.SetPoint(6, new Vector2f(114, 552));
            MountShape1.SetPoint(7, new Vector2f(147, 564));
            MountShape1.SetPoint(8, new Vector2f(161, 591));
            MountShape1.SetPoint(9, new Vector2f(178, 620));
            MountShape1.SetPoint(10, new Vector2f(213, 659));
            MountShape1.SetPoint(11, new Vector2f(243, 697));
            MountShape1.SetPoint(12, new Vector2f(273, 744));
            MountShape1.SetPoint(13, new Vector2f(299, 769));
            MountShape1.SetPoint(14, new Vector2f(327, 771));
            MountShape1.SetPoint(15, new Vector2f(357, 767));
            MountShape1.SetPoint(16, new Vector2f(362, 853));
            MountShape1.SetPoint(17, new Vector2f(-157, 850));
            SetMountain(MountShape1);
            #endregion

            
            #region m3
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(19);
            MountShape1.SetPoint(0, new Vector2f(350, 767));
            MountShape1.SetPoint(1, new Vector2f(411, 743));
            MountShape1.SetPoint(2, new Vector2f(449, 713));
            MountShape1.SetPoint(3, new Vector2f(542, 666));
            MountShape1.SetPoint(4, new Vector2f(609, 667));
            MountShape1.SetPoint(5, new Vector2f(654, 670));
            MountShape1.SetPoint(6, new Vector2f(715, 684));
            MountShape1.SetPoint(7, new Vector2f(767, 705));
            MountShape1.SetPoint(8, new Vector2f(845, 729));
            MountShape1.SetPoint(9, new Vector2f(922, 741));
            MountShape1.SetPoint(10, new Vector2f(1019, 754));
            MountShape1.SetPoint(11, new Vector2f(1089, 759));
            MountShape1.SetPoint(12, new Vector2f(1128, 784));
            MountShape1.SetPoint(13, new Vector2f(1172, 797));
            MountShape1.SetPoint(14, new Vector2f(1209, 801));
            MountShape1.SetPoint(15, new Vector2f(1300, 822));
            MountShape1.SetPoint(16, new Vector2f(1348, 832));
            MountShape1.SetPoint(17, new Vector2f(1344, 893));
            MountShape1.SetPoint(18, new Vector2f(350, 890));

            SetMountain(MountShape1);
            #endregion
            

            
            #region m -2
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(13);
            MountShape1.SetPoint(0, new Vector2f(-875, 785));
            MountShape1.SetPoint(1, new Vector2f(-830, 773));
            MountShape1.SetPoint(2, new Vector2f(-803, 749));
            MountShape1.SetPoint(3, new Vector2f(-761, 741));
            MountShape1.SetPoint(4, new Vector2f(-655, 769));
            MountShape1.SetPoint(5, new Vector2f(-586, 782));
            MountShape1.SetPoint(6, new Vector2f(-456, 782));
            MountShape1.SetPoint(7, new Vector2f(-397, 770));
            MountShape1.SetPoint(8, new Vector2f(-321, 771));
            MountShape1.SetPoint(9, new Vector2f(-266, 784));
            MountShape1.SetPoint(10, new Vector2f(-152, 762));
            MountShape1.SetPoint(11, new Vector2f(-148, 894));
            MountShape1.SetPoint(12, new Vector2f(-875, 895));

            SetMountain(MountShape1);
            #endregion
            

            
            #region m3
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(20);
            MountShape1.SetPoint(0, new Vector2f(614, 563));
            MountShape1.SetPoint(1, new Vector2f(577, 520));
            MountShape1.SetPoint(2, new Vector2f(636, 439));
            MountShape1.SetPoint(3, new Vector2f(696, 379));
            MountShape1.SetPoint(4, new Vector2f(719, 344));
            MountShape1.SetPoint(5, new Vector2f(760, 333));
            MountShape1.SetPoint(6, new Vector2f(791, 341));
            MountShape1.SetPoint(7, new Vector2f(813, 362));
            MountShape1.SetPoint(8, new Vector2f(831, 409));
            MountShape1.SetPoint(9, new Vector2f(861, 435));
            MountShape1.SetPoint(10, new Vector2f(878, 482));
            MountShape1.SetPoint(11, new Vector2f(976, 536));
            MountShape1.SetPoint(12, new Vector2f(1009, 589));
            MountShape1.SetPoint(13, new Vector2f(1040, 626));
            MountShape1.SetPoint(14, new Vector2f(1020, 649));
            MountShape1.SetPoint(15, new Vector2f(911, 635));
            MountShape1.SetPoint(16, new Vector2f(821, 555));
            MountShape1.SetPoint(17, new Vector2f(725, 555));
            MountShape1.SetPoint(18, new Vector2f(676, 575));
            MountShape1.SetPoint(19, new Vector2f(636, 573));

            SetMountain(MountShape1);
            #endregion
            
            
            #region m3
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(15);
            MountShape1.SetPoint(0, new Vector2f(1338, 831));
            MountShape1.SetPoint(1, new Vector2f(1562, 835));
            MountShape1.SetPoint(2, new Vector2f(1639, 846));
            MountShape1.SetPoint(3, new Vector2f(1856, 736));
            MountShape1.SetPoint(4, new Vector2f(1915, 730));
            MountShape1.SetPoint(5, new Vector2f(2024, 789));
            MountShape1.SetPoint(6, new Vector2f(2118, 830));
            MountShape1.SetPoint(7, new Vector2f(2166, 831));
            MountShape1.SetPoint(8, new Vector2f(2284, 788));
            MountShape1.SetPoint(9, new Vector2f(2392, 758));
            MountShape1.SetPoint(10, new Vector2f(2508, 767));
            MountShape1.SetPoint(11, new Vector2f(2598, 805));
            MountShape1.SetPoint(12, new Vector2f(2654, 804));
            MountShape1.SetPoint(13, new Vector2f(2659, 892));
            MountShape1.SetPoint(14, new Vector2f(1338, 890));
            SetMountain(MountShape1);
            #endregion
            
            
            #region m3
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(4);
            MountShape1.SetPoint(0, new Vector2f(-468, 455));
            MountShape1.SetPoint(1, new Vector2f(-592, 529));
            MountShape1.SetPoint(2, new Vector2f(-458, 636));
            MountShape1.SetPoint(3, new Vector2f(-316, 564));
            SetMountain(MountShape1);
            #endregion

            
            #region m4
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(11);
            MountShape1.SetPoint(0, new Vector2f(2657, 889));
            MountShape1.SetPoint(1, new Vector2f(2653, 805));
            MountShape1.SetPoint(2, new Vector2f(2721, 780));
            MountShape1.SetPoint(3, new Vector2f(2827, 689));
            MountShape1.SetPoint(4, new Vector2f(2943, 543));
            MountShape1.SetPoint(5, new Vector2f(2993, 486));
            MountShape1.SetPoint(6, new Vector2f(3056, 463));
            MountShape1.SetPoint(7, new Vector2f(3159, 484));
            MountShape1.SetPoint(8, new Vector2f(3224, 530));
            MountShape1.SetPoint(9, new Vector2f(3250, 556));
            MountShape1.SetPoint(10, new Vector2f(3335, 888));

            SetMountain(MountShape1);
            #endregion
            

            
            #region m5
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(10);
            MountShape1.SetPoint(0, new Vector2f(3455, 464));
            MountShape1.SetPoint(1, new Vector2f(3508, 413));
            MountShape1.SetPoint(2, new Vector2f(3581, 385));
            MountShape1.SetPoint(3, new Vector2f(3650, 401));
            MountShape1.SetPoint(4, new Vector2f(3697, 442));
            MountShape1.SetPoint(5, new Vector2f(3764, 568));
            MountShape1.SetPoint(6, new Vector2f(3801, 676));
            MountShape1.SetPoint(7, new Vector2f(3794, 707));
            MountShape1.SetPoint(8, new Vector2f(3645, 723));
            MountShape1.SetPoint(9, new Vector2f(3497, 602));
            SetMountain(MountShape1);
            #endregion
            
         
            
            #region m6
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(10);
            MountShape1.SetPoint(0, new Vector2f(-1139, 895));
            MountShape1.SetPoint(1, new Vector2f(-1141, 794));
            MountShape1.SetPoint(2, new Vector2f(-1353, 781));
            MountShape1.SetPoint(3, new Vector2f(-1528, 707));
            MountShape1.SetPoint(4, new Vector2f(-1708, 469));
            MountShape1.SetPoint(5, new Vector2f(-1846, 150));
            MountShape1.SetPoint(6, new Vector2f(-2001, 71));
            MountShape1.SetPoint(7, new Vector2f(-2442, 127));
            MountShape1.SetPoint(8, new Vector2f(-2716, 292));
            MountShape1.SetPoint(9, new Vector2f(-2579, 892));
            SetMountain(MountShape1);
            #endregion
            

            
            #region m7
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(8);
            MountShape1.SetPoint(0, new Vector2f(3329, 890));
            MountShape1.SetPoint(1, new Vector2f(3283, 735));
            MountShape1.SetPoint(2, new Vector2f(3422, 771));
            MountShape1.SetPoint(3, new Vector2f(3583, 814));
            MountShape1.SetPoint(4, new Vector2f(3776, 858));
            MountShape1.SetPoint(5, new Vector2f(3964, 820));
            MountShape1.SetPoint(6, new Vector2f(4031, 798));
            MountShape1.SetPoint(7, new Vector2f(4025, 893));
            SetMountain(MountShape1);
            #endregion
            

            
            #region m8
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(8);
            MountShape1.SetPoint(0, new Vector2f(4017, 894));
            MountShape1.SetPoint(1, new Vector2f(4016, 798));
            MountShape1.SetPoint(2, new Vector2f(4160, 802));
            MountShape1.SetPoint(3, new Vector2f(4312, 785));
            MountShape1.SetPoint(4, new Vector2f(4539, 786));
            MountShape1.SetPoint(5, new Vector2f(4615, 801));
            MountShape1.SetPoint(6, new Vector2f(4644, 804));
            MountShape1.SetPoint(7, new Vector2f(4635, 894));
            SetMountain(MountShape1);
            #endregion


            
            #region m9
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(14);
            MountShape1.SetPoint(0, new Vector2f(4613, 894));
            MountShape1.SetPoint(1, new Vector2f(4613, 799));
            MountShape1.SetPoint(2, new Vector2f(4841, 759));
            MountShape1.SetPoint(3, new Vector2f(4931, 684));
            MountShape1.SetPoint(4, new Vector2f(5019, 584));
            MountShape1.SetPoint(5, new Vector2f(5120, 504));
            MountShape1.SetPoint(6, new Vector2f(5297, 490));
            MountShape1.SetPoint(7, new Vector2f(5426, 507));
            MountShape1.SetPoint(8, new Vector2f(5475, 580));
            MountShape1.SetPoint(9, new Vector2f(5539, 669));
            MountShape1.SetPoint(10, new Vector2f(5605, 724));
            MountShape1.SetPoint(11, new Vector2f(5712, 807));
            MountShape1.SetPoint(12, new Vector2f(5866, 875));
            MountShape1.SetPoint(13, new Vector2f(5920, 882));
            SetMountain(MountShape1);
            #endregion
            

            #region m10
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(14);
            MountShape1.SetPoint(0, new Vector2f(5735, 877));
            MountShape1.SetPoint(1, new Vector2f(5839, 820));
            MountShape1.SetPoint(2, new Vector2f(6047, 650));
            MountShape1.SetPoint(3, new Vector2f(6343, 498));
            MountShape1.SetPoint(4, new Vector2f(6539, 420));
            MountShape1.SetPoint(5, new Vector2f(6777, 344));
            MountShape1.SetPoint(6, new Vector2f(6928, 277));
            MountShape1.SetPoint(7, new Vector2f(7344, 214));
            MountShape1.SetPoint(8, new Vector2f(7452, 20));
            MountShape1.SetPoint(9, new Vector2f(7632, 30));
            MountShape1.SetPoint(10, new Vector2f(7921, 153));
            MountShape1.SetPoint(11, new Vector2f(8016, 360));
            MountShape1.SetPoint(12, new Vector2f(8057, 704));
            MountShape1.SetPoint(13, new Vector2f(8541, 877));
            SetMountain(MountShape1);
            #endregion
            



            /*
            #region m3
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(18);

            SetMountain(MountShape1);
            #endregion
            */



            /*
            #region m3
            //mount2
            MountShape1 = new ConvexShape();
            MountShape1.SetPointCount(18);

            SetMountain(MountShape1);
            #endregion
            */

        }

        private void SetMountain(ConvexShape shape)
        {

            shape.Texture = Program.m_TextureManager.MountainTexture_01;
            shape.Texture.Smooth = true;
            shape.Position = new Vector2f(850, 0);
            MountColliders[numOfMount] = shape;
            numOfMount += 1;

        }




        public void Update()
        {
            mark_1.Update();

            for (int i = 0; i < MountColliders.Length; i++)
            {
                Program.window.Draw(MountColliders[i]);
            }
            
        }


    }
}
