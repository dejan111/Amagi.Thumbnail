using Amagi.Thumbnail.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amagi.Thumbnail.BusinessLayer;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AmagiContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")))
            .AddScoped<AmagiContext>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IThumbnailService, ThumbnailService>();
        return services;
    }
}
