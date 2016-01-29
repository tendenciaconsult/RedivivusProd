using System.Collections.Generic;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class ControllerVM
    {
        public string ControllerNome { get; set; }
        public string Display { get; set; }

        internal static ControllerVM ToDomain(AspNetController item)
        {
            return new ControllerVM
            {
                ControllerNome = item.Nome,
                Display = item.Display
            };
        }
    }

    public class ActionVM : ModuloVM
    {
        public string ControllerNome { get; set; }
        public string ActionNome { get; set; }

        internal static ActionVM ToDomain(AspNetAction item)
        {
            return new ActionVM
            {
                ActionNome = item.Nome,
                ControllerNome = item.AspNetController.Nome,
                Display = item.Display,
                ModuloId = item.AspNetModuloId,
                Nivel = item.Nivel
            };
        }

        internal static ICollection<ActionVM> ToDomain(ICollection<AspNetModulo> collection)
        {
            var actionsVM = new List<ActionVM>();

            if (collection == null) return actionsVM;

            foreach (var item in collection)
            {
                if (item is AspNetAction)
                    actionsVM.Add(ToDomain((AspNetAction) item));
            }

            return actionsVM;
        }
    }

    public class PerfilVM
    {
        public int SimirPerfilId { get; set; }
        //o mesmo que ClaimType
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<ModuloVM> SimirModulos { get; set; }

        internal static PerfilVM ToDomain(AspNetPerfil item)
        {
            if (item == null) return new PerfilVM();
            return new PerfilVM
            {
                SimirPerfilId = item.AspNetPerfilId,
                Nome = item.Nome,
                Descricao = item.Descricao,
                SimirModulos = ModuloVM.ToDomain(item.SimirModulos)
            };
        }

        internal static ICollection<PerfilVM> ToDomain(ICollection<AspNetPerfil> collection)
        {
            var perfisVM = new List<PerfilVM>();

            if (collection == null) return perfisVM;

            foreach (var item in collection)
            {
                perfisVM.Add(ToDomain(item));
            }

            return perfisVM;
        }
    }

    public class ModuloVM
    {
        public int ModuloId { get; set; }
        public int Nivel { get; set; }
        public string Display { get; set; }
        public int FlagTipo { get; set; } //0:modulo 1:Pai 2:action

        public string DisplayToListbox
        {
            get
            {
                var retorno = "";
                for (var i = 0; i < Nivel; i++)
                    retorno += " | ";
                if (FlagTipo == 1)
                    retorno += " + ";
                if (FlagTipo == 2)
                    retorno += (this as ActionVM).ControllerNome;

                retorno += Display;
                return retorno;
            }
        }

        internal static ICollection<ModuloVM> ToDomain(ICollection<AspNetModulo> collection)
        {
            var listModulos = new List<ModuloVM>();
            if (collection == null) return listModulos;

            foreach (var item in collection)
            {
                listModulos.Add(ToDomain(item));
            }
            return listModulos;
        }

        internal static ModuloVM ToDomain(AspNetModulo item)
        {
            if (item is AspNetModuloPai)
            {
                var paiVM = ModuloPaiVM.ToDomain(item as AspNetModuloPai);
                paiVM.FlagTipo = 1;
                return paiVM;
            }
            var actionVM = ActionVM.ToDomain(item as AspNetAction);
            actionVM.FlagTipo = 2;
            return actionVM;
        }
    }

    public class ModuloPaiVM : ModuloVM
    {
        public virtual ICollection<ModuloVM> Filhos { get; set; }

        internal static ModuloPaiVM ToDomain(AspNetModuloPai modulo)
        {
            return new ModuloPaiVM
            {
                ModuloId = modulo.AspNetModuloId,
                Nivel = modulo.Nivel,
                Display = modulo.Display,
                Filhos = ToDomain(modulo.ModuloFilhos)
            };
        }
    }
}