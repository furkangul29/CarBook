using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Services
{
    //Bu sınıfı program.cs dosyasında handlerları tek tek eklememek için oluşturduk.
    // Microsoft.Extensions.DependencyInjection paketini kurup program.cs dosyasında AddApplicationServices metodunu çağırarak handlerları tek bir yerden ekleyebiliriz.
    public static class ServiceRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(config=>config.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        }
    }
}
