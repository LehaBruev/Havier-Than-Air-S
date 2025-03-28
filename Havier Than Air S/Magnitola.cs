using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;

namespace Havier_Than_Air_S
{





    public class Magnitola
    {
        public Magnitola() 
        {

            static string Music3Level = LoadMusic("airvolfbig.wav"); // Музыка аирвольв
            static string Level1Music = LoadMusic("Level1Music.wav"); //Левел 1 музыка
            static string StoreMusic = LoadMusic("topgun3.wav"); //Магазинчик
            static string mainmenumusic = LoadMusic("mainmenumusic.wav"); //Вертолет рабочий режим звука
            static string finalmusic = LoadMusic("finalmusic.wav"); //Вертолет рабочий режим звука
            static string musicotkazsistem = LoadMusic("musicotkazsistem.wav"); //Музыка для напряженной обстановке


            static string playingmusic;// Текущая песня
            static string playlistmusic;// Текущая песня


        }



    }
}
