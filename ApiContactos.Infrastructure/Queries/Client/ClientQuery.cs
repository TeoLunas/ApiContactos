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

        public async Task<ResponseData<PagedResponse<IEnumerable<ClientResponse>>>> GetAllClients(int pageNumber, int pageSize)
        {
            try
            {
                var totalClients = await _dbContext.Clients.CountAsync();

                var skip = (pageNumber - 1) * pageSize;

                var clients = await _dbContext.Clients
                    .Skip(skip)
                    .Take(pageSize)
                    .ToListAsync();

                var clientResponses = clients.Select(c => new ClientResponse
                {
                    ClientId = c.ClientID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Phone = c.Phone,
                    Email = c.Email,
                    CountryID = c.CountryID
                }).ToList();

                var totalPages = (int)Math.Ceiling((double)totalClients / pageSize);

                var pagedResponse = new PagedResponse<IEnumerable<ClientResponse>>
                {
                    Data = clientResponses,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = totalClients,
                    TotalPages = totalPages
                };
                
                return new ResponseData<PagedResponse<IEnumerable<ClientResponse>>>
                {
                    Descripcion = "Lista de contactos paginada",
                    Resultado = pagedResponse,
                    Exitoso = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseData<PagedResponse<IEnumerable<ClientResponse>>>
                {
                    Descripcion = "Error al obtener los clientes: " + ex.Message,
                    Resultado = null,
                    Exitoso = false
                };
            }
        }
    }
}