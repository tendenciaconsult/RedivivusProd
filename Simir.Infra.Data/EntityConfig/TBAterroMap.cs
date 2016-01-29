using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;


namespace Simir.Infra.Data.EntityConfig
{
    public class TBAterroMap : EntityTypeConfiguration<TBAterro>
    {
        public TBAterroMap()
        {
            // Primary Key
            HasKey(t => t.AterroID);

            // Properties
            Property(t => t.nmFantasiaAterro)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.nmRazaoSocialAterro)
                        .IsRequired()
                        .HasMaxLength(200);

            Property(t => t.CNPJ)
            .IsRequired()
            .HasMaxLength(20);

            Property(t => t.numeroLicencaOp)
            .IsRequired()
            .HasMaxLength(30);

            // Table & Column Mappings
            ToTable("TBAterro");
            Property(t => t.AterroID).HasColumnName("AterroID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            Property(t => t.nmFantasiaAterro).HasColumnName("nmFantasiaAterro");
            Property(t => t.nmRazaoSocialAterro).HasColumnName("nmRazaoSocialAterro");
            Property(t => t.CNPJ).HasColumnName("CNPJ");
            Property(t => t.numeroLicencaOp).HasColumnName("numeroLicencaOp");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.AterroControlado).HasColumnName("AterroControlado");

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
