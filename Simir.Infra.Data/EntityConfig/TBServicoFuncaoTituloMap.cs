using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBServicoFuncaoTituloMap : EntityTypeConfiguration<TBServicoFuncaoTitulo>
    {
        public TBServicoFuncaoTituloMap()
        {
            // Primary Key
            HasKey(t => t.ServicoFuncaoTituloID);

            // Properties
            Property(t => t.nmServicoFuncaoTitulo)
                .IsRequired()
                .HasMaxLength(100);
            
        }
    }
}
