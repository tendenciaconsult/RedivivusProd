using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBContratoEquipamentoMap : EntityTypeConfiguration<TBContratoEquipamento>
    {
        public TBContratoEquipamentoMap()
        {
            // Primary Key
            HasKey(t => t.ContratoEquipamentoID);


            // Properties
            Property(t => t.Tipo)
                .IsRequired()
                .HasMaxLength(100);


            HasRequired(t => t.Contrato)
                .WithMany()
                .HasForeignKey(d => d.ContratoID);

        }
    }
}
