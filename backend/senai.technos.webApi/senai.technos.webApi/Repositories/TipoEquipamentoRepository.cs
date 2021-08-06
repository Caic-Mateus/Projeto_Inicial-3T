using senai.technos.webApi.Contexts;
using senai.technos.webApi.Domains;
using senai.technos.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.technos.webApi.Repositories
{
    public class TipoEquipamentoRepository : ITipoEquipamentoRepository
    {
        TechnoContext ctx = new TechnoContext();
        public List<TipoEquipamento> Read()
        {
            return ctx.TipoEquipamentos.ToList();
        }
    }
}
