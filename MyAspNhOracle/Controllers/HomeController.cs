using MyAspNhOracle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAspNhOracle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var owners = session.Get<Owners>(3);
                Console.WriteLine(owners.Id + "-----" + owners.Name + "---" + owners.AddDate);
                //Console.ReadKey();
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