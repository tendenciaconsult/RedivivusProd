using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduosGeradoMap : EntityTypeConfiguration<TBResiduosGerados>
    {
        public TBResiduosGeradoMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduosGeradosID);

            // Properties
            this.Property(t => t.CnpjColetora)
                .HasMaxLength(50);

            this.Property(t => t.nmRazaoSocialColetora)
                .HasMaxLength(150);

            this.Property(t => t.CNPJDestinadora)
                .HasMaxLength(50);

            this.Property(t => t.RazaoSocialDestinadora)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("TBResiduosGerados");
            this.Property(t => t.ResiduosGeradosID).HasColumnName("ResiduosGeradosID");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.dtMesReferencia).HasColumnName("dtMesReferencia");
            this.Property(t => t.ColetoraPublica).HasColumnName("ColetoraPublica");
            this.Property(t => t.CnpjColetora).HasColumnName("CnpjColetora");
            this.Property(t => t.nmRazaoSocialColetora).HasColumnName("nmRazaoSocialColetora");
            this.Property(t => t.CNPJDestinadora).HasColumnName("CNPJDestinadora");
            this.Property(t => t.RazaoSocialDestinadora).HasColumnName("RazaoSocialDestinadora");


            // Relationships
            HasRequired(t => t.Empresa)
                .WithMany() //.WithMany(t => t.TBResiduosGerados)
                .HasForeignKey(d => d.EmpresaID);

            // Relationships
            HasMany(t => t.Itens)
                .WithRequired(x=>x.ResiduosGerado) //.WithMany(t => t.TBResiduosGerados)
                .HasForeignKey(d => d.ResiduosGeradoID);
        }
    }
}