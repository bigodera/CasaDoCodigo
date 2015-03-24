using CasaDoCodigo.DAO;
using CasaDoCodigo.Infra;
using CasaDoCodigo.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class LojaController : Controller
    {
        // GET: Loja
        public ActionResult Index()
        {
            IList<Livro> livros = new LivroDAO().Lista();
            return View(livros);
        }

        public ActionResult Livro(int id)
        {
            Livro livro = new LivroDAO().BuscaPorId(id);
            return View(livro);
        }
    }
}