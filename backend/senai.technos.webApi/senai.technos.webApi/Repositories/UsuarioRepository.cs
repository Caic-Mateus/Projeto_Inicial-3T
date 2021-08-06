using Microsoft.EntityFrameworkCore;
using senai.technos.webApi.Contexts;
using senai.technos.webApi.Domains;
using senai.technos.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.technos.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        TechnoContext ctx = new TechnoContext();
        public Usuario Logar(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}
