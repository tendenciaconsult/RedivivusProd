using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEmpresaMap : EntityTypeConfiguration<TBEmpresa>
    {
        public TBEmpresaMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpresaID);

            // Properties
            this.Property(t => t.nmRazaoSocial)
                .HasMaxLength(255);

            this.Property(t => t.nmFantasia)
                .HasMaxLength(255);

            this.Property(t => t.CNPJ)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Site)
                .HasMaxLength(100);

            this.Property(t => t.Telefone)
                .HasMaxLength(20);

            this.Property(t => t.Celular)
                .HasMaxLength(20);

            this.Property(t => t.InscricaoEsdatudal)
                .HasMaxLength(50);

            this.Property(t => t.InscricaoMunicipal)
                .HasMaxLength(50);

            this.Property(t => t.CNAE)
                .HasMaxLength(50);

            this.Property(t => t.AlvaraFuncionamento)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TBEmpresa");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.nmRazaoSocial).HasColumnName("nmRazaoSocial");
            this.Property(t => t.nmFantasia).HasColumnName("nmFantasia");
            this.Property(t => t.CNPJ).HasColumnName("CNPJ");
            this.Property(t => t.PorteEmpresaID).HasColumnName("PorteEmpresaID");
            this.Property(t => t.RamoEmpresaID).HasColumnName("RamoEmpresaID");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Site).HasColumnName("Site");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Celular).HasColumnName("Celular");
            this.Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            this.Property(t => t.InscricaoEsdatudal).HasColumnName("InscricaoEsdatudal");
            this.Property(t => t.InscricaoMunicipal).HasColumnName("InscricaoMunicipal");
            this.Property(t => t.CNAE).HasColumnName("CNAE");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.AlvaraFuncionamento).HasColumnName("AlvaraFuncionamento");
            this.Property(t => t.bGeradorResiduo).HasColumnName("bGeradorResiduo");
            this.Property(t => t.bTratamentoResiduo).HasColumnName("bTratamentoResiduo");
            this.Property(t => t.bColetorResiduo).HasColumnName("bColetorResiduo");
            this.Property(t => t.bDisposicaoFinalResiduo).HasColumnName("bDisposicaoFinalResiduo");

            // Relationships
            this.HasOptional(t => t.TBEndereco)
                .WithMany(t => t.TBEmpresas)
                .HasForeignKey(d => d.EnderecoID);
            this.HasOptional(t => t.TBPorteEmpresa)
                .WithMany(t => t.TBEmpresas)
                .HasForeignKey(d => d.PorteEmpresaID);
            this.HasOptional(t => t.TBPrefeitura)
                .WithMany(t => t.TBEmpresas)
                .HasForeignKey(d => d.PrefeituraID);
            this.HasOptional(t => t.TBRamoEmpresa)
                .WithMany(t => t.TBEmpresas)
                .HasForeignKey(d => d.RamoEmpresaID);

        }
    }
}
