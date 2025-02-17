using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiContactos.Application.Features.Interface.Client;
using ApiContactos.Infrastructure.Queries.Client;

namespace ApiContactos.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string sc = configuration.GetSection("ConnectionStrings")["ConexionDb"] ?? "";
            services.AddDbContext<DbContext>(options => options.UseSqlServer(sc));

            services.AddScoped<IClientQuery, ClientQuery>();


            return services;
        }
    }
}
