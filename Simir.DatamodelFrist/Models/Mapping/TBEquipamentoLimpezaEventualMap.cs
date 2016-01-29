using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEquipamentoLimpezaEventualMap : EntityTypeConfiguration<TBEquipamentoLimpezaEventual>
    {
        public TBEquipamentoLimpezaEventualMap()
        {
            // Primary Key
            this.HasKey(t => t.EquipamentoLimpezaEventualID);

            // Properties
            this.Property(t => t.nmTipoEquipamento)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBEquipamentoLimpezaEventual");
            this.Property(t => t.EquipamentoLimpezaEventualID).HasColumnName("EquipamentoLimpezaEventualID");
            this.Property(t => t.LimpezaEventualID).HasColumnName("LimpezaEventualID");
            this.Property(t => t.nmTipoEquipamento).HasColumnName("nmTipoEquipamento");
            this.Property(t => t.Quantidade).HasColumnName("Quantidade");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
        }
    }
}
