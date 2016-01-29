using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEquipamentoColetaOrdinariaHistoricoMap :
        EntityTypeConfiguration<TBEquipamentoColetaOrdinariaHistorico>
    {
        public TBEquipamentoColetaOrdinariaHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.EquipamentoColetaOrdinariaHistoricoID);

            // Properties
            Property(t => t.nmEquipamento)
                .HasMaxLength(255);

            Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBEquipamentoColetaOrdinariaHistorico");
            Property(t => t.EquipamentoColetaOrdinariaHistoricoID)
                .HasColumnName("EquipamentoColetaOrdinariaHistoricoID");
            Property(t => t.EquipamentoColetaOrdinariaID).HasColumnName("EquipamentoColetaOrdinariaID");
            Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
            Property(t => t.Volume).HasColumnName("Volume");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}