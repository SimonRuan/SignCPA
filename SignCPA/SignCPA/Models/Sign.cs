using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignCPA.Models
{
    public class Sign
    {
        public int ID { get; set; }
        public string SignTime { get; set; }
        public int DoneLevel { get; set; }
        public string Content { get; set; }
        public string CreateTime { get; set; }
        public string ModifyTime { get; set; }

        public string Color { get; set; }
    }
}