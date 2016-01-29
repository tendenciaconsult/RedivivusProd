using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEquipamentoLimpezaEventualHistoricoMap : EntityTypeConfiguration<TBEquipamentoLimpezaEventualHistorico>
    {
        public TBEquipamentoLimpezaEventualHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.EquipamentoLimpezaEventualHistoricoID);

            // Properties
            this.Property(t => t.nmTipoEquipamento)
                .HasMaxLength(255);

            this.Property(t => t.userID)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBEquipamentoLimpezaEventualHistorico");
            this.Property(t => t.EquipamentoLimpezaEventualHistoricoID).HasColumnName("EquipamentoLimpezaEventualHistoricoID");
            this.Property(t => t.LimpezaEventualID).HasColumnName("LimpezaEventualID");
            this.Property(t => t.nmTipoEquipamento).HasColumnName("nmTipoEquipamento");
            this.Property(t => t.Quantidade).HasColumnName("Quantidade");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
        }
    }
}
