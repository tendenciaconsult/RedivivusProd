using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class AspNetClient
    {
        public int Id { get; set; }
        public string ClientKey { get; set; }
        public string SimirUser_Id { get; set; }
        public string FuncaoSelecionada { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
