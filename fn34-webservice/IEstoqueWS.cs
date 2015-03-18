using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServicoEstoque
{
    [ServiceContract(Namespace="http://caelum.com.br/estoquews/v1")]
    public interface IEstoqueWS
    {
        [OperationContract]
        [FaultContract(typeof(AutorizacaoFault))]
        IList<ItemEstoque> GetQuantidade(List<string> codigos);
    }
}
