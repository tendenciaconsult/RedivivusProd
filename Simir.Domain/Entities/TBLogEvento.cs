using System;

namespace Simir.Domain.Entities
{
    public class TBLogEvento
    {
        public int LogEventosID { get; set; }
        public string UserId { get; set; }
        public string nmUsuario { get; set; }
        public DateTime dtDataAcao { get; set; }
        public string Acao { get; set; }
        public int? PrefeituraID { get; set; }
        public virtual TBPrefeitura Prefeitura { get; set; }

        internal static TBLogEvento Novo(AspNetUser user, DateTime dt, string acao)
        {
            return new TBLogEvento
            {
                UserId = user.Id,
                nmUsuario = user.TBUsuario.nmUsuario,
                dtDataAcao = dt,
                PrefeituraID = user.TBUsuario.PrefeituraID,
                Acao = acao
            };
        }
    }
}