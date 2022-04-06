using System;
using System.Collections.Generic;

namespace API.db
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string NmUsuario { get; set; } = null!;
        public string NrCpf { get; set; } = null!;
        public string NrTelefone { get; set; } = null!;
    }
}
