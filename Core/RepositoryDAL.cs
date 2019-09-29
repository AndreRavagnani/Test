using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RepositoryDAL<T> : IRepositoryDAL<T> where T : class
    {
        public void Create(T entity)
        {
            using (ISession session = FluentSessionFactory.OpenSession())
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity);
                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        throw e;
                    }

                }
            }
        }

        public void Delete(T entity)
        {
            using (ISession session = FluentSessionFactory.OpenSession())
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entity);
                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        throw e;
                    }

                }
            }
        }

        public T Restore(int id)
        {
            using (ISession session = FluentSessionFactory.OpenSession())
            {
                try
                {
                    return session.Get<T>(id);
                }
                catch (Exception e)
                {

                    throw e;
                }


            }
        }

        public IList<T> RestoreAll()
        {
            using (ISession session = FluentSessionFactory.OpenSession())
            {
                try
                {
                    return session.Query<T>().ToList(); ;
                }
                catch (Exception e)
                {

                    throw e;
                }


            }
        }

        public void Update(T entity)
        {
            using (ISession session = FluentSessionFactory.OpenSession())
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        throw e;
                    }

                }
            }
        }
    }
}
