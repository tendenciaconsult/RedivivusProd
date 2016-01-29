using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBUsuario_HistoricoMap : EntityTypeConfiguration<TBUsuario_Historico>
    {
        public TBUsuario_HistoricoMap()
        {
            // Primary Key
            HasKey(t => t.usuario_HistoricoID);

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
        }
    }
}