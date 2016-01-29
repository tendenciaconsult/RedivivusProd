using Simir.Domain.Entities;

namespace Simir.Domain.Helpers
{
    public abstract class DaPrefeitura
    {
        public int? PrefeituraID { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public bool bAtivo { get; set; }
    }
}