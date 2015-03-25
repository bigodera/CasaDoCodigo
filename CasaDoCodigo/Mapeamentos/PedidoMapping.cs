using CasaDoCodigo.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasaDoCodigo.Mapeamentos
{
    public class PedidoMapping: ClassMap<Pedido>
    {
        public PedidoMapping()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Data);
            References(p => p.Pagamento, "PagamentoId");

            //TODO: Corrigir mapeamento aqui, não entendi como rola no
            //hibernate e aqui não. Tem que gerar a tabela
            HasMany(p => p.Itens);
        }
    }
}