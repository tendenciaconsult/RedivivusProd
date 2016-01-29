using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBGeradorMtrMap : EntityTypeConfiguration<TBGeradorMtr>
    {
        public TBGeradorMtrMap()
        {
            Property(t => t.EmpresaGeradoraID).HasColumnName("EmpresaID");
            Property(t => t.dtMtr).HasColumnName("dtMtr");

            HasRequired(t => t.EmpresaGeradora)
                .WithMany()
                .HasForeignKey(d => d.EmpresaGeradoraID);
        }
    }
}