using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEquipamentoColetaEventualHistoricoMap : EntityTypeConfiguration<TBEquipamentoColetaEventualHistorico>
    {
        public TBEquipamentoColetaEventualHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.EquipamentoColetaEventualHistoricoID);

            // Properties
            Property(t => t.nmEquipamento)
                .HasMaxLength(255);

            Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBEquipamentoColetaEventualHistorico");
            Property(t => t.EquipamentoColetaEventualHistoricoID).HasColumnName("EquipamentoColetaEventualHistoricoID");
            Property(t => t.EquipamentoColetaEventualID).HasColumnName("EquipamentoColetaEventualID");
            Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
            Property(t => t.Volume).HasColumnName("Volume");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserID");
        }
    }
}