using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBFaleConoscoMap : EntityTypeConfiguration<TBFaleConosco>
    {
        public TBFaleConoscoMap()
        {
            // Primary Key
            this.HasKey(t => t.FaleConoscoID);

            // Properties
            this.Property(t => t.UserID)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.nmSolicitante)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.EmailContato)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.TelefoneContato)
                .HasMaxLength(30);

            this.Property(t => t.nmAssunto)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Mensagem)
                .IsRequired()
                .HasMaxLength(8000);

            // Table & Column Mappings
            this.ToTable("TBFaleConosco");
            this.Property(t => t.FaleConoscoID).HasColumnName("FaleConoscoID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.nmSolicitante).HasColumnName("nmSolicitante");
            this.Property(t => t.EmailContato).HasColumnName("EmailContato");
            this.Property(t => t.TelefoneContato).HasColumnName("TelefoneContato");
            this.Property(t => t.AssuntoID).HasColumnName("AssuntoID");
            this.Property(t => t.nmAssunto).HasColumnName("nmAssunto");
            this.Property(t => t.Mensagem).HasColumnName("Mensagem");

            // Relationships
            this.HasRequired(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);

        }
    }
}
