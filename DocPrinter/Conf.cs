using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocPrinter
{
    class Conf
    {

        public static readonly string[] InitTypes = {
            "机动车驾驶证申请表",
            "机动车驾驶人考试成绩单",
            "机动车驾驶人身体条件说明"
        };

        public static int HttpRetryTimes { get { return 2; } }
        public static int HttpTimeout { get { return 30 * 1000; } }
        
        public static Doc.Type CurrentType { get; set; }
    }
}
