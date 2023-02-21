using global::System.Reflection;

namespace MiniORM;

internal static class ReflectionHelper
{
    /// <summary>
    /// Replaces an auto-generated backing field with an object instance.
    /// Commonly used to set properties without a setter.
    /// </summary>
    public static void ReplaceBackingField(object sourceObj, string propertyName, object newValue)
    {
        var backingField = global::System.Linq.Enumerable
            .First(fi => fi.Name == $"<{propertyName}>k__BackingField");

        backingField.SetValue(sourceObj, newValue);
    }

    /// <summary>
    /// Extension method for MemberInfo, which checks if a member contains an attribute.
    /// </summary>
    public static bool HasAttribute<T>(this global::System.Reflection.MemberInfo mi)
        where T : global::System.Attribute
    {
        var hasAttribute = global::System.Reflection.CustomAttributeExtensions.GetCustomAttribute<T>() != null;
        return hasAttribute;
    }
}