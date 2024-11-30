using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PruebaCoink.Application.UseCases.Common.Behaviors;
using System.Reflection;


namespace PruebaCoink.Application.UseCases.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
