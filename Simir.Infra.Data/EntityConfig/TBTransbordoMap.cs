using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;


namespace Simir.Infra.Data.EntityConfig
{
    public class TBTransbordoMap : EntityTypeConfiguration<TBTransbordo>
    {
        public TBTransbordoMap()
        {
            // Primary Key
            HasKey(t => t.TransbordoID);

            // Properties
            Property(t => t.nmFantasiaTransbordo)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.nmRazaoSocialTransbordo)
                        .IsRequired()
                        .HasMaxLength(200);

            Property(t => t.CNPJ)
            .IsRequired()
            .HasMaxLength(20);

            Property(t => t.numeroLicencaOp)
            .IsRequired()
            .HasMaxLength(30);

            // Table & Column Mappings
            ToTable("TBTransbordo");
            Property(t => t.TransbordoID).HasColumnName("TransbordoID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            Property(t => t.nmFantasiaTransbordo).HasColumnName("nmFantasiaTransbordo");
            Property(t => t.nmRazaoSocialTransbordo).HasColumnName("nmRazaoSocialTransbordo");
            Property(t => t.CNPJ).HasColumnName("CNPJ");
            Property(t => t.numeroLicencaOp).HasColumnName("numeroLicencaOp");
            Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            HasRequired(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
            HasRequired(t => t.TBEndereco)
                .WithMany()
                .HasForeignKey(d => d.EnderecoID);

        }
    }
}
