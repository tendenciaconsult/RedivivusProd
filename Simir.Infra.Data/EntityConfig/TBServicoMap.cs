using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBServicoMap : EntityTypeConfiguration<TBServico>
    {
        public TBServicoMap()
        {
            // Primary Key
            HasKey(t => t.ServicoID);

            // Properties
            Property(t => t.nmServico)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBServicos");
        }
    }
}
