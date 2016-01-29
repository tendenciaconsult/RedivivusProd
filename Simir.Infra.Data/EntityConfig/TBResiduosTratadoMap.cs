using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduosTratadoMap : EntityTypeConfiguration<TBResiduosTratado>
    {
        public TBResiduosTratadoMap()
        {
            // Primary Key
            HasKey(t => t.ResiduosTratadosID);

            Property(x => x.OutroTipoTratamento).HasMaxLength(255);

            // Properties
            // Table & Column Mappings
            ToTable("TBResiduosTratados");

            // Relationships
            HasRequired(t => t.Empresa)
                .WithMany() //.WithMany(t => t.TBResiduosTratados)
                .HasForeignKey(d => d.EmpresaID);
            HasRequired(t => t.ResiduoClassificado)
                .WithMany()
                .HasForeignKey(d => d.ResiduoClassificadoID);
        }
    }
}