using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduosGeradoItemMap : EntityTypeConfiguration<TBResiduosGeradoItem>
    {

        public TBResiduosGeradoItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduosGeradoItemID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TBResiduosGeradosItem");
            this.Property(t => t.ResiduosGeradoItemID).HasColumnName("ResiduosGeradosItemID");
            this.Property(t => t.ResiduosGeradoID).HasColumnName("ResiduosGeradosID");
            this.Property(t => t.ResiduoClassificadoID).HasColumnName("ResiduoClassificadoID");
            this.Property(t => t.emLitros).HasColumnName("emLitros");
            this.Property(t => t.qtResiduo).HasColumnName("qtResiduo");




           
            HasRequired(t => t.ResiduoClassificado)
                .WithMany()
                .HasForeignKey(d => d.ResiduoClassificadoID);
        }
    }
}
