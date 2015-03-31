using CasaDoCodigo.DAO;
using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class CarrinhoController : Controller
    {
        private static Carrinho carrinho = new Carrinho();
        private LivroDAO dao;

        public CarrinhoController(LivroDAO dao)
        {
            //this.carrinho = carrinho;
            this.dao = dao;
        }

        // GET: Carrinho
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            carrinho.VerificarDisponibilidadeDosItensComSoap();

            return View(carrinho);
        }

        public ActionResult AdicionarItem(int id, Formato formato)
        {
            Livro livro = dao.BuscaPorId(id);
            carrinho.AdicionarOuIncremantarQuantidadeDoItem(livro, formato);
            return RedirectToAction("Listar");
        }

    }
}