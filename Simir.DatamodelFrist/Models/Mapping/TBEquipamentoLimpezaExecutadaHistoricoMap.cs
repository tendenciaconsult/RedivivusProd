using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEquipamentoLimpezaExecutadaHistoricoMap : EntityTypeConfiguration<TBEquipamentoLimpezaExecutadaHistorico>
    {
        public TBEquipamentoLimpezaExecutadaHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.EquipamentoLimpezaExecutadaHistorico);

            // Properties
            this.Property(t => t.nmTipoEquipamento)
                .HasMaxLength(100);

            this.Property(t => t.UserID)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBEquipamentoLimpezaExecutadaHistorico");
            this.Property(t => t.EquipamentoLimpezaExecutadaHistorico).HasColumnName("EquipamentoLimpezaExecutadaHistorico");
            this.Property(t => t.EquipamentoLimpezaExecutadaID).HasColumnName("EquipamentoLimpezaExecutadaID");
            this.Property(t => t.nmTipoEquipamento).HasColumnName("nmTipoEquipamento");
            this.Property(t => t.Quantidade).HasColumnName("Quantidade");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserID).HasColumnName("UserID");
        }
    }
}
