using System.Reflection;
using Elkood.Application.Helper.ExtensionMethods.Object;

namespace Domain;

public class Permissions
{
    public static Dictionary<string, IEnumerable<string>> GetAll()
    {
        var name = "Name";
        var flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
        var nestedTypes = typeof(Permissions).GetNestedTypes(BindingFlags.Public);
        return nestedTypes.OrderBy(t => t.Name).ToDictionary(t => t.GetField(name)!.GetValue(null).CastTo<string>(),
            t => t.GetFields(flags).Where(f => f.Name != name).OrderBy(f => f.Name)
                .Select(x => x.GetValue(null).CastTo<string>()));
    }

    public static IEnumerable<string> IsValid(IEnumerable<string> permissions)
    {
        var allPermission = GetAll().SelectMany(p => p.Value).ToList();
        foreach (var permission in permissions)
        {
            if (!allPermission.Contains(permission))
            {
                yield return permission;
            }
        }
    }

    public class Shops
    {
        public const string Name = nameof(Shops);
        public const string Add = $"{Name}.{nameof(Add)}";
    }
    public class Cities
    {
        public const string Name = nameof(Cities);
        public const string Add = $"{Name}.{nameof(Add)}";
        public const string Get = $"{Name}.{nameof(Get)}";
    }
    public class ShopCategories
    {
        public const string Name = nameof(ShopCategories);
        public const string Add = $"{Name}.{nameof(Add)}";
        public const string Get = $"{Name}.{nameof(Get)}";
    }
}