using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBRegiaoAdministrativaHistoricoMap : EntityTypeConfiguration<TBRegiaoAdministrativaHistorico>
    {
        public TBRegiaoAdministrativaHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.RegiaoAdministrativaHistoricoID);

            // Properties
            Property(t => t.nmRegiaoAdministrativa)
                .HasMaxLength(255);


            // Table & Column Mappings
            ToTable("TBRegiaoAdministrativaHistorico");
            Property(t => t.RegiaoAdministrativaHistoricoID).HasColumnName("RegiaoAdministrativaHistoricoID");
            Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.nmRegiaoAdministrativa).HasColumnName("nmRegiaoAdministrativa");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
        }
    }
}