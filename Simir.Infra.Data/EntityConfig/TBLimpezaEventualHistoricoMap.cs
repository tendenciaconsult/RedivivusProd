using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBLimpezaEventualHistoricoMap : EntityTypeConfiguration<TBLimpezaEventualHistorico>
    {
        public TBLimpezaEventualHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.LimpezaEventualHistoricoID);

            // Properties
            Property(t => t.nmOutroLogradouro)
                .HasMaxLength(255);

            Property(t => t.nmProgramacao)
                .HasMaxLength(255);


            // Table & Column Mappings
            ToTable("TBLimpezaEventualHistorico");
            Property(t => t.LimpezaEventualHistoricoID).HasColumnName("LimpezaEventualHistoricoID");
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
        }
    }
}