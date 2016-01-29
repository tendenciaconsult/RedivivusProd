using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBLimpezaEventualMap : EntityTypeConfiguration<TBLimpezaEventual>
    {
        public TBLimpezaEventualMap()
        {
            // Primary Key
            HasKey(t => t.LimpezaEventualID);

            // Properties
            Property(t => t.nmOutroLogradouro)
                .HasMaxLength(255);

            Property(t => t.nmProgramacao)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBLimpezaEventual");
            Property(t => t.LimpezaEventualID).HasColumnName("LimpezaEventualID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            Property(t => t.dtInicio).HasColumnName("dtInicio");
            Property(t => t.dtFim).HasColumnName("dtFim");
            Property(t => t.qtTintasUtilizados).HasColumnName("qtTintasUtilizados");
            Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.nmOutroLogradouro).HasColumnName("nmOutroLogradouro");
            Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
            Property(t => t.qtGaris).HasColumnName("qtGaris");

            // Relationships
            HasRequired(t => t.TBEnderecoBairro)
                .WithMany()
                .HasForeignKey(d => d.EnderecoBairroID);
            HasOptional(t => t.TBEnderecoLogradouro)
                .WithMany()
                .HasForeignKey(d => d.EnderecoLogradouroID);
            HasRequired(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
            //this.HasRequired(t => t.TBPrestadoraServico)
            //    .WithMany()
            //    .HasForeignKey(d => d.PrestadoraServicosID);
            HasRequired(t => t.TBRegiaoAdministrativa)
                .WithMany()
                .HasForeignKey(d => d.RegiaoAdministrativaID);

            HasOptional(x => x.TBLimpezaExecutada)
                .WithRequired(x => x.TBLimpezaEventual);

            HasMany(s => s.Equipamentos)
                .WithRequired(s => s.LimpezaEventual)
                .HasForeignKey(s => s.LimpezaEventualID);
        }
    }
}