using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Win.Controllers
{
    public partial class XFrmImportFile : XtraForm
    {
        public static List<KeyValuePair<string, string>> ImportType => new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("A", "1. 导入草单电子件"),
            new KeyValuePair<string, string>("B", "2. 导入第三方账单电子件")
        };

        private Hashtable _htFiles;

        private readonly IObjectSpace _objectSpace;

        public XFrmImportFile(IObjectSpace objectSpace)
        {
            InitializeComponent();
            _objectSpace = objectSpace;
            xlueImportType.Properties.DataSource = ImportType;
        }

        private void xbeExcelFile_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                SplashScreenManager.ShowDefaultWaitForm();
                xbeFilePath.Text = folderBrowserDialog.SelectedPath;
                _htFiles = new Hashtable();
                Directory.GetFiles(xbeFilePath.Text, "*.*", SearchOption.TopDirectoryOnly).ToList().ForEach(p => _htFiles.Add(p, string.Empty));
                xgcResult.DataSource = _htFiles;
                xgvResult.RefreshData();
                xgvResult.BestFitColumns(true);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message + "\r\n" + exception.StackTrace);
            }
            finally
            {
                SplashScreenManager.CloseDefaultWaitForm();
            }
        }
        private void xsbOk_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowDefaultWaitForm();
                if (_htFiles == null || xlueImportType.EditValue == null) return;
                foreach (string sFilePath in _htFiles.Keys.Cast<string>().ToList())
                {
                    try
                    {
                        if (!File.Exists(sFilePath))
                        {
                            _htFiles[sFilePath] = "导入失败，文件不存在。";
                            continue;
                        }
                        var sCondition = xlueImportType.EditValue.ToString() == "A"
                            ? $"InternalNo = '{Path.GetFileNameWithoutExtension(sFilePath)}'"
                            : $"FirmNo = '{Path.GetFileNameWithoutExtension(sFilePath)}'";
                        var internalInvoice = _objectSpace.FindObject<InternalInvoice>(CriteriaOperator.Parse(sCondition));
                        if (internalInvoice == null)
                        {
                            _htFiles[sFilePath] = "导入失败，未找到对应的草单。";
                            continue;
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(internalInvoice.InvoiceNo))
                            {
                                _htFiles[sFilePath] = "导入失败，该草单禁止修改。";
                                continue;
                            }
                            var fileData = new FileData(internalInvoice.Session);
                            using (var stream = new FileStream(sFilePath, FileMode.Open))
                            {
                                fileData.LoadFromStream(Path.GetFileName(sFilePath), stream);
                                stream.Close();
                            }
                            if (xlueImportType.EditValue.ToString() == "A")
                            {

                                var bIsUpdate = internalInvoice.InvoiceFile != null;
                                internalInvoice.InvoiceFile?.Delete();
                                internalInvoice.InvoiceFile = fileData;
                                internalInvoice.Save();
                                _objectSpace.CommitChanges();
                                _htFiles[sFilePath] = bIsUpdate ? "导入成功，更新电子件。" : "导入成功，上传电子件。";

                            }
                            else
                            {
                                var bIsUpdate = internalInvoice.FInvoiceFile != null;
                                internalInvoice.FInvoiceFile?.Delete();
                                internalInvoice.FInvoiceFile = fileData;
                                internalInvoice.Save();
                                _objectSpace.CommitChanges();
                                _htFiles[sFilePath] = bIsUpdate ? "导入成功，更新电子件。" : "导入成功，上传电子件。";
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        _htFiles[sFilePath] = "导入失败。" + exception;
                    }

                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message + "\r\n" + exception.StackTrace);
            }
            finally
            {
                xgcResult.DataSource = null;
                xgcResult.DataSource = _htFiles;
                xgvResult.BestFitColumns(true);
                SplashScreenManager.CloseDefaultWaitForm();
            }
        }

        private void xsbExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            xgvResult.ExportToXlsx(saveFileDialog.FileName);
        }
    }
}