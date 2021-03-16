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
        
        public Map()
        {
            ReadFromFile("mapBase");
        }

        // Read maps data from the given file
        public void ReadFromFile(string fileName)
        {
            string path = @"Maps/" + fileName + ".txt";
            
            using(StreamReader streamReader = new StreamReader(path))
            {
                mapData = streamReader.ReadToEnd();
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
