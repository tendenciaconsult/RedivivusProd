using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBSecretariasResponsabilidades_HistoricoMap : EntityTypeConfiguration<TBSecretariasResponsabilidades_Historico>
    {
        public TBSecretariasResponsabilidades_HistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.SecretariasResponsabilidades_HistoricoID);

            // Properties
            this.Property(t => t.nmOutros)
                .HasMaxLength(255);

            this.Property(t => t.UserId)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBSecretariasResponsabilidades_Historico");
            this.Property(t => t.SecretariasResponsabilidades_HistoricoID).HasColumnName("SecretariasResponsabilidades_HistoricoID");
            this.Property(t => t.SecretariasResponsabilidadesID).HasColumnName("SecretariasResponsabilidadesID");
            this.Property(t => t.ResponsabilidadesID).HasColumnName("ResponsabilidadesID");
            this.Property(t => t.SecretariaID).HasColumnName("SecretariaID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.nmOutros).HasColumnName("nmOutros");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
