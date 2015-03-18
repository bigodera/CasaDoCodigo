using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ServicoEstoque
{
    [DataContract]
    public class AutorizacaoFault
    {
        [DataMember]
        public string Mensagem { get; set; }

        public AutorizacaoFault(string mensagem)
        {
            this.Mensagem = mensagem;
        }

    }
}
