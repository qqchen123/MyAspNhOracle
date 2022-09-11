using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAspNhOracle.Models
{
    public class ProjectInfo
    {
        public virtual int ProId { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual string PMO { get; set; }
        public virtual string Sponsor { get; set; }
        public virtual string Technology { get; set; }
        public virtual string Customer { get; set; }
        public virtual string Application { get; set; }
        public virtual string KeyWords { get; set; }
        public virtual string FilePath { get; set; }
        public virtual string IsDelete { get; set; }
    }
}