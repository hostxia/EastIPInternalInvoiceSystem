using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using EastIPSystem.Module.BusinessObjects;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace EastIPSystem.Module.Win.Controllers
{
    public partial class VCPatentPaymentList : ViewController
    {
        public VCPatentPaymentList()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            saExportPaymentList.Execute += SaExportPaymentList_Execute;
        }

        private void SaExportPaymentList_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var listPayments = e.SelectedObjects.Cast<PatentPayment>().ToList();
            if (listPayments.Count == 0) return;
            if (listPayments.GroupBy(p => p.n_PayCaseType).Select(p => p.Key).Count() > 1) return;
            var savefileDialog = new SaveFileDialog();
            savefileDialog.FileName =
                $"{DateTime.Now:yyyyMMdd}-{listPayments[0].n_PayCaseType}-{listPayments[0].n_PaidBy}.xls";
            savefileDialog.Filter = "Excel文件|*.xls";
            if (savefileDialog.ShowDialog() != DialogResult.OK) return;
            File.Copy($@"{System.Windows.Forms.Application.StartupPath}\Template\{listPayments[0].n_PayCaseType}-{listPayments[0].n_PaidBy}.xls", savefileDialog.FileName, true);
            Application excel = null;
            Workbook workBook = null;
            if (!Directory.Exists(Path.GetDirectoryName(savefileDialog.FileName))) return;
            Cursor.Current = Cursors.WaitCursor;
            excel = new Application();
            excel.Visible = false;
            workBook = excel.Workbooks.Open(savefileDialog.FileName,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            var nType = listPayments[0].n_PayCaseType;
            var nPaidBy = listPayments[0].n_PaidBy;
            for (int i = 0; i < listPayments.Count; i++)
            {
                var payment = listPayments[i];
                if (nType == EnumsAll.PayCaseType.国内 && nPaidBy == EnumsAll.PaidBy.网上缴费)
                {
                    excel.Cells[i + 3, 2] = payment.s_AppNo.Replace(".", "");
                    excel.Cells[i + 3, 3] = payment.s_PayerName;
                    excel.Cells[i + 3, 4] = payment.s_FeeName;
                    excel.Cells[i + 3, 6] = payment.n_Amount;
                }
                else if (nType == EnumsAll.PayCaseType.国内 && nPaidBy == EnumsAll.PaidBy.现金缴费)
                {
                    excel.Cells[i + 3, 2] = payment.s_AppNo.Replace(".", "");
                    excel.Cells[i + 3, 3] = payment.s_PayerName;
                    excel.Cells[i + 3, 4] = payment.s_FeeName;
                    excel.Cells[i + 3, 5] = payment.n_Amount;
                }
                else if (nType == EnumsAll.PayCaseType.PCT国家 && nPaidBy == EnumsAll.PaidBy.网上缴费)
                {
                    excel.Cells[i + 3, 2] = payment.s_AppNo.Replace(".", "");
                    excel.Cells[i + 3, 3] = payment.n_PatentType == EnumsAll.PatentType.发明 ? "1!PCT发明" : "2!PCT实用新型";
                    excel.Cells[i + 3, 4] = payment.s_PayerName;
                    excel.Cells[i + 3, 5] = payment.s_FeeName;
                    excel.Cells[i + 3, 7] = payment.n_Amount;
                }
                else if (nType == EnumsAll.PayCaseType.PCT国家 && nPaidBy == EnumsAll.PaidBy.现金缴费)
                {
                    excel.Cells[i + 3, 2] = payment.s_AppNo.Replace(".", "");
                    excel.Cells[i + 3, 3] = payment.n_PatentType == EnumsAll.PatentType.发明 ? "发明" : "新型";
                    excel.Cells[i + 3, 4] = payment.s_PayerName;
                    excel.Cells[i + 3, 5] = payment.s_FeeName;
                    excel.Cells[i + 3, 6] = payment.n_Amount;
                }
                else if (nType == EnumsAll.PayCaseType.PCT国际 && nPaidBy == EnumsAll.PaidBy.网上缴费)
                {
                    excel.Cells[i + 3, 2] = payment.s_AppNo.Replace(".", "");
                    excel.Cells[i + 3, 4] = payment.s_PayerName;
                }
                else if (nType == EnumsAll.PayCaseType.PCT国际 && nPaidBy == EnumsAll.PaidBy.现金缴费)
                {
                    excel.Cells[i + 3, 2] = payment.s_AppNo.Replace(".", "");
                    excel.Cells[i + 3, 3] = payment.s_PayerName;
                    excel.Cells[i + 3, 4] = payment.s_FeeName;
                    excel.Cells[i + 3, 6] = payment.n_Amount;
                }
            }

            workBook.SaveAs(savefileDialog.FileName,
                           Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                           XlSaveAsAccessMode.xlNoChange,
                           Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            workBook.Close();
            excel.Quit();
            Cursor.Current = Cursors.Default;
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
