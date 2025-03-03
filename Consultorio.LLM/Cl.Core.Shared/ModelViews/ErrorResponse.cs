using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.Core.Shared.ModelViews
{
    public class ErrorResponse
    {
        public ErrorResponse(string id)
        {
            Id = id;
            Data = DateTime.Now;
            Mensagem = "Erro ineperado";
        }
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public String Mensagem { get; set; } = string.Empty;
    }
}
