using ExadelTasks.Task1.FileReader.Enums;
using System.Reflection;

namespace ExadelTasks.Task1.FileReader.Extensions
{
    public static class FieldInfoExtension
    {
        public static AccessModifier GetAccessModifier(this FieldInfo fieldInfo)
        {
            if (fieldInfo.IsPublic)
            {
                return AccessModifier.Public;
            }
            else if (fieldInfo.IsAssembly)
            {
                return AccessModifier.Internal;
            }
            else if (fieldInfo.IsFamilyOrAssembly)
            {
                return AccessModifier.ProtectedInternal;
            }
            else if (fieldInfo.IsFamily)
            {
                return AccessModifier.Protected;
            }
            else if (fieldInfo.IsFamilyAndAssembly)
            {
                return AccessModifier.PrivateProtected;
            }
            else if (fieldInfo.IsPrivate)
            {
                return AccessModifier.Private;
            }
            else
            {
                return AccessModifier.Unknown;
            }
        }

        public static string GetInfo(this FieldInfo fieldInfo)
        {
            var staticModifier = fieldInfo.IsStatic ? "Static" : "Non-static";

            return $"Field: {fieldInfo.GetAccessModifier()} {staticModifier} {fieldInfo}";
        }
    }
}
