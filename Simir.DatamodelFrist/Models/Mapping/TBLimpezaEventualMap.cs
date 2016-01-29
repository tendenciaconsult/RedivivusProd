using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBLimpezaEventualMap : EntityTypeConfiguration<TBLimpezaEventual>
    {
        public TBLimpezaEventualMap()
        {
            // Primary Key
            this.HasKey(t => t.LimpezaEventualID);

            // Properties
            this.Property(t => t.nmOutroLogradouro)
                .HasMaxLength(255);

            this.Property(t => t.nmProgramacao)
                .HasMaxLength(255);

            this.Property(t => t.nmTipoProgramacao)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBLimpezaEventual");
            this.Property(t => t.LimpezaEventualID).HasColumnName("LimpezaEventualID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            this.Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            this.Property(t => t.dtInicio).HasColumnName("dtInicio");
            this.Property(t => t.dtFim).HasColumnName("dtFim");
            this.Property(t => t.qtTintasUtilizados).HasColumnName("qtTintasUtilizados");
            this.Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.nmOutroLogradouro).HasColumnName("nmOutroLogradouro");
            this.Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
            this.Property(t => t.qtGaris).HasColumnName("qtGaris");
            this.Property(t => t.TipoProgramacao).HasColumnName("TipoProgramacao");
            this.Property(t => t.bServicoOrdinario).HasColumnName("bServicoOrdinario");
            this.Property(t => t.bFeiraLivre).HasColumnName("bFeiraLivre");
            this.Property(t => t.nmTipoProgramacao).HasColumnName("nmTipoProgramacao");

            // Relationships
            this.HasOptional(t => t.TBEnderecoBairro)
                .WithMany(t => t.TBLimpezaEventuals)
                .HasForeignKey(d => d.EnderecoBairroID);
            this.HasOptional(t => t.TBEnderecoLogradouro)
                .WithMany(t => t.TBLimpezaEventuals)
                .HasForeignKey(d => d.EnderecoLogradouroID);
            this.HasRequired(t => t.TBPrefeitura)
                .WithMany(t => t.TBLimpezaEventuals)
                .HasForeignKey(d => d.PrefeituraID);
            this.HasRequired(t => t.TBPrestadoraServico)
                .WithMany(t => t.TBLimpezaEventuals)
                .HasForeignKey(d => d.PrestadoraServicosID);
            this.HasRequired(t => t.TBRegiaoAdministrativa)
                .WithMany(t => t.TBLimpezaEventuals)
                .HasForeignKey(d => d.RegiaoAdministrativaID);

        }
    }
}
