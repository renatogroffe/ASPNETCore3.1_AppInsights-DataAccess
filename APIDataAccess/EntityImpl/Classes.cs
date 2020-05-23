using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIDataAccess.EntityImpl
{
    public class Regiao
    {
        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }
        public List<Estado> Estados { get; set; }
    }

    public class Estado
    {
        public string SiglaEstado { get; set; }
        public string NomeEstado { get; set; }
        public string NomeCapital { get; set; }
 
        [ForeignKey("IdRegiao")]
        [JsonIgnore]
        public Regiao Regiao { get; set; }
    }
}