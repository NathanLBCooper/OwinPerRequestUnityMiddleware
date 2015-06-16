using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OwinPerRequestExample.Models
{
    public class ObjectInfoModel
    {
        public object Object { get; set; }
        public string ObjectName { get; set; }
        public string HashCode { get; set; }
        public int Undisposed { get; set; }
    }
}