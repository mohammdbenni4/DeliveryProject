using Elkood.Domain.Primitives;

namespace Domain.ShareMethods
{
    public static class Middelware
    {
        public static string GetByLanguage(this LanguageProperty prop,string languageCode)
            =>prop.TryGetValue(languageCode, out string value)?value:prop.Get(ConestValues.DefaultLanguage);    
    }
}
