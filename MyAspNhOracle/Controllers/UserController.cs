using MyAspNhOracle.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace MyAspNhOracle.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public String Index()
        {

            DataTable dt = OracleHelper.ExecuteDataTable("select * from T_ADDRESS");
            List<Address> addressList = DataTableToModelUtil.DataTableToList<Address>(dt);

            //return "user index:"+dt.Rows[0]["name"];
            return addressList[0].name + addressList[2].name;
        }

        public String OwnerList()
        {
            DataTable ownerDt = OracleHelper.ExecuteDataTable("select * from t_owners");
            if (ownerDt.Rows.Count > 0)
            {
                List<Owners> ownerList = DataTableToModelUtil.DataTableToList<Owners>(ownerDt);
                var olList = from ol in ownerList
                             where ol.Id < 6
                             select ol;
                foreach (var item in olList)
                {
                    Console.WriteLine(item.Name);
                }
                return ownerList[0].Name + "--" + ownerList[1].Name;
            }

            return "";
        }

        public string Owner()
        {
            DataTable ownerDt = OracleHelper.ExecuteDataTable("select * from t_owners where id = 2");
            Owners owner = DataTableToModelUtil.DataTableToModel<Owners>(ownerDt);
            return owner.Id + "--" + owner.Name + "--" + owner.AddDate;
        }

        public ActionResult MyTest()
        {
            //MyJsonResult myJsonResult = new MyJsonResult();
            Owners owner = null;
            try
            {
                DataTable ownerDt = OracleHelper.ExecuteDataTable("select * from t_owners where id = 2");
                owner = DataTableToModelUtil.DataTableToModel<Owners>(ownerDt);
                //throw new Exception("哈哈哈，测试错误！");
            }
            catch (Exception e)
            {
                return Json(MyJsonResult.getJsonData(1, "error", e.Message), JsonRequestBehavior.AllowGet);
            }

            return Json(MyJsonResult.getJsonData(0, "success", owner), JsonRequestBehavior.AllowGet);
        }
    }
}