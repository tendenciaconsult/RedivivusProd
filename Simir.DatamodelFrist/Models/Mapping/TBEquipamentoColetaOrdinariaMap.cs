using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEquipamentoColetaOrdinariaMap : EntityTypeConfiguration<TBEquipamentoColetaOrdinaria>
    {
        public TBEquipamentoColetaOrdinariaMap()
        {
            // Primary Key
            this.HasKey(t => t.EquipamentoColetaOrdinariaID);

            // Properties
            this.Property(t => t.nmEquipamento)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBEquipamentoColetaOrdinaria");
            this.Property(t => t.EquipamentoColetaOrdinariaID).HasColumnName("EquipamentoColetaOrdinariaID");
            this.Property(t => t.ColetaOrdinariaID).HasColumnName("ColetaOrdinariaID");
            this.Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            this.Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
            this.Property(t => t.Volume).HasColumnName("Volume");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            this.HasRequired(t => t.TBColetaOrdinaria)
                .WithMany(t => t.TBEquipamentoColetaOrdinarias)
                .HasForeignKey(d => d.ColetaOrdinariaID);

        }
    }
}
