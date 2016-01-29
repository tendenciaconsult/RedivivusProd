using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBRegiaoAdministrativaHistoricoMap : EntityTypeConfiguration<TBRegiaoAdministrativaHistorico>
    {
        public TBRegiaoAdministrativaHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.RegiaoAdministrativaHistoricoID);

            // Properties
            this.Property(t => t.nmRegiaoAdministrativa)
                .HasMaxLength(255);

            this.Property(t => t.UserID)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBRegiaoAdministrativaHistorico");
            this.Property(t => t.RegiaoAdministrativaHistoricoID).HasColumnName("RegiaoAdministrativaHistoricoID");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.nmRegiaoAdministrativa).HasColumnName("nmRegiaoAdministrativa");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
        }
    }
}
