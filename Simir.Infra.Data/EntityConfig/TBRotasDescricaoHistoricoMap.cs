using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBRotasDescricaoHistoricoMap : EntityTypeConfiguration<TBRotasDescricaoHistorico>
    {
        public TBRotasDescricaoHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.RotasDescricaoHistoricoID);

            // Properties
            Property(t => t.UserId)
                .HasMaxLength(100);

            Property(t => t.nmDirecionamento)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("TBRotasDescricaoHistorico");
            Property(t => t.RotasDescricaoHistoricoID).HasColumnName("RotasDescricaoHistoricoID");
            Property(t => t.RotasDescricaoID).HasColumnName("RotasDescricaoID");
            Property(t => t.RotasID).HasColumnName("RotasID");
            Property(t => t.ExtensaoPercorrida).HasColumnName("ExtensaoPercorrida");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserID");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.nmDirecionamento).HasColumnName("nmDirecionamento");
            Property(t => t.PEV).HasColumnName("PEV");
            Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
        }
    }
}