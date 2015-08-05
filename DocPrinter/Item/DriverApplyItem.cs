using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocPrinter.Item
{
    class DriverApplyItem:BaseItem
    {
        public string Brith { get; set; }
        public string IdName2 { get; set; }
        public string IdCode2 { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string ZipCode { get; set; }
        public string Nationality { get; set; }
        public string FileCode { get; set; }

        public class Columns
        {
            public const string Name = "Name|姓名";
            public const string Sex = "Sex|性别";
            public const string Brith = "Brith|出生日期";
            public const string IdName1 = "IdName1|身份证明文件名称1";
            public const string IdCode1 = "IdCode1|身份证明文件号码1";
            public const string IdName2 = "IdName2|身份证明文件名称2";
            public const string IdCode2 = "IdCode2|身份证明文件号码2";
            public const string Mobile = "Mobile|移动电话";
            public const string Phone = "Phone|固定电话";
            public const string Address = "Address|邮寄地址";
            public const string EMail = "EMail|电子邮件";
            public const string ZipCode = "ZipCode|邮政编码";
            public const string Nationality = "Nationality|国籍";
            public const string FileCode = "FileCode|档案编号";
        }
        
        public static string[] ColunmHeaders = { Columns.Name, Columns.Sex, Columns.Mobile, Columns.Brith, Columns.IdName1, Columns.IdCode1 };
    }
}
