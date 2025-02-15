using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContactos.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string sc = configuration.GetSection("ConnectionStrings")["ConexionDb"] ?? "";
            //services.AddDbContext<SCCSDbContext>(options => options.UseSqlServer(sc));

            

            return services;
        }
    }
}
