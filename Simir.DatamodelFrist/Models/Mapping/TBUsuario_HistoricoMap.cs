using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBUsuario_HistoricoMap : EntityTypeConfiguration<TBUsuario_Historico>
    {
        public TBUsuario_HistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.usuario_HistoricoID);

            // Properties
            this.Property(t => t.nmUsuario)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Cargo)
                .HasMaxLength(100);

            this.Property(t => t.CPF)
                .HasMaxLength(50);

            this.Property(t => t.matricula)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Celular)
                .HasMaxLength(20);

            this.Property(t => t.UserId)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBUsuario_Historico");
            this.Property(t => t.usuario_HistoricoID).HasColumnName("usuario_HistoricoID");
            this.Property(t => t.usuarioID).HasColumnName("usuarioID");
            this.Property(t => t.nmUsuario).HasColumnName("nmUsuario");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Cargo).HasColumnName("Cargo");
            this.Property(t => t.CPF).HasColumnName("CPF");
            this.Property(t => t.matricula).HasColumnName("matricula");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Celular).HasColumnName("Celular");
            this.Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
        }
    }
}
