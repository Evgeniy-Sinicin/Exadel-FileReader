using ExadelTasks.Task1.FileReader.Enums;
using System.Reflection;

namespace ExadelTasks.Task1.FileReader.Extensions
{
    public static class MethodInfoExtension
    {
        public static AccessModifier GetAccessModifier(this MethodInfo methodInfo)
        {
            if (methodInfo.IsPublic)
            {
                return AccessModifier.Public;
            }
            else if (methodInfo.IsAssembly)
            {
                return AccessModifier.Internal;
            }
            else if (methodInfo.IsFamilyOrAssembly)
            {
                return AccessModifier.ProtectedInternal;
            }
            else if (methodInfo.IsFamily)
            {
                return AccessModifier.Protected;
            }
            else if (methodInfo.IsFamilyAndAssembly)
            {
                return AccessModifier.PrivateProtected;
            }
            else if (methodInfo.IsPrivate)
            {
                return AccessModifier.Private;
            }
            else
            {
                return AccessModifier.Unknown;
            }
        }

        public static string GetInfo(this MethodInfo methodInfo)
        {
            var staticModifier = methodInfo.IsStatic ? "Static" : "Non-static";

            return $"Method: {methodInfo.GetAccessModifier()} {staticModifier} {methodInfo}";
        }

        public static bool IsExecutable(this MethodInfo methodInfo)
        {
            return methodInfo.IsStatic && methodInfo.GetParameters().Length == 0;
        }
    }
}
