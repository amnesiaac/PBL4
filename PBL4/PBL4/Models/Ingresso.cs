using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL4.Models
{
    public class Ingresso
    {
        public int IngressoId { get; set; }
        public virtual Evento Evento { get; set; }
        public int EventoId { get; set; }
        public double Valor { get; set; }
        public int QuantidadeIngressos { get; set; }
    }
}