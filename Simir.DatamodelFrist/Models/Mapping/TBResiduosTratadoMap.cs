using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduosTratadoMap : EntityTypeConfiguration<TBResiduosTratado>
    {
        public TBResiduosTratadoMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduosTratadosID);

            // Properties
            this.Property(t => t.OutroTipoTratamento)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBResiduosTratados");
            this.Property(t => t.ResiduosTratadosID).HasColumnName("ResiduosTratadosID");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.ResiduoClassificadoID).HasColumnName("ResiduoClassificadoID");
            this.Property(t => t.TipoTratamento).HasColumnName("TipoTratamento");
            this.Property(t => t.OutroTipoTratamento).HasColumnName("OutroTipoTratamento");
            this.Property(t => t.qtResiduoTratado).HasColumnName("qtResiduoTratado");
            this.Property(t => t.qtRejeito).HasColumnName("qtRejeito");
            this.Property(t => t.emLitros).HasColumnName("emLitros");

            // Relationships
            this.HasRequired(t => t.TBEmpresa)
                .WithMany(t => t.TBResiduosTratados)
                .HasForeignKey(d => d.EmpresaID);
            this.HasRequired(t => t.TBResiduoClassificado)
                .WithMany(t => t.TBResiduosTratados)
                .HasForeignKey(d => d.ResiduoClassificadoID);

        }
    }
}
