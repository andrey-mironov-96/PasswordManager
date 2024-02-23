using AutoMapper;
using System.Reflection;

namespace PasswordManager.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsForAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsForAssembly(Assembly assembly)
        {
            IEnumerable<Type> types = assembly.GetExportedTypes().Where(_ =>
                _.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                    )
            );

            foreach ( var type in types )
            {
                object instance = Activator.CreateInstance(type)!;

                var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");
                methodInfo?.Invoke(instance, [this]);
            }
        }
    }
}
