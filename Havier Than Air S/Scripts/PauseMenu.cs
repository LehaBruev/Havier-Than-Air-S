using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Scripts
{
    internal class PauseMenu
    {

        private Texture scoreTexture = new Texture("Images\\score1back.png");
        private Sprite scoreSprite;
        Button[] buttons;

        public PauseMenu()
        {
            scoreSprite = new Sprite(scoreTexture);
            SetButtons();
        }

        private void SetButtons()
        {
            buttons = new Button[2];
        }


        public void Update()
        {
            //background
            Program.window.Draw(scoreSprite);

            //buttons
            for (int i = 0; i<buttons.Length; i++)
            {
                buttons[i].Update();

            }
        }

    }
}
