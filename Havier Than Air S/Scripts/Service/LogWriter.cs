using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havier_Than_Air_S
{
    public class LogWriter
    {
        //string path = "E:\\c_sharp projects\\log.txt";
        //string path = "C:\\Users\\user\\Desktop\\С-Шарп проекты\\log.txt";
        string path = "C:\\Users\\bruev_at\\Desktop\\log\\";

        string currentGameLogFile;


        public LogWriter() 
        {
            currentGameLogFile = "Game" + Program.random.Next(1,12000);
            File.Create(path + currentGameLogFile + ".txt").Close();
        }


        public async void WriteXY(string t)
        {
            
            using (StreamWriter writer = new StreamWriter(path+ "log.txt", true))
            {
                await writer.WriteLineAsync(t);
            }
            
        }

        public async void WriteHistory(string t)
        {

            using (StreamWriter writer = new StreamWriter(path + currentGameLogFile + ".txt", true))
            {
                await writer.WriteLineAsync(t);
            }

        }


        public void SaveCurrentGameLogFile(string textic)
        {

            File.WriteAllText(path + currentGameLogFile + ".txt", textic); // перезапись
            File.AppendAllText(path + currentGameLogFile + ".txt", Environment.NewLine + "EndLog" ); // добавление
            
            
        }


    }
}
