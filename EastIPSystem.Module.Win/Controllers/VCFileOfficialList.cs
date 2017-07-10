using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.XtraBars.Docking2010.FreeLayoutEngine;
using EastIPSystem.Module.BusinessObjects;
using EastIPSystem.Module.Win.MarkCode;
using EastIPSystem.Module.Win.OfficialFileImport;
using Novacode;

namespace EastIPSystem.Module.Win.Controllers
{
    public partial class VCFileOfficialList : ViewController
    {
        public VCFileOfficialList()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        private void saOfficialFileImport_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            new XFrmOfficialFileImport(View.ObjectSpace).Show();
        }

        private void saGenerateOutFile_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View is DetailView)
            {
                var fileInOfficial = ((DetailView)View).CurrentObject as FileInOfficial;
                if (fileInOfficial == null) return;
                GenerateOutDoc(fileInOfficial);
            }
            else
            {
                var listFileInOfficial = (View as ListView)?.SelectedObjects.Cast<FileInOfficial>().ToList();
                if (listFileInOfficial?.Count > 0)
                    listFileInOfficial.ForEach(GenerateOutDoc);
            }
        }

        private void GenerateOutDoc(FileInOfficial fileInOfficial)
        {
            var fileTemplate = ObjectSpace.FindObject<FileOutTemplate>(CriteriaOperator.Parse("s_FileCode = ? And s_ClientNo = ?", fileInOfficial.s_FileCode, fileInOfficial.FilePatent?.Client?.Code));
            if (fileTemplate == null)
                fileTemplate = ObjectSpace.FindObject<FileOutTemplate>(CriteriaOperator.Parse("s_FileCode = ?", fileInOfficial.s_FileCode));
            if (fileTemplate == null || fileTemplate.TemplateData == null) return;
            using (var stream = new MemoryStream())
            {
                fileTemplate.TemplateData.SaveToStream(stream);
                var doc = DocX.Load(stream);
                stream.Close();

                ReplaceMark(fileInOfficial, doc);
                ReplaceMark(fileInOfficial, doc);//替换两遍，目的是替换标签内容中的标签

                using (var streamWrite = new MemoryStream())
                {
                    doc.SaveAs(streamWrite);
                    streamWrite.Position = 0;
                    if (fileInOfficial.OutFileData == null)
                        fileInOfficial.OutFileData = new FileData(fileInOfficial.Session);
                    var sFileName = fileTemplate.s_FileName;
                    foreach (Match match in Regex.Matches(fileTemplate.s_FileName, @"(?<=\[\[\[).*?(?=\]\]\])"))
                    {
                        if (!match.Success) continue;
                        var markCode = MarkCodeCollection.Instanse.FirstOrDefault(m => m.MarkName == match.Value);
                        if (markCode == null) continue;
                        sFileName = sFileName.Replace("[[[" + match.Value + "]]]", markCode.GetValue(fileInOfficial).ToString());
                    }
                    fileInOfficial.OutFileData.LoadFromStream(sFileName + ".docx", streamWrite);
                    streamWrite.Close();
                    fileInOfficial.Save();
                    fileInOfficial.Session.CommitTransaction();
                }
            }
        }

        private static void ReplaceMark(FileInOfficial fileInOfficial, DocX doc)
        {
            foreach (Match match in Regex.Matches(doc.Text, @"(?<=\[\[\[).*?(?=\]\]\])"))
            {
                if (!match.Success) continue;
                var sValue = string.Empty;
                var listParas = match.Value.Split('|').ToList();
                var markCode = MarkCodeCollection.Instanse.FirstOrDefault(m => m.MarkName == listParas[0]);
                if (markCode == null) continue;
                sValue = markCode.GetValue(fileInOfficial)?.ToString();
                if (markCode.DataType == DataType.DateTime)
                    sValue = Convert.ToDateTime(sValue).ToString("yyyy/M/d", DateTimeFormatInfo.InvariantInfo);

                if (listParas.Count >= 2 && !string.IsNullOrWhiteSpace(sValue))
                {
                    var dtValue = Convert.ToDateTime(sValue);
                    var sPara = listParas[1].ToUpper();
                    var nDaySeq = sPara.IndexOf("D", StringComparison.Ordinal);
                    var nMonthSeq = sPara.IndexOf("M", StringComparison.Ordinal);
                    var nCount1 =
                        Convert.ToInt32(Regex.Match(sPara, @"[-]?\d+").Success ? Regex.Match(sPara, @"[-]?\d+").Value : "0");
                    var nCount2 =
                        Convert.ToInt32(Regex.Match(sPara, @"[-]?\d+").NextMatch().Success
                            ? Regex.Match(sPara, @"[-]?\d+").NextMatch().Value
                            : "0");
                    if (nDaySeq > -1 && nMonthSeq > -1)
                    {
                        dtValue = nMonthSeq < nDaySeq
                            ? dtValue.AddMonths(nCount1).AddDays(nCount2)
                            : dtValue.AddDays(nCount1).AddMonths(nCount2);
                    }
                    else if (nDaySeq > -1 && nMonthSeq < 0)
                    {
                        dtValue = dtValue.AddDays(nCount1);
                    }
                    else if (nMonthSeq > -1 && nDaySeq < 0)
                    {
                        dtValue = dtValue.AddMonths(nCount1);
                    }
                    sValue = dtValue.ToString("yyyy/M/d", DateTimeFormatInfo.InvariantInfo);
                    if (listParas.Count == 3)
                    {
                        var sFormat = listParas[2].ToUpper();
                        if (sFormat == "CN")
                            sValue = dtValue.ToString("yyyy年M月d日", DateTimeFormatInfo.InvariantInfo);
                        if (sFormat == "EN")
                            sValue = dtValue.ToString("MMMM d, yyyy", DateTimeFormatInfo.InvariantInfo);
                    }
                }

                doc.ReplaceText("[[[" + match.Value + "]]]", sValue ?? string.Empty);
            }
        }
    }
}
