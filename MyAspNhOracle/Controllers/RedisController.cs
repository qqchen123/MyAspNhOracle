using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAspNhOracle.Controllers
{
    public class RedisController : Controller
    {
        // GET: Redis
        public String Index()
        {
            RedisHelper redisHelper = new RedisHelper();
            redisHelper.Set("username", "qqchen", 1000);

            return "redis test!"+redisHelper.Get<String>("username");
        }
    }
}