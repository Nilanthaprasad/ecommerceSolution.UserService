using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure service to the dependency injection container
        ///
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            //To do: Add services to the Ioc container
            //Insfrastructure services often include data access, caching and other low level components.
            services.AddTransient<IUsersService, UserServices>();

            //No need to add this again for the other validators since this will register all the other
            //validators automatically once inserted for a one validator
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            return services;
        }
    }
}
