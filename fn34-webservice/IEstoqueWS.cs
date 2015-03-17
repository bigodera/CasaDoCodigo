using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServicoEstoque
{
    [ServiceContract]
    public interface IEstoqueWS
    {
        [OperationContract]
        IList<ItemEstoque> GetQuantidade(IList<string> codigos);
    }
}
