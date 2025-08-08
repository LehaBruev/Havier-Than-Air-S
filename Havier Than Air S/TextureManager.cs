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
        public Texture backgroundLevel1;
        Texture backgroundLevel3;

        //Техника
        Texture uh61;
        Texture aiming;

       

       

        private GameMode _gameMode;

        public bool ChangeBackground = true;


        public TextureManager()
        {
            _gameMode = GameMode.MainMenu;
             backgroundLevel1 = new Texture("Images\\BackGroundLevel1.png");
             backgroundLevel3 = new Texture("Images\\BackGroundLevel3.png");

           // BackgroundSprite = new Sprite();

            //Техника
             uh61 = new Texture("Images\\uh61all.png");
             aiming = new Texture("Images\\aim.png");

            //Меню
            // mainmenutexture = new Texture("Images\\mainmenu.png");
            // scoresprite = new Texture("Images\\score1back.png");

        }


        public void DrawBackground()
        {
            ChangeBackgroundSprite();
           // Program.window.Draw(BackgroundSprite);


        }

        private void ChangeBackgroundSprite()
        {
            if(_gameMode == GameMode.MainMenu && ChangeBackground == true)
            {
                
                ChangeBackground = false;
            }

        }



        public void DrawObjectSprite(GameObject gameObject)
        {



        }


        /*
        //ТЕКСТУРЫ
        static string backgroundLevel3 = LoadTexture("Images\\BackGroundLevel3.png");
        //static string backgroundLevel2 = LoadTexture("Images\\BackGroundLevel2.png");
        static string backgroundLevel1 = LoadTexture("Images\\BackGroundLevel1.png");
        static string uh61 = LoadTexture("Images\\uh61all.png");
        static string aiming = LoadTexture("Images\\aim.png");
        static string maimenutexture = LoadTexture("Images\\mainmenu.png");
        static string scoresprite = LoadTexture("Images\\score1back.png");


        */




    }
}
