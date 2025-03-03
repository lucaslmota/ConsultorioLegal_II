using Cl.Core.Shared.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CL_WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErroController : ControllerBase
    {
        [Route("erro")]
        public ErrorResponse Error()
        {
            Response.StatusCode = 500;
            //Pega o id do erro ou da requição OBS aqui eu tive que mudar o id pra pegar somente do httpcontexto pois no arquivo de logo ñ há mais o SpanId
            //var idError = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            var idError = HttpContext?.TraceIdentifier;
            return new ErrorResponse(idError);
        }
    }
}
