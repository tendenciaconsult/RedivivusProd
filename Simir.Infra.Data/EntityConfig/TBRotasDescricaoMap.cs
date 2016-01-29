using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBRotasDescricaoMap : EntityTypeConfiguration<TBRotasDescricao>
    {
        public TBRotasDescricaoMap()
        {
            // Primary Key
            HasKey(t => t.RotasDescricaoID);

            // Properties
            Property(t => t.nmDirecionamento)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("TBRotasDescricao");
            Property(t => t.RotasDescricaoID).HasColumnName("RotasDescricaoID");
            Property(t => t.RotasID).HasColumnName("RotasID");
            Property(t => t.ExtensaoPercorrida).HasColumnName("ExtensaoPercorrida");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.nmDirecionamento).HasColumnName("nmDirecionamento");
            Property(t => t.PEV).HasColumnName("PEV");
            Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");

            // Relationships
            HasOptional(t => t.TBEnderecoBairro)
                .WithMany()
                .HasForeignKey(d => d.EnderecoBairroID);
            HasOptional(t => t.TBEnderecoLogradouro)
                .WithMany()
                .HasForeignKey(d => d.EnderecoLogradouroID);
            HasOptional(t => t.TBRegiaoAdministrativa)
                .WithMany()
                .HasForeignKey(d => d.RegiaoAdministrativaID);

            HasOptional(t => t.TBRota)
                .WithMany(t => t.TBRotasDescricaos)
                .HasForeignKey(d => d.RotasID);
        }
    }
}