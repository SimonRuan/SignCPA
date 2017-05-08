using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignCPA.Models
{
    public class Sign
    {
        public int ID { get; set; }
        public DateTime SignTime { get; set; }
        public int DoneLevel { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        
    }
}