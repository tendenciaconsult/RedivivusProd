using System;

namespace Simir.Domain.Helpers
{
    public abstract class Historico<TPrincipal>
    {
        public DateTime dtAlteracao { get; set; }
        public string UserId { get; set; }
        public abstract void To(TPrincipal principal);
    }
}