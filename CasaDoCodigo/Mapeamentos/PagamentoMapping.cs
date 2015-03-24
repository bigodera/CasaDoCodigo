using CasaDoCodigo.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasaDoCodigo.Mapeamentos
{
    public class PagamentoMapping : ClassMap<Pagamento>
    {
        public PagamentoMapping()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Status);
            Map(p => p.Valor);
            Map(p => p.Links);
        }
    }
}