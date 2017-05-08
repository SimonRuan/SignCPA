using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignCPA.Helper
{
    public class EnumHelper
    {
        public string ToColor(int doneLevel)
        { 
            switch(doneLevel)
                case 0:   //一点也没完成
                    return "#FF6666";
                case 1:   //完成了一部分
                    return "#FF6600";
                case 2:   //完成任务
                    return "";
                case 3:   //超额完成
                    return "";      
        }
    }
}