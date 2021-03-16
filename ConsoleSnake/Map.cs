using System;
using System.IO;

namespace ConsoleSnake
{
    // Store a map and its parameters
    class Map
    {
        private string mapData;
        private int width;
        private int height;

        public int Width { get => width; }
        public int Height { get => height; }
        
        public Map()
        {
            ReadFromFile("mapBase");
        }

        // Read maps data from the given file
        public void ReadFromFile(string fileName)
        {
            string path = @"Maps/" + fileName + ".txt";
            int lines = 0;

            using(StreamReader streamReader = new StreamReader(path))
            {
                //mapData = streamReader.ReadToEnd();

                string line = streamReader.ReadLine() + "\n";
                width = line.Length;
                mapData += line;

                while(!streamReader.EndOfStream)
                {
                    mapData += streamReader.ReadLine() + "\n";
                    lines++;
                }

                height = lines;
            }
        }

        public void Print()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(mapData);
        }
    }
}
