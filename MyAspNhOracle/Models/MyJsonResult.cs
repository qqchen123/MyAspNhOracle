using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAspNhOracle.Models
{
    public class MyJsonResult
    {
        public virtual int Code { get; set; }
        public virtual String Status { get; set; }
        public virtual Object Data { get; set; }


        public MyJsonResult() { }
        public MyJsonResult(int code,String status, Object data) {
            this.Code = code;
            this.Status = status;
            this.Data = data;
        }

        public static MyJsonResult getJsonData(int code, String status, Object data) {
            return new MyJsonResult( code,  status,  data);
        }
    }
}