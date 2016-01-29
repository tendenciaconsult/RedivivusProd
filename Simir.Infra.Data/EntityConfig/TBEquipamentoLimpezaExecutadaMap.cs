using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEquipamentoLimpezaExecutadaMap : EntityTypeConfiguration<TBEquipamentoLimpezaExecutada>
    {
        public TBEquipamentoLimpezaExecutadaMap()
        {
            // Primary Key
            HasKey(t => t.EquipamentoLimpezaExecutadaID);

            // Properties
            Property(t => t.nmTipoEquipamento)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBEquipamentoLimpezaExecutada");
            Property(t => t.EquipamentoLimpezaExecutadaID).HasColumnName("EquipamentoLimpezaExecutadaID");
            Property(t => t.LimpezaExecutadaID).HasColumnName("LimpezaExecutadaID");
            Property(t => t.nmTipoEquipamento).HasColumnName("nmTipoEquipamento");
            Property(t => t.Quantidade).HasColumnName("Quantidade");
            Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            HasRequired(t => t.TBLimpezaExecutada)
                .WithMany(t => t.TBEquipamentoLimpezaExecutadas)
                .HasForeignKey(d => d.LimpezaExecutadaID);
        }
    }
}