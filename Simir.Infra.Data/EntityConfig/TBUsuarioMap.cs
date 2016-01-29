using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBUsuarioMap : EntityTypeConfiguration<TBUsuario>
    {
        public TBUsuarioMap()
        {
            // Primary Key
            HasKey(t => t.usuarioID);

            // Properties
            Property(t => t.nmUsuario)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Cargo)
                .HasMaxLength(100);

            Property(t => t.CPF)
                .HasMaxLength(50);

            Property(t => t.matricula)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Celular)
                .HasMaxLength(20);

            // Table & Column Mappings
            ToTable("TBUsuario");
            Property(t => t.usuarioID).HasColumnName("usuarioID");
            Property(t => t.nmUsuario).HasColumnName("nmUsuario");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.Cargo).HasColumnName("Cargo");
            Property(t => t.CPF).HasColumnName("CPF");
            Property(t => t.matricula).HasColumnName("matricula");
            Property(t => t.Telefone).HasColumnName("Telefone");
            Property(t => t.Celular).HasColumnName("Celular");
            Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");

            // Relationships
            //this.HasOptional(t => t.TBEndereco).WithMany(t => t.TBUsuarios) .HasForeignKey(d => d.EnderecoID);
            HasOptional(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
        }
    }
}