using ApiContactos.Application.Features.Interface.Client;
using ApiContactos.Application.Models.Response;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContactos.Infrastructure.Queries.Client
{
    public class ClientQuery : IClientQuery
    {
        private readonly DbContext _dbContext;
        private readonly ILogger<ClientQuery> _logger;

        public ClientQuery(IConfiguration configuration, ILogger<ClientQuery> logger)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseSqlServer(configuration.GetSection("ConnectionStrings")["ConexionDb"]);
            _dbContext = new DbContext(optionsBuilder.Options);
            _logger = logger;
        }

        public async Task<ResponseData<IEnumerable<ClientResponse>>> GetAllClients()
        {
            //_logger.LogInformation("Obteniendo todos los clientes");

            var clients = await _dbContext.Clients.ToListAsync();

            //_logger.LogInformation($"Se encontraron {clients.Count} clientes");

            return new ResponseData<IEnumerable<ClientResponse>> { Descripcion = "Lista de contactos", Resultado = (IEnumerable<ClientResponse>)clients, Exitoso = true };
        }
    }
}