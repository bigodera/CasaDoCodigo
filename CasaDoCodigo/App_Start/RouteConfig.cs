using CasaDoCodigo.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CasaDoCodigo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //TODO: tirar esse código daqui, provavelmente em algum método específico de inicialização
            ISession session = NHibernateHelper.AbreSession();
            if (ConfigurationManager.AppSettings["InicializaBanco"].ToString() == "S")
            {
                NHibernateHelper.PopulaBanco();
            }
            

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Loja", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
