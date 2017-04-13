using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;

namespace EastIPInternalInvoiceSystem.Module.Win.Controllers
{
    public partial class XFrmImport : XtraForm
    {
        private DataTable _dtExcelData;

        private List<string> _listSheetsName;
        private readonly IObjectSpace _objectSpace;

        public XFrmImport(IObjectSpace objectSpace)
        {
            InitializeComponent();
            _listSheetsName = new List<string>();
            xlueFormatType.Properties.DataSource = FormatterHelper.FormatterType;
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
                default:
                    break;
            }
            xgvResult.BestFitColumns(true);
        }
    }
}