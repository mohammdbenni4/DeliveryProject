namespace Domain;

public class Permissions
{
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