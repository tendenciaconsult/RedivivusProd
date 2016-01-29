using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBRotasDescricaoMap : EntityTypeConfiguration<TBRotasDescricao>
    {
        public TBRotasDescricaoMap()
        {
            // Primary Key
            this.HasKey(t => t.RotasDescricaoID);

            // Properties
            this.Property(t => t.nmDirecionamento)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TBRotasDescricao");
            this.Property(t => t.RotasDescricaoID).HasColumnName("RotasDescricaoID");
            this.Property(t => t.RotasID).HasColumnName("RotasID");
            this.Property(t => t.ExtensaoPercorrida).HasColumnName("ExtensaoPercorrida");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.nmDirecionamento).HasColumnName("nmDirecionamento");
            this.Property(t => t.PEV).HasColumnName("PEV");
            this.Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            this.Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");

            // Relationships
            this.HasOptional(t => t.TBEnderecoBairro)
                .WithMany(t => t.TBRotasDescricaos)
                .HasForeignKey(d => d.EnderecoBairroID);
            this.HasOptional(t => t.TBEnderecoLogradouro)
                .WithMany(t => t.TBRotasDescricaos)
                .HasForeignKey(d => d.EnderecoLogradouroID);
            this.HasOptional(t => t.TBRegiaoAdministrativa)
                .WithMany(t => t.TBRotasDescricaos)
                .HasForeignKey(d => d.RegiaoAdministrativaID);
            this.HasOptional(t => t.TBRota)
                .WithMany(t => t.TBRotasDescricaos)
                .HasForeignKey(d => d.RotasID);

        }
    }
}
