using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBLimpezaExecutadaHistoricoMap : EntityTypeConfiguration<TBLimpezaExecutadaHistorico>
    {
        public TBLimpezaExecutadaHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.LimpezaExecutadaHistoricoID);

            // Properties
            this.Property(t => t.nmLimpezaExecutada)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.sObservacao)
                .HasMaxLength(900);

            this.Property(t => t.UserID)
                .HasMaxLength(100);

            this.Property(t => t.nmMotivoNaoExecucao)
                .HasMaxLength(900);

            // Table & Column Mappings
            this.ToTable("TBLimpezaExecutadaHistorico");
            this.Property(t => t.LimpezaExecutadaHistoricoID).HasColumnName("LimpezaExecutadaHistoricoID");
            this.Property(t => t.LimpezaExecutadaID).HasColumnName("LimpezaExecutadaID");
            this.Property(t => t.nmLimpezaExecutada).HasColumnName("nmLimpezaExecutada");
            this.Property(t => t.dtProgramacao).HasColumnName("dtProgramacao");
            this.Property(t => t.ProgramacaoRealizada).HasColumnName("ProgramacaoRealizada");
            this.Property(t => t.dtInicio).HasColumnName("dtInicio");
            this.Property(t => t.dtFim).HasColumnName("dtFim");
            this.Property(t => t.qtGaris).HasColumnName("qtGaris");
            this.Property(t => t.qtSupervisor).HasColumnName("qtSupervisor");
            this.Property(t => t.qtEncarregado).HasColumnName("qtEncarregado");
            this.Property(t => t.sObservacao).HasColumnName("sObservacao");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.nmMotivoNaoExecucao).HasColumnName("nmMotivoNaoExecucao");
        }
    }
}
