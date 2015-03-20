using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasaDoCodigo.Models
{
    public class Transacao
    {
        public string Numero { get; set; }
        public string Titular { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return "Transacao [numero=" + this.Numero + ", titular=" + this.Titular + ", valor="
                + this.Valor + "]";
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (obj != typeof(Transacao))
                return false;
            Transacao other = (Transacao)obj;
            if (this.Numero == null)
            {
                if (other.Numero != null)
                    return false;
            }
            else if (!this.Numero.Equals(other.Numero))
                return false;
            if (this.Titular == null)
            {
                if (other.Titular != null)
                    return false;
            }
            else if (!this.Titular.Equals(other.Titular))
                return false;
            if (this.Valor == null)
            {
                if (other.Valor != null)
                    return false;
            }
            else if (!this.Valor.Equals(other.Valor))
                return false;
            return true;
        }

    }
}
