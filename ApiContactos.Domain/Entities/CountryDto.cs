using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContactos.Domain.Entities
{
    public class CountryDto
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
        public ICollection<ClientDto> Clients { get; set; }
    }
}
