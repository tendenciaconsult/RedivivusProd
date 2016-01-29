using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBPrestadoraServicosEquipamentosHistoricoMap : EntityTypeConfiguration<TBPrestadoraServicosEquipamentosHistorico>
    {
        public TBPrestadoraServicosEquipamentosHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.PrestadoraServicosEquipamentosHistoricoID);

            // Properties
            this.Property(t => t.nmEquipamento)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserId)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBPrestadoraServicosEquipamentosHistorico");
            this.Property(t => t.PrestadoraServicosEquipamentosHistoricoID).HasColumnName("PrestadoraServicosEquipamentosHistoricoID");
            this.Property(t => t.PrestadoraServicosEquipamentosID).HasColumnName("PrestadoraServicosEquipamentosID");
            this.Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            this.Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            this.Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
            this.Property(t => t.Volume).HasColumnName("Volume");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
