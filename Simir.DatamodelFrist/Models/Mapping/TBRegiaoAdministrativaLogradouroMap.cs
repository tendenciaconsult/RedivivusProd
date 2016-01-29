using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBRegiaoAdministrativaLogradouroMap : EntityTypeConfiguration<TBRegiaoAdministrativaLogradouro>
    {
        public TBRegiaoAdministrativaLogradouroMap()
        {
            // Primary Key
            this.HasKey(t => t.RegiaoAdministrativaLogradouroID);

            // Properties
            this.Property(t => t.nmOutroPavimento)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBRegiaoAdministrativaLogradouro");
            this.Property(t => t.RegiaoAdministrativaLogradouroID).HasColumnName("RegiaoAdministrativaLogradouroID");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            this.Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            this.Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            this.Property(t => t.qtSargetas).HasColumnName("qtSargetas");
            this.Property(t => t.bTotalmenteAsfaltado).HasColumnName("bTotalmenteAsfaltado");
            this.Property(t => t.qtSemPavimento).HasColumnName("qtSemPavimento");
            this.Property(t => t.qtAsfalto).HasColumnName("qtAsfalto");
            this.Property(t => t.qtBloco).HasColumnName("qtBloco");
            this.Property(t => t.nmOutroPavimento).HasColumnName("nmOutroPavimento");
            this.Property(t => t.qtOutroPavimento).HasColumnName("qtOutroPavimento");
            this.Property(t => t.qtExtensaoTotal).HasColumnName("qtExtensaoTotal");
            this.Property(t => t.qtBocaLobo).HasColumnName("qtBocaLobo");
            this.Property(t => t.qtLarguraVia).HasColumnName("qtLarguraVia");
            this.Property(t => t.bRealizaLimpezaMecanica).HasColumnName("bRealizaLimpezaMecanica");
            this.Property(t => t.bRealizaLavagem).HasColumnName("bRealizaLavagem");
            this.Property(t => t.bPossuiAreaVerde).HasColumnName("bPossuiAreaVerde");
            this.Property(t => t.bLogradouroArborizado).HasColumnName("bLogradouroArborizado");
            this.Property(t => t.bPraca).HasColumnName("bPraca");
            this.Property(t => t.bParque).HasColumnName("bParque");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.qtArvores).HasColumnName("qtArvores");

            // Relationships
            this.HasOptional(t => t.TBEnderecoBairro)
                .WithMany(t => t.TBRegiaoAdministrativaLogradouroes)
                .HasForeignKey(d => d.EnderecoBairroID);
            this.HasOptional(t => t.TBEnderecoLogradouro)
                .WithMany(t => t.TBRegiaoAdministrativaLogradouroes)
                .HasForeignKey(d => d.EnderecoLogradouroID);
            this.HasOptional(t => t.TBRegiaoAdministrativa)
                .WithMany(t => t.TBRegiaoAdministrativaLogradouroes)
                .HasForeignKey(d => d.RegiaoAdministrativaID);

        }
    }
}
