using System.Collections.Generic;

namespace APIDataAccess.NHibernateImpl
{
    public class Regiao
    {
        public virtual int IdRegiao { get; set; }
        public virtual string NomeRegiao { get; set; }
        public virtual IList<Estado> Estados { get; set; }

        public Regiao()
        {
            Estados = new List<Estado>();
        }
    }

    public class Estado
    {
        public virtual string SiglaEstado { get; set; }
        public virtual string NomeEstado { get; set; }
        public virtual string NomeCapital { get; set; }
    }
}