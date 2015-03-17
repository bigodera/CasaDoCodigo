using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fn34_webservice
{
    public class ItemEstoque
    {
        public string Codigo { get; set; }
        public int Quantidade { get; set; }

        public ItemEstoque()
        {

        }

        public ItemEstoque(string codigo, int quantidade)
        {
            this.Codigo = codigo;
            this.Quantidade = quantidade;
        }
    }
}
