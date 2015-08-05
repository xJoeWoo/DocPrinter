using DocPrinter.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DocPrinter
{
    class UI
    {

        public static void LoadDetailDataGrid(DataGrid datagrid)
        {
            datagrid.Columns.Clear();
            datagrid.Items.Clear();

            ChangeColumns(datagrid);

            switch (Conf.CurrentType)
            {
                case Doc.Type.DriverApply:
                    for (int i = 0; i < 49; i++)
                    {
                        datagrid.Items.Add(new DriverApplyItem() { Name = "醒目", Sex = "男",Mobile = (136600963675 + i).ToString()});
                    }
                    break;
                case Doc.Type.HealthStatus:
                    for (int i = 0; i < 49; i++)
                    {
                        datagrid.Items.Add(new DriverApplyItem() { Name = "Ohyeah", Sex = "男", Mobile = (136600963675 + i).ToString() });
                    }
                    break;
                case Doc.Type.TestResult:
                    for (int i = 0; i < 49; i++)
                    {
                        datagrid.Items.Add(new DriverApplyItem() { Name = "傻瓜", Sex = "男", Mobile = (136600963675 + i).ToString() });
                    }
                    break;
            }
        }

        private static void ChangeColumns(DataGrid datagrid)
        {
            switch (Conf.CurrentType)
            {
                case Doc.Type.DriverApply:
                    foreach (string str in DriverApplyItem.ColunmHeaders)
                        AddColumn(datagrid, str);
                    break;
                case Doc.Type.HealthStatus:
                    foreach (string str in TestResultItem.ColunmHeaders)
                        AddColumn(datagrid, str);
                    break;
                case Doc.Type.TestResult:
                    foreach (string str in HealthStatusItem.ColunmHeaders)
                        AddColumn(datagrid, str);
                    break;
            }


        }
        private static void AddColumn(DataGrid datagrid, string columnStr)
        {
            string[] strs = columnStr.Split('|');
            datagrid.Columns.Add(new DataGridTextColumn() { Header = strs[1], Binding = new Binding(strs[0]), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });

        }

    }
}
