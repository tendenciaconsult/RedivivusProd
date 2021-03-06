using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            this.AspNetClients = new List<AspNetClient>();
            this.AspNetUserClaims = new List<AspNetUserClaim>();
            this.AspNetUserLogins = new List<AspNetUserLogin>();
            this.AspNetUserRoles = new List<AspNetUserRole>();
            this.AspNetPerfils = new List<AspNetPerfil>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public Nullable<int> EmpresaID { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public Nullable<bool> bAtivo { get; set; }
        public virtual ICollection<AspNetClient> AspNetClients { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
        public virtual TBUsuario TBUsuario { get; set; }
        public virtual ICollection<AspNetPerfil> AspNetPerfils { get; set; }
    }
}
