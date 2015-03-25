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
        private Carrinho carrinho;

        public CarrinhoController(Carrinho carrinho)
        {
            this.carrinho = carrinho;
        }

        // GET: Carrinho
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            this.carrinho.VerificarDisponibilidadeDosItensComSoap();

            return View();
        }
    }
}