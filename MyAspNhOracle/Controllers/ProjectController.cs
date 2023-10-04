using MyAspNhOracle.Models;
using System.Web.Mvc;

namespace MyAspNhOracle.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            //Owners owners;
            //IList<Owners> ownerList;
            //using (var session = NhibernateHelper.OpenSession())
            //{
            //    owners = session.Get<Owners>(3);
            //    ICriteria criteria = session.CreateCriteria(typeof(Owners));
            //    ownerList = criteria.List<Owners>();
            //}
            //ViewData["id"] = owners.Id;
            //ViewData["Name"] = owners.Name;
            //ViewData["AddDate"] = owners.AddDate;
            //ViewData["OwnerList"] = ownerList;

            using (var session = NhibernateHelper.OpenSession())
            {
                ProjectInfo projectInfo = session.Get<ProjectInfo>(3);
            }

            return View();
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}