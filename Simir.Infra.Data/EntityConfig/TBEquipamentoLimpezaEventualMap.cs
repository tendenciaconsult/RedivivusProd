using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEquipamentoLimpezaEventualMap : EntityTypeConfiguration<TBEquipamentoLimpezaEventual>
    {
        public TBEquipamentoLimpezaEventualMap()
        {
            // Primary Key
            HasKey(t => t.EquipamentoLimpezaEventualID);

            // Properties
            Property(t => t.nmTipoEquipamento)
                .HasMaxLength(200);

            // Table & Column Mappings
            ToTable("TBEquipamentoLimpezaEventual");
            Property(t => t.EquipamentoLimpezaEventualID).HasColumnName("EquipamentoLimpezaEventualID");
            Property(t => t.LimpezaEventualID).HasColumnName("LimpezaEventualID");
            Property(t => t.nmTipoEquipamento).HasColumnName("nmTipoEquipamento");
            Property(t => t.Quantidade).HasColumnName("Quantidade");
        }
    }
}