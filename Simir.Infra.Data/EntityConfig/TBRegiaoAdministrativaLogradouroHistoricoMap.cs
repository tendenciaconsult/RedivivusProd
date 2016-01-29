using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBRegiaoAdministrativaLogradouroHistoricoMap :
        EntityTypeConfiguration<TBRegiaoAdministrativaLogradouroHistorico>
    {
        public TBRegiaoAdministrativaLogradouroHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.RegiaoAdministrativaLogradouroHistoricoID);

            // Properties
            Property(t => t.nmOutroPavimento)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBRegiaoAdministrativaLogradouroHistorico");
            Property(t => t.RegiaoAdministrativaLogradouroHistoricoID)
                .HasColumnName("RegiaoAdministrativaLogradouroHistoricoID");
            Property(t => t.RegiaoAdministrativaLogradouroID).HasColumnName("RegiaoAdministrativaLogradouroID");
            Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            Property(t => t.qtSargetas).HasColumnName("qtSargetas");
            Property(t => t.bTotalmenteAsfaltado).HasColumnName("bTotalmenteAsfaltado");
            Property(t => t.qtSemPavimento).HasColumnName("qtSemPavimento");
            Property(t => t.qtAsfalto).HasColumnName("qtAsfalto");
            Property(t => t.qtBloco).HasColumnName("qtBloco");
            Property(t => t.nmOutroPavimento).HasColumnName("nmOutroPavimento");
            Property(t => t.qtOutroPavimento).HasColumnName("qtOutroPavimento");
            Property(t => t.qtExtensaoTotal).HasColumnName("qtExtensaoTotal");
            Property(t => t.qtBocaLobo).HasColumnName("qtBocaLobo");
            Property(t => t.qtLarguraVia).HasColumnName("qtLarguraVia");
            Property(t => t.bRealizaLimpezaMecanica).HasColumnName("bRealizaLimpezaMecanica");
            Property(t => t.bRealizaLavagem).HasColumnName("bRealizaLavagem");
            Property(t => t.bPossuiAreaVerde).HasColumnName("bPossuiAreaVerde");
            Property(t => t.bLogradouroArborizado).HasColumnName("bLogradouroArborizado");
            Property(t => t.bPraca).HasColumnName("bPraca");
            Property(t => t.bParque).HasColumnName("bParque");
            Property(t => t.qtArvores).HasColumnName("qtArvores");
        }
    }
}