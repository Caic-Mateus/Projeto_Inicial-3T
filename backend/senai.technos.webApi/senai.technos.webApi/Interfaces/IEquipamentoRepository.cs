using senai.technos.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.technos.webApi.Interfaces
{
    interface IEquipamentoRepository
    {
        /// <summary>
        /// cria um novo equipamento
        /// </summary>
        /// <param name="novoEquipamento">informações do novo equipamento que será criado</param>
        void Create(Equipamento novoEquipamento);

        /// <summary>
        /// lista todos os equipamentos
        /// </summary>
        /// <returns>retorna a lista de todos os equipamentos</returns>
        List<Equipamento> List();

        /// <summary>
        /// atualiza um determinado equipamento
        /// </summary>
        /// <param name="equipamentoAtualizado">informações do equipamnto que será atualizado</param>
        /// <param name="id">id do equipamento que será passado</param>
        void Update(int id, Equipamento equipamentoAtualizado);

        /// <summary>
        /// apaga um equimanto
        /// </summary>
        /// <param name="id">id que será passado</param>
        void Delete(int id);

        Equipamento BuscarPorId(int id);
    }
}
