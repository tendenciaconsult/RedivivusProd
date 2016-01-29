using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBLicencaOperacaoMap : EntityTypeConfiguration<TBLicencaOperacao>
    {
        public TBLicencaOperacaoMap()
        {
            // Primary Key
            HasKey(t => t.LicencaOperacaoID);

            // Properties
            Property(t => t.CodigoLicencaOperacao)
                .IsRequired()
                .HasMaxLength(50);
            Property(t => t.nmLicencaOperacao)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBLicencaOperacao");
            Property(t => t.LicencaOperacaoID).HasColumnName("LicencaOperacaoID");
            Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            Property(t => t.CodigoLicencaOperacao).HasColumnName("CodigoLicencaOperacao");
            Property(t => t.nmLicencaOperacao).HasColumnName("nmLicencaOperacao");
            Property(t => t.dtValidade).HasColumnName("dtValidade");

            // Relationships
            /*
            this.HasOptional(t => t.TBEmpresa)
                .WithMany()//.WithMany(t => t.TBLicencaOperacaos)
                .HasForeignKey(d => d.EmpresaID);
             * */
        }
    }
}