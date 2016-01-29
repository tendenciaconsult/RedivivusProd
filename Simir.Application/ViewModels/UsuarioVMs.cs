using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;
using System.Web.Mvc;

namespace Simir.Application.ViewModels
{
    public class UsuarioBasicoVM
    {
        public UsuarioBasicoVM()
        {
        }

        public UsuarioBasicoVM(TBUsuario usuario)
        {
            Id = usuario.usuarioID;
            Email = usuario.Email;
            Nome = usuario.nmUsuario;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string[] Funcoes { get; set; }

        internal static ICollection<UsuarioBasicoVM> ToDomain(ICollection<AspNetUser> listUser)
        {
            var usuarios = new List<UsuarioBasicoVM>();
            if (listUser == null) return usuarios;
            foreach (var item in listUser)
            {
                usuarios.Add(ToDomain(item));
            }
            return usuarios;
        }

        internal static UsuarioBasicoVM ToDomain(AspNetUser item)
        {
            return new UsuarioBasicoVM();
        }
    }

    public class UsuarioAutoEditVM
    {
        public UsuarioAutoEditVM()
        {
            Endereco = new EnderecoVM();
        }

        public UsuarioAutoEditVM(TBUsuario usuario)
        {
            Id = usuario.usuarioID;
            NomeUsuario = usuario.nmUsuario;
            Email = usuario.Email;
            EmailConfirme = usuario.Email;
            Cargo = usuario.Cargo;
            CPF = usuario.CPF;
            matricula = usuario.matricula;
            Telefone = usuario.Telefone;
            Celular = usuario.Celular;
            Endereco = EnderecoVM.ToView(usuario.TBEndereco);
        }

        public int Id { get; set; }
        public int prefeituraID { get; set; }

        [Display(Name = "Nome Completo")]
        [StringLength(250)]
        public string NomeUsuario { get; set; }

        [Display(Name = "E-mail do Usuario")]
        public string Email { get; set; }

        [Display(Name = "Confirmar E-mail")]
        public string EmailConfirme { get; set; }

        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Display(Name = "Matrícula")]
        public string matricula { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        public virtual EnderecoVM Endereco { get; set; }

        internal static ICollection<UsuarioAutoEditVM> ToDomain(ICollection<AspNetUser> listUser)
        {
            var usuarios = new List<UsuarioAutoEditVM>();
            if (listUser == null) return usuarios;
            foreach (var item in listUser)
            {
                usuarios.Add(ToDomain(item));
            }
            return usuarios;
        }

        internal static UsuarioAutoEditVM ToDomain(AspNetUser item)
        {
            return new UsuarioAutoEditVM();
        }

        public static void ToModel(ref TBUsuario usuario, UsuarioAutoEditVM model)
        {
            usuario.TBEndereco = EnderecoVM.ToModel(model.Endereco);

            usuario.TBEndereco.EnderecoID = (int) usuario.EnderecoID;
        }
    }

    public class UsuarioVM
    {
        public UsuarioVM()
        {
            Usuarios = new List<UsuarioBasicoVM>();
            Endereco = new EnderecoVM();
            PerfilAcessoTodos = new List<SelectListItem>();
            PerfilAcessoVinculados = new List<SelectListItem>();
        }

        public UsuarioVM(TBUsuario usuario)
        {
            Id = usuario.usuarioID;
            NomeUsuario = usuario.nmUsuario;
            Email = usuario.Email;
            EmailConfirme = usuario.Email;
            Cargo = usuario.Cargo;
            CPF = usuario.CPF;
            matricula = usuario.matricula;
            Telefone = usuario.Telefone;
            Celular = usuario.Celular;
            Endereco = EnderecoVM.ToView(usuario.TBEndereco);
        }

        public int Id { get; set; }
        public int prefeituraID { get; set; }
        public string Btn { get; set; }

        [Required(ErrorMessage = "E-Nome Completo é obrigatório")]
        [Display(Name = "Nome Completo")]
        [StringLength(250)]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [Display(Name = "E-mail do Usuario", Description = "Este e-mail será utilizado para confirmar a conta.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirmar E-mail é obrigatório")]
        [Display(Name = "Confirmar E-mail")]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "O E-mail e a Confirmação do E-mail não conferem")]
        [StringLength(50)]
        public string EmailConfirme { get; set; }

        [Display(Name = "Cargo")]
        [StringLength(50)]
        public string Cargo { get; set; }

        [Display(Name = "CPF")]
        [RegularExpression(@"^\d{3}.\d{3}.\d{3}-\d{2}$", ErrorMessage = "CPF inválido")]
        [InputMask("999.999.999-99")]
        public string CPF { get; set; }

        [Display(Name = "Matrícula")]
        [Required(ErrorMessage = "Digite a Matrícula")]
        [StringLength(50)]
        public string matricula { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Digite a Telefone")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        [InputMask("(99)9999-9999")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{5}-?\d{4}$", ErrorMessage = "Celular inválido")]
        [InputMask("(99)99999-9999")]
        public string Celular { get; set; }

        public string[] PerfilAcessoIDs { get; set; }
        public IEnumerable<SelectListItem> PerfilAcessoTodos { get; set; }
        public string[] PerfilAcessoVinculadoIDs { get; set; }
        public IEnumerable<SelectListItem> PerfilAcessoVinculados { get; set; }

        public virtual ICollection<UsuarioBasicoVM> Usuarios { get; set; }
        public virtual EnderecoVM Endereco { get; set; }

        internal static ICollection<UsuarioVM> ToDomain(ICollection<AspNetUser> listUser)
        {
            var usuarios = new List<UsuarioVM>();
            if (listUser == null) return usuarios;
            foreach (var item in listUser)
            {
                usuarios.Add(ToDomain(item));
            }
            return usuarios;
        }

        internal static UsuarioVM ToDomain(AspNetUser item)
        {
            return new UsuarioVM();
        }

        public static void ToModel(ref TBUsuario usuario, UsuarioVM model)
        {
            if (usuario == null)
            {
                usuario = new TBUsuario();
            }
            ;
            usuario.usuarioID = model.Id;
            usuario.nmUsuario = model.NomeUsuario;
            usuario.Email = model.Email;
            usuario.Cargo = model.Cargo;
            usuario.CPF = model.CPF;
            usuario.matricula = model.matricula;
            usuario.Telefone = model.Telefone;
            usuario.Celular = model.Celular;
            usuario.bAtivo = true;
            usuario.PrefeituraID = model.prefeituraID;
            usuario.TBEndereco = EnderecoVM.ToModel(model.Endereco);

            usuario.EnderecoID = usuario.TBEndereco.EnderecoID;
        }
    }
}