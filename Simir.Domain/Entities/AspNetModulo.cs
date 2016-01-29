using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public abstract class AspNetModulo
    {
        public int AspNetModuloId { get; set; }
        public int Nivel { get; set; }
        public string Display { get; set; }
        public bool bVisivelDisplay { get; set; }
        public int? ModuloPaiId { get; set; }
        public virtual AspNetModuloPai ModuloPai { get; set; }

        public int Ordem { get; set; }
        
        public ICollection<AspNetModulo> ToListAnemica()
        {
            var retorno = new List<AspNetModulo> {this};
            if (this is AspNetModuloPai)
            {
                foreach (var item in (this as AspNetModuloPai).ModuloFilhos)
                {
                    retorno.AddRange(item.ToListAnemica());
                }
                (this as AspNetModuloPai).ModuloFilhos = null;
            }
            return retorno;
        }
    }
}