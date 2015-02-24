using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasaDoCodigo.Models
{
    public class Carrinho
    {
        public SortedSet<ItemCompra> Itens { get; set; }
    }
}