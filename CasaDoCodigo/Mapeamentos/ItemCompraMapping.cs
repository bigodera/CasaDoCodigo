using CasaDoCodigo.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasaDoCodigo.Mapeamentos
{
    public class ItemCompraMapping : ClassMap<ItemCompra>
    {
        public ItemCompraMapping()
        {
            Id(ic => ic.Id).GeneratedBy.Identity();
            Map(ic => ic.Formato);
            Map(ic => ic.Quantidade);
            Map(ic => ic.QuantidadeEstoque);
            References(ic => ic.Livro, "LivroId");
        }
    }
}