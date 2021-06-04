using Application.Common.Interfaces.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Application.Common.Mappings
{
    public sealed class Map
    {
        public Type Source { get; set; }
        public Type Destination { get; set; }
    }

    interface IMapFrom<TEntity> { }
    interface IMapTo<TEntity> { }

    public static class MapperProfileHelper
    {
        public static IList<Map> LoadStandardMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                        !type.IsAbstract &&
                        !type.IsInterface &&
                        instance.GetGenericArguments().Any()
                    select new Map
                    {
                        Source = instance.GetGenericArguments().First(),
                        Destination = type
                    }).ToList();

            var mapsTo = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                        !type.IsAbstract &&
                        !type.IsInterface &&
                        instance.GetGenericArguments().Any()
                    select new Map
                    {
                        Source = type,
                        Destination = instance.GetGenericArguments().First()
                    }).ToList();

            List<Map> result = new List<Map>();
            result.AddRange(mapsFrom);
            result.AddRange(mapsTo);

            return result;
        }

        public static IList<IMapping> LoadCustomMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        typeof(IMapping).IsAssignableFrom(type) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select (IMapping)Activator.CreateInstance(type)).ToList();

            return mapsFrom;
        }
    }

}
