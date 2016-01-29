using System;
using System.IO;

namespace Simir.Domain.Entities
{
    public class TBGeradorMtr : TBArquivo
    {
        public TBGeradorMtr(int empresaID, string path, string fileName)
        {
            ArquivoID = 0;
            EmpresaGeradoraID = empresaID;
            dtMtr = DateTime.Now;
            Url = path;


            nmArquivo = "grmtr-" + empresaID.ToString("000000000") + dtMtr.Ticks + Path.GetExtension(fileName);
        }

        public TBGeradorMtr()
        {
            // TODO: Complete member initialization
        }

        public DateTime dtMtr { get; set; }
        public int EmpresaGeradoraID { get; set; }
        public virtual TBEmpresa EmpresaGeradora { get; set; }
    }
}