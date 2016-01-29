using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class AspNetModuloPai : AspNetModulo
    {
        public virtual ICollection<AspNetModulo> ModuloFilhos { get; set; }

        public void DescerUmNivel()
        {
            foreach (var filho in ModuloFilhos)
            {
                //if (filho.Nivel > 0) throw new Exception("Você adicionou algum modulo que já é sub-nível de outro");

                filho.Nivel++;

                if (filho is AspNetModuloPai)
                    (filho as AspNetModuloPai).DescerUmNivel();
            }
        }

        public void SobeUmNivel()
        {
            foreach (var filho in ModuloFilhos)
            {
                //if (filho.Nivel > 0) throw new Exception("Você adicionou algum modulo que já é sub-nível de outro");

                filho.Nivel--;

                if (filho is AspNetModuloPai)
                    (filho as AspNetModuloPai).SobeUmNivel();
            }
        }
    }
}