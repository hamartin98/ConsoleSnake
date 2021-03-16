using System.IO;

namespace ConsoleSnake
{
    class FileIO
    {
        public static string readToString(string path)
        {
            string result;
            using(StreamReader streamReader = new StreamReader(path))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
    }
}
