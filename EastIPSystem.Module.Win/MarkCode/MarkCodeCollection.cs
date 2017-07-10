using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EastIPSystem.Module.BusinessObjects;
using EastIPSystem.Module.DBUtility;

namespace EastIPSystem.Module.Win.MarkCode
{
    public class MarkCodeCollection : List<MarkCode>
    {
        public static MarkCodeCollection Instanse => new MarkCodeCollection();

        public MarkCodeCollection()
        {
            InitMarkCodeCollceion();
        }

        private void InitMarkCodeCollceion()
        {
            Clear();
            Add(new MarkCodeOurNo());
            Add(new MarkCodeIssueDate());//TODO 需要反射动态读取
            Add(new MarkCodeFileName());
            Add(new MarkCodeFileCode());
            Add(new MarkCodeAppNo());
            Add(new MarkCodeAppDate());
            Add(new MarkCodeCaseName());
            Add(new MarkCodeCaseCNName());
            Add(new MarkCodeCaseApplicantCNName());
            Add(new MarkCodeCaseApplicantName());
            Add(new MarkCodePubNo());
            Add(new MarkCodePubDate());
            Add(new MarkCodeToday());
            Add(new MarkCodeClientNum());
            Add(new MarkCodeAppNum());
            Add(new MarkCodeFirstHKCancelY());
            Add(new MarkCodeFirstHKCancelN());
            Add(new MarkCodeModification());
            Add(new MarkCodePubVol());
            Add(new MarkCodePubVolNo());
            Add(new MarkCodePubInfo());
            Add(new MarkCodeOfficialAgent1());
        }
    }

    public class MarkCodeOurNo : MarkCode
    {
        public override string MarkName => "我方卷号";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return fileInOfficial?.FilePatent?.s_OurNo;
        }
    }

    public class MarkCodeIssueDate : MarkCode
    {
        public override string MarkName => "进入实审日";
        public override DataType DataType => DataType.DateTime;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DbHelperOra.GetSingle($"select SE_DATE from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
        }
    }

    public class MarkCodeFileName : MarkCode
    {
        public override string MarkName => "官文名称";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return fileInOfficial?.s_FileName;
        }
    }

    public class MarkCodeFileCode : MarkCode
    {
        public override string MarkName => "官文代码";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return fileInOfficial?.s_FileCode;
        }
    }

    public class MarkCodeAppNo : MarkCode
    {
        public override string MarkName => "申请号";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DbHelperOra.GetSingle($"select APPLICATION_NO from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
        }
    }

    public class MarkCodeAppDate : MarkCode
    {
        public override string MarkName => "申请日";
        public override DataType DataType => DataType.DateTime;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DbHelperOra.GetSingle($"select FILING_DATE from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
        }
    }

    public class MarkCodeCaseName : MarkCode
    {
        public override string MarkName => "专利名称外文";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DbHelperOra.GetSingle($"select TITLE from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
        }
    }

    public class MarkCodeCaseCNName : MarkCode
    {
        public override string MarkName => "专利名称中文";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DbHelperOra.GetSingle($"select TITLE_CHINESE from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
        }
    }

    public class MarkCodeCaseApplicantCNName : MarkCode
    {
        public override string MarkName => "申请人中文";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            var dr = DbHelperOra.Query($"select APPLICANT_CH1,APPLICANT_CH2,APPLICANT_CH3,APPLICANT_CH4,APPLICANT_CH5 from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'").Tables[0].Rows[0];
            var listStr = new List<string>();
            for (var i = 1; i <= 5; i++)
            {
                if (!string.IsNullOrWhiteSpace(dr[$"APPLICANT_CH{i}"]?.ToString()))
                    listStr.Add(dr[$"APPLICANT_CH{i}"]?.ToString());
            }
            return string.Join("; ", listStr);
        }
    }

    public class MarkCodeCaseApplicantName : MarkCode
    {
        public override string MarkName => "申请人外文";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            var dr = DbHelperOra.Query($"select APPLICANT1,APPLICANT2,APPLICANT3,APPLICANT4,APPLICANT5 from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'").Tables[0].Rows[0];
            var listStr = new List<string>();
            for (var i = 1; i <= 5; i++)
            {
                if (!string.IsNullOrWhiteSpace(dr[$"APPLICANT{i}"]?.ToString()))
                    listStr.Add(dr[$"APPLICANT{i}"]?.ToString());
            }
            return string.Join("; ", listStr);
        }
    }

    public class MarkCodePubNo : MarkCode
    {
        public override string MarkName => "公开号";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DbHelperOra.GetSingle($"select PUBLICATION_NO from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
        }
    }


    public class MarkCodePubDate : MarkCode
    {
        public override string MarkName => "公开日";
        public override DataType DataType => DataType.DateTime;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DbHelperOra.GetSingle($"select PUBLICATION from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
        }
    }

    public class MarkCodeToday : MarkCode
    {
        public override string MarkName => "当天";
        public override DataType DataType => DataType.DateTime;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DateTime.Now.Date;
        }
    }

    public class MarkCodeOfficialAgent1 : MarkCode
    {
        public override string MarkName => "官方第一代理人";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DbHelperOra.GetSingle($"select OAGENT1 from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
        }
    }

    public class MarkCodeClientNum : MarkCode
    {
        public override string MarkName => "对方卷号";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DbHelperOra.GetSingle($"select CLIENT_NUMBER from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
        }
    }

    public class MarkCodeAppNum : MarkCode
    {
        public override string MarkName => "申请人卷号";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            return DbHelperOra.GetSingle($"select APP_REF from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
        }
    }

    public class MarkCodeFirstHKCancelY : MarkCode
    {
        public override string MarkName => "放弃第一次香港登记Y";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            var objHKCancel = DbHelperOra.GetSingle($"select FIRST_HK_CANCELLED from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
            return objHKCancel?.ToString().ToUpper() == "Y" ? @"In addition, please be advised that if a Chinese patent application for invention is to be protected in Hong Kong, it must be registered as a standard patent application in Hong Kong via the following two-stage registration system: (1) within six months from the publication date of the Chinese patent application, a Request to Record in Hong Kong must be filed; and (2) within six months from the date of announcement of the granting of the Chinese patent right by SIPO, or of the publication in Hong Kong of the Request to Record, whichever is later, a Request for Registration in Hong Kong must be filed. No grace period will be allowed when the above-mentioned 6-months term is over.
If you wish to entrust us to obtain patent protection for this application in Hong Kong, please send your instructions at least 30 days before the deadline. If we do not receive your instructions, we will not record this application in Hong Kong. The estimated cost of filing a request to record this application in Hong Kong is about US$670, including both the official fee and our service fee.  The filing deadline is:
[[[公开日|M6|EN]]]
No grace period will be allowed when the said 6-month term is over.  No other documents but a written letter of instructions from you is required if you wish to entrust us to obtain patent protection for this application in Hong Kong.  We prefer to receive your instructions at least 20 days before said deadline if you decide to record this case in Hong Kong." : string.Empty;
        }
    }

    public class MarkCodeFirstHKCancelN : MarkCode
    {
        public override string MarkName => "放弃第一次香港登记N";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            var objHKCancel = DbHelperOra.GetSingle($"select FIRST_HK_CANCELLED from patentcase where ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
            return objHKCancel?.ToString().ToUpper() != "Y" ? @"According to your general instruction, we will file the request to record in Hong Kong as soon as possible, and before the filing deadline, which is [[[公开日|M6|EN]]]." : string.Empty;
        }
    }

    public class MarkCodeModification : MarkCode
    {
        public override string MarkName => "主动修改";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            var drs = DbHelperOra.Query($"select * from Generalalert where typeid = 'modification' and ourno = '{fileInOfficial?.FilePatent?.s_OurNo}'").Tables[0].Rows;

            return drs.Count > 0 ? @"Pursuant to your instructions, we will file a voluntary amendment for the above–referenced application as soon as possible. If further amendments are needed, should the applicant(s) decide to do so, please let us know at least 20 days before the due date." : @"Should the applicant(s) decide to do so, please let us know at least 20 days before the due date.";
        }
    }

    public class MarkCodePubVol : MarkCode
    {
        public override string MarkName => "公开卷号";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            var objInfo = DbHelperOra.GetSingle($"select info from caseotherinfo where infotype = 'pubinfo' and caseno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
            if (string.IsNullOrWhiteSpace(objInfo?.ToString()) || objInfo?.ToString().Split(';').Length < 3) return string.Empty;
            return objInfo?.ToString().Split(';')[0];
        }
    }

    public class MarkCodePubVolNo : MarkCode
    {
        public override string MarkName => "公开编号";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            var objInfo = DbHelperOra.GetSingle($"select info from caseotherinfo where infotype = 'pubinfo' and caseno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
            if (string.IsNullOrWhiteSpace(objInfo?.ToString()) || objInfo?.ToString().Split(';').Length < 3) return string.Empty;
            return objInfo?.ToString().Split(';')[1];
        }
    }

    public class MarkCodePubInfo : MarkCode
    {
        public override string MarkName => "公开信息";
        public override DataType DataType => DataType.String;
        public override object GetValue(FileInOfficial fileInOfficial)
        {
            var objInfo = DbHelperOra.GetSingle($"select info from caseotherinfo where infotype = 'pubinfo' and caseno = '{fileInOfficial?.FilePatent?.s_OurNo}'");
            if (string.IsNullOrWhiteSpace(objInfo?.ToString()) || objInfo?.ToString().Split(';').Length < 3) return string.Empty;
            var sInfo = objInfo?.ToString().Split(';')[2];
            if (sInfo == "1")
                return
                    "Since the published specification is identical with the specification as filed, we enclose herewith: (1) the notice and its English translation; and (2) one copy of the frontpage of the published application.  If you need the entire published application, please do not hesitate to contact us.";
            if (sInfo == "2")
                return
                    "We enclose herewith: (1) the notice and its English translation; (2) the entire published application; and (3) our debit note on this matter.";
            if (sInfo == "3")
                return
                    "We enclose herewith: (1) the notice and its English translation; (2) the entire published application. Our debit note on this matter will follow.";
            return string.Empty;
        }
    }
}
