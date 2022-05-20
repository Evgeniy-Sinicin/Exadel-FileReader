using System.Reflection;

namespace ExadelTasks.Task1.FileReader
{
    public class FileMetadata
    {
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

        public static MemberInfo[] GetTypeMembers(Type type)
        {
            return type.GetMembers();
        }

        public FileMetadata(string filePath)
        {
            Assembly = Assembly.LoadFrom(filePath);
            Types = Assembly.GetTypes();
        }
    }
}
