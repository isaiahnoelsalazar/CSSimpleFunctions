using System.IO;

namespace CSSimpleFunctions
{
    public class SimpleFileHandler
    {
        public static void Write(string FilePath, string Content)
        {
            File.WriteAllText(FilePath, Content);
        }

        public static string Read(string FilePath)
        {
            return File.ReadAllText(FilePath);
        }

        public static void Append(string FilePath, string Content)
        {
            File.AppendAllText(FilePath, Content);
        }
    }
}
