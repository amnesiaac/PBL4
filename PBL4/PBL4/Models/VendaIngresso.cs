using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL4.Models
{
    public class VendaIngresso
    {
        public int VendaIngressoId { get; set; }
        public virtual Ingresso Ingresso { get; set; }
        public int IngressoId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public virtual Bilheteria Bilheteria { get; set; }
        public int BilheteriaId { get; set; }
        public bool VIP { get; set; }

        public bool decrementaIngresso()
        {
            if (Ingresso.QuantidadeIngressos != 0)
            {
                return true;
            }
            return false;
        }
    }
}