using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBContratoVeiculoMap : EntityTypeConfiguration<TBContratoVeiculo>
    {
        public TBContratoVeiculoMap()
        {
            // Primary Key
            HasKey(t => t.ContratoVeiculoID);


            // Properties
            Property(t => t.Tipo)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Placa)
                .IsRequired()
                .HasMaxLength(8);


            HasRequired(t => t.Contrato)
                .WithMany()
                .HasForeignKey(d => d.ContratoID);

        }
    }
}
