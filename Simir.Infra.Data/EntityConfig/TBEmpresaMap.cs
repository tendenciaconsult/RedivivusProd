using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEmpresaMap : EntityTypeConfiguration<TBEmpresa>
    {
        public TBEmpresaMap()
        {
            // Primary Key
            HasKey(t => t.EmpresaID);

            // Properties
            Property(t => t.nmRazaoSocial)
                .HasMaxLength(255);

            Property(t => t.nmFantasia)
                .HasMaxLength(255);

            Property(t => t.CNPJ)
                .HasMaxLength(50);

            Property(t => t.Email)
                .HasMaxLength(100);

            Property(t => t.Site)
                .HasMaxLength(100);

            Property(t => t.Telefone)
                .HasMaxLength(20);

            Property(t => t.Celular)
                .HasMaxLength(20);

            Property(t => t.InscricaoEsdatudal)
                .HasMaxLength(50);

            Property(t => t.InscricaoMunicipal)
                .HasMaxLength(50);

            Property(t => t.Alvara)
                .HasMaxLength(50);

            Property(t => t.CNAE)
                .HasMaxLength(50);

            Property(t => t.AlvaraFuncionamento)
                .HasMaxLength(50);


            // Table & Column Mappings
            ToTable("TBEmpresa");
            Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            Property(t => t.nmRazaoSocial).HasColumnName("nmRazaoSocial");
            Property(t => t.nmFantasia).HasColumnName("nmFantasia");
            Property(t => t.CNPJ).HasColumnName("CNPJ");
            Property(t => t.PorteEmpresaID).HasColumnName("PorteEmpresaID");
            Property(t => t.RamoEmpresaID).HasColumnName("RamoEmpresaID");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.Site).HasColumnName("Site");
            Property(t => t.Telefone).HasColumnName("Telefone");
            Property(t => t.Celular).HasColumnName("Celular");
            Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            Property(t => t.InscricaoEsdatudal).HasColumnName("InscricaoEsdatudal");
            Property(t => t.InscricaoMunicipal).HasColumnName("InscricaoMunicipal");
            Property(t => t.CNAE).HasColumnName("CNAE");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.AlvaraFuncionamento).HasColumnName("AlvaraFuncionamento");
            Property(t => t.bGeradorResiduo).HasColumnName("bGeradorResiduo");
            Property(t => t.bTratamentoResiduo).HasColumnName("bTratamentoResiduo");
            Property(t => t.bColetorResiduo).HasColumnName("bColetorResiduo");
            Property(t => t.bDisposicaoFinalResiduo).HasColumnName("bDisposicaoFinalResiduo");

            // Relationships
            //this.HasOptional(t => t.TBEndereco).WithMany();
            HasOptional(t => t.TBPorteEmpresa)
                .WithMany()
                .HasForeignKey(d => d.PorteEmpresaID);
            HasOptional(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
            HasOptional(t => t.TBRamoEmpresa)
                .WithMany()
                .HasForeignKey(d => d.RamoEmpresaID);

            HasMany(x => x.TBLicencaOperacaos)
                .WithOptional()
                .HasForeignKey(x => x.EmpresaID);
        }
    }
}