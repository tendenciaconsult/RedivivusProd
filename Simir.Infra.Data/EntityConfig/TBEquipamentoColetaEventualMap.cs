using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEquipamentoColetaEventualMap : EntityTypeConfiguration<TBEquipamentoColetaEventual>
    {
        public TBEquipamentoColetaEventualMap()
        {
            // Primary Key
            HasKey(t => t.EquipamentoColetaEventualID);

            // Properties
            Property(t => t.nmEquipamento)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBEquipamentoColetaEventual");
            Property(t => t.EquipamentoColetaEventualID).HasColumnName("EquipamentoColetaEventualID");
            Property(t => t.ColetaEventualID).HasColumnName("ColetaEventualID");
            Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
            Property(t => t.Volume).HasColumnName("Volume");
            Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            HasRequired(t => t.TBColetaEventual)
                .WithMany(t => t.TBEquipamentoColetaEventuals)
                .HasForeignKey(d => d.ColetaEventualID);
        }
    }
}