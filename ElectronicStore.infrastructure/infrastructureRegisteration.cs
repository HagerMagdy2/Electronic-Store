using ElectronicStore.Core.Interfaces;
using ElectronicStore.infrastructure.Repositries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.infrastructure
{
    public static class infrastructureRegisteration
    {
        public static IServiceCollection InfrastructureConfigration(this IServiceCollection services)
        {
            //services.AddTransient
            //services.AddSingleton
            //services.AddScoped
            services.AddScoped(typeof(IGenericRepositry<>), typeof(GenericRepositry<>));
            services.AddScoped<ICategoryRepositry, CategoryRepositry>();
            services.AddScoped<IProductRepositry, ProductRepositry>();
            services.AddScoped<IPhotoRepositry, PhotoRepositry>();

            return services;
        }
    }
}
