using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEquipamentoColetaOrdinariaMap : EntityTypeConfiguration<TBEquipamentoColetaOrdinaria>
    {
        public TBEquipamentoColetaOrdinariaMap()
        {
            // Primary Key
            HasKey(t => t.EquipamentoColetaOrdinariaID);

            // Properties
            Property(t => t.nmEquipamento)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBEquipamentoColetaOrdinaria");
            Property(t => t.EquipamentoColetaOrdinariaID).HasColumnName("EquipamentoColetaOrdinariaID");
            Property(t => t.ColetaOrdinariaID).HasColumnName("ColetaOrdinariaID");
            Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
            Property(t => t.Volume).HasColumnName("Volume");
            Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            HasRequired(t => t.TBColetaOrdinaria)
                .WithMany(t => t.TBEquipamentoColetaOrdinarias)
                .HasForeignKey(d => d.ColetaOrdinariaID);
        }
    }
}