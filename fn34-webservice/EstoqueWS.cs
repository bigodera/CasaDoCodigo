using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicoEstoque
{
    public class EstoqueWS : IEstoqueWS
    {
        private Dictionary<string, ItemEstoque> repositorio = new Dictionary<string, ItemEstoque>();

        public EstoqueWS()
        {
            repositorio.Add("SOA", new ItemEstoque() { Codigo = "SOA", Quantidade = 5 });
            repositorio.Add("TDD", new ItemEstoque() { Codigo = "TDD", Quantidade = 1 });
            repositorio.Add("RES", new ItemEstoque() { Codigo = "RES", Quantidade = 2 });
            repositorio.Add("LOG", new ItemEstoque() { Codigo = "LOG", Quantidade = 4 });
            repositorio.Add("WEB", new ItemEstoque() { Codigo = "WEB", Quantidade = 1 });
            repositorio.Add("ARQ", new ItemEstoque() { Codigo = "ARQ", Quantidade = 2 });
        }

        public IList<ItemEstoque> GetQuantidade(List<string> codigos)
        {
            IList<ItemEstoque> itens = new List<ItemEstoque>();
            
            var opContext = OperationContext.Current;
            var requestContext = opContext.RequestContext;
            var headers = requestContext.RequestMessage.Headers;
            int headerIndex = headers.FindHeader("Token", "");
            var token = headers.GetHeader<string>(headerIndex);
            
            if  (token == "TOKEN123")
            {
                if (codigos == null)
                {
                    return itens;
                }

                foreach (string codigo in codigos)
                {
                    if(this.repositorio.ContainsKey(codigo))
                    {
                        itens.Add(repositorio[codigo]);
                    }
                }
            }
            else
            {
                throw new FaultException<AutorizacaoFault>(new AutorizacaoFault("Usuário X passou token inválido."), "Token inválido!");
            }

            return itens;
        }
    }
}
