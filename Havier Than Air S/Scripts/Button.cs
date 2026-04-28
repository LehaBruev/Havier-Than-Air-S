using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Linq;

namespace Havier_Than_Air_S.Scripts
{
    internal class Button
    {

        Texture buttontexture;

        public RectangleShape shape;
        public Text butoonText;
        Color currentColor;
        Color normColor = new Color(Color.White);
        Color checkColor = new Color(Color.Green);
        float minTimeTochange = 0.3f;

        public bool buttonIsPressed = false;

        public Clock clock = new Clock();

        //sound
        SoundBuffer bufer = new SoundBuffer("Sounds\\buttonclick.wav");
        Sound sound = new Sound();

        public Button()
        {
            shape = new RectangleShape();
            butoonText = new Text("Аааа",Program.font, 16); //Шрифт, текст, размер
            clock.Restart();

            sound.SoundBuffer = bufer;
        }


        public void SetButtonParameters(Vector2f pos, Vector2f size, Color color)
        {
            shape.Position = pos;
            shape.Size = size;
            shape.FillColor = color;
            //currentColor = color;
        }

        public void SetButtonTextParam(string tekst, uint size, Vector2f pos, Color color)
        {
            butoonText = new Text(tekst, Program.font, size);
            butoonText.Position = pos + shape.Position;
            butoonText.FillColor = color;
            butoonText.OutlineColor = Color.Yellow;

        }

        public void SetButtonText(string tekst)
        {
            butoonText.DisplayedString = tekst;

        }

        public void SetButtonShape(RectangleShape reckShape)
        {
            shape = new RectangleShape(reckShape);
        }


        public void Update()
        {
            Vector2i pixelPos = Mouse.GetPosition(Program.window);

            if (shape.GetGlobalBounds().Contains(pixelPos.X, pixelPos.Y))
            {
                butoonText.FillColor = checkColor;
                sound.Play();
            }
            else
            {
                butoonText.FillColor = normColor;
            }


            Program.window.Draw(shape);
            Program.window.Draw(butoonText);


        }








    }
}
