using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S.Weapon
{
    public class Bang
    {
        //string bangsound = LoadSound("explode4.wav"); //взрыв

        private Texture[] bangTextures;
        private Image uhImage = new Image("uh61all.png");
        Sprite bangSprite;

        public PullStatus pullStatus;
        private Vector2f pullPosition;

        Clock clock = new Clock();
        float frameTimer = 0.001f;
        int currentFrame = 0;
        bool activated = false;

        int y = 663;
        int x = 915;
        Vector2f origin = new Vector2f(57, 55);

        public Bang(Vector2f pPosition)
        {
            pullPosition = pPosition;
            pullStatus = PullStatus.inPool;

            bangTextures = new Texture[40];
            bangSprite = new Sprite();
            bangSprite.Origin = origin;
            bangSprite.Scale = new Vector2f(0.1f, 0.1f);
            //uhImage.CreateMaskFromColor(new Color(210,197,195));
            //uhImage.CreateMaskFromColor(new Color(203,187,184));
            

            int n = 0;
            for (int i = 0; i <5;i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bangTextures[n] = new Texture(uhImage, new IntRect(703 + j* x/8, 15 + i* y/6, 113, 110));
                    n += 1;
                }
            }


        }

        public void StartBang(Vector2f pos)
        {
            if (!activated)
            {
                bangSprite.Position = pos;
                activated = true;
                pullStatus = PullStatus.inAir;
                clock.Restart();
            }
        }

        public void UpdateBang()
        {
            if (activated == true)
            {
                if (clock.ElapsedTime.AsSeconds() > frameTimer || currentFrame == 0)
                {
                    currentFrame += 1;
                    bangSprite.Texture = bangTextures[currentFrame];
                    bangSprite.Rotation = new Random().Next(-5, 5);
                    //bangSprite.Texture.Srgb
                    
                    clock.Restart();

                }

                Program.window.Draw(bangSprite);

                if (currentFrame == 39)
                {
                    activated = false;
                    currentFrame = 0;
                    bangSprite.Position = pullPosition;
                    pullStatus = PullStatus.inPool;
                }

            }
        }




    }
}
