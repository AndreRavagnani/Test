using Core.Mapping;
using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class FluentSessionFactory
    {
        private static ISessionFactory session;

        //Singleton
        public static ISessionFactory CreateSession()
        {
            if (session != null)
                return session;


            session = Fluently.Configure()
             .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
             .ConnectionString("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\andre\\Documents\\Visual Studio 2017\\Projects\\Test\\Core\\Database1.mdf\";Integrated Security=True")
             )
             .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMapping>())
             .BuildConfiguration()
             .BuildSessionFactory();

            return session;
        }

        public static ISession OpenSession()
        {
            return CreateSession().OpenSession();
        }
    }
}
