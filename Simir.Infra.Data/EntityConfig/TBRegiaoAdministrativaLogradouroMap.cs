using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBRegiaoAdministrativaLogradouroMap : EntityTypeConfiguration<TBRegiaoAdministrativaLogradouro>
    {
        public TBRegiaoAdministrativaLogradouroMap()
        {
            // Primary Key
            HasKey(t => t.RegiaoAdministrativaLogradouroID);

            // Properties
            Property(t => t.nmOutroPavimento)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBRegiaoAdministrativaLogradouro");
            Property(t => t.RegiaoAdministrativaLogradouroID).HasColumnName("RegiaoAdministrativaLogradouroID");
            Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
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

            // Relationships
            HasOptional(t => t.TBEnderecoBairro)
                .WithMany()
                .HasForeignKey(d => d.EnderecoBairroID);
            HasOptional(t => t.TBEnderecoLogradouro)
                .WithMany()
                .HasForeignKey(d => d.EnderecoLogradouroID);
            HasOptional(t => t.TBRegiaoAdministrativa)
                .WithMany(t => t.TBRegiaoAdministrativaLogradouroes)
                .HasForeignKey(d => d.RegiaoAdministrativaID);
        }
    }
}