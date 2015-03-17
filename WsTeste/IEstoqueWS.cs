using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace fn34_webservice
{
    [ServiceContract]
    public interface IEstoqueWS
    {
        //[OperationContract]
        //ItemEstoque GetQuantidade(string codigo);

        [OperationContract]
        string Teste();
    }
}
