using senai.technos.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.technos.webApi.Interfaces
{
    interface ISalaRepository
    {
        /// <summary>
        /// Cadastra uma nova sala
        /// </summary>
        /// <param name="novaSala">objeto com os dados da nova sala</param>
        void Create(Sala novaSala);

        /// <summary>
        /// Lista todas as salas
        /// </summary>
        /// <returns>Uma lista das salas existentes</returns>
        List<Sala> Read();

        /// <summary>
        /// Atualiza uma determinada sala
        /// </summary>
        /// <param name="id">id da sala a ser atualizada</param>
        /// <param name="salaAtualizada">objeto com as informações da sala atualizada</param>
        void Update(int id, Sala salaAtualizada);

        /// <summary>
        /// Deleta uma determinada sala
        /// </summary>
        /// <param name="id">id da sala a ser excluida</param>
        void Delete(int id);

        Sala BuscarPorId(int id);
    }
}
