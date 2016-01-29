using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBRegiaoAdministrativaMap : EntityTypeConfiguration<TBRegiaoAdministrativa>
    {
        public TBRegiaoAdministrativaMap()
        {
            // Primary Key
            this.HasKey(t => t.RegiaoAdministrativaID);

            // Properties
            this.Property(t => t.nmRegiaoAdministrativa)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBRegiaoAdministrativa");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.nmRegiaoAdministrativa).HasColumnName("nmRegiaoAdministrativa");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            this.HasOptional(t => t.TBPrefeitura)
                .WithMany(t => t.TBRegiaoAdministrativas)
                .HasForeignKey(d => d.PrefeituraID);

        }
    }
}
