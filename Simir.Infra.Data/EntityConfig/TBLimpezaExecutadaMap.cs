using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBLimpezaExecutadaMap : EntityTypeConfiguration<TBLimpezaExecutada>
    {
        public TBLimpezaExecutadaMap()
        {
            // Primary Key
            HasKey(t => t.LimpezaExecutadaID);

            // Properties
            Property(t => t.nmLimpezaExecutada)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.sObservacao)
                .HasMaxLength(900);

            // Table & Column Mappings
            ToTable("TBLimpezaExecutada");
            Property(t => t.LimpezaExecutadaID).HasColumnName("LimpezaExecutadaID");
            Property(t => t.nmLimpezaExecutada).HasColumnName("nmLimpezaExecutada");
            Property(t => t.dtProgramacao).HasColumnName("dtProgramacao");
            Property(t => t.ProgramacaoRealizada).HasColumnName("ProgramacaoRealizada");
            Property(t => t.dtInicio).HasColumnName("dtInicio");
            Property(t => t.dtFim).HasColumnName("dtFim");
            Property(t => t.qtGaris).HasColumnName("qtGaris");
            Property(t => t.qtSupervisor).HasColumnName("qtSupervisor");
            Property(t => t.qtEncarregado).HasColumnName("qtEncarregado");
            Property(t => t.sObservacao).HasColumnName("sObservacao");

            // Relationships
            //this.HasRequired(t => t.TBLimpezaEventual)
            //    .WithOptional()
            //    .HasForeignKey(d => d.LimpezaEventualID);
        }
    }
}