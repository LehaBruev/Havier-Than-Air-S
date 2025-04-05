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

        Music _Music = new Music("airvolfbig.wav");

        static string Music3Level = ("airvolfbig.wav"); // Музыка аирвольв
        static string Level1Music = ("Level1Music.wav"); //Левел 1 музыка
        static string StoreMusic = ("topgun3.wav"); //Магазинчик
        static string mainmenumusic = ("mainmenumusic.wav"); //Вертолет рабочий режим звука
        static string finalmusic = ("finalmusic.wav"); //Вертолет рабочий режим звука
        static string musicotkazsistem = ("musicotkazsistem.wav"); //Музыка для напряженной обстановке

        public Magnitola() 
        {
            _Music.Pitch=0.8F;
            _Music.Volume = 50;
            _Music.Position = new SFML.System.Vector3f(50, 50, 50);    
            _Music.Play();


            /*
            static string Music3Level = LoadMusic("airvolfbig.wav"); // Музыка аирвольв
            static string Level1Music = LoadMusic("Level1Music.wav"); //Левел 1 музыка
            static string StoreMusic = LoadMusic("topgun3.wav"); //Магазинчик
            static string mainmenumusic = LoadMusic("mainmenumusic.wav"); //Вертолет рабочий режим звука
            static string finalmusic = LoadMusic("finalmusic.wav"); //Вертолет рабочий режим звука
            static string musicotkazsistem = LoadMusic("musicotkazsistem.wav"); //Музыка для напряженной обстановке


            static string playingmusic;// Текущая песня
            static string playlistmusic;// Текущая песня

            */
        }

        /*
        static void magnitola()
        {



            if (mainmenuSwitch != 0 || resultsmenuswitch != 0) //меню
            {
                playlistmusic = mainmenumusic;

            }

            if (levelchoise == 1 && mainmenuSwitch == 0 && resultsmenuswitch == 0) // музыка левел1
            {

                if (winpobeda == 1) playlistmusic = finalmusic;
                else
                {
                    playlistmusic = Level1Music;
                    if (padstoreswitch == 1) playlistmusic = StoreMusic;
                }


            }
            if (levelchoise == 3 && mainmenuSwitch == 0 && resultsmenuswitch == 0) // музыка левел3
            {


                if (winpobeda == 1) playlistmusic = finalmusic;
                else
                {
                    if (padstoreswitch == 1) playlistmusic = StoreMusic;
                    else playlistmusic = Music3Level;


                }

            }
            //Напряженная обстановка
            if ((otkazhydrosis == 1 && otkazols == 1) || (otkazhydrosis == 1 && helienginelife < 75) || helienginelife < 65 || helilife <= 0 || otkazpojardvig == 1)
            {
                playlistmusic = musicotkazsistem;
            }



            if (playingmusic != playlistmusic) // смена музыки
            {
                if (playingmusic != "")
                {
                    StopMusic(playingmusic);
                    Delay(20);
                    PlayMusic(playlistmusic, volume + 20);
                    Delay(20);
                    playingmusic = playlistmusic;
                }
                if (playingmusic == "")
                {
                    PlayMusic(mainmenumusic, volume + 20);
                    playingmusic = mainmenumusic;

                }

            }


        }


        */


    }
}
