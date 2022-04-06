using System;
using System.Collections.Generic;

namespace API.db
{
    public partial class TbUsuario
    {
        public int IdUsuario { get; set; }
        public string NmUsuario { get; set; } = null!;
        public string NmEmail { get; set; } = null!;
        public string NrCpf { get; set; } = null!;
        public string NrTelefone { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
