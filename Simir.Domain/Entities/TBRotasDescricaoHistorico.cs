using System;
using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBRotasDescricaoHistorico : Historico<TBRotasDescricao>
    {
        public int RotasDescricaoHistoricoID { get; set; }
        public int? RotasDescricaoID { get; set; }
        public int? RotasID { get; set; }
        public int? ExtensaoPercorrida { get; set; }
        public bool bAtivo { get; set; }
        public string nmDirecionamento { get; set; }
        public bool PEV { get; set; }
        public int? EnderecoBairroID { get; set; }
        public int? EnderecoLogradouroID { get; set; }
        public int? RegiaoAdministrativaID { get; set; }

        public override void To(TBRotasDescricao pricipal)
        {
            RotasDescricaoID = pricipal.RotasDescricaoID;
            RotasID = pricipal.RotasID;
            nmDirecionamento = pricipal.nmDirecionamento;
            ExtensaoPercorrida = Convert.ToInt32(pricipal.ExtensaoPercorrida);
            bAtivo = pricipal.bAtivo;
            PEV = pricipal.PEV;
            EnderecoBairroID = pricipal.EnderecoBairroID;
            EnderecoLogradouroID = pricipal.EnderecoLogradouroID;
            RegiaoAdministrativaID = pricipal.RegiaoAdministrativaID;

        }
    }
}
