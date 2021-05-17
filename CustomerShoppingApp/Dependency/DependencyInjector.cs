using System;
using CustomerShoppingApp.DAL;
using CustomerShoppingApp.Data;
using CustomerShoppingApp.DataContext;
using CustomerShoppingApp.Token;
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
            services.AddTransient<ICustomerData, CustomerData>();
            services.AddTransient<IDataBaseChanges, DataBaseChanges>();
            services.AddTransient<IUserTokenGenerator, UserTokenGenerator>();
            return services;
        }
    }
}
