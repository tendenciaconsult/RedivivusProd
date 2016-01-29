using System.ComponentModel.DataAnnotations;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels.ContratoVMs
{
    public class ContratoServicoVM
    {
        private bool v;

        public ContratoServicoVM()
        {
                
        }


        public ContratoServicoVM(TBServico x, bool v)
        {
            ID = x.ServicoID;
            Nome = x.nmServico;
            Status = v;
        }

        public int ID { get; set; }

        public string Nome { get; set; }

        public bool Status { get; set; }

    }
}