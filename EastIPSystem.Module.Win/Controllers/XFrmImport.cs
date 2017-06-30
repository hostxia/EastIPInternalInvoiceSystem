using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;

namespace EastIPSystem.Module.Win.Controllers
{
    public partial class XFrmImport : XtraForm
    {
        private DataTable _dtExcelData;

        private List<string> _listSheetsName;
        private readonly IObjectSpace _objectSpace;

        public enum FormType
        {
            Invoice,
            Case
        }

        public XFrmImport(IObjectSpace objectSpace, FormType formType)
        {
            InitializeComponent();
            if (formType == FormType.Invoice)
            {
                Text = "导入草单";
                xlueFormatType.Properties.DataSource = FormatterHelper.FormatterType.Where(f => "ABC".Contains(f.Key)).ToList();
            }
            else if (formType == FormType.Case)
            {
                Text = "导入案件";
                xlueFormatType.Properties.DataSource = FormatterHelper.FormatterType.Where(f => "DE".Contains(f.Key)).ToList();
            }
            _listSheetsName = new List<string>();
            //xlueFormatType.Properties.DataSource = FormatterHelper.FormatterType;
            xlueFormatType.ItemIndex = 0;
            _objectSpace = objectSpace;
        }

        private void xbeExcelFile_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowDefaultWaitForm();
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                xbeExcelFile.Text = openFileDialog.FileName;
                FormatterHelper.LoadExcel(xbeExcelFile.Text, 0, ref _listSheetsName, ref _dtExcelData);
                xlueSheet.Properties.DataSource = _listSheetsName;
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

        private void xlueSheet_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowDefaultWaitForm();
                if (xlueSheet.ItemIndex >= 0)
                    FormatterHelper.LoadExcel(openFileDialog.FileName, xlueSheet.ItemIndex, ref _listSheetsName,
                        ref _dtExcelData);
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
                if (_dtExcelData == null || xlueFormatType.EditValue == null) return;
                FormatData();
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

        private void xsbExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            xgvResult.ExportToXlsx(saveFileDialog.FileName);
        }

        private void FormatData()
        {
            switch (xlueFormatType.EditValue.ToString())
            {
                case "A":
                    xgcResult.DataSource = FormatterHelper.ImportData(_dtExcelData, _objectSpace);
                    break;
                case "B":
                    xgcResult.DataSource = FormatterHelper.ImportDataOld(_dtExcelData, _objectSpace);
                    break;
                case "C":
                    xgcResult.DataSource = FormatterHelper.ImportInvoiceNo(_dtExcelData, _objectSpace);
                    break;
                case "D":
                    xgcResult.DataSource = FormatterHelper.ImportReceiveCaseBase(_dtExcelData, _objectSpace);
                    break;
                case "E":
                    xgcResult.DataSource = FormatterHelper.ImportTransferCaseBase(_dtExcelData, _objectSpace);
                    break;
                default:
                    break;
            }
            xgvResult.BestFitColumns(true);
        }
    }
}