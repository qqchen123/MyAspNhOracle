using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAspNhOracle.Manager
{
    public interface IModel
    {
    }
    public class Common
    {
        //public IList<T> LoadByPage(int pageIndex, int pageSize, out int totalCount) 
        //{
        //    using (var session = NhibernateHelper.OpenSession())
        //    {
        //        totalCount = session.QueryOver<T>().RowCount();	//总条数
        //        return session.QueryOver<T>().Skip((pageIndex - 1) * pageSize).Take(pageSize).List();
        //    }
        //}
    }
}