using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBRegiaoAdministrativaMap : EntityTypeConfiguration<TBRegiaoAdministrativa>
    {
        public TBRegiaoAdministrativaMap()
        {
            // Primary Key
            HasKey(t => t.RegiaoAdministrativaID);

            // Properties
            Property(t => t.nmRegiaoAdministrativa)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBRegiaoAdministrativa");
            Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.nmRegiaoAdministrativa).HasColumnName("nmRegiaoAdministrativa");

            // Relationships
            HasOptional(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
        }
    }
}