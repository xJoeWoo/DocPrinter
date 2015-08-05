using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using DocPrinter.Item;
using System.Windows.Xps.Packaging;
using System.IO;
using System.Diagnostics;

namespace DocPrinter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Doc.StartWord();
            foreach (string str in Conf.InitTypes)
                lbType.Items.Add(str);
        }

        private void lbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string which = (string)e.AddedItems[0];
            if (e.AddedItems.Count > 0)
            {

                if (which.Equals(Conf.InitTypes[0])) //申请表
                {
                    Conf.CurrentType = Doc.Type.DriverApply;
                }
                else if (which.Equals(Conf.InitTypes[1])) //成绩单
                {
                    Conf.CurrentType = Doc.Type.TestResult;

                }
                else if (which.Equals(Conf.InitTypes[2])) //身体条件说明
                {
                    Conf.CurrentType = Doc.Type.HealthStatus;
                }
                UI.LoadDetailDataGrid(dgDetail);
            }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Doc.CloseWord();
        }

        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {
            Doc.CheckWinWordProcess();
            Process.Start(Doc.SaveDocAsXPS(Doc.InflateDoc(dgDetail.SelectedItem), true));
        }

        private void btnOutput_Click(object sender, RoutedEventArgs e)
        {
            Doc.CheckWinWordProcess();
            string filename = Conf.InitTypes[(int)Conf.CurrentType] + "_" + ((BaseItem)dgDetail.SelectedItem).Name;
            Process.Start("explorer.exe", Doc.SaveDocAsDoc(Doc.InflateDoc(dgDetail.SelectedItem), filename, true));
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Doc.CheckWinWordProcess();
            Printer.PrintXPS(Doc.SaveDocAsXPS(Doc.InflateDoc(dgDetail.SelectedItem), true));
        }

        private void dgDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                btnOutput.IsEnabled = true;
                btnPreview.IsEnabled = true;
                btnPrint.IsEnabled = true;
            }
            else
            {
                btnOutput.IsEnabled = false;
                btnPreview.IsEnabled = false;
                btnPrint.IsEnabled = false;
            }
        }
    }
}
