using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hex_Viewer
{
    class hexReadWrite
    {
        string inputFile;

        public string[] Read(string input)
        {
            Queue<string> fileContents = new Queue<string>();

            if (!String.IsNullOrEmpty(input)) inputFile = input;
            using (StreamReader reader = new StreamReader(inputFile))
            {
                int position = 0;
                while (!reader.EndOfStream)
                {
                    char[] buffer = new char[16];
                    int charactersRead = reader.ReadBlock(buffer, 0, 16);
                    position += charactersRead;
                    string hex = null;

                    for (int i = 0; i < 16; i++)
                    {
                        if (i < charactersRead)
                        {
                            hex += String.Format("{0:x2}", (byte)buffer[i]);
                            hex += " ";
                        }
                        else hex += "    ";

                        if (i == 7) hex += "-- ";
                        if (buffer[i] < 32 || buffer[i] > 250) buffer[i] = '*';
                    }
                    string bufferContents = new string(buffer);
                    hex += "   " + bufferContents.Substring(0, charactersRead);
                    fileContents.Enqueue(hex + "\r\n");
                }
                return fileContents.ToArray();
            }
        }


    }
}
