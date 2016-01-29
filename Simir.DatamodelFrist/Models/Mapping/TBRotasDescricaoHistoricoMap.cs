using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBRotasDescricaoHistoricoMap : EntityTypeConfiguration<TBRotasDescricaoHistorico>
    {
        public TBRotasDescricaoHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.RotasDescricaoHistoricoID);

            // Properties
            this.Property(t => t.UserID)
                .HasMaxLength(100);

            this.Property(t => t.nmDirecionamento)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TBRotasDescricaoHistorico");
            this.Property(t => t.RotasDescricaoHistoricoID).HasColumnName("RotasDescricaoHistoricoID");
            this.Property(t => t.RotasDescricaoID).HasColumnName("RotasDescricaoID");
            this.Property(t => t.RotasID).HasColumnName("RotasID");
            this.Property(t => t.ExtensaoPercorrida).HasColumnName("ExtensaoPercorrida");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.nmDirecionamento).HasColumnName("nmDirecionamento");
            this.Property(t => t.PEV).HasColumnName("PEV");
            this.Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            this.Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
        }
    }
}
