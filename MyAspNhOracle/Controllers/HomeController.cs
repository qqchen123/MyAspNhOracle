using MyAspNhOracle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAspNhOracle.Manager;

namespace MyAspNhOracle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //using (var session = NhibernateHelper.OpenSession())
            //{
            //    var owners = session.Get<Owners>(3);
            //    Console.WriteLine(owners.Id + "-----" + owners.Name + "---" + owners.AddDate);
            //    Console.ReadKey();

            //}
            OwnersManager ownersManager = new OwnersManager();
            int totalCount;
            var ownersList = ownersManager.LoadByPage(0, 2, out totalCount);
            foreach (var item in ownersList)
            {
                Console.WriteLine(item.Id + "--" + item.Name);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}



//select t.month,
//       Max(case
//             when t.owneruuid = '1' then
//              t.money
//             else
//              0
//           end) as a,
//       Max(case
//             when t.owneruuid = '2' then
//              t.money
//             else
//    0
//           end) as b,
//           Max(case
//             when t.owneruuid = '1' then
//              t.money
//             else
//    0
//           end) -
//       Max(case
//             when t.owneruuid = '2' then
//              t.money
//             else
//    0
//           end) as c


//  from T_ACCOUNT t
// group by t.month order by t.month;