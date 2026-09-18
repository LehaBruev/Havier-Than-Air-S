using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S.Scripts.Menu
{
    internal class Button
    {

        //ОСНОВНЫЕ ПАРАМЕТРЫ КНОПКИ
        public Shape ButtonShape;
        public Texture ButtonTexture;
        public Text ButtonText;

        //ОПЦИИ КНОПКИ
        public bool ButtonIsPressed = false;
        public bool ButtonIsActivated = false;

        public Clock clock = new Clock();
        public int CodeOfButton = 0;

        //ДЕЛЕГАТЫ
        public delegate void Podpiska(int code);
        public event Podpiska PRESS;

        //ЦВЕТА
        public Color ButtonColor;
        public Color ButtonColor2;
        public Color TextColor = new Color(Color.Green);
        public Color TextColor2 = new Color(Color.Red);


        public Button(Shape buttonShape,  string buttonText, Vector2f buttonPos, Vector2f textLocalPos, int codeOfButton)
        {
           // clock.Restart();
            ButtonShape = buttonShape;
            ButtonShape.Position = buttonPos;
            ButtonShape.FillColor = new Color(255,255,255,0);

            ButtonText = new Text(buttonText,Program.font);
            ButtonText.Position = buttonPos + textLocalPos;
            ButtonText.Scale = new Vector2f(0.75f, 0.75f);
            ButtonText.FillColor = TextColor;

            CodeOfButton = codeOfButton;
        }
        public void SetButtonTexture(Texture buttonTexture)
        {
            ButtonTexture = buttonTexture;
        }

        public void SetButtonColors(Color buttonColor, Color buttonColor2, Color textColor, Color textColor2, int buttonCode)
        {
            ButtonColor = buttonColor;
            ButtonColor2 = buttonColor2;
            ButtonShape.FillColor = buttonColor;
            TextColor = textColor;
            TextColor2 = textColor2;
            ButtonText.FillColor = TextColor;
            CodeOfButton = buttonCode;
        }

        public void Update()
        {
            if (ButtonShape.GetGlobalBounds().Contains(Program.m_MouseController.x, Program.m_MouseController.y))
            {
                if (ButtonIsActivated == false)
                {
                    ButtonIsActivated = true;
                    if (ButtonColor2 != null)
                    {
                        ButtonShape.FillColor = ButtonColor2;
                    }

                    if (TextColor2 != null)
                    {
                        ButtonText.FillColor = TextColor2;
                    }
                    
                        PRESS?.Invoke(108);
                    
                }
                if (Program.m_MouseController.LeftButtonIsPressed == true && Program.m_MouseController.IsButtonClicked == false)
                {
                    PRESS?.Invoke(CodeOfButton);
                }

            }
            else
            {
                if (ButtonIsActivated == true)
                {
                    ButtonIsActivated = false;
                    
                        if (ButtonColor != null)
                        {
                            ButtonShape.FillColor = ButtonColor;
                        }

                        if (TextColor != null)
                        {
                            ButtonText.FillColor = TextColor;
                        }

                }
            }
            Program.window.Draw(ButtonShape);
            Program.window.Draw(ButtonText);


        }


    }
}
