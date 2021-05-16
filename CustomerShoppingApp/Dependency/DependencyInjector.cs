using System;
using CustomerShoppingApp.DataContext;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerShoppingApp.Dependency
{
    public static class DependencyInjector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureShoppingCartServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerShoppingCart, CustomerShoppingCart>();
            return services;
        }
    }
}
