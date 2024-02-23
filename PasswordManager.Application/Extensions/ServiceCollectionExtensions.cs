using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application.Common.Mappings;
using System.Reflection;

namespace PasswordManager.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper();
        services.AddMediatR();
        services.AddValidator();
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
    }

    private static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }

    private static void AddValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }


}
