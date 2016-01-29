using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduoClassificadoMap : EntityTypeConfiguration<TBResiduoClassificado>
    {
        public TBResiduoClassificadoMap()
        {
            HasKey(t => t.ResiduoClassificadoID);

            HasRequired(t => t.Lista)
                .WithMany()
                .HasForeignKey(d => d.ResiduoListaID);

            HasRequired(t => t.Atividade)
                .WithMany(x => x.Residuos)
                .HasForeignKey(d => d.ResiduoAtividadeID);

            HasRequired(t => t.Classe)
                .WithMany()
                .HasForeignKey(d => d.ResiduoClasseID);

            HasRequired(t => t.Residuo)
                .WithMany()
                .HasForeignKey(d => d.ResiduoID);
        }
    }
}