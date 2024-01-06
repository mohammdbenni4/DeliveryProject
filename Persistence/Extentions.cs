using Domain.ShareMethods;
using Microsoft.EntityFrameworkCore;


namespace Persistence
{
    public static class Extentions
    {
        public static void ConfigureElDbFunctions(this ModelBuilder builder)
        {
            var getByLanguageDbFunc = builder
                .HasDbFunction(typeof(Middelware).GetMethod(nameof(Middelware.GetByLanguage))!)
                .HasName(nameof(Middelware.GetByLanguage).ToLower())
                .IsBuiltIn(false);

            getByLanguageDbFunc.HasParameter("prop").HasStoreType("jsonb");
            getByLanguageDbFunc.HasParameter("languageCode").HasStoreType("text");
        }
    }
}
