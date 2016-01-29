using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBSecretaria_HistoricoMap : EntityTypeConfiguration<TBSecretaria_Historico>
    {
        public TBSecretaria_HistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.Secretaria_HistoricoID);

            // Properties
            this.Property(t => t.nmSecretaria)
                .HasMaxLength(255);

            this.Property(t => t.nmSecretario)
                .HasMaxLength(255);

            this.Property(t => t.Site)
                .HasMaxLength(255);

            this.Property(t => t.Telefone1)
                .HasMaxLength(255);

            this.Property(t => t.Telefone2)
                .HasMaxLength(255);

            this.Property(t => t.Email)
                .HasMaxLength(255);

            this.Property(t => t.UserId)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBSecretaria_Historico");
            this.Property(t => t.Secretaria_HistoricoID).HasColumnName("Secretaria_HistoricoID");
            this.Property(t => t.SecretariaID).HasColumnName("SecretariaID");
            this.Property(t => t.nmSecretaria).HasColumnName("nmSecretaria");
            this.Property(t => t.nmSecretario).HasColumnName("nmSecretario");
            this.Property(t => t.Site).HasColumnName("Site");
            this.Property(t => t.Telefone1).HasColumnName("Telefone1");
            this.Property(t => t.Telefone2).HasColumnName("Telefone2");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
