using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasaDoCodigo.Models
{
    public class Livro
    {
        public virtual int Id { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string TituloCurto { get; set; }
        public virtual string NomeAutor { get; set; }
        public virtual string Imagem { get; set; }
        public virtual decimal ValorEbook { get; set; }
        public virtual decimal ValorImpresso { get; set; }
        public virtual string Descricao { get; set; }

        public Livro()
        {

        }

        public Livro(string codigo, string titulo, string tituloCurto, string descricao,
			         string nomeAutor, string imagem, decimal valorEbook, decimal valorImpresso)
        {
            this.Codigo = codigo;
            this.Titulo = titulo;
            this.TituloCurto = tituloCurto;
            this.Descricao = descricao;
            this.NomeAutor = nomeAutor;
            this.Imagem = imagem;
            this.ValorEbook = valorEbook;
            this.ValorImpresso = valorImpresso;
        }

        public virtual decimal GetValor(Formato formato)
        {
            if (formato.Equals(Formato.EBOOK))
            {
                return this.ValorEbook;
            }

            return this.ValorImpresso;
        }

        public override string ToString()
        {
            return "Livro [id=" + this.Id + ", codigo=" + this.Codigo + ", titulo=" + this.Titulo + ", tituloCurto="
                    + this.TituloCurto + ", nomeAutor=" + this.NomeAutor + ", imagem=" + this.Imagem + ", valorEbook="
                    + this.ValorEbook + ", valorImpresso=" + this.ValorImpresso + ", descricao=" + this.Descricao
                    + "]";
        }
    }
}