using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasaDoCodigo.Models
{
    public class Pedido
    {
        public virtual int Id { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual ISet<ItemCompra> Itens { get; set; }
        public virtual Pagamento Pagamento { get; set; }

        public virtual string Status
        {
            get
            {
                return this.Pagamento == null ? "INDEFINIDO" : this.Pagamento.Status;
            }
        }

        public virtual string GetFormato()
        {
            return this.TemApenasLivrosImpressos() ? "impresso" : "ebook";
        }

        public virtual bool TemApenasLivrosImpressos()
        {

            foreach (ItemCompra itemCompra in this.Itens)
            {
                if (!itemCompra.isImpresso())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
