using senai.technos.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.technos.webApi.Interfaces
{
    interface ITipoEquipamentoRepository
    {
        /// <summary>
        /// Lista todos os tipos de equipamentos
        /// </summary>
        /// <returns>Uma lista dos tipos de equipamentos existentes</returns>
        List<TipoEquipamento> Read();
    }
}
