using CasaDoCodigo.Infra;
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
            ISession session = NHibernateHelper.AbreSession();
            return View();
        }
    }
}