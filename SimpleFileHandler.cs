using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

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

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ProjectToLocation(Assembly CallingAssembly, string FileName)
        {
            try
            {
                Console.WriteLine(CallingAssembly.EntryPoint.DeclaringType.Namespace);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            try
            {
                Console.WriteLine(Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            try
            {
                Console.WriteLine(Assembly.GetEntryAssembly().EntryPoint.DeclaringType.Namespace);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            try
            {
                if (!Path.GetDirectoryName(FileName).Equals(string.Empty) && !Directory.Exists(Path.GetDirectoryName(FileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(FileName));
                }
                FileStream ProjectFileStream = File.Create(FileName);
                Assembly.GetExecutingAssembly().GetManifestResourceStream(CallingAssembly.EntryPoint.DeclaringType.Namespace + "." + Path.GetFileName(FileName)).CopyTo(ProjectFileStream);
                ProjectFileStream.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Cannot copy project file. Please make sure the file's build action is set to 'Embedded Resource'.");
                Console.WriteLine(exception.Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ProjectToLocation(Assembly CallingAssembly, string FileName, string FilePath)
        {
            try
            {
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                FileStream ProjectFileStream = File.Create(Path.Combine(FilePath, Path.GetFileName(FileName)));
                Assembly.GetExecutingAssembly().GetManifestResourceStream(CallingAssembly.EntryPoint.DeclaringType.Namespace + "." + Path.GetFileName(FileName)).CopyTo(ProjectFileStream);
                ProjectFileStream.Close();
            }
            catch
            {
                Console.WriteLine("Cannot copy project file. Please make sure the file's build action is set to 'Embedded Resource'.");
            }
        }
    }
}
