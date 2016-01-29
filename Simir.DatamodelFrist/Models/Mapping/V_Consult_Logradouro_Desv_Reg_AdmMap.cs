using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class V_Consult_Logradouro_Desv_Reg_AdmMap : EntityTypeConfiguration<V_Consult_Logradouro_Desv_Reg_Adm>
    {
        public V_Consult_Logradouro_Desv_Reg_AdmMap()
        {
            // Primary Key
            this.HasKey(t => new { t.nmBairro, t.nmLogradouro, t.EnderecoCidadeID, t.RegiaoAdministrativaID });

            // Properties
            this.Property(t => t.nmBairro)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.nmLogradouro)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.EnderecoCidadeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RegiaoAdministrativaID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("V_Consult_Logradouro_Desv_Reg_Adm");
            this.Property(t => t.nmBairro).HasColumnName("nmBairro");
            this.Property(t => t.nmLogradouro).HasColumnName("nmLogradouro");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.EnderecoCidadeID).HasColumnName("EnderecoCidadeID");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
        }
    }
}
