using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAspNhOracle.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public String Index()
        {

            DataTable dt = OracleHelper.ExecuteDataTable("select * from T_ADDRESS");


            return "user index";
        }
    }
}