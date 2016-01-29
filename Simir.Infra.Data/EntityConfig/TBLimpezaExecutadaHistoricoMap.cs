using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBLimpezaExecutadaHistoricoMap : EntityTypeConfiguration<TBLimpezaExecutadaHistorico>
    {
        public TBLimpezaExecutadaHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.LimpezaExecutadaHistoricoID);

            // Properties
            Property(t => t.nmLimpezaExecutada)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.sObservacao)
                .HasMaxLength(900);


            // Table & Column Mappings
            ToTable("TBLimpezaExecutadaHistorico");
            Property(t => t.LimpezaExecutadaHistoricoID).HasColumnName("LimpezaExecutadaHistoricoID");
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
        }
    }
}