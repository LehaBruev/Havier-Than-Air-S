using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace Havier_Than_Air_S.Weapon
{
    public class Bang: IMoovable
    {
        CircleShape circleshape;

        //string bangsound = LoadSound("explode4.wav"); //взрыв
        public TypeOfObject typeOfObject;

        private Texture[] bangTextures;
        private Image uhImage = new Image("uh61all.png");
        Sprite bangSprite;

        public PullStatus pullStatus;
        private Vector2f pullPosition;

        Clock clock = new Clock();
        float frameTimer = 0.01f;
        int currentFrame = 0;
        bool activated = false;

        public Vector2f position;
        int y = 663;
        int x = 915;
        Vector2f origin = new Vector2f(57, 55);

        SoundBuffer soundBuffer;
        Sound sound;

        public Bang(Vector2f pPosition)
        {
            soundBuffer = new SoundBuffer("explode4.wav");
            sound = new Sound(soundBuffer);
            
            

            typeOfObject = TypeOfObject.bang;

            pullPosition = pPosition;
            pullStatus = PullStatus.inPool;

            bangTextures = new Texture[40];
            bangSprite = new Sprite();
            bangSprite.Origin = origin;
            bangSprite.Scale = new Vector2f(0.5f, 0.5f);
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

        public void Start(Vector2f pos, float angle, Vector2f speed)
        {
            if (!activated)
            {
                bangSprite.Position = pos;
                activated = true;
                pullStatus = PullStatus.inAir;
                clock.Restart();
                sound.Play();
            }
        }

        public void Update()
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

        public TypeOfObject GetTypeOfObject()
        {

            return typeOfObject;
        }
        public PullStatus GetCurrentPullStatus()
        {

            return pullStatus;
        }

        public Shape GetShape()
        {
           return circleshape;
        }

        public Vector2f GetPosition()
        {
            return position;
        }

        public void SetDamage(IMoovable obj)
        {
            throw new NotImplementedException();
        }

        public bool GetColliderStatus()
        {
            throw new NotImplementedException();
        }
    }
}
