using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBFuncoesEmpresaMap : EntityTypeConfiguration<TBFuncoesEmpresa>
    {
        public TBFuncoesEmpresaMap()
        {
            // Primary Key
            HasKey(t => t.FuncoesEmpresaID);

            // Properties
            Property(t => t.nmFuncoesEmpresa)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBFuncoesEmpresa");
            Property(t => t.FuncoesEmpresaID).HasColumnName("FuncoesEmpresaID");
            Property(t => t.nmFuncoesEmpresa).HasColumnName("nmFuncoesEmpresa");
        }
    }
}