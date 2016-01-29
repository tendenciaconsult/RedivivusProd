using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class AspNetClaimMap : EntityTypeConfiguration<AspNetClaim>
    {
        public AspNetClaimMap()
        {
            // Primary Key
            this.HasKey(t => t.SimirClaimsId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AspNetClaims");
            this.Property(t => t.SimirClaimsId).HasColumnName("SimirClaimsId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
