using CasaDoCodigo.Infra;
using CasaDoCodigo.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasaDoCodigo.DAO
{
    public class LivroDAO
    {
        public IList<Models.Livro> Lista()
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                string hql = "Select l from Livro l ";
                IQuery query = session.CreateQuery(hql);
                return query.List<Livro>();
            }
        }

        public Livro BuscaPorId(int id)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                return session.Get<Livro>(id);
            }
        }
    }
}
