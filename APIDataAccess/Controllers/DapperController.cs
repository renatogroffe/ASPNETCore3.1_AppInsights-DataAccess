using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Slapper;
using APIDataAccess.DapperImpl;

namespace APIDataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DapperController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Regiao> Get(
            [FromServices]IConfiguration configuration)
        {
            using var conexao = new SqlConnection(
                configuration.GetConnectionString("DadosGeograficos"));

            var dados = conexao.Query<dynamic>(
                "SELECT R.IdRegiao, " +
                       "R.NomeRegiao, " +
                       "E.SiglaEstado AS Estados_SiglaEstado, " +
                       "E.NomeEstado AS Estados_NomeEstado, " +
                       "E.NomeCapital AS Estados_NomeCapital " +
                "FROM dbo.Regioes R " +
                "INNER JOIN dbo.Estados E " +
                    "ON E.IdRegiao = R.IdRegiao " +
                "ORDER BY R.NomeRegiao, E.NomeEstado");

            AutoMapper.Configuration.AddIdentifier(
                typeof(Regiao), "IdRegiao");
            AutoMapper.Configuration.AddIdentifier(
                typeof(Estado), "SiglaEstado");

            return (AutoMapper.MapDynamic<Regiao>(dados)
                as IEnumerable<Regiao>).ToList();
        }
    }
}