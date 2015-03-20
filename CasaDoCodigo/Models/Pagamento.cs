using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasaDoCodigo.Models
{
    public class Pagamento
    {
        private static string STATUS_CRIADO = "CRIADO";
        private static string STATUS_CONFIRMADO = "CONFIRMADO";
        private static string STATUS_CANCELADO = "CANCELADO";

        public int Id { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public List<Link> Links { get; set; }

        public Link GetLinkPeloRel(string rel)
        {
            foreach (Link link in this.Links)
            {
                if (link.Rel.Equals(rel))
                {
                    return link;
                }
            }
            return null;
        }

        public bool EhCriado()
        {
            return STATUS_CRIADO.Equals(this.Status);
        }

        public bool EhConfirmado()
        {
            return STATUS_CONFIRMADO.Equals(this.Status);
        }

        public bool EhCancelado()
        {
            return STATUS_CANCELADO.Equals(this.Status);
        }

        public override string ToString()
        {
            return "Pagamento [id=" + this.Id + ", status=" + this.Status + ", valor=" + this.Valor + ", links="
                    + this.Links + "]";
        }
    }
}
