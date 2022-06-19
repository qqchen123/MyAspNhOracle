using NHibernate;
using NHibernate.Cfg;
using MyAspNhOracle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAspNhOracle
{
    class NhibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(Owners).Assembly);
                    //我们创建一个会话工厂。这是一个昂贵的过程，因此应该只执行一次。
                    //这就是为什么我将其放入此方法的原因，该方法在测试周期内仅执行一次
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}
