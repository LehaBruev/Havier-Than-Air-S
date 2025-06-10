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
        string path = "E:\\c_sharp projects\\log.txt";

        public LogWriter() 
        {
            
        }

        public async void WriteXY(string t)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                await writer.WriteLineAsync(t);
            }

        }

          



    }
}
