using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBLicencaOperacaoMap : EntityTypeConfiguration<TBLicencaOperacao>
    {
        public TBLicencaOperacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.LicencaOperacaoID);

            // Properties
            this.Property(t => t.CodigoLicencaOperacao)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.nmLicencaOperacao)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBLicencaOperacao");
            this.Property(t => t.LicencaOperacaoID).HasColumnName("LicencaOperacaoID");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.CodigoLicencaOperacao).HasColumnName("CodigoLicencaOperacao");
            this.Property(t => t.dtValidade).HasColumnName("dtValidade");
            this.Property(t => t.nmLicencaOperacao).HasColumnName("nmLicencaOperacao");

            // Relationships
            this.HasOptional(t => t.TBEmpresa)
                .WithMany(t => t.TBLicencaOperacaos)
                .HasForeignKey(d => d.EmpresaID);

        }
    }
}
