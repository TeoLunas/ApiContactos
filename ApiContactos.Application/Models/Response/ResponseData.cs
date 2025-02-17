using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContactos.Application.Models.Response
{
    public class ResponseData<T>
    {
        public bool Exitoso {  get; set; }
        public string Descripcion { get; set; }
        public T? Resultado { get; set; }
        public dynamic Errores { get; set; }
        public bool Error {  get; set; }
        public int Code { get; set; }
        public ResponseData()
        {
            Exitoso = false;
            Errores = null;
        }
    }
}
