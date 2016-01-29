using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEquipamentoColetaEventualMap : EntityTypeConfiguration<TBEquipamentoColetaEventual>
    {
        public TBEquipamentoColetaEventualMap()
        {
            // Primary Key
            this.HasKey(t => t.EquipamentoColetaEventualID);

            // Properties
            this.Property(t => t.nmEquipamento)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBEquipamentoColetaEventual");
            this.Property(t => t.EquipamentoColetaEventualID).HasColumnName("EquipamentoColetaEventualID");
            this.Property(t => t.ColetaEventualID).HasColumnName("ColetaEventualID");
            this.Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            this.Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
            this.Property(t => t.Volume).HasColumnName("Volume");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            this.HasRequired(t => t.TBColetaEventual)
                .WithMany(t => t.TBEquipamentoColetaEventuals)
                .HasForeignKey(d => d.ColetaEventualID);

        }
    }
}
