using CasaDoCodigo.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasaDoCodigo.Mapeamentos
{
    public class LivroMapping: ClassMap<Livro>
    {
        public LivroMapping()
        {
            Id(livro => livro.Id).GeneratedBy.Identity();
            Map(livro => livro.Codigo);
            Map(livro => livro.Titulo);
            Map(livro => livro.TituloCurto);
            Map(livro => livro.NomeAutor);
            Map(livro => livro.Imagem);
            Map(livro => livro.ValorEbook);
            Map(livro => livro.ValorImpresso);
            Map(livro => livro.Descricao).Length(1000);
        }
    }
}