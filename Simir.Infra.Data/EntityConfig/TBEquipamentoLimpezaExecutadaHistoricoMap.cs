using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEquipamentoLimpezaExecutadaHistoricoMap :
        EntityTypeConfiguration<TBEquipamentoLimpezaExecutadaHistorico>
    {
        public TBEquipamentoLimpezaExecutadaHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.EquipamentoLimpezaExecutadaHistorico);

            // Properties
            Property(t => t.nmTipoEquipamento)
                .HasMaxLength(100);


            // Table & Column Mappings
            ToTable("TBEquipamentoLimpezaExecutadaHistorico");
            Property(t => t.EquipamentoLimpezaExecutadaHistorico).HasColumnName("EquipamentoLimpezaExecutadaHistorico");
            Property(t => t.EquipamentoLimpezaExecutadaID).HasColumnName("EquipamentoLimpezaExecutadaID");
            Property(t => t.nmTipoEquipamento).HasColumnName("nmTipoEquipamento");
            Property(t => t.Quantidade).HasColumnName("Quantidade");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
        }
    }
}