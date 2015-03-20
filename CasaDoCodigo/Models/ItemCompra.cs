using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasaDoCodigo.Models
{
    public class ItemCompra
    {
        public int Id { get; set; }
        public Formato Formato { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeEstoque { get; set; }

        public Livro Livro { get; set; }

        public ItemCompra()
        {

        }

        public ItemCompra(Livro livro, Formato formato)
        {
            this.Livro = livro;
            this.Formato = formato;
            this.Quantidade = 1;
            this.QuantidadeEstoque = 0;
        }

        public void IncrementaQuantidade(int quantidade)
        {
            this.Quantidade += quantidade;
        }

        public bool isImpresso()
        {
            return this.Formato.Equals(Formato.IMPRESSO);
        }

        public string GetImagem()
        {
            return this.Livro.Imagem;
        }

        public decimal GetValorUnico()
        {
            return this.Livro.GetValor(this.Formato);
        }

        public decimal GetTotal()
        {
            decimal valorLivro = this.GetValorUnico();
            return valorLivro * this.Quantidade;
        }

        public bool TemCodigo(string codigo)
        {
            return this.Livro.Codigo.Equals(codigo);
        }

	    public override string ToString() {
		    return "ItemCompra [titulo=" + this.Livro.Titulo + ", image=" + this.Livro.Imagem + ", codigo=" + this.Livro.Codigo
				    + ", formato=" + this.Formato + ", quantidade=" + this.Quantidade + ", quantidadeEstoque="
				    + this.QuantidadeEstoque + ", valorUnico=" + this.Livro.GetValor(this.Formato) + "]";
	    }

	    public override int GetHashCode() {
		    int prime = 31;
		    int result = 1;
		    result = prime * result + ((this.Livro.Codigo == null) ? 0 : this.Livro.Codigo.GetHashCode());
		    result = prime * result + ((this.Formato == null) ? 0 : this.Formato.GetHashCode());
		    return result;
	    }

	    public override bool Equals(Object obj) {
		    if (this == obj)
			    return true;
		    if (obj == null)
			    return false;
		    if (!(obj is ItemCompra))
			    return false;

		    ItemCompra other = (ItemCompra) obj;
		    if (this.Livro.Codigo == null) {
			    if (other.Livro.Codigo != null)
				    return false;
		    } else if (!this.Livro.Codigo.Equals(other.Livro.Codigo))
			    return false;
		    if (this.Formato != other.Formato)
			    return false;
		    return true;
	    }

    }
}
