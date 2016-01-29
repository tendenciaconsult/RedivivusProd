using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBServicoFuncaoSubtituloMap : EntityTypeConfiguration<TBServicoFuncaoSubtitulo>
    {
        public TBServicoFuncaoSubtituloMap()
        {
            // Primary Key
            HasKey(t => t.ServicoFuncaoSubtituloID);

            // Properties
            Property(t => t.nmServicoFuncaoSubtitulo)
                .IsRequired()
                .HasMaxLength(100);
            

            // Relationships
            HasRequired(t => t.ServicoFuncaoTitulo)
                .WithMany() 
                .HasForeignKey(d => d.ServicoFuncaoTituloID);

            
        }
    }
}
