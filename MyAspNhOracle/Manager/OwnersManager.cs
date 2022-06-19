using MyAspNhOracle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAspNhOracle.Manager
{
    public class OwnersManager : IOwnersManager
    {
        public void Add(Owners owners)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(owners);
                    tx.Commit();
                }
            }
        }

        public ICollection<Owners> GetAllOwners()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var owners = session.Get<Owners>(3);
                Console.WriteLine(owners.Id + "-----" + owners.Name + "---" + owners.AddDate);
                //Console.ReadKey();
            }
        }

        public Owners GetById(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var owners = session.Get<Owners>(id);
                Console.WriteLine(owners.Id + "-----" + owners.Name + "---" + owners.AddDate);
                //Console.ReadKey();
                return owners;
            }
        }

        public Owners GetByOwners(string name)
        {
        }

        public void Remove(Owners owners)
        {
        }

        public void Update(Owners owners)
        {
        }

        //public List<Owners> GetListByPage(int pageIndex, int pageSize)
        //{
        //    int totalCount;	//总条数
        //    var productIList = productDao.LoadByPage(pageIndex, pageSize, out totalCount);
        //    List<ProductVM> productListByPage = (from p in productIList
        //                                         select new ProductVM
        //                                         {
        //                                             ID = p.ID,
        //                                             Code = p.Code,
        //                                             Name = p.Name,
        //                                         }).ToList();
        //    return productListByPage;
        //}
    }
}