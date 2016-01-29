using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEquipamentoColetaEventualHistoricoMap : EntityTypeConfiguration<TBEquipamentoColetaEventualHistorico>
    {
        public TBEquipamentoColetaEventualHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.EquipamentoColetaEventualHistoricoID);

            // Properties
            this.Property(t => t.nmEquipamento)
                .HasMaxLength(255);

            this.Property(t => t.UserID)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBEquipamentoColetaEventualHistorico");
            this.Property(t => t.EquipamentoColetaEventualHistoricoID).HasColumnName("EquipamentoColetaEventualHistoricoID");
            this.Property(t => t.EquipamentoColetaEventualID).HasColumnName("EquipamentoColetaEventualID");
            this.Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            this.Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
            this.Property(t => t.Volume).HasColumnName("Volume");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserID).HasColumnName("UserID");
        }
    }
}
