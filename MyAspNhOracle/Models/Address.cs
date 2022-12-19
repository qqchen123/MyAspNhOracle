using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAspNhOracle.Models
{
    public class Address
    {
        public virtual decimal id { get; set; }
        public virtual string name { get; set; }
        public virtual decimal areaid { get; set; }
        public virtual decimal operatorid { get; set; }
    }
}