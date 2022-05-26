using System.Reflection;

namespace ExadelTasks.Task1.FileReader
{
    public class FileMetadata
    {
        private readonly string _filePath;

        public Assembly Assembly { get; set; }

        public Type[] Types { get; set; }

        public static MethodInfo[] GetTypeMethods(Type type)
        {
            return type.GetMethods();
        }

        public static PropertyInfo[] GetTypeProperties(Type type)
        {
            return type.GetProperties();
        }

        public static FieldInfo[] GetTypeFields(Type type)
        {
            return type.GetFields();
        }

        public static string GetRandomInfo() => "Random Info ...";

        public FileMetadata(string filePath)
        {
            _filePath = filePath;

            Assembly = Assembly.LoadFrom(filePath);
            Types = Assembly.GetTypes();
        }
    }
}
