using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S
{
    public class TextureManager
    {

        //Фон
        Texture backgroundLevel1;
        Texture backgroundLevel3;

        //Техника
        Texture uh61;
        Texture aiming;

        //Меню
        Texture maimenutexture;
        Texture scoresprite;
        

        public TextureManager()
        {

             backgroundLevel1 = new Texture("BackGroundLevel1.png");
             backgroundLevel3 = new Texture("BackGroundLevel3.png"); 

            //Техника
             uh61 = new Texture("uh61all.png");
             aiming = new Texture("aim.png");

            //Меню
             maimenutexture = new Texture("mainmenu.png");
             scoresprite = new Texture("score1back.png");

        }

        /*
        //ТЕКСТУРЫ
        static string backgroundLevel3 = LoadTexture("BackGroundLevel3.png");
        //static string backgroundLevel2 = LoadTexture("BackGroundLevel2.png");
        static string backgroundLevel1 = LoadTexture("BackGroundLevel1.png");
        static string uh61 = LoadTexture("uh61all.png");
        static string aiming = LoadTexture("aim.png");
        static string maimenutexture = LoadTexture("mainmenu.png");
        static string scoresprite = LoadTexture("score1back.png");


        */




    }
}
