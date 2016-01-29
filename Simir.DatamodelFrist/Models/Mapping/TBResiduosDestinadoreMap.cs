using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduosDestinadoreMap : EntityTypeConfiguration<TBResiduosDestinadore>
    {
        public TBResiduosDestinadoreMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduosDestinadoresID);

            // Properties
            this.Property(t => t.nmRazaoSocialTransbordo)
                .HasMaxLength(255);

            this.Property(t => t.CNPJTransbordo)
                .HasMaxLength(50);

            this.Property(t => t.nmRazaoSocialTransportadora)
                .HasMaxLength(255);

            this.Property(t => t.CNPJTransportadora)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TBResiduosDestinadores");
            this.Property(t => t.ResiduosDestinadoresID).HasColumnName("ResiduosDestinadoresID");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.dtMesReferencia).HasColumnName("dtMesReferencia");
            this.Property(t => t.RealizouTransbordo).HasColumnName("RealizouTransbordo");
            this.Property(t => t.nmRazaoSocialTransbordo).HasColumnName("nmRazaoSocialTransbordo");
            this.Property(t => t.CNPJTransbordo).HasColumnName("CNPJTransbordo");
            this.Property(t => t.nmRazaoSocialTransportadora).HasColumnName("nmRazaoSocialTransportadora");
            this.Property(t => t.CNPJTransportadora).HasColumnName("CNPJTransportadora");

            // Relationships
            this.HasOptional(t => t.TBEmpresa)
                .WithMany(t => t.TBResiduosDestinadores)
                .HasForeignKey(d => d.EmpresaID);

        }
    }
}
