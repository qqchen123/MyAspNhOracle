using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAspNhOracle.Models;

namespace MyAspNhOracle.Manager
{
    interface IOwnersManager
    {
        void Add(Owners owners);
        void Update(Owners owners);
        void Remove(Owners owners);
        Owners GetById(int id);
        Owners GetByOwners(string name);
        ICollection<Owners> GetAllOwners();

        //public IList<Owners> LoadByPage(int pageIndex, int pageSize, out int totalCount)
        //{
        //    using (var session = NhibernateHelper.OpenSession())
        //    {
        //        totalCount = session.QueryOver<Owners>().RowCount();	//总条数
        //        return session.QueryOver<Owners>().Skip((pageIndex - 1) * pageSize).Take(pageSize).List();
        //    }
        //}
    }
}
