using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application.Common.Mappings;

namespace PasswordManager.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        MappingProfile mappingProfile = new MappingProfile();
        services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
    }

    


}
