using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL4.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public bool Restricao { get; set; }
    }
}