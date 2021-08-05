using System;
using System.Collections.Generic;

#nullable disable

namespace senai.technos.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Equipamentos = new HashSet<Equipamento>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Equipamento> Equipamentos { get; set; }
    }
}
