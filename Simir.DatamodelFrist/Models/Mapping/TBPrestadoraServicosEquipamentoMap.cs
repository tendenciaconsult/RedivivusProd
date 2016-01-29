using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBPrestadoraServicosEquipamentoMap : EntityTypeConfiguration<TBPrestadoraServicosEquipamento>
    {
        public TBPrestadoraServicosEquipamentoMap()
        {
            // Primary Key
            this.HasKey(t => t.PrestadoraServicosEquipamentosID);

            // Properties
            this.Property(t => t.nmEquipamento)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("TBPrestadoraServicosEquipamentos");
            this.Property(t => t.PrestadoraServicosEquipamentosID).HasColumnName("PrestadoraServicosEquipamentosID");
            this.Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            this.Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            this.Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
            this.Property(t => t.Volume).HasColumnName("Volume");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            this.HasRequired(t => t.TBPrestadoraServico)
                .WithMany(t => t.TBPrestadoraServicosEquipamentos)
                .HasForeignKey(d => d.PrestadoraServicosID);

        }
    }
}
