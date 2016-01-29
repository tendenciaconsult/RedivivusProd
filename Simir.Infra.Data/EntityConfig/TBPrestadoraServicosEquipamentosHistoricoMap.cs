using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBPrestadoraServicosEquipamentosHistoricoMap :
        EntityTypeConfiguration<TBPrestadoraServicosEquipamentosHistorico>
    {
        public TBPrestadoraServicosEquipamentosHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.PrestadoraServicosEquipamentosHistoricoID);

            // Properties
            Property(t => t.nmEquipamento)
                .IsRequired()
                .HasMaxLength(100);
            Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(256);


            // Table & Column Mappings
            ToTable("TBPrestadoraServicosEquipamentosHistorico");
            Property(t => t.PrestadoraServicosEquipamentosHistoricoID)
                .HasColumnName("PrestadoraServicosEquipamentosHistoricoID");
            //this.Property(t => t.PrestadoraServicosHistoricoID).HasColumnName("PrestadoraServicosHistoricoID");
            Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
            Property(t => t.Volume).HasColumnName("Volume");
        }
    }
}