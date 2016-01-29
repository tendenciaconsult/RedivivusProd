using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduosColetadoItemMap : EntityTypeConfiguration<TBResiduosColetadoItem>
    {
        public TBResiduosColetadoItemMap()
        {
            this.HasKey(t => t.ResiduosColetadoItemID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TBResiduosColetadosItem");
            this.Property(t => t.ResiduosColetadoItemID).HasColumnName("ResiduosColetadosItemID");
            this.Property(t => t.ResiduosColetadoID).HasColumnName("ResiduosColetadosID");
            this.Property(t => t.ResiduoClassificadoID).HasColumnName("ResiduoClassificadoID");
            this.Property(t => t.emLitros).HasColumnName("emLitros");
            this.Property(t => t.qtResiduo).HasColumnName("qtResiduo");




            HasRequired(t => t.ResiduoClassificado)
                .WithMany()
                .HasForeignKey(d => d.ResiduoClassificadoID);

        }
    }
}
