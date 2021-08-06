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
    public class EquipamentoRepository : IEquipamentoRepository
    {
        TechnoContext ctx = new TechnoContext();

        public void Update(int id, Equipamento equipamentoAtualizado)
        {
            Equipamento equipamentoBuscado = ctx.Equipamentos.Find(id);

            if(equipamentoBuscado.Marca != null)
            {
                equipamentoBuscado.Marca = equipamentoAtualizado.Marca;
            }

            if (equipamentoBuscado.NumeroSerie != 0)
            {
                equipamentoBuscado.NumeroSerie = equipamentoAtualizado.NumeroSerie;
            }

            if (equipamentoBuscado.NumeroPatrimonio != 0)
            {
                equipamentoBuscado.NumeroPatrimonio = equipamentoAtualizado.NumeroPatrimonio;
            }

            if (equipamentoBuscado.Situacao != null)
            {
                equipamentoBuscado.Situacao = equipamentoAtualizado.Situacao;
            }

            if (equipamentoBuscado.Descricao != null)
            {
                equipamentoBuscado.Descricao = equipamentoAtualizado.Descricao;
            }

            ctx.Equipamentos.Update(equipamentoBuscado);

            ctx.SaveChanges();
        }

        public void Create(Equipamento novoEquipamento)
        {
            ctx.Equipamentos.Add(novoEquipamento);

            
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Equipamento equipamentoBuscado =  ctx.Equipamentos.Find(id);

            ctx.Equipamentos.Remove(equipamentoBuscado);

            ctx.SaveChanges();
        }

        public List<Equipamento> List()
        {
            return ctx.Equipamentos.Include(x => x.IdTipoEquipamentoNavigation).
                Include(x => x.IdUsuarioNavigation).ToList();
        }

        public Equipamento BuscarPorId(int id)
        {
            return ctx.Equipamentos.Find(id);
        }
    }
}
