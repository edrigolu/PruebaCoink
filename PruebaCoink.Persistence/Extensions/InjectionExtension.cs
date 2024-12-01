using Microsoft.Extensions.DependencyInjection;
using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Persistence.Context;
using PruebaCoink.Persistence.Repositories;

namespace PruebaCoink.Persistence.Extensions
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
