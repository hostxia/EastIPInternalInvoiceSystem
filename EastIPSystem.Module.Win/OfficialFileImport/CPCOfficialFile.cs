using System;
using System.Collections;
using System.Data;
using System.Linq;
using BEOfficialFileImport;

namespace EastIPSystem.Module.Win.OfficialFileImport
{
    public class CPCOfficialFile
    {
        public CPCOfficialFile(DataRow row)
        {
            FileCode = row["TONGZHISDM"].ToString().Trim();
            CPCSerial = row["NEIBUBH"].ToString().Trim();
            FileSerial = row["TONGZHISBH"].ToString().Trim();
            SendSerial = row["FAWENXLH"].ToString().Trim();
            CaseName = row["FAMINGMC"].ToString().Trim();
            FileName = row["TONGZHISMC"].ToString().Trim();
            AppNo = row["SHENQINGH"].ToString().Trim();
            AppDate = StringToDatetime(row["SHENQINGR"].ToString().Trim());
            PCTAppNo = row["GUOJISQH"].ToString().Trim();
            SendDate = StringToDatetime(row["FAWENRQ"].ToString().Trim());
            PubNO = row["GongBuH"].ToString().Trim();
            PubDate = StringToDatetime(row["GongBuR"].ToString().Trim());
            ProcNO = row["ShouQuanGGH"].ToString().Trim();
            ProcDate = StringToDatetime(row["ShouQuanGGR"].ToString().Trim());
            FilePath = row["CUNCHULJ"].ToString().Trim();
            DownloadDate = StringToDatetime(row["XIAZAIRQ"].ToString().Trim());
            CpcID = row["ID"].ToString().Trim();
            BizFileID = "0";
            Abstract = "";
            Officer = "";
            BizOfficialID = 0;
            BizOfficialName = "";
            CaseStatusID = 0;

            CPCOfficialFileConfig = CPCOfficialFileConfigCollection.Instance.FirstOrDefault(c => c.Code == FileCode);
        }

        public CPCOfficialFileConfig CPCOfficialFileConfig { get; set; }

        /// <summary>
        ///     彼速来文类型
        /// </summary>
        public string BizFileType { get; set; }

        /// <summary>
        ///     CPC中记录的文号（内部编号）
        /// </summary>
        public string CPCSerial { get; set; }

        /// <summary>
        ///     来文方式，取XML中的配置
        /// </summary>
        public string SendMethod { get; set; }

        /// <summary>
        ///     彼速来文机构ID
        /// </summary>
        public int BizOfficialID { get; set; }

        /// <summary>
        ///     彼速来文机构名称
        /// </summary>
        public string BizOfficialName { get; set; }

        /// <summary>
        ///     合成后的PDF文件路径
        /// </summary>
        public string BizFilePath { get; set; }

        /// <summary>
        ///     审查员
        /// </summary>
        public string Officer { get; set; }

        /// <summary>
        ///     摘要
        /// </summary>
        public string Abstract { get; set; }

        /// <summary>
        ///     保存后的来文ID
        /// </summary>
        public string BizFileID { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public string Note { get; set; }


        /// <summary>
        ///     来文对应的彼速文件名称
        /// </summary>
        public string BizFileName { get; set; }

        /// <summary>
        ///     案件对应的文件所属程序的ID
        /// </summary>
        public int CaseStatusID { get; set; }

        /// <summary>
        ///     下载日期(收文日期)
        /// </summary>
        public DateTime DownloadDate { get; set; }


        /// <summary>
        ///     来文所属程序
        /// </summary>
        public int BizFileStatusCode { get; set; }

        /// <summary>
        ///     来文彼速编码
        /// </summary>
        public int BizFileCode { get; set; }


        /// <summary>
        ///     CPC数据库流水号
        /// </summary>
        public string CpcID { get; set; }


        /// <summary>
        ///     CPC中记录的文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        ///     授权公告日
        /// </summary>
        public DateTime ProcDate { get; set; }

        /// <summary>
        ///     授权公告号
        /// </summary>
        public string ProcNO { get; set; }


        /// <summary>
        ///     公开日
        /// </summary>
        public DateTime PubDate { get; set; }

        /// <summary>
        ///     公开号
        /// </summary>
        public string PubNO { get; set; }

        /// <summary>
        ///     发送日期
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        ///     国际申请号
        /// </summary>
        public string PCTAppNo { get; set; }

        /// <summary>
        ///     申请日
        /// </summary>
        public DateTime AppDate { get; set; }

        /// <summary>
        ///     申请号
        /// </summary>
        public string AppNo { get; set; }

        /// <summary>
        ///     通知书名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        ///     案件名称
        /// </summary>
        public string CaseName { get; set; }

        /// <summary>
        ///     发文序号
        /// </summary>
        public string SendSerial { get; set; }

        /// <summary>
        ///     通知书编号
        /// </summary>
        public string FileSerial { get; set; }

        /// <summary>
        ///     通知书代码
        /// </summary>
        public string FileCode { get; set; }

        /// <summary>
        ///     我方文号
        /// </summary>
        public string CaseSerial { get; set; }

        /// <summary>
        ///     案件ID
        /// </summary>
        public int CaseID { get; set; }

        /// <summary>
        ///     由string获取日期
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        private DateTime StringToDatetime(string sDate)
        {
            var date = DateTime.MinValue;
            if (sDate == "")
                return date;
            date = DateTime.Parse(sDate);
            if (date.Year == 1970 || date.Year == 1900) //cpc中时间为空用1970-1-1标示，为了后面好判断，所有空值均用1900-1-1标示
                date = DateTime.MinValue;
            return date;
        }

        public string ClientNo { get; set; }

        public string ClientName { get; set; }

        public Hashtable Applicants { get; set; }

        public string WithDrew { get; set; }

        public DateTime? DivFilingDate { get; set; }
    }
}