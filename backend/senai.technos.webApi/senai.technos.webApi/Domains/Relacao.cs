using System;
using System.Collections.Generic;

#nullable disable

namespace senai.technos.webApi.Domains
{
    public partial class Relacao
    {
        public int IdRelacao { get; set; }
        public int? IdEquipamento { get; set; }
        public int? IdSala { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }

        public virtual Equipamento IdEquipamentoNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
    }
}
