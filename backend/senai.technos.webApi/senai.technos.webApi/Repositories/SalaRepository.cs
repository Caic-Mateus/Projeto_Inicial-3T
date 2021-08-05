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
    public class SalaRepository : ISalaRepository
    {
        TechnoContext ctx = new TechnoContext();

        public Sala BuscarPorId(int id)
        {
            return ctx.Salas.FirstOrDefault(x => x.IdSala == id);
        }

        /// <summary>
        /// Cadastra uma nova sala
        /// </summary>
        /// <param name="novaSala">objeto criado com as informações da nova sala</param>
        public void Create(Sala novaSala)
        {
            ctx.Salas.Add(novaSala);

            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Salas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Sala> Read()
        {
            return ctx.Salas.ToList();
        }

        public void Update(int id, Sala salaAtualizada)
        {
            Sala salaBuscada = ctx.Salas.Find(id);

            if (salaAtualizada.Nome != null)
            {
                salaBuscada.Nome = salaAtualizada.Nome;
            }
            if (salaAtualizada.Andar != null)
            {
                salaBuscada.Andar = salaAtualizada.Andar;
            }
            if(salaAtualizada.Metragem != null)
            {
                salaBuscada.Metragem = salaAtualizada.Metragem;
            }

            ctx.Update(salaBuscada);
            ctx.SaveChanges();
        }
    }
}
