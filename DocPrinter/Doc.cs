using DocPrinter.Item;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Resources;
using Word = Microsoft.Office.Interop.Word;

namespace DocPrinter
{
    public class Doc
    {
        private static Word.Application currentWordApp = null;
        private static string ROOT_PATH = AppDomain.CurrentDomain.BaseDirectory;
        private static string TEMP_PATH = ROOT_PATH + "temp\\";
        private static string OUTPUT_PATH = ROOT_PATH;
        private static string TEMPLATE_PATH = @"pack://application:,,,/Template/";
        private static Object MISSING = System.Reflection.Missing.Value;
        private static string currentBookmarkName = String.Empty;

        public enum Type { DriverApply=0, TestResult=1, HealthStatus=2 };

        public static Word.Document InflateDoc(Object item)
        {
            CheckWinWordProcess();
            try
            {
                if (item is DriverApplyItem)
                {
                    return InflateDriverApply((DriverApplyItem)item);
                }
                else if(item is HealthStatusItem)
                {
                    return InflateHealthStatus((HealthStatusItem)item);
                }
                else if(item is TestResultItem)
                {
                    return InflateTestResult((TestResultItem)item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }

        private static Word.Document InflateDriverApply(DriverApplyItem item)
        {
            Word.Document doc = GetEditableDoc(Type.DriverApply);

            foreach(Word.Bookmark bm in doc.Bookmarks)
            {
                bm.Select();
                currentBookmarkName = bm.Name;

                if (BmComp(DriverApplyItem.Columns.Name))
                {
                    InsertText(item.Name);
                }
                else if (BmComp(DriverApplyItem.Columns.Sex))
                {
                    InsertText(item.Sex);
                }
                else if (BmComp(DriverApplyItem.Columns.Brith))
                {
                    InsertText(item.Brith);
                }
                else if (BmComp(DriverApplyItem.Columns.IdName1))
                {
                    InsertText(item.IdName1);
                }
                else if (BmComp(DriverApplyItem.Columns.IdCode1))
                {
                    InsertText(item.IdCode1);
                }
                else if (BmComp(DriverApplyItem.Columns.IdName2))
                {
                    InsertText(item.IdName2);
                }
                else if (BmComp(DriverApplyItem.Columns.IdCode2))
                {
                    InsertText(item.IdCode2);
                }
                else if (BmComp(DriverApplyItem.Columns.Mobile))
                {
                    InsertText(item.Mobile);
                }
                else if (BmComp(DriverApplyItem.Columns.Phone))
                {
                    InsertText(item.Phone);
                }
                else if (BmComp(DriverApplyItem.Columns.Address))
                {
                    InsertText(item.Address);
                }
                else if (BmComp(DriverApplyItem.Columns.EMail))
                {
                    InsertText(item.EMail);
                }
                else if (BmComp(DriverApplyItem.Columns.ZipCode))
                {
                    InsertText(item.ZipCode);
                }
                else if (BmComp(DriverApplyItem.Columns.Nationality))
                {
                    InsertText(item.Nationality);
                }
                else if (BmComp(DriverApplyItem.Columns.FileCode))
                {
                    //InsertText(item.FileCode);
                }
            }
            return doc;
        }
        private static Word.Document InflateHealthStatus(HealthStatusItem item)
        {
            Word.Document doc = GetEditableDoc(Type.HealthStatus);

            foreach (Word.Bookmark bm in doc.Bookmarks)
            {
                bm.Select();
                currentBookmarkName = bm.Name;

                if (BmComp(HealthStatusItem.Columns.Name))
                {
                    InsertText(item.Name);
                }
                else if (BmComp(HealthStatusItem.Columns.Sex))
                {
                    InsertText(item.Sex);
                }
                else if (BmComp(HealthStatusItem.Columns.Brith))
                {
                    InsertText(item.Brith);
                }
                else if (BmComp(HealthStatusItem.Columns.IdName1))
                {
                    InsertText(item.IdName1);
                }
                else if (BmComp(HealthStatusItem.Columns.Mobile))
                {
                    InsertText(item.Mobile);
                }
                else if (BmComp(HealthStatusItem.Columns.Address))
                {
                    InsertText(item.Address);
                }
                else if (BmComp(HealthStatusItem.Columns.Nationality))
                {
                    InsertText(item.Nationality);
                }
                else if (BmComp(HealthStatusItem.Columns.FileCode))
                {
                    InsertText(item.FileCode);
                }
                else if (BmComp(HealthStatusItem.Columns.VehicleType))
                {
                    InsertText(item.VehicleType);
                }
            }
            return doc;
        }
        private static Word.Document InflateTestResult(TestResultItem item)
        {
            Word.Document doc = GetEditableDoc(Type.TestResult);

            foreach (Word.Bookmark bm in doc.Bookmarks)
            {
                bm.Select();
                currentBookmarkName = bm.Name;

                if (BmComp(TestResultItem.Columns.Name))
                {
                    InsertText(item.Name);
                }
                else if (BmComp(TestResultItem.Columns.Sex))
                {
                    InsertText(item.Sex);
                }
                else if (BmComp(TestResultItem.Columns.IdName1))
                {
                    InsertText(item.IdName1);
                }
                else if (BmComp(TestResultItem.Columns.IdCode1))
                {
                    InsertText(item.IdCode1);
                }
                else if (BmComp(TestResultItem.Columns.VehicleType))
                {
                    InsertText(item.VehicleType);
                }
                else if (BmComp(TestResultItem.Columns.OriVehicleType))
                {
                    InsertText(item.OriVehicleType);
                }
                else if (BmComp(TestResultItem.Columns.School))
                {
                    InsertText(item.School);
                }
            }
            return doc;
        }

        private static Word.Document GetEditableDoc(Type type)
        {
            try
            {
                string tempDoc = TEMP_PATH + "tempt";

                string filename = String.Empty;
                switch (type)
                {
                    case Type.DriverApply:
                        filename = "DriverApply.doc";
                        break;
                    case Type.TestResult:
                        filename = "TestResult.doc";
                        break;
                    case Type.HealthStatus:
                        filename = "HealthStatus.doc";
                        break;
                }
                string oriDoc = TEMPLATE_PATH + filename;

                StreamResourceInfo docInfo = System.Windows.Application.GetResourceStream(new Uri(oriDoc));

                if (!Directory.Exists(TEMP_PATH))
                {
                    DirectoryInfo dic = Directory.CreateDirectory(TEMP_PATH);
                    dic.Attributes |= FileAttributes.Hidden;
                }
                if (File.Exists(tempDoc))
                    File.Delete(tempDoc);
                using (FileStream fs = File.Create(tempDoc))
                {
                    docInfo.Stream.CopyTo(fs);
                }
                object tempDocObj = tempDoc;

                return currentWordApp.Documents.Open(ref tempDocObj, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return null;
        }

        public static string SaveDocAsXPS(Word.Document doc, bool close)
        {
            CheckWinWordProcess();
            object filepath = TEMP_PATH + "temp.xps";
            object format = Word.WdSaveFormat.wdFormatXPS;
            doc.SaveAs(ref filepath, ref format, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING);
            if (close)
                CloseDoc(doc);
            return (string)filepath;
        }
        public static string SaveDocAsDoc(Word.Document doc,string filename, bool close)
        {
            CheckWinWordProcess();
            object filepath = OUTPUT_PATH + filename+".doc";
            object format = Word.WdSaveFormat.wdFormatDocument;
            doc.SaveAs(ref filepath, ref format, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING, ref MISSING);
            if (close)
                CloseDoc(doc);
            return (string)filepath;
        }

        
        private static void CloseDoc(Word.Document doc)
        {
            if (doc != null)
            {
                object saveChanges = Word.WdSaveOptions.wdSaveChanges;
                object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
                object routeDocument = false;
                doc.Close(ref saveChanges, ref originalFormat, ref routeDocument);
            }
            //DirectoryInfo dir = new DirectoryInfo(TEMP_PATH);
            //foreach (FileInfo file in dir.GetFiles())
            //    file.Delete();
            //dir.Delete(true);
        }
        public static void StartWord()
        {
            KillWinWordProcess();
            if (currentWordApp == null)
            {
                currentWordApp = new Word.ApplicationClass();
                currentWordApp.Visible = false;
                currentWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            }
        }
        public static void CloseWord()
        {
            if (currentWordApp != null)
            {
                object saveChanges = Word.WdSaveOptions.wdSaveChanges;
                object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
                object routeDocument = false;
                currentWordApp.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
                currentWordApp = null;
            }
            KillWinWordProcess();
        }

        public static void CheckWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            if (processes.Length == 0)
            {
                currentWordApp = null;
                StartWord();
                Console.WriteLine("NO WINWORD");
            }
            else
            {
                Console.WriteLine("WINWORD");
            }
        }
        private static void KillWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
        }

        private static void InsertText(string str)
        {
            currentWordApp.Selection.TypeText(str);
        }
        private static bool BmComp(string str)
        {
            return currentBookmarkName.Equals(SplitString(str));
        }
        private static string SplitString(string str)
        {
            return str.Split('|')[0];
        }
    }
}
