using Domain;
using Microsoft.EntityFrameworkCore;

namespace DeliveryProjectApi
{
    public static class Translate
    {
        public static string GetLanguageOrDefault(this Dictionary<string, string> keyValuePairs, string langaugeCode)
        {
            return keyValuePairs.ContainsKey(langaugeCode) ? keyValuePairs[langaugeCode] : keyValuePairs["ar"];
        }

        public static async Task<IApplicationBuilder> CreateDbFunctions<TContext>(this IApplicationBuilder builder) where TContext : DbContext
        {
            var serviceProvider = builder.ApplicationServices;
            var context = serviceProvider.GetRequiredService<TContext>();

            var sql = $"""
                            
                                            CREATE OR REPLACE FUNCTION public.getbylanguage(prop jsonb, languagecode text)
                                            RETURNS text
                                            LANGUAGE plpgsql
                                            AS $$
                                            begin
                                                if (prop ->> languageCode is not null) then
                                                    RETURN prop ->> languageCode;
                                                ELSE
                                                    RETURN prop ->> 'ar';
                                                end if;
                                            end;
                                            $$
                                            
                            """;
            await context.Database.ExecuteSqlRawAsync(sql);
            return builder;
        }

        private static IServiceProvider ServiceProvider(this IApplicationBuilder builder)
            => builder
            .ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope()
            .ServiceProvider;
    }
}

