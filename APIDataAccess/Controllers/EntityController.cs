using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDataAccess.EntityImpl;

namespace APIDataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Regiao> Get(
            [FromServices]DadosGeograficosContext context)
        {
            return context.Regioes.Include(r => r.Estados)
                .OrderBy(r => r.NomeRegiao).ToArray();
        }
    }
}