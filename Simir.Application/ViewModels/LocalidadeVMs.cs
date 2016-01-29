using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class LocalidadeIdexVM
    {
        public string Teste { get; set; }
    }

    public class EnderecoVM
    {
        [Key]
        public int EnderecoVMId { get; set; }

        [Required(ErrorMessage = "Digite o número")]
        [DisplayName("Número")]
        [StringLength(10)]
        public string Numero { get; set; }

        [DisplayName("Complemento")]
        [StringLength(40)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Digite o nome do Logradouro")]
        [DisplayName("Endereço")]
        [StringLength(100)]
        public string Endereco { get; set; }

        [DisplayName("CEP")]
        [InputMask("99999-999")]
        [RegularExpression(@"^(\d{5}-\d{3})?$", ErrorMessage = "CEP inválido")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Selecione um Estado")]
        [Display(Name = "UF")]
        [StringLength(6)]
        public string LocalidadeUfValor { get; set; }

        public string LocalidadeUfDescricao { get; set; }

        [Required(ErrorMessage = "Selecione um Bairro")]
        [DisplayName("Bairro")]
        public string LocalidadeBairroValor { get; set; }

        public string LocalidadeBairroDescricao { get; set; }

        [Required(ErrorMessage = "Seleione um Município")]
        [Display(Name = "Município")]
        [StringLength(40)]
        public string LocalidadeMunicipioValor { get; set; }

        public string LocalidadeMunicipioDescricao { get; set; }

        internal static EnderecoVM ToView(TBEndereco tBEndereco)
        {
            return new EnderecoVM
            {
                LocalidadeUfValor =
                    tBEndereco.TBEnderecoBairro.TBEnderecoCidade.TBEnderecoEstado.EnderecoEstadoID.ToString(),
                LocalidadeUfDescricao = tBEndereco.TBEnderecoBairro.TBEnderecoCidade.TBEnderecoEstado.Abraviacao,
                LocalidadeMunicipioValor = tBEndereco.TBEnderecoBairro.TBEnderecoCidade.EnderecoCidadeID.ToString(),
                LocalidadeMunicipioDescricao = tBEndereco.TBEnderecoBairro.TBEnderecoCidade.nmCidade,
                Endereco = tBEndereco.nmLogradouro,
                LocalidadeBairroValor = tBEndereco.TBEnderecoBairro.EnderecoBairroID.ToString(),
                LocalidadeBairroDescricao = tBEndereco.TBEnderecoBairro.nmBairro,
                Cep = tBEndereco.CEP,
                Complemento = tBEndereco.Complemento,
                EnderecoVMId = tBEndereco.EnderecoID,
                Numero = tBEndereco.Numero
            };
        }

        internal static EnderecoVM ToView(TBEnderecoLogradouro tBEnderecoLogradouro)
        {
            return new EnderecoVM
            {
                Cep = tBEnderecoLogradouro.CEP,
                LocalidadeUfValor =
                    tBEnderecoLogradouro.TBEnderecoBairro.TBEnderecoCidade.TBEnderecoEstado.EnderecoEstadoID.ToString(),
                LocalidadeUfDescricao =
                    tBEnderecoLogradouro.TBEnderecoBairro.TBEnderecoCidade.TBEnderecoEstado.Abraviacao,
                LocalidadeMunicipioValor =
                    tBEnderecoLogradouro.TBEnderecoBairro.TBEnderecoCidade.EnderecoCidadeID.ToString(),
                LocalidadeMunicipioDescricao = tBEnderecoLogradouro.TBEnderecoBairro.TBEnderecoCidade.nmCidade,
                Endereco = tBEnderecoLogradouro.nmLogradouro,
                LocalidadeBairroValor = tBEnderecoLogradouro.TBEnderecoBairro.EnderecoBairroID.ToString(),
                LocalidadeBairroDescricao = tBEnderecoLogradouro.TBEnderecoBairro.nmBairro
            };
        }

        internal static TBEndereco ToModel(EnderecoVM enderecoVM)
        {
            return new TBEndereco
            {
                CEP = enderecoVM.Cep,
                Complemento = enderecoVM.Complemento,
                nmLogradouro = enderecoVM.Endereco,
                Numero = enderecoVM.Numero,
                EnderecoBairroID = int.Parse(enderecoVM.LocalidadeBairroValor),
                EnderecoCidadeID = int.Parse(enderecoVM.LocalidadeMunicipioValor),
                EnderecoEstadoID = int.Parse(enderecoVM.LocalidadeUfValor)
            };
        }

        public static string ValidaCep(string cep)
        {
            if (cep.Length != 9)
            {
                throw new ArgumentException("cep", MensagensErro.cepInvalido);
            }
            return cep.Substring(0, 5) + cep.Substring(6, 3);
        }

        public static string ToViewSimples(TBEndereco tBEndereco)
        {
            return String.Format("{0}, nº {1}, {2} - {3} - {4} - {5} - CEP: {6}",
                tBEndereco.nmLogradouro,
                tBEndereco.Numero,
                tBEndereco.Complemento,
                tBEndereco.TBEnderecoBairro.nmBairro,
                tBEndereco.TBEnderecoCidade.nmCidade,
                tBEndereco.TBEnderecoEstado.Abraviacao,
                tBEndereco.CEP
                );
        }
    }


    public class LogradouroVM
    {
        public LogradouroVM()
        {
            LocalidadeUfValor = "-1";
            LocalidadeUfDescricao = "ES";
        }

        [Key]
        public int LogradouroVMId { get; set; }

        [Required(ErrorMessage = "Selecione um tipo")]
        [Display(Name = "Tipo")]
        [StringLength(6)]
        public string LocalidadeLogradouroTipoValor { get; set; }

        public string LocalidadeLogradouroTipoDescricao { get; set; }

        [Required(ErrorMessage = "Digite o nome do Logradouro")]
        [DisplayName("Logradouro")]
        [StringLength(50)]
        public string Nome { get; set; }

        [DisplayName("CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Selecione um Estado")]
        [Display(Name = "UF")]
        [StringLength(3)]
        public string LocalidadeUfValor { get; set; }

        public string LocalidadeUfDescricao { get; set; }

        [Required(ErrorMessage = "Digite o Bairro")]
        [DisplayName("Bairro")]
        public string nmBairro { get; set; }

        [Required(ErrorMessage = "Seleione um Município")]
        [Display(Name = "Município")]
        [StringLength(40)]
        public string LocalidadeMunicipioValor { get; set; }

        public string LocalidadeMunicipioDescricao { get; set; }
    }

    public class EnderecoDetalheVM
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
    }
}