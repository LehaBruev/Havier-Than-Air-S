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
        static string Music3Level = ("airvolfbig.wav"); // Музыка аирвольв
        static string Level1Music = ("Level1Music.wav"); //Левел 1 музыка
        static string StoreMusic = ("topgun3.wav"); //Магазинчик
        static string mainmenumusic = ("mainmenumusic.wav"); //Вертолет рабочий режим звука
        static string finalmusic = ("finalmusic.wav"); //Вертолет рабочий режим звука

        //Муз дорожки
        private Music _Music;
        Music musicotkazsistem = new Music("musicotkazsistem.wav");

        public void PlayMusic()
        {
            if (Program.Game.missionSwitch == MissionSwitch.mis1)
            {
                _Music.Stop();
                _Music = new Music(Level1Music);
                _Music.Pitch = 1.0f;
                _Music.Volume = 60;
                _Music.Play();
            }

        }

        public Magnitola() 
        {
            _Music = new Music(mainmenumusic);
            _Music.Loop = true;
            _Music.Pitch = 1.0f;
            _Music.Volume = 75;
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
