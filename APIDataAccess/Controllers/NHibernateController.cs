using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDataAccess.NHibernateImpl;

namespace APIDataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NHibernateController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Regiao> Get(
            [FromServices]NHibernate.ISession sessionNH)
        {
            return sessionNH.Query<Regiao>()
                .OrderBy(r => r.NomeRegiao).ToArray();
        }
    }
}