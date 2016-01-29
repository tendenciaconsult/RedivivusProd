using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBAterroHistoricoMap : EntityTypeConfiguration<TBAterroHistorico>
    {
        public TBAterroHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.AterroHistoricoID);

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
            ToTable("TBAterroHistorico");
            Property(t => t.AterroHistoricoID).HasColumnName("AterroHistoricoID");
            Property(t => t.AterroID).HasColumnName("AterroID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            Property(t => t.nmFantasiaAterro).HasColumnName("nmFantasiaAterro");
            Property(t => t.nmRazaoSocialAterro).HasColumnName("nmRazaoSocialAterro");
            Property(t => t.CNPJ).HasColumnName("CNPJ");
            Property(t => t.numeroLicencaOp).HasColumnName("numeroLicencaOp");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.AterroControlado).HasColumnName("AterroControlado");
        }
    }
}
