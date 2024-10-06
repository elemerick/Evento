using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Evento.UseCases
{
    public static class ConfigureServices
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
