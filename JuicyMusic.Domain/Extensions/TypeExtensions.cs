using System.Reflection;

namespace JuicyMusic.Domain.Extensions;

public static class TypeExtension
{
    public static T GetStaticField<T>(this Type type, string fieldName)
    {
        var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Static);

        if (field == null)
            throw new ArgumentException($"Field '{fieldName}' not found on type {type.Name}.");

        return (T?)field.GetValue(null)
                ?? throw new Exception($"Field '{fieldName}' is null where a non-null value was expected."); ;
    }
}
