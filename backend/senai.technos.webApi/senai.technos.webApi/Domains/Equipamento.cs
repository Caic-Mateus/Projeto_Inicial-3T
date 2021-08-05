using System;
using System.Collections.Generic;

#nullable disable

namespace senai.technos.webApi.Domains
{
    public partial class Equipamento
    {
        public Equipamento()
        {
            Relacaos = new HashSet<Relacao>();
        }

        public int IdEquipamento { get; set; }
        public int? IdTipoEquipamento { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdSala { get; set; }
        public string Marca { get; set; }
        public int NumeroSerie { get; set; }
        public int NumeroPatrimonio { get; set; }
        public bool Situacao { get; set; }
        public string Descricao { get; set; }

        public virtual Sala IdSalaNavigation { get; set; }
        public virtual TipoEquipamento IdTipoEquipamentoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Relacao> Relacaos { get; set; }
    }
}
