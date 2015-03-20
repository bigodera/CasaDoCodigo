using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasaDoCodigo.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public ISet<ItemCompra> Itens { get; set; }
        public Pagamento Pagamento;

        public string Status
        {
            get
            {
                return this.Pagamento == null ? "INDEFINIDO" : this.Pagamento.Status;
            }
        }

        public string GetFormato()
        {
            return this.TemApenasLivrosImpressos() ? "impresso" : "ebook";
        }

        private bool TemApenasLivrosImpressos() 
        {
		
		    foreach (ItemCompra itemCompra in this.Itens) {
			    if(!itemCompra.isImpresso()) {
				    return false;
			    }
		    }
		    
            return true;
	    }



    }
}
