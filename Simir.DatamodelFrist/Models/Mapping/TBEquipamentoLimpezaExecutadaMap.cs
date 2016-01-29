using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEquipamentoLimpezaExecutadaMap : EntityTypeConfiguration<TBEquipamentoLimpezaExecutada>
    {
        public TBEquipamentoLimpezaExecutadaMap()
        {
            // Primary Key
            this.HasKey(t => t.EquipamentoLimpezaExecutadaID);

            // Properties
            this.Property(t => t.nmTipoEquipamento)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBEquipamentoLimpezaExecutada");
            this.Property(t => t.EquipamentoLimpezaExecutadaID).HasColumnName("EquipamentoLimpezaExecutadaID");
            this.Property(t => t.nmTipoEquipamento).HasColumnName("nmTipoEquipamento");
            this.Property(t => t.Quantidade).HasColumnName("Quantidade");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.LimpezaExecutadaID).HasColumnName("LimpezaExecutadaID");

            // Relationships
            this.HasRequired(t => t.TBLimpezaExecutada)
                .WithMany(t => t.TBEquipamentoLimpezaExecutadas)
                .HasForeignKey(d => d.LimpezaExecutadaID);

        }
    }
}
