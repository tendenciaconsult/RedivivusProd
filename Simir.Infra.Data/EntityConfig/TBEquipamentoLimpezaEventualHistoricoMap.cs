using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEquipamentoLimpezaEventualHistoricoMap :
        EntityTypeConfiguration<TBEquipamentoLimpezaEventualHistorico>
    {
        public TBEquipamentoLimpezaEventualHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.EquipamentoLimpezaEventualHistoricoID);

            // Properties
            Property(t => t.nmTipoEquipamento)
                .HasMaxLength(200);

            // Table & Column Mappings
            ToTable("TBEquipamentoLimpezaEventualHistorico");
            Property(t => t.EquipamentoLimpezaEventualHistoricoID)
                .HasColumnName("EquipamentoLimpezaEventualHistoricoID");
            Property(t => t.LimpezaEventualID).HasColumnName("LimpezaEventualID");
            Property(t => t.nmTipoEquipamento).HasColumnName("nmTipoEquipamento");
            Property(t => t.Quantidade).HasColumnName("Quantidade");
        }
    }
}