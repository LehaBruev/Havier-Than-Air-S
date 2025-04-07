using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    internal class Mission1_Learning
    {

        // Бэкграунд 
        Texture backgroundLevel1 = new Texture("BackGroundLevel1.png");
        Sprite backGroundSprite = new Sprite();


        public void Start()
        {
            backGroundSprite.Texture = backgroundLevel1;

        }

        public void UpdateMission_1()
        {

            Program.window.Draw(backGroundSprite);


            // Место старта верта

            // Описать верт

            // Этапы сценария


            // Положение объектов

            // Проверка столкновений объектов + отработка событий + результаты

            // Отрисовка объектов










        }




    }
}
