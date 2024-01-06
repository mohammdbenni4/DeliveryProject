using Domain.Interfaces;
using Domain.Models;
using Elkood.Domain.Primitives.Entity.Interface;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
using ProtoBuf.Meta;
using Elkood.Domain.Primitives;

namespace DeliveryProjectApi.Util
{
    public class ElProtoBuf
    {
        public static void Initial()
        {
           /* var assembly = Assembly.Load("Domain");
            foreach (var cacheType in assembly.GetTypes().Where(c => c.IsClass && c.GetInterface(nameof(ICacheEntity)) != null))
            {
                if (cacheType.BaseType?.BaseType == typeof(AggregateRoot) && cacheType.BaseType.GetGenericArguments().FirstOrDefault() is { } translateEntityType)
                {
                    RuntimeTypeModel.Default.Add(translateEntityType, false)
                        .Add(translateEntityType.GetProperties().Where(p => p.PropertyType.GenericTypeArguments.All(w => w.GetInterface(nameof(IBaseEntity)) == null) &&
                                                                            p.PropertyType.GetInterface(nameof(IBaseEntity)) == null).Select(p => p.Name).ToArray());
                }

                RuntimeTypeModel.Default.Add(cacheType, false)
              .Add(cacheType.GetProperties()
                  .Where(s => s.PropertyType.GenericTypeArguments.All(w => w.GetInterface(nameof(IBaseEntity)) == null) &&
                              s.PropertyType.GetInterface(nameof(IBaseEntity)) == null && s.Name != nameof(AggregateRoot.DomainEvents))
                  .Select(p => p.Name).ToArray());
                var x = cacheType.GetProperties().ToList();
                foreach (var vo in cacheType.GetProperties()
                             .Where(p => p.PropertyType.BaseType == typeof(ValueObject))
                             .Select(p => p.PropertyType))
                {
                    RuntimeTypeModel.Default.Add(vo, false).Add(vo.GetProperties().Select(x => x.Name).ToArray());
                }


            }*/
            //RuntimeTypeModel.Default.Add(typeof(TimeOnly), false).SetSurrogate(typeof(TimeOnlySurrogate));
           // RuntimeTypeModel.Default.Add(typeof(DateOnly), false).SetSurrogate(typeof(DateOnlySurrogate));
           // RuntimeTypeModel.Default.Add(typeof(DateTimeOffset), false).SetSurrogate(typeof(DateTimeOffsetSurrogate));
        }
    }
}
