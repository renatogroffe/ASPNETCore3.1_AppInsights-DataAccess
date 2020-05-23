using FluentNHibernate.Mapping;

namespace APIDataAccess.NHibernateImpl
{
    public class RegiaoMap : ClassMap<Regiao>
    {
        public RegiaoMap()
        {
            Table("dbo.Regioes");
            Id(r => r.IdRegiao);
            Map(r => r.NomeRegiao);
            HasMany(r => r.Estados)
                .Table("dbo.Estados")
                .KeyColumn("IdRegiao")
                .AsBag().Not.LazyLoad();;
        }
    }

    public class EstadoMap : ClassMap<Estado>
    {
        public EstadoMap()
        {
            Table("dbo.Estados");
            Id(e => e.SiglaEstado);
            Map(e => e.NomeEstado);
            Map(e => e.NomeCapital);
        }
    }
}