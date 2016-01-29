using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class ListaGrupoAcessoVM
    {
        public int PermissaoId { get; set; }
        public int idModulo { get; set; }
        public string MenuPai { get; set; }
        public string MenuFilho { get; set; }
        public bool Consultar { get; set; }
        public bool Incluir { get; set; }
        public bool Alterar { get; set; }
        public bool Excluir { get; set; }
        public bool Imprimir { get; set; }
        public int Status { get; set; }

        internal static IList<ListaGrupoAcessoVM> ToView(ICollection<Proc_ReturnListaMenu> collection)
        {
            return collection.Select(x => ToView(x)).ToList();
        }

        internal static ListaGrupoAcessoVM ToView(Proc_ReturnListaMenu item)
        {
            return new ListaGrupoAcessoVM
            {
                PermissaoId = Convert.ToInt32(item.AspNetPermissaoId),
                idModulo = Convert.ToInt32(item.ModuloID),
                MenuPai = item.MenuPai,
                MenuFilho = item.MenuFilho,
                Consultar = (item.Consultar != null) && (Boolean) item.Consultar,
                Incluir = (item.Incluir != null) && (Boolean)item.Incluir,
                Alterar = (item.Alterar != null) && (Boolean)item.Alterar,
                Excluir = (item.Excluir != null) && (Boolean)item.Excluir,
                Imprimir = (item.Imprimir != null) && (Boolean)item.Imprimir,
                Status = 1
            };
        }
    }
    public class BuscaPerfilVM
    {
        public BuscaPerfilVM(AspNetPerfil x)
        {
            PerfilID = x.AspNetPerfilId;
            nmProgramacao = x.Nome;
            nmDescricao = x.Descricao;

        }

        public int PerfilID { get; set; }

        [Display(Name = "Grupo de Acesso")]
        public string nmProgramacao { get; set; }

        [Display(Name = "Descrção")]
        public string nmDescricao { get; set; }

    }
    public class GrupoAcessoVM
    {
        public GrupoAcessoVM()
        {
            ListaAcesso = new List<ListaGrupoAcessoVM>();
        }

        public string Btn { get; set; }
        public int PrefeituraID { get; set; }
        public int GrupoAcessoID { get; set; }
        
        [Display(Name = "Configure as permissões de acesso")]
        public IList<ListaGrupoAcessoVM> ListaAcesso { get; set; }

        [Display(Name = "Nome da Programação")]
        [StringLength(100)]
        public string nmProgramacao { get; set; }

        [Display(Name = "Descrição da Programação")]
        [StringLength(100)]
        public string Descricao { get; set; }

        internal static GrupoAcessoVM ToView(AspNetPerfil Dados)
        {
            return new GrupoAcessoVM
            {
                GrupoAcessoID = Dados.AspNetPerfilId,
                PrefeituraID = Convert.ToInt32(Dados.PrefeituraID),
                nmProgramacao = Dados.Nome,
                Descricao = Dados.Descricao
            };
        }
    
    }
}
