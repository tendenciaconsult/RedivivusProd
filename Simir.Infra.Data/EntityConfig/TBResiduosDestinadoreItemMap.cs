using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduosDestinadoreItemMap: EntityTypeConfiguration<TBResiduosDestinadoreItem>
    {
        public TBResiduosDestinadoreItemMap()
        {
            // Primary Key
            HasKey(t => t.ResiduosDestinadoreItemID);

            this.ToTable("TBResiduosDestinadoresItem");
            this.Property(t => t.ResiduosDestinadoreItemID).HasColumnName("ResiduosDestinadoresItemID");
            this.Property(t => t.ResiduosDestinadorID).HasColumnName("ResiduosDestinadoresID");
            this.Property(t => t.ResiduoClassificadoID).HasColumnName("ResiduoClassificadoID");
            this.Property(t => t.emLitros).HasColumnName("emLitros");
            this.Property(t => t.qtResiduo).HasColumnName("qtResiduo");





            HasRequired(t => t.ResiduoClassificado)
                .WithMany()
                .HasForeignKey(d => d.ResiduoClassificadoID);

        }
    }
}
