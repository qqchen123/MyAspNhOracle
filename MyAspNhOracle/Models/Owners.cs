using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAspNhOracle.Models
{
    public class Owners
    {
        public virtual decimal Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal AddressId { get; set; }
        public virtual string HouseNumber { get; set; }
        public virtual string WaterMeter { get; set; }
        public virtual DateTime AddDate { get; set; }
        public virtual decimal OwnerTypeId { get; set; }


    }
}
