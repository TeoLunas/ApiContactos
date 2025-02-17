using ApiContactos.Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContactos.Application.Features.Interface.Client
{
    public interface IClientQuery
    {
        Task<ResponseData<PagedResponse<IEnumerable<ClientResponse>>>> GetAllClients(int pageNumber, int pageSize);

    }
}
