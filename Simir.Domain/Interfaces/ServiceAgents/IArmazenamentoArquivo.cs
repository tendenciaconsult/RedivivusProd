using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.ServiceAgents
{
    public interface IArmazenamentoArquivo
    {
        Task UploadArquivo(TBArquivo arquivo,string pasta, Stream inputStream);
        Task<Stream> DownloadArquivo(string nmArquivo, string pasta);
        Task DeleteArquivo(string nmArquivo, string pasta);
    }
}
