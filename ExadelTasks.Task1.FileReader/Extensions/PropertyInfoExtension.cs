using System.Reflection;

namespace ExadelTasks.Task1.FileReader.Extensions
{
    public static class PropertyInfoExtension
    {
        public static string GetInfo(this PropertyInfo propertyInfo)
        {
            var getterStaticModifier = propertyInfo.GetMethod != null && propertyInfo.GetMethod.IsStatic ? "Static" : "Non-static";
            var setterStaticModifier = propertyInfo.SetMethod != null && propertyInfo.SetMethod.IsStatic ? "Static" : "Non-static";
            
            return $"Property: {propertyInfo.GetMethod?.GetAccessModifier()} {getterStaticModifier} getter & {propertyInfo.SetMethod?.GetAccessModifier()} {setterStaticModifier} setter {propertyInfo}";
        }
    }
}
