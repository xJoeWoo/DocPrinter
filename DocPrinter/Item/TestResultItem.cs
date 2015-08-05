using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocPrinter.Item
{
    class TestResultItem:BaseItem
    {
        public string School { get; set; }
        public string VehicleType { get; set; }
        public string OriVehicleType { get; set; }

        public class Columns
        {
            public const string Name = "Name|姓名";
            public const string Sex = "Sex|性别";
            public const string School = "School|驾培机构";
            public const string IdName1 = "IdName1|身份证明文件名称";
            public const string IdCode1 = "IdCode1|身份证明文件号码";
            public const string VehicleType = "VehicleType|报考车型";
            public const string OriVehicleType = "OriVehicleType|原准驾车型";
        }

        public static string[] ColunmHeaders = { Columns.Name, Columns.Sex, Columns.School, Columns.VehicleType, Columns.OriVehicleType };
    }
}
